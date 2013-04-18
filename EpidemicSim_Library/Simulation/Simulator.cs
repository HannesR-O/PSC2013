using PSC2013.ES.Library.PopulationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulation
{
    public class Simulator
    {
        public void Simulate()
        {
            //Assumption : SimulationData initialized Completely, including default Mindset, Professions, etc

            //Let people think and Move them
            for (int i = 0; i < SimulationData.Population.Length; ++i)
            {
                for (int j = 0; j < SimulationData.Population[i].Humans.Length; ++j)
                {
                    if (SimulationData.Population[i].Humans[j].IsDead())
                        continue;

                    switch (SimulationData.Population[i].Humans[j].GetMindset())
                    {
                        case EMindset.Stationary: break;
                        case EMindset.HomeStaying: break;
                        case EMindset.Working: break;
                        case EMindset.Vacationing: break;
                        case EMindset.Shopping: break;
                    }
                }
            }

            //refresh influencing Factors
            for (int i = 0; i < SimulationData.FederalStates.Length; ++i)
            {

                //SimulationData.FederalStates[i].Influence = 0;
            }

            //Calculate new Infected
            for (int i = 0; i < SimulationData.Population.Length; ++i)
            {
                for (int j = 0; j < SimulationData.Population[i].Humans.Length; ++j)
                {
                    if (SimulationData.Population[i].Humans[j].IsDead())
                        continue;


                }
            }

            //DiseaseTick
            for (int i = 0; i < SimulationData.Population.Length; ++i)
            {
                for (int j = 0; j < SimulationData.Population[i].Humans.Length; ++j)
                {
                    if (SimulationData.Population[i].Humans[j].IsDead())
                        continue;

                    //SimulationData.Population[i].Humans[j].DoDiseaseTick();
                }
            }

            //if a day has passed recalculate Mindset
            for (int i = 0; i < SimulationData.Population.Length; ++i)
            {
                for (int j = 0; j < SimulationData.Population[i].Humans.Length; ++j)
                {
                    if (SimulationData.Population[i].Humans[j].IsDead())
                        continue;
                }
            }

            //if a Month has passed give Birth to new Babys
            for (int i = 0; i < SimulationData.Population.Length; ++i)
            {
                //Add all Females/males calculate new Babys by chance
            }

            //if a year has passed trigger Aging
            for (int i = 0; i < SimulationData.Population.Length; ++i)
            {
                for (int j = 0; j < SimulationData.Population[i].Humans.Length; ++j)
                {
                    SimulationData.Population[i].Humans[j].DoAgeTick();
                    //if human got older change Profession!!!!!!
                }
            }
        }
    }
}