using System;

namespace PSC2013.ES.Library.Simulation.Components
{
    public class InfectionCalculatorComponent : ISimulationComponent
    {
        public void PerformSimulationStage(SimulationData data)
        {
            throw new NotImplementedException();
        }

        public ESimulationStage SimulationStages { get { return ESimulationStage.InfectedCalculation; } }

        public bool Equals(ISimulationComponent other)
        {
            throw new NotImplementedException();
        }
    }
}