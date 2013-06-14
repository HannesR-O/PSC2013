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
        private SimulationData _data;

        public MovementComponent()
            : base(ESimulationStage.BeforeInfectedCalculation)
        {
            _simulationIntervall = 1;
        }

        public override void PerformSimulationStage(SimulationData data)
        {
            _data = data;
            fixed (Human* humanptr = _data.Humans)
            {
                Human* startPtr = humanptr;

                Parallel.For(0, _data.Humans.Length, Constants.DEFAULT_PARALLELOPTIONS,
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
                                MoveHuman(ptr, ptr->DesiredCell);
                            }
                            else
                            {
                                //CurrentPosition + DesiredPosition
                                int currentX = ptr->CurrentCell % _data.ImageWidth;
                                int currentY = ptr->CurrentCell / _data.ImageWidth;
                                int desiredX = ptr->DesiredCell % _data.ImageWidth;
                                int desiredY = ptr->DesiredCell / _data.ImageWidth;

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
                                        nextCell = ptr->CurrentCell + travelDistanceX + travelDistanceY * _data.ImageWidth;

                                    }
                                    else
                                    {
                                        nextCell = ptr->CurrentCell + travelDistanceX - travelDistanceY * _data.ImageWidth;
                                    }
                                }
                                else
                                {
                                    //y-currentposition < y desiredposition
                                    if (currentY < desiredY)
                                    {
                                        nextCell = ptr->CurrentCell - travelDistanceX + travelDistanceY * _data.ImageWidth;
                                    }
                                    else
                                    {
                                        nextCell = ptr->CurrentCell - travelDistanceX - travelDistanceY * _data.ImageWidth;
                                    }
                                }

                                //TODO |h| Make an algorith that tries another route?
                                if (_data.Cells[nextCell] == null)
                                    nextCell = ptr->CurrentCell;

                                MoveHuman(ptr, nextCell);

                            }
                        }
                        //Staying Home doesn't vary no matter what profession the human is having.
                        else if (ptr->GetMindset() == PopulationData.EMindset.HomeStaying)
                        {
                            if (_data.CurrentHour > 6 && _data.CurrentHour < 19)
                            {
                                if (!ptr->IsAtHome())
                                {
                                    if (RANDOM.Next(3) == 0)
                                        LetHumanTravelHome(ptr);
                                }
                                else
                                {
                                    if (RANDOM.Next(5) == 0)
                                        LetHumanTravel(ptr, FindCellInReach(ptr->CurrentCell, 2, 75));
                                }
                            }
                            else if (_data.CurrentHour == 19)
                            {
                                if (!ptr->IsAtHome())
                                    LetHumanTravelHome(ptr);
                            }
                            else
                                return;
                            //chance every day to go out 1-3 hours
                            //if ill -> go to hospital
                            //if healthy wander around aimlessly in departement (short range)
                        }
                        else if (ptr->GetMindset() == EMindset.Vacationing)
                        {
                            if (_data.CurrentHour == 8 && ptr->IsAtHome())
                            {
                                LetHumanTravel(ptr, FindCellInReach(ptr->CurrentCell, 400, 800));
                            }
                            else if (_data.CurrentHour == 6 && !ptr->IsAtHome())
                            {
                                if (RANDOM.Next(14) == 13)
                                {
                                    LetHumanTravelHome(ptr);
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
                                case EProfession.Pupil: MovePupil(ptr); break;
                                case EProfession.Student: MoveStudent(ptr); break;
                                case EProfession.Housewife: MoveHousewife(ptr); break;
                                case EProfession.Plumber: MovePlumber(ptr); break;
                                case EProfession.DeskJobber: MoveDeskJobber(ptr); break;
                                case EProfession.Commuter: MoveCommuter(ptr); break;
                                case EProfession.TravellingSalesman: MoveTravellingSalesman(ptr); break;
                                default: return;
                            }
                        }
                    });
            }
        }

        public void MoveHuman(Human* ptr, int destination)
        {
            lock (_data.Cells[destination])
                lock (_data.Cells[ptr->CurrentCell])
                {
                    PopulationCell currentcell = _data.Cells[ptr->CurrentCell];
                    PopulationCell destinationcell = _data.Cells[destination];

                    if (ptr->IsInfected())
                    {
                        --currentcell.Infecting;
                        ++destinationcell.Infecting;
                    }

                    if (ptr->IsSpreading())
                    {
                        --currentcell.Spreading;
                        ++destinationcell.Spreading;
                    }

                    if (ptr->IsDiseased())
                    {
                        --currentcell.Diseased;
                        ++destinationcell.Diseased;
                    }



                    if (ptr->GetGender() == EGender.Male)
                    {
                        switch (ptr->GetAge())
                        {
                            case EAge.Baby: --currentcell.MaleBabies;
                                ++destinationcell.MaleBabies; break;
                            case EAge.Child: --currentcell.MaleChildren;
                                ++destinationcell.MaleChildren; break;
                            case EAge.Adult: --currentcell.MaleAdults;
                                ++destinationcell.MaleAdults; break;
                            case EAge.Senior: --currentcell.MaleSeniors;
                                ++destinationcell.MaleSeniors; break;
                        }
                    }
                    else
                    {
                        switch (ptr->GetAge())
                        {
                            case EAge.Baby: --currentcell.FemaleBabies;
                                ++destinationcell.FemaleBabies; break;
                            case EAge.Child: --currentcell.FemaleChildren;
                                ++destinationcell.FemaleChildren; break;
                            case EAge.Adult: --currentcell.FemaleAdults;
                                ++destinationcell.FemaleAdults; break;
                            case EAge.Senior: --currentcell.FemaleSeniors;
                                ++destinationcell.FemaleSeniors; break;
                        }
                    }
                }

            ptr->CurrentCell = destination;
        }

        /// <summary>
        /// Moves a selected Human to another Area in the PopulationCellGrid.
        /// </summary>
        /// <param name="data">Reference to SimulationData</param>
        /// <param name="currentcell">The cell the human to move is currently in</param>
        /// <param name="human">The index of the selected human in the current cell</param>
        /// <param name="destinationcell">The index of the cell the human should be moved to</param>
        private void LetHumanTravel(Human* ptr, int destinationcell)
        {
            int maxcelldiffernce = Math.Max(Math.Abs(ptr->CurrentCell % _data.ImageWidth - destinationcell % _data.ImageWidth),
                                      Math.Abs(ptr->CurrentCell / _data.ImageWidth - destinationcell / _data.ImageWidth));


            if (maxcelldiffernce < 75)
            {
                //Add the selected Human in the Destinationcell
                MoveHuman(ptr, destinationcell);
            }
            else
            {
                ptr->TravellingCounter = (byte)((maxcelldiffernce / 5) / 70);
                ptr->DesiredCell = destinationcell;
                ptr->SetTravelling(true);
            }
        }

        private void LetHumanTravelHome(Human* ptr)
        {
            LetHumanTravel(ptr, ptr->HomeCell);
        }

        private void MovePupil(Human* ptr)
        {
            switch (ptr->GetMindset())
            {
                //Working Mindset -> Pupil going to school this day
                //Assert : Pupil is at Home at 0 o'clock
                case PopulationData.EMindset.Working:

                    //Pupil is at Home in the Morning
                    if (_data.CurrentHour < 7)
                    {
                        return;
                    }
                    //Pupil should be in school from 7-10
                    else if (_data.CurrentHour == 7)
                    {
                        LetHumanTravel(ptr, FindCellInReach(ptr->CurrentCell, 2, 125));
                    }
                    else if (_data.CurrentHour < 11)
                    {
                        return; //Pupil should stay in school
                    }
                    //pupil has chance that school ends
                    else if (_data.CurrentHour < 14)
                    {
                        if (!ptr->IsAtHome())
                        {
                            if (RANDOM.Next(3) == 2)
                                LetHumanTravelHome(ptr);
                            else
                                return;
                        }
                        else
                            return;
                    }
                    //School ends definately
                    else if (_data.CurrentHour == 14)
                    {
                        if (!ptr->IsAtHome())
                            LetHumanTravelHome(ptr);
                        else
                            return;
                    }
                    else if (_data.CurrentHour == 15)
                    {
                        if (RANDOM.Next(2) == 1)
                            LetHumanTravel(ptr, FindCellInReach(ptr->CurrentCell, 2, 25));
                        else
                            return;
                    }
                    //Return pupil home if he isn't already
                    else if (_data.CurrentHour == 18)
                    {
                        if (!ptr->IsAtHome())
                            LetHumanTravelHome(ptr);
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
                    if (_data.CurrentHour < 7)
                        return;
                    else if (_data.CurrentHour < 18)
                        LetHumanTravel(ptr, FindCellInReach(ptr->CurrentCell, 0, 25));
                    else if (_data.CurrentHour == 18 && !ptr->IsAtHome())
                        LetHumanTravelHome(ptr);
                    else
                        return;

                    break;
            }
        }

        private void MoveStudent(Human* ptr)
        {

            switch (ptr->GetMindset())
            {
                //Working Mindset -> Student going to University this day
                //Assert : Student is at Home at 0 o'clock; It isn't suturday or sunday; University traveltime <= 1h
                case PopulationData.EMindset.Working:
                    //Student can have lectures during day including breaks
                    if (_data.CurrentHour > 8 && _data.CurrentHour < 18)
                    {
                        if (ptr->IsAtHome())
                        {
                            //chance to go to university
                            if (RANDOM.Next(3) == 2)
                                LetHumanTravel(ptr, FindCellInReach(ptr->CurrentCell, 3, 75));
                            else
                                return;
                        }
                        else
                        {
                            //chance to go home
                            if (RANDOM.Next(9) == 8)
                                LetHumanTravelHome(ptr);
                            else
                                return;

                        }
                    }
                    //No lectures after 18 o'clock
                    else if (_data.CurrentHour == 18)
                    {
                        LetHumanTravelHome(ptr);
                    }
                    //in the morning/evening student is at home 
                    else
                        return;

                    break;

                //DayOff Mindset :
                case EMindset.DayOff:

                    if (_data.CurrentHour == 6 && !ptr->IsAtHome())
                    {
                        LetHumanTravelHome(ptr);
                    }
                    else if (_data.CurrentHour > 6 && _data.CurrentHour < 19)
                    {
                        if (ptr->IsAtHome() && RANDOM.Next(6) == 5)
                        {
                            LetHumanTravel(ptr, FindCellInReach(ptr->CurrentCell, 0, 74));
                        }
                    }
                    else if (_data.CurrentHour == 19 && !ptr->IsAtHome())
                    {
                        LetHumanTravelHome(ptr);
                    }
                    else if (_data.CurrentHour == 22 && RANDOM.Next(2) == 1)
                    {
                        //Party
                        LetHumanTravel(ptr, FindCellInReach(ptr->CurrentCell, 25, 75));
                    }
                    else
                        return;

                    break;
            }
        }

        private void MovePlumber(Human* ptr)
        {
            //Working Mindset -> Plumber going to different households each hour
            //Assert : Plumber is at Home at 0 o'clock; 
            switch (ptr->GetMindset())
            {
                case PopulationData.EMindset.Working:
                    if (_data.CurrentHour > 7 && _data.CurrentHour < 18)
                    {
                        LetHumanTravel(ptr, FindCellInReach(ptr->CurrentCell, 5, 74));
                    }
                    //return home at 18 o'clock
                    else if (_data.CurrentHour == 18)
                    {
                        if (!ptr->IsAtHome())
                            LetHumanTravelHome(ptr);
                        else
                            return;
                    }
                    else
                        return;

                    break;

                case PopulationData.EMindset.DayOff:
                    if (_data.CurrentHour < 11)
                    {
                        //sleep
                        return;
                    }
                    else if (_data.CurrentHour < 20 && ptr->IsAtHome())
                    {
                        if (RANDOM.Next(20) == 19)
                            LetHumanTravel(ptr, FindCellInReach(ptr->CurrentCell, 10, 50));
                    }
                    else if (_data.CurrentHour == 20 && !ptr->IsAtHome())
                        LetHumanTravelHome(ptr);
                    else
                        return;

                    break;
            }
        }

        private void MoveDeskJobber(Human* ptr)
        {
            switch (ptr->GetMindset())
            {
                //Working Mindset -> Deskjobber has 9 to 5 job
                //Assert : Deskjobber is at Home at 0 o'clock;
                case PopulationData.EMindset.Working:
                    //Go to work
                    if (_data.CurrentHour == 9)
                    {
                        LetHumanTravel(ptr, FindCellInReach(ptr->CurrentCell, 0, 75));
                    }
                    //Go home
                    else if (_data.CurrentHour == 18)
                    {
                        LetHumanTravelHome(ptr);
                    }
                    //In the morning and evening stay at home
                    else
                        return;

                    break;

                case PopulationData.EMindset.DayOff:

                    if (_data.CurrentHour < 11)
                    {
                        //sleep
                        return;
                    }
                    else if (_data.CurrentHour < 20 && ptr->IsAtHome())
                    {
                        if (RANDOM.Next(20) == 19)
                            LetHumanTravel(ptr, FindCellInReach(ptr->CurrentCell, 10, 50));
                    }
                    else if (_data.CurrentHour == 20 && !ptr->IsAtHome())
                    {
                        LetHumanTravelHome(ptr);
                    }
                    else
                        return;

                    break;
            }
        }

        private void MoveHousewife(Human* ptr)
        {
            switch (ptr->GetMindset())
            {
                //Working Mindset -> Housewife doesn't go to work is either at home in the city or by friends
                //Assert : Housewife is at Home at 0 o'clock;
                case PopulationData.EMindset.DayOff:
                case PopulationData.EMindset.Working:
                    //Run around aimlessly^^
                    if (_data.CurrentHour > 6 && _data.CurrentHour < 20)
                    {
                        //chance to go shopping/visit friends/work
                        LetHumanTravel(ptr, FindCellInReach(ptr->CurrentCell, 0, 5));
                    }
                    //return home at 20 o'clock
                    else if (_data.CurrentHour == 20)
                    {
                        if (!ptr->IsAtHome())
                            LetHumanTravelHome(ptr);
                        else
                            return;
                    }
                    else
                        return;

                    break;
            }
        }

        private void MoveTravellingSalesman(Human* ptr)
        {
            switch (ptr->GetMindset())
            {
                //Working Mindset -> Travelling Salesman travels through Germany, changes location each day,
                //                   returns home on friday
                case PopulationData.EMindset.Working:
                    //Returns home on friday
                    if (_data.CurrentDay == DayOfWeek.Friday)
                    {
                        //Travel Home on Friday
                        if (_data.CurrentHour == 4)
                            LetHumanTravelHome(ptr);
                    }
                    //on every other day travel through germany
                    else
                    {
                        if (_data.CurrentHour == 4)
                        {
                            LetHumanTravel(ptr, FindCellInReach(ptr->CurrentCell, 400, 800));
                        }
                        else
                            return;
                    }

                    break;
                case PopulationData.EMindset.DayOff:

                    if (_data.CurrentHour < 12)
                    {
                        //sleep
                        return;
                    }
                    else if (_data.CurrentHour < 20 && ptr->IsAtHome())
                    {
                        if (RANDOM.Next(20) == 19)
                            LetHumanTravel(ptr, FindCellInReach(ptr->CurrentCell, 10, 50));
                    }
                    else if (_data.CurrentHour == 20 && !ptr->IsAtHome())
                    {
                        LetHumanTravelHome(ptr);
                    }
                    else
                        return;

                    break;
            }
        }

        private void MoveCommuter(Human* ptr)
        {
            switch (ptr->GetMindset())
            {
                //Working Mindset -> Commuter goes to work in a city that is 0,5-2 hours away from home
                //Assert : Commuter is at Home at 0 o'clock;
                case PopulationData.EMindset.Working:
                    //travel to distant workplace
                    if (_data.CurrentHour == 6)
                    {
                        LetHumanTravel(ptr, FindCellInReach(ptr->CurrentCell, 125, 400));
                    }
                    //return home
                    else if (_data.CurrentHour == 17)
                    {
                        LetHumanTravelHome(ptr);
                    }
                    //Stay home in the morning and evening
                    else
                        return;

                    break;

                case PopulationData.EMindset.DayOff:
                    if (_data.CurrentHour < 11)
                    {
                        //sleep
                        return;
                    }
                    else if (_data.CurrentHour < 20 && ptr->IsAtHome())
                    {
                        if (RANDOM.Next(20) == 19)
                            LetHumanTravel(ptr, FindCellInReach(ptr->CurrentCell, 10, 50));
                    }
                    else if (_data.CurrentHour == 20 && !ptr->IsAtHome())
                    {
                        LetHumanTravelHome(ptr);
                    }
                    else
                        return;

                    break;
            }
        }

        private int FindCellInReach(int origincell, int minrange, int maxrange)
        {
            //TODO negativ movement also!

            //Horizontal Movement
            int x = minrange + RANDOM.Next((maxrange - minrange));
            if (RANDOM.Next(2) == 0)
            {
                //Do not move over array boundaries 
                while ((origincell % _data.ImageWidth) + x > _data.ImageWidth || _data.Cells[origincell + x] == null)
                {
                    --x;
                }
            }
            else
            {
                x = -x;

                while ((origincell % _data.ImageWidth) + x < 0 || _data.Cells[origincell + x] == null)
                {
                    ++x;
                }
            }

            //Vertical Movement
            int y = ((minrange + RANDOM.Next((maxrange - minrange))) * _data.ImageWidth);

            if (RANDOM.Next(2) == 0)
            {
                while (origincell + x + y >= (_data.ImageWidth * _data.ImageHeight)
                    || _data.Cells[origincell + x + y] == null)
                {
                    y = y - _data.ImageWidth;
                }
            }
            else
            {
                y = -y;

                while (origincell + x + y < 0
                       || _data.Cells[origincell + x + y] == null)
                {
                    y = y + _data.ImageWidth;
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