using PSC2013.ES.Library.PopulationData;
using System;

namespace PSC2013.ES.Library.Simulation.Components
{
    /// <summary>
    /// SimulationComponent to move the entire human population 
    /// according to their Mindset, Profession and SimulationTime
    /// </summary>
    public unsafe class MovementSimulationComponent : ISimulationComponent
    {
        private readonly Random _random;
        private int _randomHolder, _simulationIntervall;         //1. tmp-variable to hold Random.Next() results
        private Human* _ptr;

        public MovementSimulationComponent()
        {
            _random = new Random();
            _simulationIntervall = 1;
        }


        public void PerformSimulationStage(SimulationData data)
        {
            fixed (Human* humanptr = data.Humans)
            {

                for (_ptr = humanptr; _ptr < humanptr + data.Humans.Length; ++_ptr)
                {
                    //Stationary Mindset implies the human chosen won't move this day regardless of profession
                    //If the human is dead he won't move....
                    if (_ptr->IsDead() ||
                        _ptr->GetMindset() == PopulationData.EMindset.Stationary)
                    {
                        continue;
                    }
                    //Travelling implies ignoring the Mindset until the human reached its Destination
                    else if (_ptr->IsTravelling())
                    {
                        //reduce counter, if counter == 0 remove flag travelling else continue
                        _ptr->SetTravelling(false);
                    }
                    //Staying Home doesn't vary no matter what profession the human is having.
                    else if (_ptr->GetMindset() == PopulationData.EMindset.HomeStaying)
                    {
                        //chance every day to go out 1-3 hours
                        //if ill -> go to hospital
                        //if healthy wander around aimlessly in departement (short range)
                    }
                    //Handle Movement for Mindsets which are dependent on the profession od the selected human
                    else
                    {
                        switch (_ptr->GetProfession())
                        {
                            case PopulationData.EProfession.Pupil: MovePupil(data); break;
                        }
                    }
                }
            }
        }

        public void SetSimulationIntervall(int intervall)
        {
            _simulationIntervall = intervall;           //TODO: |f| make use of this ;) & add range checks?
        }

        /// <summary>
        /// Moves a selected Human to another Area in the PopulationCellGrid.
        /// </summary>
        /// <param name="data">Reference to SimulationData</param>
        /// <param name="currentcell">The cell the human to move is currently in</param>
        /// <param name="human">The index of the selected human in the current cell</param>
        /// <param name="destinationcell">The index of the cell the human should be moved to</param>
        private void MoveHuman(SimulationData data, int destinationcell)
        {
            //Set selected Human to status "travelling"
            _ptr->SetTravelling(true);
            if (_ptr->IsInfected())
                --data.Cells[_ptr->CurrentCell].Infected;
            else if (_ptr->IsSpreading())
                --data.Cells[_ptr->CurrentCell].Spreading;
            else if (_ptr->IsDiseased())
                --data.Cells[_ptr->CurrentCell].Diseased;

            if (_ptr->GetGender() == EGender.Male)
            {
                switch (_ptr->GetAge())
                {
                    case EAge.Baby: --data.Cells[_ptr->CurrentCell].MaleBabies; break;
                    case EAge.Child: --data.Cells[_ptr->CurrentCell].MaleChildren; break;
                    case EAge.Adult: --data.Cells[_ptr->CurrentCell].MaleAdults; break;
                    case EAge.Senior: --data.Cells[_ptr->CurrentCell].MaleSeniors; break;
                }
            }
            else
            {
                switch (_ptr->GetAge())
                {
                    case EAge.Baby: --data.Cells[_ptr->CurrentCell].FemaleBabies; break;
                    case EAge.Child: --data.Cells[_ptr->CurrentCell].FemaleChildren; break;
                    case EAge.Adult: --data.Cells[_ptr->CurrentCell].FemaleAdults; break;
                    case EAge.Senior: --data.Cells[_ptr->CurrentCell].FemaleSeniors; break;
                }
            }


            //TODO |h| Set Travelling Counter and check for short travels (travellingcounter == 0)
            //ptr->SetTravellingCounter();


            //Add the selected Human in the Destinationcell
            _ptr->CurrentCell = destinationcell;
   
        }

        private void MoveHumanHome()
        {
            _ptr->CurrentCell = _ptr->HomeCell;
        }

        private void MovePupil(SimulationData data)
        {
            switch (_ptr->GetMindset())
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
                        if (_ptr->HomeCell != _ptr->CurrentCell)
                        {
                            if ((_randomHolder = _random.Next(3)) == 3)
                                MoveHumanHome();
                            else
                                return;

                        }
                        else
                            return;

                    }
                    //School ends definately
                    else if (data.CurrentHour == 14)
                    {
                        if (_ptr->HomeCell != _ptr->CurrentCell)
                            MoveHumanHome();
                        else
                            return;
                    }
                    else if (data.CurrentHour == 15)
                    {
                        if (_random.Next(1) == 1)
                        {
                            //MoveHuman(data, cell, human, friend);
                        }
                        else
                            return;
                    }
                    //Return pupil home if he isn't already
                    else if (data.CurrentHour == 18)
                    {
                        if (_ptr->HomeCell != _ptr->CurrentCell)
                            MoveHumanHome();
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

        private void MoveStudent(SimulationData data)
        {

            switch (_ptr->GetMindset())
            {
                //Working Mindset -> Student going to University this day
                //Assert : Student is at Home at 0 o'clock; It isn't suturday or sunday; University traveltime <= 1h
                case PopulationData.EMindset.Working:
                    //Student can have lectures during day including breaks
                    if (data.CurrentHour > 8 && data.CurrentHour < 18)
                    {
                        if ((_ptr->HomeCell == _ptr->CurrentCell))
                        {
                            //Chance to go/return to University dependent on hour


                        }
                        else
                        {
                            //chance to go home dependent on hour

                        }
                    }
                    //No lectures after 18 o'clock
                    else if (data.CurrentHour == 18)
                    {
                        MoveHumanHome();
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

        private void MovePlumber(SimulationData data)
        {
            //Working Mindset -> Plumber going to different households each hour
            //Assert : Plumber is at Home at 0 o'clock; 
            switch (_ptr->GetMindset())
            {
                case PopulationData.EMindset.Working:

                    if (data.CurrentHour > 7 && data.CurrentHour < 18)
                    {
                        //Move to another cell in <= 1h reach
                    }
                    //return home at 18 o'clock
                    else if (data.CurrentHour == 18)
                    {
                        if (_ptr->HomeCell != _ptr->CurrentCell)
                            MoveHumanHome();
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

        private void MoveDeskJobber(SimulationData data)
        {

            switch (_ptr->GetMindset())
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
                        MoveHumanHome();
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

            switch (_ptr->GetMindset())
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
                        if (_ptr->HomeCell != _ptr->CurrentCell)
                            MoveHumanHome();
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

        private void MoveTravellingSalesman(SimulationData data)
        {

            switch (_ptr->GetMindset())
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
            switch (_ptr->GetMindset())
            {
                //Working Mindset -> Commuter goes to work in a city that is 0,5-2 hours away from home
                //Assert : Commuter is at Home at 0 o'clock;
                case PopulationData.EMindset.Working:
                    //travel to distant workplace
                    if (data.CurrentHour == 6)
                    {

                    }
                    //return home
                    else if (data.CurrentHour == 17)
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