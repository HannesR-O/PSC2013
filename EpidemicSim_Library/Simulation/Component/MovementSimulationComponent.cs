using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulation.Component
{
    /// <summary>
    /// SimulationComponent to move the entire human population 
    /// according to their Mindset, Profession and SimulationTime
    /// </summary>
    public class MovementSimulationComponent : ISimulationComponent
    {
        private Random random;
        private int randomHolder; //tmp-variable to hold Random.Next() results

        public MovementSimulationComponent()
        {
            random = new Random();
        }


        public void PerformSimulationStage(SimulationData data)
        {
            for (int i = 0; i < data.Population.Length; ++i)
            {
                for (int j = 0; j < data.Population[i].Humans.Length; ++j)
                {
                    //Stationary Mindset implies the human chosen won't move this day regardless of profession
                    if (data.Population[i].Humans[j].IsDead() || 
                        data.Population[i].Humans[j].GetMindset() == PopulationData.EMindset.Stationary)
                        continue;
                    //else if (data.Population[i].Humans[j].IsTravelling())
                    //reduce counter, if counter == 0 remove flag travelling else continue

                    //Handle Movement for different professions
                    switch (data.Population[i].Humans[j].GetProfession())
                    {
                        case PopulationData.EProfession.Pupil: MovePupil(data, i, j); break;
                    }
                }
            }
        }

        private void MovePupil(SimulationData data , int cell, int human)
        {
            switch(data.Population[cell].Humans[human].GetMindset())
            {
                //Working Mindset -> Pupil going to school this day
                //Assert : Pupil is at Home at 0 o'clock; It isn't suturday or sunday
                case PopulationData.EMindset.Working:

                        //Pupil is at Home in the Morning
                        if (data.CurrentHour < 7)
                        {
                            return;
                        }
                        //Pupil should be in School from 7-10
                        else if (data.CurrentHour == 7)
                        {
                            //Move Pupil to school set traveltime + travelflag
                        }
                        else if (data.CurrentHour < 11)
                        {
                            return; //Pupil should stay in shool
                        }
                        //pupil can still be in school from 10-14
                        else if (data.CurrentHour < 14)
                        {
                            randomHolder = random.Next(5);
                        }
                        //pupil has chance to visit friends from 14-18
                        else if (data.CurrentHour < 18)
                        {
                            randomHolder = random.Next();
                        }
                        
                        else if (data.CurrentHour == 18)
                        {

                        }
                        //in the evening pupil should be at home
                        else
                        {
                            return;
                        }
                    

                    
                    break;

                case PopulationData.EMindset.Shopping: break;
                case PopulationData.EMindset.Vacationing: 
                    //Assert : traveltime <= 10 h 
                    break;
            }
        }

        private void MoveStudent(SimulationData data, int cell, int human)
        {

            switch (data.Population[cell].Humans[human].GetMindset())
            {
                case PopulationData.EMindset.Working: break;
                case PopulationData.EMindset.HomeStaying: break;
                case PopulationData.EMindset.Shopping: break;
                case PopulationData.EMindset.Stationary: break;
                case PopulationData.EMindset.Travelling: break;
                case PopulationData.EMindset.Vacationing: break;
            }
        }

        private void MovePlumber(SimulationData data, int cell, int human)
        {

            switch (data.Population[cell].Humans[human].GetMindset())
            {
                case PopulationData.EMindset.Working: break;
                case PopulationData.EMindset.HomeStaying: break;
                case PopulationData.EMindset.Shopping: break;
                case PopulationData.EMindset.Stationary: break;
                case PopulationData.EMindset.Travelling: break;
                case PopulationData.EMindset.Vacationing: break;
            }
        }

        private void MoveDeskJobber(SimulationData data , int cell, int human)
        {

            switch(data.Population[cell].Humans[human].GetMindset())
            {
                case PopulationData.EMindset.Working: break;
                case PopulationData.EMindset.HomeStaying: break;
                case PopulationData.EMindset.Shopping: break;
                case PopulationData.EMindset.Stationary: break;
                case PopulationData.EMindset.Travelling: break;
                case PopulationData.EMindset.Vacationing: break;
            }
        }

        private void MoveHousewife(SimulationData data, int cell, int human)
        {

            switch (data.Population[cell].Humans[human].GetMindset())
            {
                case PopulationData.EMindset.Working: break;
                case PopulationData.EMindset.HomeStaying: break;
                case PopulationData.EMindset.Shopping: break;
                case PopulationData.EMindset.Stationary: break;
                case PopulationData.EMindset.Travelling: break;
                case PopulationData.EMindset.Vacationing: break;
            }
        }

        private void MoveTravellingSalesman(SimulationData data, int cell, int human)
        {

            switch (data.Population[cell].Humans[human].GetMindset())
            {
                case PopulationData.EMindset.Working: break;
                case PopulationData.EMindset.HomeStaying: break;
                case PopulationData.EMindset.Shopping: break;
                case PopulationData.EMindset.Stationary: break;
                case PopulationData.EMindset.Travelling: break;
                case PopulationData.EMindset.Vacationing: break;
            }
        }

        public ESimulationStage GetSimulationStages()
        {
            return ESimulationStage.BeforeInfectedCalculation;
        }
    }
}
