using System;

namespace PSC2013.ES.Library.Simulation.Component
{
    public class DebugSimulationComponent : ISimulationComponent
    {
        void ISimulationComponent.PerformSimulationStage(ref SimulationData data)
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