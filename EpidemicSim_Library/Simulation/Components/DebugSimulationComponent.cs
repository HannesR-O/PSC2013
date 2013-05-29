using System;

namespace PSC2013.ES.Library.Simulation.Components
{
    public class DebugSimulationComponent : SimulationComponent
    {
        public DebugSimulationComponent() : base(ESimulationStage.InfectedCalculation) 
        {
        }

        public override void PerformSimulationStage(SimulationData data)
        {
#if DEBUG
            Console.WriteLine("DEBUG SIMULATION TICK");
#endif
        }

        public override int GetHashCode()
        {
            return "DEBUG SIMULATION TICK".GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SimulationComponent);
        }

        public override bool Equals(SimulationComponent other)
        {
            return (other as DebugSimulationComponent) != null;
        }
    }
}