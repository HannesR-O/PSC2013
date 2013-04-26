using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.Simulation;
using PSC2013.ES.Library.Snapshot;
using System.IO;
using System.Threading;
using PSC2013.ES.Library.Simulation.Component;

namespace PSC2013.ES.Library
{
    public class EpidemicSimulator
    {
        // Constants
        private const string ERROR_MESSAGE_SIMULATION = "A Simulation is already running!";
        private const string ERROR_MESSAGE_NO_SIMULATION = "No Simulation running!";

        private const int SIMULATION_DEFAULT_START = 0x0;
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
        public bool IsSimulationg { get { return _simulationLock; } }

        // Events
        public event EventHandler<SimulationEventArgs> SimulationStarted;
        public event EventHandler<SimulationEventArgs> SimulationEnded;
        public event EventHandler<SimulationEventArgs> TickFinished;
        //TODO: |f| do we also want StageFinished ?

        private EpidemicSimulator()
        {
            _simData = new SimulationData();

            _snapshotMgr = new SnapshotManager(); // Needs to be initialized before using

            _before = new List<ISimulationComponent>();
            _after = new List<ISimulationComponent>();
        }

        /// <summary>
        /// Creates a new EpidemicSimulator with the given ISimulationComponents
        /// </summary>
        /// <param name="components">The initial ISimulationComponents to add to the EpidemicSimulator</param>
        /// <returns>The created instance of EpidemicSimulator</returns>
        public static EpidemicSimulator Create(params ISimulationComponent[] components)
        {
            var sim = new EpidemicSimulator();

            foreach (ISimulationComponent component in components)
            {
                sim.AddSimulationComponent(component);
            }

            return sim;
        }

        /// <summary>
        /// Adds a new ISimulationComponent to the EpidemicSimulator. If the given ISimulationComponent is an Infection Simulator,
        /// the previous one will be overriden
        /// </summary>
        /// <param name="component"></param>
        public void AddSimulationComponent(ISimulationComponent component)
        {
            if (_simulationLock)
                throw new SimulationException("Could not add a new ISimulationComponent. " + ERROR_MESSAGE_SIMULATION);

            ESimulationStage stages = component.GetSimulationStages();
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
            else
            {
                if ((stages & ESimulationStage.BeforeInfectedCalculation) == ESimulationStage.BeforeInfectedCalculation &&
                    _before.Contains(component))
                    _before.Add(component);

                if ((stages & ESimulationStage.AfterInfectedCalculation) == ESimulationStage.AfterInfectedCalculation &&
                    _after.Contains(component))
                    _after.Add(component);

                return;
            }

            throw new ArgumentException("The component's ESimulationStage is not valid!", "component");
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
            if (_infectionSimulator == null)
                throw new SimulationException("No ISimulationComponent specified for disease spreading!");

            if (_simulationLock)
                throw new SimulationException("Could not start a new Simulation. " + ERROR_MESSAGE_SIMULATION);

            if (!Directory.Exists(saveDirectory) && !Directory.CreateDirectory(saveDirectory).Exists)
                throw new ArgumentException("Could not start a new Simulation. Could not create given directory!", "saveDirectory");

            if (limit < 0)
                throw new ArgumentException("Simulationround limit must be greater than 0!", "limit");

            _simulationLimit = limit;

            OnSimulationStarted(new SimulationEventArgs() { SimulationRunning = true });
            _simulationLock = true;
            //_snapshotMgr.InitalizeSimulation(saveDirectory, SimulationData.CurrentDisease); //TODO: |f| Get correct values.

            // Actual Simulation
            _simulation = Task.Run(() => PerformSimulation()).ContinueWith(_ => PerformSimulationStop());
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

                //_snapshotMgr.TakeSnapshot(SimulationData.Population, new string[] { "Test" });  //TODO: |f| Figure out where to get dead people
                long round = Interlocked.Increment(ref _simulationRound);
                if (round != SIMULATION_DEFAULT_LIMIT)
                    _simulationLock = round <= _simulationLimit;

                OnTickFinished(new SimulationEventArgs() { SimulationRunning = true, SimulationRound = round });
            }
        }

        /// <summary>
        /// Stops the current Simulation.
        /// </summary>
        public void StopSimulation()
        {
            if (!_simulationLock)
                throw new SimulationException("Could not stop Simulation. " + ERROR_MESSAGE_NO_SIMULATION);

            _simulationLock = false;
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