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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ISimulationComponent);
        }

        public bool Equals(ISimulationComponent other)
        {
            var otherComponent = other as InfectionCalculatorComponent;
            if (otherComponent == null)
                return false;

            throw new NotImplementedException();
        }
    }
}