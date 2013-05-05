using System;

namespace PSC2013.ES.Library.Simulation.Components
{
    public class MindsetSimulationComponent : ISimulationComponent
    {
        public void PerformSimulationStage(SimulationData data)
        {       
            //Update Mindsets every Day
            //TODO |f| add Events to SimulationData to trigger events new Day/Month/Year? vs Using Simulators events?

            if (data.CurrentHour == 0)
            {

                for (int i = 0; i < data.Population.Length; ++i)
                {
                    for (int j = 0; j < data.Population[i].Humans.Length; ++j)
                    {

                    }
                }
            }
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