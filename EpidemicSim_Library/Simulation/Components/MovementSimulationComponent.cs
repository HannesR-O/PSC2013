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
                if (data.Population[i] == null)
                    continue;
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
                        data.Population[i].Humans[j].SetTravelling(false);
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

        private void MoveHumanHome(SimulationData data, int currentcell, int human)
        {
            MoveHuman(data, currentcell, human, data.Population[currentcell].Humans[human].HomeCell);
        }

        private void MovePupil(SimulationData data , int cell, int human)
        {
            switch(data.Population[cell].Humans[human].GetMindset())
            {
                //Working Mindset -> Pupil going to school this day
                //Assert : Pupil is at Home at 0 o'clock
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
                                    MoveHumanHome(data, cell, human);
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
                                MoveHumanHome(data, cell, human);
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
                                MoveHumanHome(data, cell, human);
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
                //Assert : Student is at Home at 0 o'clock; It isn't suturday or sunday; University traveltime <= 1h
                case PopulationData.EMindset.Working:
                    //Student can have lectures during day including breaks
                    if (data.CurrentHour > 8 && data.CurrentHour < 18)
                    {
                        if (data.Population[cell].Humans[human].HomeCell == cell)
                        {
                            //Chance to go/return to University dependent on hour


                        }
                        else
                        {
                            //chance to go home dependent on hour

                        }
                    }
                    //No lectures after 18 o'clock
                    else if(data.CurrentHour == 18)
                    {
                        MoveHuman(data, cell, human, data.Population[cell].Humans[human].HomeCell);
                    }
                    //in the morning/evening student is at home 
                    else 
                    {
                        return;
                    }
                    
                    
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
            //Working Mindset -> Plumber going to different households each hour
            //Assert : Plumber is at Home at 0 o'clock; 
            switch (data.Population[cell].Humans[human].GetMindset())
            {
                case PopulationData.EMindset.Working:

                    if (data.CurrentHour > 7 && data.CurrentHour < 18)
                    {
                        //Move to another cell in <= 1h reach
                    }
                    //return home at 18 o'clock
                    else if (data.CurrentHour == 18)
                    {
                        if (data.Population[cell].Humans[human].HomeCell != cell)
                            MoveHuman(data, cell, human, data.Population[cell].Humans[human].HomeCell);
                        else
                            return;
                    }
                    else
                    {
                        return;
                    }
                    
                    
                    break;
                case PopulationData.EMindset.DayOff: break;
                case PopulationData.EMindset.Vacationing: break;
            }
        }

        private void MoveDeskJobber(SimulationData data , int cell, int human)
        {

            switch(data.Population[cell].Humans[human].GetMindset())
            {
                //Working Mindset -> Deskjobber has 9 to 5 job
                //Assert : Deskjobber is at Home at 0 o'clock;
                case PopulationData.EMindset.Working:
                    //Go to work
                    if (data.CurrentHour == 9)
                    {
                        //MoveHuman(data, cell, human, workplace);
                    }
                    //Go home
                    else if (data.CurrentHour == 18)
                    {
                        MoveHuman(data, cell, human, data.Population[cell].Humans[human].HomeCell);
                    }
                    //In the morning and evening stay at home
                    else
                    {
                        return;
                    }
                    break;
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
                //Working Mindset -> Housewife doesn't go to work is either at home in the city or by friends
                //Assert : Housewife is at Home at 0 o'clock;
                case PopulationData.EMindset.Working:
                    //Run around aimlessly^^
                    if (data.CurrentHour > 6 && data.CurrentHour < 20)
                    {
                        //chance to go shopping/visit friends/work at home dependent on hour?

                    }
                    //return home at 20 o'clock
                    else if (data.CurrentHour == 20)
                    {
                        if (data.Population[cell].Humans[human].HomeCell != cell)
                            MoveHumanHome(data, cell, human);
                        else
                            return;
                    }
                    else
                    {
                        return;
                    }
                    
                    break;
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
                //Working Mindset -> Travelling Salesman travels through Germany, changes location each day,
                //                   returns home on friday
                case PopulationData.EMindset.Working:
                    //Returns home on friday
                    if (data.CurrentDay == DayOfWeek.Friday)
                    {
                        //if hometravelltime == arrives on 17-20 o'clock -> go home else stay where you are
                    }
                    //on every other day travel through germany
                    else
                    {
                        if (data.CurrentHour == 4)
                        {
                            //travel to distant point
                        }
                        else
                            return;
                    }
                    
                    break;
                case PopulationData.EMindset.HomeStaying: break;
                case PopulationData.EMindset.Shopping: break;
                case PopulationData.EMindset.Stationary: break;
                case PopulationData.EMindset.DayOff: break;
                case PopulationData.EMindset.Vacationing: break;
            }
        }

        private void MoveCommuter(SimulationData data, int cell, int human)
        {
            switch (data.Population[cell].Humans[human].GetMindset())
            {
                //Working Mindset -> Commuter goes to work in a city that is 0,5-2 hours away from home
                //Assert : Commuter is at Home at 0 o'clock;
                case PopulationData.EMindset.Working:
                    //travel to distant workplace
                    if (data.CurrentHour == 6)
                    {
                        
                    }
                    //return home
                    else if(data.CurrentHour == 17)
                    {

                    }
                    //Stay home in the morning and evening
                    else 
                    {
                        return;
                    }

                    break;
                case PopulationData.EMindset.HomeStaying: break;
                case PopulationData.EMindset.Shopping: break;
                case PopulationData.EMindset.Stationary: break;
                case PopulationData.EMindset.DayOff: break;
                case PopulationData.EMindset.Vacationing: break;
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