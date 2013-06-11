using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulation.Components
{
    public abstract class SimulationComponent : IEquatable<SimulationComponent>
    {
        protected int _simulationIntervall = 1;
        protected ESimulationStage _simulationStages;

        protected SimulationComponent(ESimulationStage stages)
        {
            _simulationStages = stages;
        }

        /// <summary>
        /// The main operation which gets called by EpidemicSimulator during each tick.
        /// </summary>
        /// <param name="data">The data for the simulation to work with</param>
        public abstract void PerformSimulationStage(SimulationData data);

        /// <summary>
        /// Sets the amount of hours passing in one simulation tick.
        /// </summary>
        /// <param name="intervall">Intervall to set. Must be greater than 0</param>
        public virtual void SetSimulationIntervall(int intervall)
        {
            if(intervall < 1)
                throw new ArgumentOutOfRangeException("intervall");

            _simulationIntervall = intervall;
        }

        /// <summary>
        /// The ISimulationComponent's simulation stage(s) to determine when PerformSimulationStage()
        /// gets executed.
        /// </summary>
        public ESimulationStage SimulationStages { get { return _simulationStages; } }

        public abstract bool Equals(SimulationComponent other);
    }

    /// <summary>
    /// Enum to determine when the ISimulationComponent should exeute. [Flags] to allow multiple stages
    /// </summary>
    [Flags]
    public enum ESimulationStage
    {
        BeforeInfectedCalculation = 1,
        InfectedCalculation = 2,
        AfterInfectedCalculation = 4
    }
}