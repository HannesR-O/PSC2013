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

                foreach (int i in data.Population.Keys)
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
    }
}