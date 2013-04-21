using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.Simulation;
using PSC2013.ES.Library.Snapshot;

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
        private List<ISimulationComponent> _stage1, _stage2, _stage3;

        // Misc
        private volatile bool _simulationLock = false;       //TODO: |f| might not need volatile
        private long _simulationRound = 1;

        // Events
        public event EventHandler<SimulationEventArgs> SimulationStarted;
        public event EventHandler<SimulationEventArgs> SimulationEnded;
        public event EventHandler<SimulationEventArgs> TickFinished;
        //TODO: |f| do we also want StageFinished ?

        private EpidemicSimulator()
        {
            _simData = new SimulationData();

            _snapshotMgr = new SnapshotManager();

            _stage1 = new List<ISimulationComponent>();
            _stage2 = new List<ISimulationComponent>();
            _stage3 = new List<ISimulationComponent>();
        }

        public EpidemicSimulator Create(params ISimulationComponent[] components)
        {
            var sim = new EpidemicSimulator();

            foreach (ISimulationComponent component in components)
            {
                sim.AddSimulationComponent(component);
            }

            return sim;
        }

        public void AddSimulationComponent(ISimulationComponent component)
        {
            if(_simulationLock)
                throw new SimulationException("Could not add a new ISimulationComponent. " + ERROR_MESSAGE_SIMULATION);

            switch (component.GetSimulationStage())
            {
                case ESimulationStage.BeforeInfectedCalculation:
                    _stage1.Add(component);
                    break;
                case ESimulationStage.InfectedCalculation:
                    _stage2.Add(component);
                    break;
                case ESimulationStage.AfterInfectedCalculation:
                    _stage3.Add(component);
                    break;
                default:
                    throw new ArgumentException("The component's ESimulationStage is not valid!", "component");
            }
        }

        public void StartSimulation()
        {
            if (_simulationLock)
                throw new SimulationException("Could not start a new Simulation. " + ERROR_MESSAGE_SIMULATION);

            _simulationLock = true;
            // _snapshotMgr.StartSimulation().. TODO: |f| Start snapshot capturing here

            while (_simulationLock)
            {
                foreach (ISimulationComponent comp in _stage1)
                {
                    comp.PerformSimulationStage(ref _simData);
                }

                foreach (ISimulationComponent comp in _stage2)
                {
                    comp.PerformSimulationStage(ref _simData);
                }

                foreach (ISimulationComponent comp in _stage3)
                {
                    comp.PerformSimulationStage(ref _simData);
                }

                _simulationRound++;
                //TODO: |f| Add current snapshot to the SnapshotManager
            }
        }

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