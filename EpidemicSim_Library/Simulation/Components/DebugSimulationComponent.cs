using System;

namespace PSC2013.ES.Library.Simulation.Components
{
    public class DebugSimulationComponent : ISimulationComponent
    {
        void ISimulationComponent.PerformSimulationStage(SimulationData data)
        {
#if DEBUG
            Console.WriteLine("DEBUG SIMULATION TICK");
#endif
        }

        ESimulationStage ISimulationComponent.GetSimulationStages()
        {
            return ESimulationStage.InfectedCalculation;
        }
    }
}