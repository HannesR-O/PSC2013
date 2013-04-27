using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PSC2013.ES.Library.Diseases;
using PSC2013.ES.Library.Simulation;
using PSC2013.ES.Library.Snapshot;
using System.IO;
using System.Threading;
using PSC2013.ES.Library.Simulation.Components;

namespace PSC2013.ES.Library
{
    public class EpidemicSimulator
    {
        // Constants
        private const string ERROR_STARTING_SIMULATION = "Could not start Simulation. ";
        private const string ERROR_STOPPING_SIMULATION = "Could not stop Simulation. ";
        private const string ERROR_MESSAGE_SIMULATION_RUNNING = "A Simulation is already running!";
        private const string ERROR_MESSAGE_NO_SIMULATION_RUNNING = "No Simulation running!";

        private const int SIMULATION_DEFAULT_START = 0x1;
        private const int SIMULATION_DEFAULT_LIMIT = 0x0;

        // Data
        private SimulationData _simData;
        private Task _simulation;

        // Managers
        private SnapshotManager _snapshotMgr;

        // ISimulationComponents
        private ISimulationComponent _infectionSimulator;
        private List<ISimulationComponent> _before, _after;

        // Misc
        private volatile bool _simulationLock = false;
        private long _simulationRound = SIMULATION_DEFAULT_START;
        private long _simulationLimit = SIMULATION_DEFAULT_LIMIT;

        // Properties
        public bool CanStartSimulation 
        {
            get { return !_simulationLock && _infectionSimulator != null && _simData.IsValid; }
        }
        public bool IsSimulationg { get { return _simulationLock; } }

        // Events
        public event EventHandler<SimulationEventArgs> SimulationStarted;
        public event EventHandler<SimulationEventArgs> SimulationEnded;
        public event EventHandler<SimulationEventArgs> TickFinished;
        //TODO: |f| do we also want StageFinished ?

        private EpidemicSimulator(Disease disease)
        {
            _simData = new SimulationData {CurrentDisease = disease};

            _snapshotMgr = new SnapshotManager();       // Needs to be initialized before using

            _before = new List<ISimulationComponent>();
            _after = new List<ISimulationComponent>();
        }

        /// <summary>
        /// Creates a new EpidemicSimulator with the given ISimulationComponents
        /// </summary>
        /// <param name="dataFilePath"></param>
        /// <param name="components">The initial ISimulationComponents to add to the EpidemicSimulator</param>
        /// <returns>The created instance of EpidemicSimulator</returns>
        public static EpidemicSimulator Create(Disease disease, string dataFilePath, params ISimulationComponent[] components)
        {
            var sim = new EpidemicSimulator(disease);

            foreach (ISimulationComponent component in components)
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
        public void AddSimulationComponent(ISimulationComponent component)
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

                _infectionSimulator = component;
                return;
            }
            if ((stages & ESimulationStage.BeforeInfectedCalculation) == ESimulationStage.BeforeInfectedCalculation &&
                    !_before.Contains(component))
                    _before.Add(component);
            
            if ((stages & ESimulationStage.AfterInfectedCalculation) == ESimulationStage.AfterInfectedCalculation &&
                    !_after.Contains(component))
                    _after.Add(component);
        }

        /// <summary>
        /// Starts a Simulation with the previously set ISimulationComponents. EpidemicSimulator needs to have an ISimulationComponent
        /// set for the Infection calculation.
        /// </summary>
        /// <param name="saveDirectory">The directory to save the snapshots in</param>
        public void StartSimulation(string saveDirectory)
        {
            StartSimulation(saveDirectory, SIMULATION_DEFAULT_LIMIT);
        }

        /// <summary>
        /// Starts a Simulation with the previously set ISimulationComponents. EpidemicSimulator needs to have an ISimulationComponent
        /// set for the Infection calculation.
        /// </summary>
        /// <param name="saveDirectory">The directory to save the snapshots in</param>
        /// <param name="limit">The limit of simulation rounds to perform</param>
        public void StartSimulation(string saveDirectory, long limit)
        {
            if (!CanStartSimulation)
                throw new SimulationException(ERROR_STARTING_SIMULATION + "Not all mandatory settings are set up correctly.");

            if (!Directory.Exists(saveDirectory) && !Directory.CreateDirectory(saveDirectory).Exists)
                throw new ArgumentException(ERROR_STARTING_SIMULATION + "Could not create given directory!", "saveDirectory");

            if (limit < 0)
                throw new ArgumentException(ERROR_STARTING_SIMULATION + "Simulationround limit must be greater than 0!", "limit");

            _simulationLimit = limit;

            OnSimulationStarted(new SimulationEventArgs() { SimulationRunning = true });
            _simulationLock = true;
            //_snapshotMgr.Initialize(saveDirectory, _simData.CurrentDisease); //TODO: |f| Get correct values.

            // Actual Simulation is performed in another Thread to enable stopping
            _simulation = Task.Run(() => PerformSimulation()).ContinueWith(_ => PerformSimulationStop());
        }

        /// <summary>
        /// Stops the current Simulation.
        /// </summary>
        public void StopSimulation()
        {
            if (!_simulationLock)
                throw new SimulationException(ERROR_STOPPING_SIMULATION + ERROR_MESSAGE_NO_SIMULATION_RUNNING);

            _simulationLock = false;
        }

        private void PerformSimulation()
        {
            while (_simulationLock)
            {
                foreach (ISimulationComponent comp in _before)
                {
                    comp.PerformSimulationStage(_simData);
                }

                // Main simulation step
                _infectionSimulator.PerformSimulationStage(_simData);

                foreach (ISimulationComponent comp in _after)
                {
                    comp.PerformSimulationStage(_simData);
                }

                //_snapshotMgr.TakeSnapshot(_simData);
                long round = Interlocked.Increment(ref _simulationRound);
                _simulationLock = round != _simulationLimit;

                OnTickFinished(new SimulationEventArgs() { SimulationRunning = true, SimulationRound = round });
            }
        }

        private void PerformSimulationStop()
        {
            long rounds = Interlocked.Read(ref _simulationRound);
            //_snapshotMgr.Finish();
            OnSimulationEnded(new SimulationEventArgs() { SimulationRunning = false,  SimulationRound = rounds });
        }

        protected virtual void OnSimulationStarted(SimulationEventArgs e)
        {
#if DEBUG
            Console.WriteLine("Simulation started!");
#endif
            SimulationStarted.Raise(this, e);
        }

        protected virtual void OnSimulationEnded(SimulationEventArgs e)
        {
#if DEBUG
            Console.WriteLine("Simulation ended!");
#endif
            SimulationEnded.Raise(this, e);
        }

        protected virtual void OnTickFinished(SimulationEventArgs e)
        {
#if DEBUG
            Console.WriteLine("Finished Tick: " + _simulationRound);
#endif
            TickFinished.Raise(this, e);
        }
    }
}