using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using PSC2013.ES.Library.DiseaseData;
using PSC2013.ES.Library.IO.OutputTargets;
using PSC2013.ES.Library.Simulation;
using PSC2013.ES.Library.Snapshot;
using System.IO;
using System.Threading;
using PSC2013.ES.Library.Simulation.Components;
using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library.AreaData;
using PSC2013.ES.Library.IO.Readers;

namespace PSC2013.ES.Library
{
    public sealed class EpidemicSimulator : OutputTargetWriter
    {
#if DEBUG
        private readonly Stopwatch _watch = new Stopwatch();
#endif
        #region ### Private ###
        // Constants
        private const string ERROR_MESSAGE_STARTING_SIMULATION = "Could not start Simulation. ";
        private const string ERROR_MESSAGE_STOPPING_SIMULATION = "Could not stop Simulation. ";
        private const string ERROR_MESSAGE_SIMULATION_RUNNING = "A Simulation is already running!";
        private const string ERROR_MESSAGE_NO_SIMULATION_RUNNING = "No Simulation running!";

        private const int SIMULATION_DEFAULT_START = 0;
        private const int SIMULATION_DEFAULT_LIMIT = 0;

        private const int DEFAULT_SIMULATION_INTERVALL = 1;
        private const int DEFAULT_SNAPSHOT_INTERVALL = 24;

        // Simulation & Data
        private Task _simulation;
        private readonly SimulationData _simData;

        // Simulation Settings
        private int _simulationIntervall = DEFAULT_SIMULATION_INTERVALL;
        private int _snapshotIntervall = DEFAULT_SNAPSHOT_INTERVALL;
        private int _ticksPerSnapshot;

        // Managers
        private readonly SnapshotManager _snapshotMgr;

        // ISimulationComponents
        private SimulationComponent _infectionComponent;
        private readonly ISet<SimulationComponent> _before, _after;

        // Misc.
        private volatile bool _simulationFinished;
        private volatile bool _simulationLock;
        private long _simulationRound = SIMULATION_DEFAULT_START;
        private long _simulationLimit = SIMULATION_DEFAULT_LIMIT;

        #endregion

        #region ### Public ###
        // Properties
        public bool CanStartSimulation 
        {
            get 
            { 
                return !_simulationLock && 
                _infectionComponent != null &&
                _snapshotIntervall % _simulationIntervall == 0 &&
                _simData.IsValid; 
            }
        }
        public bool IsSimulating { get { return _simulationLock; } }

        public long SimulationDuration { get { return _simulationLimit; } }
        public int SimulationIntervall { get { return _simulationIntervall; } }
        public int SnapshotIntervall { get { return _snapshotIntervall; } }

        // Events
        public event EventHandler<SimulationEventArgs> SimulationStarted;
        public event EventHandler<SimulationEventArgs> SimulationEnded;
        public event EventHandler<SimulationEventArgs> TickFinished;
        public event EventHandler<EventArgs> ProcessFinished;
        public event EventHandler<EventArgs> SnapshotWritten;
        //TODO: |f| do we also want StageFinished ?
        #endregion

        private EpidemicSimulator(Disease disease, DateTime startTime) : base("ES")
        {
            _simData = new SimulationData(startTime) { DiseaseToSimulate = disease };

            _snapshotMgr = new SnapshotManager();                           // Needs to be initialized before using
            _snapshotMgr.WriterQueueEmpty += OnWriterQueueEmpty;
            _snapshotMgr.SnapshotWritten += SnapshotWritten;

            _before = new HashSet<SimulationComponent>();
            _after = new HashSet<SimulationComponent>();
        }

        /// <summary>
        /// Creates a new EpidemicSimulator with the given ISimulationComponents
        /// </summary>
        /// <param name="disease">The Disease to simulate</param>
        /// <param name="dataFilePath">The file's path containing populational data to simulate on</param>
        /// <param name="outputTarget">The initial OutputTarget. Can be null.</param>
        /// <param name="startTime">The starttime for movements.</param>
        /// <param name="components">The initial ISimulationComponents to add to the EpidemicSimulator</param>
        /// <returns>The created instance of EpidemicSimulator</returns>
        public static EpidemicSimulator Create(Disease disease, string dataFilePath, IOutputTarget outputTarget, DateTime startTime, params SimulationComponent[] components)
        {
            return Create(disease, dataFilePath, outputTarget, null, null, startTime, components);
        }

