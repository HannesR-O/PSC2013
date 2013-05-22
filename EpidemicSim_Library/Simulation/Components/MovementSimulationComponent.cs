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
                        --ptr->TravellingCounter;

                        if (ptr->TravellingCounter == 0)
                        {
                            ptr->SetTravelling(false);

                            if (ptr->IsInfected())
                                ++data.Cells[ptr->CurrentCell].Infected;

                            else if (ptr->IsSpreading())
                                ++data.Cells[ptr->CurrentCell].Spreading;

                            else if (ptr->IsDiseased())
                                ++data.Cells[ptr->CurrentCell].Diseased;



                            if (ptr->GetGender() == EGender.Male)
                            {
                                switch (ptr->GetAge())
                                {
                                    case EAge.Baby: ++data.Cells[ptr->CurrentCell].MaleBabies; break;
                                    case EAge.Child: ++data.Cells[ptr->CurrentCell].MaleChildren; break;
                                    case EAge.Adult: ++data.Cells[ptr->CurrentCell].MaleAdults; break;
                                    case EAge.Senior: ++data.Cells[ptr->CurrentCell].MaleSeniors; break;
                                }
                            }
                            else
                            {
                                switch (ptr->GetAge())
                                {
                                    case EAge.Baby: ++data.Cells[ptr->CurrentCell].FemaleBabies; break;
                                    case EAge.Child: ++data.Cells[ptr->CurrentCell].FemaleChildren; break;
                                    case EAge.Adult: ++data.Cells[ptr->CurrentCell].FemaleAdults; break;
                                    case EAge.Senior: ++data.Cells[ptr->CurrentCell].FemaleSeniors; break;
                                }
                            }
                        }
                        else
                            continue;
                    }
                    //Staying Home doesn't vary no matter what profession the human is having.
                    else if (_ptr->GetMindset() == PopulationData.EMindset.HomeStaying)
                    {
                        if (data.CurrentHour > 6 && data.CurrentHour < 19)
                        {
                            if (ptr->CurrentCell != ptr->HomeCell)
                            {
                                if(random.Next(3) == 0)
                                    MoveHumanHome(data);
                            }
                            else
                            {
                                if (random.Next(5) == 0)
                                    MoveHuman(data, FindCellInReach(data,ptr->CurrentCell, 2, 75));
                            }
                        }
                        else if (data.CurrentHour == 19)
                        {
                            if (ptr->CurrentCell != ptr->HomeCell)
                                MoveHumanHome(data);
                        }
                        else
                        {
                            continue;
                        }
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
                            case EProfession.Student: MoveStudent(data); break;
                            case EProfession.Housewife: MoveHousewife(data); break;
                            case EProfession.Plumber: MovePlumber(data); break;
                            case EProfession.DeskJobber: MoveDeskJobber(data); break;
                            case EProfession.Commuter: MoveCommuter(data); break;
                            case EProfession.TravellingSalesman: MoveTravellingSalesman(data); break;
                            default: continue;
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
            if (ptr->IsInfected())
                --data.Cells[ptr->CurrentCell].Infected;

            else if (ptr->IsSpreading())
                --data.Cells[ptr->CurrentCell].Spreading;

            else if (ptr->IsDiseased())
                --data.Cells[ptr->CurrentCell].Diseased;
            


            if (ptr->GetGender() == EGender.Male)
            {
                switch (ptr->GetAge())
                {
                    case EAge.Baby: --data.Cells[ptr->CurrentCell].MaleBabies;break;
                    case EAge.Child: --data.Cells[ptr->CurrentCell].MaleChildren;break;
                    case EAge.Adult: --data.Cells[ptr->CurrentCell].MaleAdults;break;
                    case EAge.Senior: --data.Cells[ptr->CurrentCell].MaleSeniors;break;
                }
            }
            else
            {
                switch (ptr->GetAge())
                {
                    case EAge.Baby: --data.Cells[ptr->CurrentCell].FemaleBabies;break;
                    case EAge.Child: --data.Cells[ptr->CurrentCell].FemaleChildren;break;
                    case EAge.Adult: --data.Cells[ptr->CurrentCell].FemaleAdults;break;
                    case EAge.Senior: --data.Cells[ptr->CurrentCell].FemaleSeniors;break;
                }
            }


            //TODO |h| Set Travelling Counter and check for short travels (travellingcounter == 0)
            //ptr->SetTravellingCounter();
            int maxcelldiffernce = Math.Max(Math.Abs(ptr->CurrentCell % 2814 - destinationcell % 2814),
                                      Math.Abs(ptr->CurrentCell / 2814 - destinationcell / 2814));

            //Add the selected Human in the Destinationcell
            _ptr->CurrentCell = destinationcell;

            if (maxcelldiffernce < 75)
            {
                return;
            }
            else
            {
                ptr->TravellingCounter = (byte)((maxcelldiffernce / 5)/70);
                ptr->SetTravelling(true);
            }
        }

        private void MoveHumanHome(SimulationData data)
        {
            MoveHuman(data, ptr->HomeCell);
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
                        MoveHuman(data, FindCellInReach(data, ptr->CurrentCell, 2, 125));
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
                            if (random.Next(3) == 3)
                                MoveHumanHome(data);
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
                            MoveHumanHome(data);
                        else
                            return;
                    }
                    else if (data.CurrentHour == 15)
                    {
                        if (_random.Next(1) == 1)
                        {
                            MoveHuman(data, FindCellInReach(data, ptr->CurrentCell, 2, 25));
                        }
                        else
                            return;
                    }
                    //Return pupil home if he isn't already
                    else if (data.CurrentHour == 18)
                    {
                        if (_ptr->HomeCell != _ptr->CurrentCell)
                            MoveHumanHome(data);
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

        private int FindCellInReach(SimulationData data, int origincell, int minrange, int maxrange)
        {
            //TODO negativ movement also!
           
            //Horizontal Movement
            int x = minrange + random.Next((maxrange- minrange));
            if (random.Next(1) == 0)
            {
                //Do not move over array boundaries 
                while ((origincell % 2814) + x >= 2814)
                {
                    --x;
                }
            }
            else
            {
                x = -x;

                while ((origincell % 2814) + x < 0)
                {
                    ++x;
                }
            }

            //Vertical Movement
            int y = minrange + random.Next((maxrange-minrange));

            if (random.Next(1) == 0)
            {


                while (origincell + (y * 2814) > (2814 * 3841))
                {
                    --y;
                }
            }
            else
            {
                y = -y;

                while (origincell + (y * 2814) < 0)
                {
                    ++y;
                }
            }

            return origincell + x + (y * 2814);
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
                        MoveHumanHome(data);
                    }
                    //in the morning/evening student is at home 
                    else
                    {
                        return;
                    }


                    break;
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
                            MoveHumanHome(data);
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
                        MoveHuman(data, FindCellInReach(data, ptr->CurrentCell, 0, 75));
                    }
                    //Go home
                    else if (data.CurrentHour == 18)
                    {
                        MoveHumanHome(data);
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

        private void MoveHousewife(SimulationData data)
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
                            MoveHumanHome(data);
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
                        //Travel Home on Friday
                        if (data.CurrentHour == 4)
                            MoveHumanHome(data);
                    }
                    //on every other day travel through germany
                    else
                    {
                        if (data.CurrentHour == 4)
                        {
                            MoveHuman(data, FindCellInReach(data, ptr->CurrentCell, 400, 800));
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

        private void MoveCommuter(SimulationData data)
        {
            switch (_ptr->GetMindset())
            {
                //Working Mindset -> Commuter goes to work in a city that is 0,5-2 hours away from home
                //Assert : Commuter is at Home at 0 o'clock;
                case PopulationData.EMindset.Working:
                    //travel to distant workplace
                    if (data.CurrentHour == 6)
                    {
                        MoveHuman(data, FindCellInReach(data, ptr->CurrentCell, 125, 400));
                    }
                    //return home
                    else if (data.CurrentHour == 17)
                    {
                        MoveHumanHome(data);
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