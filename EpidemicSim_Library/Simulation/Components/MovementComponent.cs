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
                            --(ptr->TravellingCounter);

                            if (ptr->TravellingCounter == 0)
                            {
                                ptr->SetTravelling(false);

                                PopulationCell currentCell = data.Cells[ptr->CurrentCell];

                                if (ptr->IsInfected())
                                    ++currentCell.Infecting;

                                if (ptr->IsSpreading())
                                    ++currentCell.Spreading;

                                if (ptr->IsDiseased())
                                    ++currentCell.Diseased;

                                if (ptr->GetGender() == EGender.Male)
                                {
                                    switch (ptr->GetAge())
                                    {
                                        case EAge.Baby: ++currentCell.MaleBabies; break;
                                        case EAge.Child: ++currentCell.MaleChildren; break;
                                        case EAge.Adult: ++currentCell.MaleAdults; break;
                                        case EAge.Senior: ++currentCell.MaleSeniors; break;
                                    }
                                }
                                else
                                {
                                    switch (ptr->GetAge())
                                    {
                                        case EAge.Baby: ++currentCell.FemaleBabies; break;
                                        case EAge.Child: ++currentCell.FemaleChildren; break;
                                        case EAge.Adult: ++currentCell.FemaleAdults; break;
                                        case EAge.Senior: ++currentCell.FemaleSeniors; break;
                                    }
                                }
                            }
                            else
                                return;
                        }
                        //Staying Home doesn't vary no matter what profession the human is having.
                        else if (ptr->GetMindset() == PopulationData.EMindset.HomeStaying)
                        {
                            if (data.CurrentHour > 6 && data.CurrentHour < 19)
                            {
                                if (!ptr->IsAtHome())
                                {
                                    if (RANDOM.Next(3) == 0)
                                        MoveHumanHome(ptr, data);
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
                                    MoveHumanHome(ptr, data);
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
                                    MoveHumanHome(ptr, data);
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

        /// <summary>
        /// Moves a selected Human to another Area in the PopulationCellGrid.
        /// </summary>
        /// <param name="data">Reference to SimulationData</param>
        /// <param name="currentcell">The cell the human to move is currently in</param>
        /// <param name="human">The index of the selected human in the current cell</param>
        /// <param name="destinationcell">The index of the cell the human should be moved to</param>
        private void MoveHuman(Human* ptr, SimulationData data, int destinationcell)
        {
            PopulationCell currentCell = data.Cells[ptr->CurrentCell];

            if (ptr->IsInfected())
                --currentCell.Infecting;

            if (ptr->IsSpreading())
                --currentCell.Spreading;

            if (ptr->IsDiseased())
                --currentCell.Diseased;
            
            if (ptr->GetGender() == EGender.Male)
            {
                switch (ptr->GetAge())
                {
                    case EAge.Baby: --currentCell.MaleBabies; break;
                    case EAge.Child: --currentCell.MaleChildren; break;
                    case EAge.Adult: --currentCell.MaleAdults; break;
                    case EAge.Senior: --currentCell.MaleSeniors; break;
                }
            }
            else
            {
                switch (ptr->GetAge())
                {
                    case EAge.Baby: --currentCell.FemaleBabies; break;
                    case EAge.Child: --currentCell.FemaleChildren; break;
                    case EAge.Adult: --currentCell.FemaleAdults; break;
                    case EAge.Senior: --currentCell.FemaleSeniors; break;
                }
            }

            int maxCellDiffernce = Math.Max(Math.Abs(ptr->CurrentCell % 2814 - destinationcell % 2814),
                                      Math.Abs(ptr->CurrentCell / 2814 - destinationcell / 2814));

            //Add the selected Human in the Destinationcell
            ptr->CurrentCell = destinationcell;
            currentCell = data.Cells[ptr->CurrentCell];

            if (maxCellDiffernce < 75)
            {

                if (ptr->IsInfected())
                    ++currentCell.Infecting;

                if (ptr->IsSpreading())
                    ++currentCell.Spreading;

                if (ptr->IsDiseased())
                    ++currentCell.Diseased;

                if (ptr->GetGender() == EGender.Male)
                {
                    switch (ptr->GetAge())
                    {
                        case EAge.Baby: ++currentCell.MaleBabies; break;
                        case EAge.Child: ++currentCell.MaleChildren; break;
                        case EAge.Adult: ++currentCell.MaleAdults; break;
                        case EAge.Senior: ++currentCell.MaleSeniors; break;
                    }
                }
                else
                {
                    switch (ptr->GetAge())
                    {
                        case EAge.Baby: ++currentCell.FemaleBabies; break;
                        case EAge.Child: ++currentCell.FemaleChildren; break;
                        case EAge.Adult: ++currentCell.FemaleAdults; break;
                        case EAge.Senior: ++currentCell.FemaleSeniors; break;
                    }
                }
                return;
            }
            else
            {
                ptr->TravellingCounter = (byte)((maxCellDiffernce / 5)/70);
                ptr->SetTravelling(true);
            }
        }

        private void MoveHumanHome(Human* ptr, SimulationData data)
        {
            MoveHuman(ptr, data, ptr->HomeCell);
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
                                MoveHumanHome(ptr, data);
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
                            MoveHumanHome(ptr, data);
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
                            MoveHumanHome(ptr, data);
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
                        MoveHumanHome(ptr, data);
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
                                MoveHumanHome(ptr, data);
                            else
                                return;

                        }
                    }
                    //No lectures after 18 o'clock
                    else if (data.CurrentHour == 18)
                    {
                        MoveHumanHome(ptr, data);
                    }
                    //in the morning/evening student is at home 
                    else
                        return;

                    break;

                //DayOff Mindset :
                case EMindset.DayOff :

                    if (data.CurrentHour == 6 && !ptr->IsAtHome())
                    {
                        MoveHumanHome(ptr, data);
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
                        MoveHumanHome(ptr, data);
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
                            MoveHumanHome(ptr, data);
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
                        MoveHumanHome(ptr, data);
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
                        MoveHumanHome(ptr, data);
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
                        MoveHumanHome(ptr, data);
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
                            MoveHumanHome(ptr, data);
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
                            MoveHumanHome(ptr, data);
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
                        MoveHumanHome(ptr, data);
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
                        MoveHumanHome(ptr, data);
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
                        MoveHumanHome(ptr, data);
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