        /// <summary>
        /// Creates a new EpidemicSimulator with the given ISimulationComponents
        /// </summary>
        /// <param name="disease">The Disease to simulate</param>
        /// <param name="dataFilePath">The file's path containing populational data to simulate on</param>
        /// <param name="outputTarget">The initial OutputTarget. Can be null.</param>
        /// <param name="readerIterationPassed">The action for the ReadFileIterationPassed-event. Can be null.</param>
        /// <param name="generatorDepartmentCalculated">The action fo the GeneratorDepartmentCalculated-event. Can be null.</param>
        /// <param name="startTime">The starttime for movements.</param>
        /// <param name="components">The initial ISimulationComponents to add to the EpidemicSimulator</param>
        /// <returns>The created instance of EpidemicSimulator</returns>
        public static EpidemicSimulator Create(Disease disease, string dataFilePath,
            IOutputTarget outputTarget, 
            Action<object, ContinuationEventArgs> readerIterationPassed, 
            Action<object, GeneratorEventArgs> generatorDepartmentCalculated,
            DateTime startTime,
            params SimulationComponent[] components)
        {
            var sim = new EpidemicSimulator(disease, startTime);

            if (readerIterationPassed != null)
                sim._simData.ReadFileIterationPassed += readerIterationPassed.Invoke;
            if (generatorDepartmentCalculated != null)
                sim._simData.DepartmentCalculated += generatorDepartmentCalculated.Invoke;

            if (outputTarget != null)
                sim.AddOutputTarget(outputTarget);

            foreach (SimulationComponent component in components)
            {
                sim.AddSimulationComponent(component);
            }

            sim.LoadSimulationBaseFromFile(dataFilePath);

            return sim;
        }

        /// <summary>
        /// Loads a .dep containing population information into the EpidemicSimulator's SimulationData
        /// </summary>
        /// <param name="dataFilePath">Path of the .deb file to read</param>
        private void LoadSimulationBaseFromFile(string dataFilePath)
        {
            _simData.InitializeFromFile(dataFilePath);
        }

        /// <summary>
        /// Adds a new ISimulationComponent to the EpidemicSimulator. If the given ISimulationComponent is an Infection Simulator,
        /// the previous one will be overriden
        /// </summary>
        /// <param name="component"></param>
        public void AddSimulationComponent(SimulationComponent component)
        {
            if (_simulationLock)
                throw new SimulationException("Could not add a new ISimulationComponent. " + ERROR_MESSAGE_SIMULATION_RUNNING);

            ESimulationStage stages = component.SimulationStages;
            if ((stages & ESimulationStage.InfectedCalculation) == ESimulationStage.InfectedCalculation)
            {
                if ((stages & ESimulationStage.BeforeInfectedCalculation) == ESimulationStage.BeforeInfectedCalculation ||
                    (stages & ESimulationStage.AfterInfectedCalculation) == ESimulationStage.AfterInfectedCalculation)
                    throw new ArgumentException(
                        "The given ISimulationComponent cannot get executed in the Infection stage and before/after!",
                        "component");

                _infectionComponent = component;
                return;
            }
            if ((stages & ESimulationStage.BeforeInfectedCalculation) == ESimulationStage.BeforeInfectedCalculation)
                    _before.Add(component);
            
            if ((stages & ESimulationStage.AfterInfectedCalculation) == ESimulationStage.AfterInfectedCalculation)
                    _after.Add(component);
        }

        public void RemoveSimulationComponent(SimulationComponent component)
        {
            var stages = component.SimulationStages;
            if((stages & ESimulationStage.InfectedCalculation) == ESimulationStage.InfectedCalculation)
                throw new SimulationException("Cannot remove Infection Simulation component! \n " +
                                              "If you want to set a new one, use AddSimulationComponent to overwrite the previous one!");

            if ((stages & ESimulationStage.BeforeInfectedCalculation) == ESimulationStage.BeforeInfectedCalculation &&
                _before.Contains(component))
                _before.Remove(component);

            if ((stages & ESimulationStage.AfterInfectedCalculation) == ESimulationStage.AfterInfectedCalculation &&
                _after.Contains(component))
                _after.Remove(component);
        }

        /// <summary>
        /// Adds a new IOutputTarget to the Epidemic Simulator. Allowing it to write messages to
        /// this Output during simulation
        /// </summary>
        /// <param name="target"></param>
        public void AddOutputTarget(IOutputTarget target)
        {
            if (_simulationLock)
                throw new SimulationException("Could not add a new IOutputTarget. " + ERROR_MESSAGE_SIMULATION_RUNNING);

            OutputTargetManager.GetInstance().RegisterTarget(target);
        }

