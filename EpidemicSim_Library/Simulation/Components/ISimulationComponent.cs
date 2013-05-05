using System;

namespace PSC2013.ES.Library.Simulation.Components
{
    public interface ISimulationComponent : IEquatable<ISimulationComponent>
    {
        /// <summary>
        /// The main operation which gets called by EpidemicSimulator during each tick.
        /// </summary>
        /// <param name="data">The data for the simulation to work with</param>
        void PerformSimulationStage(SimulationData data);

        /// <summary>
        /// The ISimulationComponent's simulation stage(s) to determine when PerformSimulationStage()
        /// gets executed.
        /// </summary>
        ESimulationStage SimulationStages { get; }
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