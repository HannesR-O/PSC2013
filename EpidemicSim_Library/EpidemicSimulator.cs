using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.Simulation;
using PSC2013.ES.Library.Snapshot;
using System.IO;
using System.Threading;

namespace PSC2013.ES.Library
{
    public class EpidemicSimulator
    {
        // Constants
        private const string ERROR_MESSAGE_SIMULATION = "A Simulation is already running!";
        private const string ERROR_MESSAGE_NO_SIMULATION = "No Simulation running!";

        // Data
        private SimulationData _simData;

        // Managers
        private SnapshotManager _snapshotMgr;

        // ISimulationComponents
        private ISimulationComponent _infectionSimulator;
        private List<ISimulationComponent> _before, _after;

        // Misc
        private volatile bool _simulationLock = false;       //TODO: |f| might not need volatile
        private long _simulationRound = 1;

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

            _snapshotMgr = new SnapshotManager();

            _before = new List<ISimulationComponent>();
            _after = new List<ISimulationComponent>();
        }

        /// <summary>
        /// Creates a new EpidemicSimulator with the given ISimulationComponents
        /// </summary>
        /// <param name="components">The initial ISimulationComponents to add to the EpidemicSimulator</param>
        /// <returns>The created instance of EpidemicSimulator</returns>
        public EpidemicSimulator Create(params ISimulationComponent[] components)
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
            if(_simulationLock)
                throw new SimulationException("Could not add a new ISimulationComponent. " + ERROR_MESSAGE_SIMULATION);

            switch (component.GetSimulationStage())
            {
                case ESimulationStage.BeforeInfectedCalculation:
                    if(!_before.Contains(component))
                        _before.Add(component);
                    break;
                case ESimulationStage.InfectedCalculation:
                    _infectionSimulator = component;
                    break;
                case ESimulationStage.AfterInfectedCalculation:
                    if(!_after.Contains(component))
                        _after.Add(component);
                    break;
                default:
                    throw new ArgumentException("The component's ESimulationStage is not valid!", "component");
            }
        }

        /// <summary>
        /// Starts a Simulation with the previously set ISimulationComponents. EpidemicSimulator needs to have an ISimulationComponent
        /// for the Infection calculation.
        /// </summary>
        public void StartSimulation(string saveDirectory)
        {
            if (_infectionSimulator == null)
                throw new SimulationException("No ISimulationComponent specified for disease spreading!");

            if (_simulationLock)
                throw new SimulationException("Could not start a new Simulation. " + ERROR_MESSAGE_SIMULATION);

            if (!Directory.Exists(saveDirectory) && !Directory.CreateDirectory(saveDirectory).Exists)
                throw new ArgumentException("Could not start a new Simulation. Could not create given directory!", "saveDirectory");

            OnSimulationStarted(new SimulationEventArgs() { SimulationRunning = true });
            _simulationLock = true;
            //_snapshotMgr.InitalizeSimulation(saveDirectory, "Test-Sim", SimulationData.CurrentDisease); //TODO: |f| Get correct values.

            Thread simulation = new Thread(PerformSimulation);
            simulation.Start();

            //_snapshotMgr.Finish();
            OnSimulationEnded(new SimulationEventArgs() { SimulationRunning = false });
        }

        private void PerformSimulation()
        {
            while (_simulationLock)
            {
                foreach (ISimulationComponent comp in _before)
                {
                    comp.PerformSimulationStage(ref _simData);
                }

                // Main simulation step
                _infectionSimulator.PerformSimulationStage(ref _simData);

                foreach (ISimulationComponent comp in _after)
                {
                    comp.PerformSimulationStage(ref _simData);
                }

                //_snapshotMgr.TakeSnapshot(SimulationData.Population, new string[] { "Test" });  //TODO: |f| Figure out where to get dead people
                _simulationRound++;
                OnTickFinished(new SimulationEventArgs() { SimulationRunning = true });
            }
        }

        /// <summary>
        /// Stops the current Simulation.
        /// </summary>
        public void StopSimulation()
        {
            if (!_simulationLock)
                throw new SimulationException("Could not stop Simulation. " + ERROR_MESSAGE_NO_SIMULATION);
            //TODO: |f| make simulationticks execute in a seperate thread and use locks, so this method can actually stop the calculation
            _simulationLock = false;
        }

        protected virtual void OnSimulationStarted(SimulationEventArgs e)
        {
            SimulationStarted.Raise(this, e);
        }

        protected virtual void OnSimulationEnded(SimulationEventArgs e)
        {
            SimulationEnded.Raise(this, e);
        }

        protected virtual void OnTickFinished(SimulationEventArgs e)
        {
            TickFinished.Raise(this, e);
        }
    }
}