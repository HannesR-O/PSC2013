using System;

namespace PSC2013.ES.Library.Simulation.Components
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
                    //If the human is dead he won't move....
                    if (data.Population[i].Humans[j].IsDead() ||
                        data.Population[i].Humans[j].GetMindset() == PopulationData.EMindset.Stationary)
                    {
                        continue;
                    }
                    //Travelling implies ignoring the Mindset until the human reached its Destination
                    else if (data.Population[i].Humans[j].IsTravelling())
                    {
                        //reduce counter, if counter == 0 remove flag travelling else continue
                    }
                    //Staying Home doesn't vary no matter what profession the human is having.
                    else if (data.Population[i].Humans[j].GetMindset() == PopulationData.EMindset.HomeStaying)
                    {
                        //chance every day to go out 1-3 hours
                        //if ill -> go to hospital
                        //if healthy wander around aimlessly in departement (short range)
                    }
                    //Handle Movement for Mindsets which are dependent on the profession od the selected human
                    else
                    {
                        switch (data.Population[i].Humans[j].GetProfession())
                        {
                            case PopulationData.EProfession.Pupil: MovePupil(data, i, j); break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Moves a selected Human to another Area in the PopulationCellGrid.
        /// </summary>
        /// <param name="data">Reference to SimulationData</param>
        /// <param name="currentcell">The cell the human to move is currently in</param>
        /// <param name="human">The index of the selected human in the current cell</param>
        /// <param name="destinationcell">The index of the cell the human should be moved to</param>
        private void MoveHuman(SimulationData data, int currentcell, int human, int destinationcell)
        {
            //Set selected Human to status "travelling"
            data.Population[currentcell].Humans[human].SetTravelling(true);

            //Set Travelling Counter
            //data.Population[currentcell].Humans[human].SetTravellingCounter();

            //Add the selected Human in the Destinationcell
            data.Population[destinationcell].AddHuman(data.Population[currentcell].Humans[human]);
            //TODO |f| Add Fields for age/gender-groups to Populationcell!!!
            //Increment Humancount (if it isn't incremented in AddHuman later on...)

            //Remove/Kill the selected Human in its original Location
            data.Population[currentcell].Humans[human].KillHuman();
            //Decrement Humancount!
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
                            //MoveHuman(data, cell, human, school);
                        }
                        else if (data.CurrentHour < 11)
                        {
                            return; //Pupil should stay in shool
                        }
                        //pupil has chance that school ends
                        else if (data.CurrentHour < 14)
                        {
                            if (data.Population[cell].Humans[human].HomeCell != cell)
                            {
                                if ((randomHolder = random.Next(3)) == 3)
                                {
                                    MoveHuman(data, cell, human, data.Population[cell].Humans[human].HomeCell);
                                }
                                else
                                    return;

                            }
                            else
                                return;
                            
                        }
                        //School ends definately
                        else if (data.CurrentHour == 14)
                        {
                            if (data.Population[cell].Humans[human].HomeCell != cell)
                            {
                                MoveHuman(data, cell, human, data.Population[cell].Humans[human].HomeCell);
                            }
                            else
                                return;
                        }
                        else if (data.CurrentHour == 15)
                        {
                            if (random.Next(1) == 1)
                            {
                                //MoveHuman(data, cell, human, friend);
                            }
                            else
                                return;
                        }
                        //Return pupil home if he isn't already
                        else if (data.CurrentHour == 18)
                        {
                            if (data.Population[cell].Humans[human].HomeCell != cell)
                            {
                                MoveHuman(data, cell, human, data.Population[cell].Humans[human].HomeCell);
                            }
                            else
                                return;
                        }
                        //in the evening pupil should be at home
                        else
                        {
                            return;
                        }
                    
                    break;

                case PopulationData.EMindset.Vacationing: 
                    //Assert : traveltime <= 10 h 
                    break;
                case PopulationData.EMindset.DayOff: 
                    
                    break;
            }
        }

        private void MoveStudent(SimulationData data, int cell, int human)
        {

            switch (data.Population[cell].Humans[human].GetMindset())
            {
                //Working Mindset -> Student going to University this day
                //Assert : Student is at Home at 0 o'clock; It isn't suturday or sunday
                case PopulationData.EMindset.Working: 
                    
                    
                    
                    break;
                case PopulationData.EMindset.HomeStaying: break;
                case PopulationData.EMindset.Shopping: break;
                case PopulationData.EMindset.Stationary: break;
                case PopulationData.EMindset.DayOff: break;
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
                case PopulationData.EMindset.DayOff: break;
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
                case PopulationData.EMindset.DayOff: break;
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
                case PopulationData.EMindset.DayOff: break;
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
                case PopulationData.EMindset.DayOff: break;
                case PopulationData.EMindset.Vacationing: break;
            }
        }

        public ESimulationStage GetSimulationStages()
        {
            return ESimulationStage.BeforeInfectedCalculation;
        }
    }
}