        /// <summary>
        /// Sets a new intervall determining how many hours shall be calculated each tick.
        /// Default is 1 (hour / tick).
        /// </summary>
        /// <param name="intervall">The new intervall to use. Must be greater than 0</param>
        public void SetSimulationIntervall(int intervall)
        {
            if (_simulationLock)
                throw new SimulationException("Could not set a new SimulationIntervall. " + ERROR_MESSAGE_SIMULATION_RUNNING);

            if (intervall < 1)
                throw new ArgumentOutOfRangeException("intervall", "The given intervall must be greater than 1.");

            _simulationIntervall = intervall;

            UpdateComponentsIntervalls();
        }

        private void UpdateComponentsIntervalls()
        {
            foreach (var component in _before)
                component.SetSimulationIntervall(_simulationIntervall);

            _infectionComponent.SetSimulationIntervall(_simulationIntervall);

            foreach (var component in _after)
                component.SetSimulationIntervall(_simulationIntervall);
        }

        /// <summary>
        /// Set a new intervall determining how often a Simulation Snapshot is taken (in hours).
        /// Default is 24 (one each day assuming 1-hour-ticks).
        /// </summary>
        /// <param name="intervall">The new intervall to use. Must be a full multiple of SimulationIntervall.</param>
        public void SetSnapshotIntervall(int intervall)
        {
            if (_simulationLock)
                throw new SimulationException("Could not set a new SimulationIntervall. " + ERROR_MESSAGE_SIMULATION_RUNNING);

            if (intervall < 1)
                throw new ArgumentOutOfRangeException("intervall", "The given intervall must be greater than 1.");

            _snapshotIntervall = intervall;
        }

        /// <summary>
        /// Starts a Simulation with the previously set ISimulationComponents. EpidemicSimulator needs to 
        /// have an ISimulationComponent set for the Infection calculation.
        /// </summary>
        /// <param name="saveFilePath">The directory to save the snapshots in</param>
        public void StartSimulation(string saveDirectory, InfectionInitState initialState)
        {
            StartSimulation(saveDirectory, initialState, SIMULATION_DEFAULT_LIMIT);
        }

        /// <summary>
        /// Starts a Simulation with the previously set ISimulationComponents. EpidemicSimulator needs to 
        /// have an ISimulationComponent set for the Infection calculation.
        /// </summary>
        /// <param name="saveFilePath">The directory to save the snapshots in</param>
        /// <param name="limit">The limit of simulation rounds to perform</param>
        public void StartSimulation(string saveFilePath, InfectionInitState initialState, long limit)
        {
            if (!CanStartSimulation)
                throw new SimulationException(ERROR_MESSAGE_STARTING_SIMULATION + 
                    "Not all mandatory settings are set up correctly. Check Intervalls!");

            if (saveFilePath == null || File.Exists(saveFilePath))
                throw new ArgumentException(ERROR_MESSAGE_STARTING_SIMULATION + "The given file is invalid!", "saveFilePath");

            if (limit < 0)
                throw new ArgumentException(ERROR_MESSAGE_STARTING_SIMULATION + "Simulationround limit must be greater than 0!", "limit");

            _simulationLimit = limit;
            _ticksPerSnapshot = _snapshotIntervall / _simulationIntervall;
            InitializeInfection(initialState);

            OnSimulationStarted(new SimulationEventArgs() { SimulationRunning = true });
            _simulationLock = true;
            _snapshotMgr.Initialize(
                saveFilePath, _simData.DiseaseToSimulate, 
                _simData.ImageWidth, _simData.ImageHeight, 
                SimulationIntervall, SnapshotIntervall, SimulationDuration);

            // Actual Simulation is performed in another Thread to enable stopping
            _simulation = Task.Run(() => PerformSimulation()).ContinueWith(_ => PerformSimulationStop());
        }

