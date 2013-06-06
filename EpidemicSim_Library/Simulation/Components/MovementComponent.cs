using PSC2013.ES.Library.PopulationData;
using System;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulation.Components
{
    /// <summary>
    /// SimulationComponent to move the entire human population 
    /// according to their Mindset, Profession and SimulationTime
    /// </summary>
    public unsafe class MovementComponent : SimulationComponent
    {
        public MovementComponent() : base(ESimulationStage.BeforeInfectedCalculation)
        {
            _simulationIntervall = 1;
        }

        public override void PerformSimulationStage(SimulationData data)
        {
            fixed (Human* humanptr = data.Humans)
            {
                Human* startPtr = humanptr;

                Parallel.For(0, data.Humans.Length, Constants.DEFAULT_PARALLELOPTIONS,
                    index =>
                    {
                        Human* ptr = startPtr + index;

                        //Stationary Mindset implies the human chosen won't move this day regardless of profession
                        //If the human is dead he won't move....
                        if (ptr->IsDead() ||
                            ptr->GetMindset() == PopulationData.EMindset.Stationary)
                        {
                            return;
                        }
                        //Travelling implies ignoring the Mindset until the human reached its Destination
                        else if (ptr->IsTravelling())
                        {
                            //reduce counter, if counter == 0 remove flag travelling else continue
                            --ptr->TravellingCounter;

                            if (ptr->TravellingCounter == 0)
                            {
                                ptr->SetTravelling(false);
                                ptr->CurrentCell = ptr->DesiredCell;
                            }
                            else
                            {
                                //CurrentPosition + DesiredPosition
                                int currentX = ptr->CurrentCell % data.ImageWidth;
                                int currentY = ptr->CurrentCell / data.ImageWidth;
                                int desiredX = ptr->DesiredCell % data.ImageWidth;
                                int desiredY = ptr->DesiredCell / data.ImageWidth;

                                //The Desiredposition might be far away, farther than the human can travel in one step
                                int travelDistanceX = Math.Abs(currentX - desiredX);
                                if (travelDistanceX > 350)
                                    travelDistanceX = 350;

                                int travelDistanceY = Math.Abs(currentY - desiredY);
                                if (travelDistanceY > 350)
                                    travelDistanceY = 350;

                                int nextCell = 0;

                                if (currentX < desiredX)
                                {
                                    if (currentY < desiredY)
                                    {
                                        nextCell = ptr->CurrentCell + travelDistanceX + travelDistanceY * data.ImageWidth;

                                    }
                                    else
                                    {
                                        nextCell = ptr->CurrentCell + travelDistanceX - travelDistanceY * data.ImageWidth;
                                    }
                                }
                                else
                                {
                                    //y-currentposition < y desiredposition
                                    if (currentY < desiredY)
                                    {
                                        nextCell = ptr->CurrentCell - travelDistanceX + travelDistanceY * data.ImageWidth;
                                    }
                                    else
                                    {
                                        nextCell = ptr->CurrentCell - travelDistanceX - travelDistanceY * data.ImageWidth;
                                    }
                                }

                                //TODO |h| Make an algorith that tries another route?
                                if (data.Cells[nextCell] == null)
                                    nextCell = ptr->CurrentCell;

                                MoveHuman(ptr, data, nextCell);

                            }
                        }
                        //Staying Home doesn't vary no matter what profession the human is having.
                        else if (ptr->GetMindset() == PopulationData.EMindset.HomeStaying)
                        {
                            if (data.CurrentHour > 6 && data.CurrentHour < 19)
                            {
                                if (!ptr->IsAtHome())
                                {
                                    if (RANDOM.Next(3) == 0)
                                        LetHumanTravelHome(ptr, data);
                                }
                                else
                                {
                                    if (RANDOM.Next(5) == 0)
                                        MoveHuman(ptr, data, FindCellInReach(data, ptr->CurrentCell, 2, 75));
                                }
                            }
                            else if (data.CurrentHour == 19)
                            {
                                if (!ptr->IsAtHome())
                                    LetHumanTravelHome(ptr, data);
                            }
                            else
                                return;
                            //chance every day to go out 1-3 hours
                            //if ill -> go to hospital
                            //if healthy wander around aimlessly in departement (short range)
                        }
                        else if (ptr->GetMindset() == EMindset.Vacationing)
                        {
                            if (data.CurrentHour == 8 && ptr->IsAtHome())
                            {
                                MoveHuman(ptr, data, FindCellInReach(data, ptr->CurrentCell, 400, 800));
                            }
                            else if (data.CurrentHour == 6)
                            {
                                if (RANDOM.Next(14) == 13)
                                {
                                    LetHumanTravelHome(ptr, data);
                                }
                            }
                            else
                                return;
                        }
                        //Handle Movement for Mindsets which are dependent on the profession od the selected human
                        else
                        {
                            switch (ptr->GetProfession())
                            {
                                case EProfession.Pupil: MovePupil(ptr, data); break;
                                case EProfession.Student: MoveStudent(ptr, data); break;
                                case EProfession.Housewife: MoveHousewife(ptr, data); break;
                                case EProfession.Plumber: MovePlumber(ptr, data); break;
                                case EProfession.DeskJobber: MoveDeskJobber(ptr, data); break;
                                case EProfession.Commuter: MoveCommuter(ptr, data); break;
                                case EProfession.TravellingSalesman: MoveTravellingSalesman(ptr, data); break;
                                default: return;
                            }
                        }
                    });
            }
        }

        public void MoveHuman(Human* ptr, SimulationData data, int destinationcell)
        {
            if (ptr->IsInfected())
            {
                --data.Cells[ptr->CurrentCell].Infecting;
                ++data.Cells[destinationcell].Infecting;
            }

            if (ptr->IsSpreading())
            {
                --data.Cells[ptr->CurrentCell].Spreading;
                ++data.Cells[destinationcell].Spreading;
            }

            if (ptr->IsDiseased())
            {
                --data.Cells[ptr->CurrentCell].Diseased;
                ++data.Cells[destinationcell].Diseased;
            }



            if (ptr->GetGender() == EGender.Male)
            {
                switch (ptr->GetAge())
                {
                    case EAge.Baby: --data.Cells[ptr->CurrentCell].MaleBabies;
                        ++data.Cells[destinationcell].MaleBabies; break;
                    case EAge.Child: --data.Cells[ptr->CurrentCell].MaleChildren;
                        ++data.Cells[destinationcell].MaleChildren; break;
                    case EAge.Adult: --data.Cells[ptr->CurrentCell].MaleAdults;
                        ++data.Cells[destinationcell].MaleAdults; break;
                    case EAge.Senior: --data.Cells[ptr->CurrentCell].MaleSeniors;
                        ++data.Cells[destinationcell].MaleSeniors; break;
                }
            }
            else
            {
                switch (ptr->GetAge())
                {
                    case EAge.Baby: --data.Cells[ptr->CurrentCell].FemaleBabies;
                        ++data.Cells[destinationcell].FemaleBabies; break;
                    case EAge.Child: --data.Cells[ptr->CurrentCell].FemaleChildren;
                        ++data.Cells[destinationcell].FemaleChildren; break;
                    case EAge.Adult: --data.Cells[ptr->CurrentCell].FemaleAdults;
                        ++data.Cells[destinationcell].FemaleAdults; break;
                    case EAge.Senior: --data.Cells[ptr->CurrentCell].FemaleSeniors;
                        ++data.Cells[destinationcell].FemaleSeniors; break;
                }
            }

            ptr->CurrentCell = destinationcell;

        }

        /// <summary>
        /// Moves a selected Human to another Area in the PopulationCellGrid.
        /// </summary>
        /// <param name="data">Reference to SimulationData</param>
        /// <param name="currentcell">The cell the human to move is currently in</param>
        /// <param name="human">The index of the selected human in the current cell</param>
        /// <param name="destinationcell">The index of the cell the human should be moved to</param>
        private void LetHumanTravel(Human* ptr, SimulationData data, int destinationcell)
        {
            int maxcelldiffernce = Math.Max(Math.Abs(ptr->CurrentCell % data.ImageWidth - destinationcell % data.ImageWidth),
                                      Math.Abs(ptr->CurrentCell / data.ImageWidth - destinationcell / data.ImageWidth));


            if (maxcelldiffernce < 75)
            {
                //Add the selected Human in the Destinationcell
                MoveHuman(ptr, data, destinationcell);
            }
            else
            {
                ptr->TravellingCounter = (byte)((maxcelldiffernce / 5) / 70);
                ptr->DesiredCell = destinationcell;
                ptr->SetTravelling(true);
            }
        }

        private void LetHumanTravelHome(Human* ptr, SimulationData data)
        {
            LetHumanTravel(ptr, data, ptr->HomeCell);
        }

        private void MovePupil(Human* ptr, SimulationData data)
        {
            switch (ptr->GetMindset())
            {
                //Working Mindset -> Pupil going to school this day
                //Assert : Pupil is at Home at 0 o'clock
                case PopulationData.EMindset.Working:

                    //Pupil is at Home in the Morning
                    if (data.CurrentHour < 7)
                    {
                        return;
                    }
                    //Pupil should be in school from 7-10
                    else if (data.CurrentHour == 7)
                    {
                        MoveHuman(ptr, data, FindCellInReach(data, ptr->CurrentCell, 2, 125));
                    }
                    else if (data.CurrentHour < 11)
                    {
                        return; //Pupil should stay in school
                    }
                    //pupil has chance that school ends
                    else if (data.CurrentHour < 14)
                    {
                        if (!ptr->IsAtHome())
                        {
                            if (RANDOM.Next(3) == 2)
                                LetHumanTravelHome(ptr, data);
                            else
                                return;
                        }
                        else
                            return;
                    }
                    //School ends definately
                    else if (data.CurrentHour == 14)
                    {
                        if (!ptr->IsAtHome())
                            LetHumanTravelHome(ptr, data);
                        else
                            return;
                    }
                    else if (data.CurrentHour == 15)
                    {
                        if (RANDOM.Next(2) == 1)
                            MoveHuman(ptr, data, FindCellInReach(data, ptr->CurrentCell, 2, 25));
                        else
                            return;
                    }
                    //Return pupil home if he isn't already
                    else if (data.CurrentHour == 18)
                    {
                        if (!ptr->IsAtHome())
                            LetHumanTravelHome(ptr, data);
                        else
                            return;
                    }
                    //in the evening pupil should be at home
                    else
                        return;

                    break;
                    
                //Dayoff Behaviour
                //Wander around aimlessly
                case PopulationData.EMindset.DayOff:
                    if (data.CurrentHour < 7)
                        return;
                    else if (data.CurrentHour < 18)
                        MoveHuman(ptr, data, FindCellInReach(data, ptr->CurrentCell, 0, 25));
                    else if (data.CurrentHour == 18 && !ptr->IsAtHome())
                        LetHumanTravelHome(ptr, data);
                    else
                        return;

                    break;
            }
        }  

        private void MoveStudent(Human* ptr, SimulationData data)
        {

            switch (ptr->GetMindset())
            {
                //Working Mindset -> Student going to University this day
                //Assert : Student is at Home at 0 o'clock; It isn't suturday or sunday; University traveltime <= 1h
                case PopulationData.EMindset.Working:
                    //Student can have lectures during day including breaks
                    if (data.CurrentHour > 8 && data.CurrentHour < 18)
                    {
                        if (ptr->IsAtHome())
                        {
                            //chance to go to university
                            if (RANDOM.Next(3) == 2)
                                MoveHuman(ptr, data, FindCellInReach(data, ptr->CurrentCell, 3, 75));
                            else
                                return;
                        }
                        else
                        {
                            //chance to go home
                            if (RANDOM.Next(9) == 8)
                                LetHumanTravelHome(ptr, data);
                            else
                                return;

                        }
                    }
                    //No lectures after 18 o'clock
                    else if (data.CurrentHour == 18)
                    {
                        LetHumanTravelHome(ptr, data);
                    }
                    //in the morning/evening student is at home 
                    else
                        return;

                    break;

                //DayOff Mindset :
                case EMindset.DayOff :

                    if (data.CurrentHour == 6 && !ptr->IsAtHome())
                    {
                        LetHumanTravelHome(ptr, data);
                    }
                    else if (data.CurrentHour > 6 && data.CurrentHour < 19)
                    {
                        if (ptr->IsAtHome() && RANDOM.Next(6) == 5)
                        {
                            MoveHuman(ptr, data, FindCellInReach(data, ptr->CurrentCell, 0, 74));
                        }
                    }
                    else if (data.CurrentHour == 19 && !ptr->IsAtHome())
                    {
                        LetHumanTravelHome(ptr, data);
                    }
                    else if (data.CurrentHour == 22 && RANDOM.Next(2) == 1)
                    {
                        //Party
                        MoveHuman(ptr, data, FindCellInReach(data, ptr->CurrentCell, 25, 75));
                    }
                    else
                        return;

                    break;
            }
        }

        private void MovePlumber(Human* ptr, SimulationData data)
        {
            //Working Mindset -> Plumber going to different households each hour
            //Assert : Plumber is at Home at 0 o'clock; 
            switch (ptr->GetMindset())
            {
                case PopulationData.EMindset.Working:
                    if (data.CurrentHour > 7 && data.CurrentHour < 18)
                    {
                        MoveHuman(ptr, data, FindCellInReach(data, ptr->CurrentCell, 5, 74));
                    }
                    //return home at 18 o'clock
                    else if (data.CurrentHour == 18)
                    {
                        if (!ptr->IsAtHome())
                            LetHumanTravelHome(ptr, data);
                        else
                            return;
                    }
                    else
                        return;

                    break;

                case PopulationData.EMindset.DayOff:
                    if (data.CurrentHour < 11)
                    {
                        //sleep
                        return;
                    }
                    else if (data.CurrentHour < 20 && ptr->IsAtHome())
                    {
                        if (RANDOM.Next(20) == 19)
                            MoveHuman(ptr, data, FindCellInReach(data, ptr->CurrentCell, 10, 50));
                    }
                    else if (data.CurrentHour == 20 && !ptr->IsAtHome())
                        LetHumanTravelHome(ptr, data);
                    else
                        return;

                    break;
            }
        }

        private void MoveDeskJobber(Human* ptr, SimulationData data)
        {
            switch (ptr->GetMindset())
            {
                //Working Mindset -> Deskjobber has 9 to 5 job
                //Assert : Deskjobber is at Home at 0 o'clock;
                case PopulationData.EMindset.Working:
                    //Go to work
                    if (data.CurrentHour == 9)
                    {
                        MoveHuman(ptr, data, FindCellInReach(data, ptr->CurrentCell, 0, 75));
                    }
                    //Go home
                    else if (data.CurrentHour == 18)
                    {
                        LetHumanTravelHome(ptr, data);
                    }
                    //In the morning and evening stay at home
                    else
                        return;

                    break;

                case PopulationData.EMindset.DayOff:

                    if (data.CurrentHour < 11)
                    {
                        //sleep
                        return;
                    }
                    else if (data.CurrentHour < 20 && ptr->IsAtHome())
                    {
                        if (RANDOM.Next(20) == 19)
                            MoveHuman(ptr, data, FindCellInReach(data, ptr->CurrentCell, 10, 50));
                    }
                    else if (data.CurrentHour == 20 && !ptr->IsAtHome())
                    {
                        LetHumanTravelHome(ptr, data);
                    }
                    else
                        return;

                    break;
            }
        }

        private void MoveHousewife(Human* ptr, SimulationData data)
        {
            switch (ptr->GetMindset())
            {
                //Working Mindset -> Housewife doesn't go to work is either at home in the city or by friends
                //Assert : Housewife is at Home at 0 o'clock;
                case PopulationData.EMindset.DayOff: 
                case PopulationData.EMindset.Working:
                    //Run around aimlessly^^
                    if (data.CurrentHour > 6 && data.CurrentHour < 20)
                    {
                        //chance to go shopping/visit friends/work
                        MoveHuman(ptr, data, FindCellInReach(data, ptr->CurrentCell, 0, 5));
                    }
                    //return home at 20 o'clock
                    else if (data.CurrentHour == 20)
                    {
                        if (!ptr->IsAtHome())
                            LetHumanTravelHome(ptr, data);
                        else
                            return;
                    }
                    else
                        return;

                    break;
            }
        }

        private void MoveTravellingSalesman(Human* ptr, SimulationData data)
        {
            switch (ptr->GetMindset())
            {
                //Working Mindset -> Travelling Salesman travels through Germany, changes location each day,
                //                   returns home on friday
                case PopulationData.EMindset.Working:
                    //Returns home on friday
                    if (data.CurrentDay == DayOfWeek.Friday)
                    {
                        //Travel Home on Friday
                        if (data.CurrentHour == 4)
                            LetHumanTravelHome(ptr, data);
                    }
                    //on every other day travel through germany
                    else
                    {
                        if (data.CurrentHour == 4)
                        {
                            MoveHuman(ptr, data, FindCellInReach(data, ptr->CurrentCell, 400, 800));
                        }
                        else
                            return;
                    }

                    break;
                case PopulationData.EMindset.DayOff:

                    if (data.CurrentHour < 12)
                    {
                        //sleep
                        return;
                    }
                    else if (data.CurrentHour < 20 && ptr->IsAtHome())
                    {
                        if (RANDOM.Next(20) == 19)
                            MoveHuman(ptr, data, FindCellInReach(data, ptr->CurrentCell, 10, 50));
                    }
                    else if (data.CurrentHour == 20 && !ptr->IsAtHome())
                    {
                        LetHumanTravelHome(ptr, data);
                    }
                    else
                        return;

                    break;
            }
        }

        private void MoveCommuter(Human* ptr, SimulationData data)
        {
            switch (ptr->GetMindset())
            {
                //Working Mindset -> Commuter goes to work in a city that is 0,5-2 hours away from home
                //Assert : Commuter is at Home at 0 o'clock;
                case PopulationData.EMindset.Working:
                    //travel to distant workplace
                    if (data.CurrentHour == 6)
                    {
                        MoveHuman(ptr, data, FindCellInReach(data, ptr->CurrentCell, 125, 400));
                    }
                    //return home
                    else if (data.CurrentHour == 17)
                    {
                        LetHumanTravelHome(ptr, data);
                    }
                    //Stay home in the morning and evening
                    else
                        return;

                    break;

                case PopulationData.EMindset.DayOff:
                    if (data.CurrentHour < 11)
                    {
                        //sleep
                        return;
                    }
                    else if (data.CurrentHour < 20 && ptr->IsAtHome())
                    {
                        if (RANDOM.Next(20) == 19)
                            MoveHuman(ptr, data, FindCellInReach(data, ptr->CurrentCell, 10, 50));
                    }
                    else if (data.CurrentHour == 20 && !ptr->IsAtHome())
                    {
                        LetHumanTravelHome(ptr, data);
                    }
                    else
                        return;

                    break;
            }
        }

        private int FindCellInReach(SimulationData data, int origincell, int minrange, int maxrange)
        {
            //TODO negativ movement also!

            //Horizontal Movement
            int x = minrange + RANDOM.Next((maxrange - minrange));
            if (RANDOM.Next(2) == 0)
            {
                //Do not move over array boundaries 
                while ((origincell % data.ImageWidth) + x > data.ImageWidth || data.Cells[origincell + x] == null)
                {
                    --x;
                }
            }
            else
            {
                x = -x;

                while ((origincell % data.ImageWidth) + x < 0 || data.Cells[origincell + x] == null)
                {
                    ++x;
                }
            }

            //Vertical Movement
            int y = ((minrange + RANDOM.Next((maxrange - minrange))) * data.ImageWidth);

            if (RANDOM.Next(2) == 0)
            {
                while (origincell + x + y  >= (data.ImageWidth * data.ImageHeight)
                    || data.Cells[origincell + x + y] == null)
                {
                    y = y - data.ImageWidth;
                }
            }
            else
            {
                y = -y;

                while (origincell + x + y  < 0
                       || data.Cells[origincell+ x + y] == null)
                {
                    y = y + data.ImageWidth;
                }
            }

            return origincell + x + y;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SimulationComponent);
        }

        public override bool Equals(SimulationComponent other)
        {
            var otherComponent = other as MindsetComponent;
            if (otherComponent == null)
                return false;

            throw new NotImplementedException();
        }
    }
}