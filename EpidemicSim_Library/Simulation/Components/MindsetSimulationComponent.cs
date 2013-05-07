using System;

namespace PSC2013.ES.Library.Simulation.Components
{
    public class MindsetSimulationComponent : ISimulationComponent
    {
        public void PerformSimulationStage(SimulationData data)
        {       
            
        }

        public ESimulationStage SimulationStages
        {
            get { return ESimulationStage.BeforeInfectedCalculation; }
        }

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
            var otherComponent = other as MindsetSimulationComponent;
            if (otherComponent == null)
                return false;

            throw new NotImplementedException();
        }
    }
}