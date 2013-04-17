using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulator
{
    public class Simulator
    {
        private Action HumanAI_Action;
        private Action[] Influencing_Action;
        private Action Infection_Action;
        private Action Disease_Action;

        //TODO Has to be Multithreaded
        public void Simulate()
        {

            //Let people think/move IMPORTANT : Save number of people in cell
            for (int i = 0; i < SimulationData.Population.Length; ++i)
            {
                HumanAI_Action();
            }

            //Calculate Resistance-influencing stuff e.g. Weather
            for (int i = 0; i < SimulationData.Population.Length; ++i)
            {
                for (int j = 0; j < Influencing_Action.Length; ++j)
                {
                    Influencing_Action[i]();
                }
            }

            //Calculate new Infected
            for (int i = 0; i < SimulationData.Population.Length; ++i)
            {
                Infection_Action();
            }

            //Let people age
            for (int i = 0; i < SimulationData.Population.Length; ++i)
            {
                Disease_Action();
            }




        }

    }
}