        private void InitializeInfection(InfectionInitState initialState)
        {
            if (initialState.Equals(InfectionInitState.Empty))
                return;

            //TODO: |f| does not handle weird diseases atm
            short infectionTimer = (short)_simData.DiseaseToSimulate.IncubationPeriod;
            short spreadingTimer = (short)_simData.DiseaseToSimulate.IdleTime;

            var toInfect = initialState.DesiredInfection.DeepCopy<int, int>();

            WriteMessage("Infecting " + toInfect.Values.Sum() + " people!");
            for (int i = 0; i < _simData.Humans.Length; ++i)
            {
                int cellIndex = _simData.Humans[i].CurrentCell;
                if (toInfect.ContainsKey(cellIndex))
                {
                    _simData.Humans[i].Infect(infectionTimer, spreadingTimer);
                   toInfect[cellIndex]--;
                    _simData.Cells[cellIndex].Infecting++;

                    if (toInfect[cellIndex] == 0)
                        toInfect.Remove(cellIndex);
                }
            }
            WriteMessage("Finished infecting!");
            WriteMessage("Could not infect " + toInfect.Values.Sum() + " people!");
        }

        /// <summary>
        /// Stops the current Simulation.
        /// </summary>
        public void StopSimulation()
        {
            if (!_simulationLock)
                throw new SimulationException(ERROR_MESSAGE_STOPPING_SIMULATION + ERROR_MESSAGE_NO_SIMULATION_RUNNING);

            _simulationLock = false;

            PerformSimulationStop(); // TODO | dj | is this good? It does not tell whether everything went fine or not...
        }

        private void PerformSimulation()
        {
            while (_simulationLock)
            {
#if DEBUG
                _watch.Reset();
                _watch.Start();
#endif
                foreach (SimulationComponent comp in _before)
                {
                    comp.PerformSimulationStage(_simData);
                }

                // Main simulation step
                _infectionComponent.PerformSimulationStage(_simData);

                foreach (SimulationComponent comp in _after)
                {
                    comp.PerformSimulationStage(_simData);
                }

                _simData.DoTick(_simulationIntervall);

                long round = Interlocked.Increment(ref _simulationRound);
                if (round % _ticksPerSnapshot == 0)
                    _snapshotMgr.TakeSnapshot(_simData, round);
                _simulationLock = round != _simulationLimit;
#if DEBUG
                _watch.Stop();
                WriteMessage("Tick took " + _watch.ElapsedMilliseconds + "ms!");
#endif
                OnTickFinished(new SimulationEventArgs() { SimulationRunning = true, SimulationRound = round });
            }
        }

        private void PerformSimulationStop()
        {
            long rounds = Interlocked.Read(ref _simulationRound);
            OnSimulationEnded(new SimulationEventArgs() { SimulationRunning = false,  SimulationRound = rounds });
        }
        
        private void OnSimulationStarted(SimulationEventArgs e)
        {
            WriteMessage("Simulation started!");

            SimulationStarted.Raise(this, e);
        }
        private void OnSimulationEnded(SimulationEventArgs e)
        {
            WriteMessage("Simulation ended!");

            SimulationEnded.Raise(this, e);
            _simulationFinished = true;
        }
        private void OnWriterQueueEmpty(object sender, EventArgs e)
        {
            if (_simulationFinished)
                OnProcessFinished();
        }
        private void OnTickFinished(SimulationEventArgs e)
        {
            WriteMessage("Finished Tick #" + _simulationRound + "!");

            TickFinished.Raise(this, e);
        }
        private void OnProcessFinished()
        {
            WriteMessage("Process is entirely finished now.");

            ProcessFinished.Raise(this, null);
        }
    }

    public struct InfectionInitState : IEquatable<InfectionInitState>
    {
        /// <summary>
        /// Describes the desired initial infection values.
        /// Key: flattened cell index to infect people in
        /// Value: amount of people to get infected in that cell
        /// </summary>
        public Dictionary<int, int> DesiredInfection { get; set; }

        /// <summary>
        /// Provides a constant value representing an empty InfectionInitState
        /// </summary>
        public static InfectionInitState Empty = new InfectionInitState() { DesiredInfection = null };

        public bool Equals(InfectionInitState other)
        {
            if (other.DesiredInfection == null)
                return DesiredInfection == null;

            foreach (var pair in DesiredInfection)
            {
                if (!other.DesiredInfection.ContainsKey(pair.Key))
                    return false;
                if (other.DesiredInfection[pair.Key] != pair.Value)
                    return false;
            }
            foreach (var pair in other.DesiredInfection)
            {
                if (!DesiredInfection.ContainsKey(pair.Key))
                    return false;
                if (DesiredInfection[pair.Key] != pair.Value)
                    return false;
            }

            return true;
        }
    }
}