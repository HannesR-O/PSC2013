namespace PSC2013.ES.Library.Simulation.Components
{
    public interface ISimulationComponent
    {
        /// <summary>
        /// The main operation which gets called by EpidemicSimulation during each tick.
        /// </summary>
        /// <param name="data">The data for the simulation to work with</param>
        void PerformSimulationStage(SimulationData data);

        /// <summary>
        /// Returns the ISimulationComponent's simulation stage(s) to determine when PerformSimulationStage()
        /// gets executed.
        /// </summary>
        /// <returns>The stage(s)</returns>
        ESimulationStage GetSimulationStages();
    }
}