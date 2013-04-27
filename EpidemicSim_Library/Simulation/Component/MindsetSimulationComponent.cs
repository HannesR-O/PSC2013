﻿namespace PSC2013.ES.Library.Simulation.Component
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

        public ESimulationStage GetSimulationStages()
        {
            return ESimulationStage.BeforeInfectedCalculation;
        }
    }
}