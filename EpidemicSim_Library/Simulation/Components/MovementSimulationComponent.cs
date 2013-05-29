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
        private int _simulationIntervall;

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
                        --_ptr->TravellingCounter;

                        if (_ptr->TravellingCounter == 0)
                        {
                            _ptr->SetTravelling(false);

                            if (_ptr->IsInfected())
                                ++data.Cells[_ptr->CurrentCell].Infected;

                            else if (_ptr->IsSpreading())
                                ++data.Cells[_ptr->CurrentCell].Spreading;

                            else if (_ptr->IsDiseased())
                                ++data.Cells[_ptr->CurrentCell].Diseased;



                            if (_ptr->GetGender() == EGender.Male)
                            {
                                switch (_ptr->GetAge())
                                {
                                    case EAge.Baby: ++data.Cells[_ptr->CurrentCell].MaleBabies; break;
                                    case EAge.Child: ++data.Cells[_ptr->CurrentCell].MaleChildren; break;
                                    case EAge.Adult: ++data.Cells[_ptr->CurrentCell].MaleAdults; break;
                                    case EAge.Senior: ++data.Cells[_ptr->CurrentCell].MaleSeniors; break;
                                }
                            }
                            else
                            {
                                switch (_ptr->GetAge())
                                {
                                    case EAge.Baby: ++data.Cells[_ptr->CurrentCell].FemaleBabies; break;
                                    case EAge.Child: ++data.Cells[_ptr->CurrentCell].FemaleChildren; break;
                                    case EAge.Adult: ++data.Cells[_ptr->CurrentCell].FemaleAdults; break;
                                    case EAge.Senior: ++data.Cells[_ptr->CurrentCell].FemaleSeniors; break;
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
                            if (!_ptr->IsAtHome())
                            {
                                if(_random.Next(3) == 0)
                                    MoveHumanHome(data);
                            }
                            else
                            {
                                if (_random.Next(5) == 0)
                                    MoveHuman(data, FindCellInReach(data,_ptr->CurrentCell, 2, 75));
                            }
                        }
                        else if (data.CurrentHour == 19)
                        {
                            if (!_ptr->IsAtHome())
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
                    else if (_ptr->GetMindset() == EMindset.Vacationing)
                    {
                        if (data.CurrentHour == 8 && _ptr->IsAtHome())
                        {
                            MoveHuman(data, FindCellInReach(data, _ptr->CurrentCell, 400, 800));
                        }
                        else if (data.CurrentHour == 6)
                        {
                            if (_random.Next(14) == 13)
                            {
                                MoveHumanHome(data);
                            }
                        }
                        else
                            continue;
                    }
                    //Handle Movement for Mindsets which are dependent on the profession od the selected human
                    else
                    {
                        switch (_ptr->GetProfession())
                        {
                            case EProfession.Pupil: MovePupil(data); break;
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
                    case EAge.Baby: --data.Cells[_ptr->CurrentCell].MaleBabies;break;
                    case EAge.Child: --data.Cells[_ptr->CurrentCell].MaleChildren;break;
                    case EAge.Adult: --data.Cells[_ptr->CurrentCell].MaleAdults;break;
                    case EAge.Senior: --data.Cells[_ptr->CurrentCell].MaleSeniors;break;
                }
            }
            else
            {
                switch (_ptr->GetAge())
                {
                    case EAge.Baby: --data.Cells[_ptr->CurrentCell].FemaleBabies;break;
                    case EAge.Child: --data.Cells[_ptr->CurrentCell].FemaleChildren;break;
                    case EAge.Adult: --data.Cells[_ptr->CurrentCell].FemaleAdults;break;
                    case EAge.Senior: --data.Cells[_ptr->CurrentCell].FemaleSeniors;break;
                }
            }

            int maxcelldiffernce = Math.Max(Math.Abs(_ptr->CurrentCell % 2814 - destinationcell % 2814),
                                      Math.Abs(_ptr->CurrentCell / 2814 - destinationcell / 2814));

            //Add the selected Human in the Destinationcell
            _ptr->CurrentCell = destinationcell;

            if (maxcelldiffernce < 75)
            {
                return;
            }
            else
            {
                _ptr->TravellingCounter = (byte)((maxcelldiffernce / 5)/70);
                _ptr->SetTravelling(true);
            }
        }

        private void MoveHumanHome(SimulationData data)
        {
            MoveHuman(data, _ptr->HomeCell);
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
                        MoveHuman(data, FindCellInReach(data, _ptr->CurrentCell, 2, 125));
                    }
                    else if (data.CurrentHour < 11)
                    {
                        return; //Pupil should stay in shool
                    }
                    //pupil has chance that school ends
                    else if (data.CurrentHour < 14)
                    {
                        if (!_ptr->IsAtHome())
                        {
                            if (_random.Next(3) == 2)
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
                        if (!_ptr->IsAtHome())
                            MoveHumanHome(data);
                        else
                            return;
                    }
                    else if (data.CurrentHour == 15)
                    {
                        if (_random.Next(2) == 1)
                        {
                            MoveHuman(data, FindCellInReach(data, _ptr->CurrentCell, 2, 25));
                        }
                        else
                            return;
                    }
                    //Return pupil home if he isn't already
                    else if (data.CurrentHour == 18)
                    {
                        if (!_ptr->IsAtHome())
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
                    
                //Dayoff Behaviour
                //Wander around aimlessly
                case PopulationData.EMindset.DayOff:
                    if (data.CurrentHour < 7)
                    {
                        return;
                    }
                    else if (data.CurrentHour < 18)
                    {
                                MoveHuman(data, FindCellInReach(data, _ptr->CurrentCell, 0, 25));
                    }
                    else if (data.CurrentHour == 18 && !_ptr->IsAtHome())
                    {
                        MoveHumanHome(data);
                    }
                    else
                        return;
                        

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
                        if (_ptr->IsAtHome())
                        {
                            //chance to go to university
                            if (_random.Next(3) == 2)
                            {
                                MoveHuman(data, FindCellInReach(data, _ptr->CurrentCell, 3, 75));
                            }
                            else
                                return;
                        }
                        else
                        {
                            //chance to go home
                            if (_random.Next(9) == 8)
                            {
                                MoveHumanHome(data);
                            }
                            else
                                return;

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

                //DayOff Mindset :
                case EMindset.DayOff :

                    if (data.CurrentHour == 6 && !_ptr->IsAtHome())
                    {
                        MoveHumanHome(data);
                    }
                    else if (data.CurrentHour > 6 && data.CurrentHour < 19)
                    {
                        if (_ptr->IsAtHome() && _random.Next(6) == 5)
                        {
                            MoveHuman(data, FindCellInReach(data, _ptr->CurrentCell, 0, 74));
                        }
                    }
                    else if (data.CurrentHour == 19 && !_ptr->IsAtHome())
                    {
                        MoveHumanHome(data);
                    }
                    else if (data.CurrentHour == 22 && _random.Next(2) == 1)
                    {
                        //Party
                        MoveHuman(data, FindCellInReach(data, _ptr->CurrentCell, 25, 75));
                    }
                    else
                        return;


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
                        MoveHuman(data, FindCellInReach(data, _ptr->CurrentCell, 5, 74));
                    }
                    //return home at 18 o'clock
                    else if (data.CurrentHour == 18)
                    {
                        if (!_ptr->IsAtHome())
                            MoveHumanHome(data);
                        else
                            return;
                    }
                    else
                    {
                        return;
                    }
                    break;


                case PopulationData.EMindset.DayOff:
                    if (data.CurrentHour < 11)
                    {
                        //sleep
                        return;
                    }
                    else if (data.CurrentHour < 20 && _ptr->IsAtHome())
                    {
                        if (_random.Next(20) == 19)
                            MoveHuman(data, FindCellInReach(data, _ptr->CurrentCell, 10, 50));
                    }
                    else if (data.CurrentHour == 20 && !_ptr->IsAtHome())
                    {
                        MoveHumanHome(data);
                    }
                    else
                    {
                        return;
                    }
                    break;

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
                        MoveHuman(data, FindCellInReach(data, _ptr->CurrentCell, 0, 75));
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



                case PopulationData.EMindset.DayOff:

                    if (data.CurrentHour < 11)
                    {
                        //sleep
                        return;
                    }
                    else if (data.CurrentHour < 20 && _ptr->IsAtHome())
                    {
                        if (_random.Next(20) == 19)
                            MoveHuman(data, FindCellInReach(data, _ptr->CurrentCell, 10, 50));
                    }
                    else if (data.CurrentHour == 20 && !_ptr->IsAtHome())
                    {
                        MoveHumanHome(data);
                    }
                    else
                    {
                        return;
                    }
                    break;
            }
        }

        private void MoveHousewife(SimulationData data)
        {

            switch (_ptr->GetMindset())
            {
                //Working Mindset -> Housewife doesn't go to work is either at home in the city or by friends
                //Assert : Housewife is at Home at 0 o'clock;
                case PopulationData.EMindset.DayOff: 
                case PopulationData.EMindset.Working:
                    //Run around aimlessly^^
                    if (data.CurrentHour > 6 && data.CurrentHour < 20)
                    {
                        //chance to go shopping/visit friends/work
                        MoveHuman(data, FindCellInReach(data, _ptr->CurrentCell, 0, 5));
                    }
                    //return home at 20 o'clock
                    else if (data.CurrentHour == 20)
                    {
                        if (!_ptr->IsAtHome())
                            MoveHumanHome(data);
                        else
                            return;
                    }
                    else
                    {
                        return;
                    }

                    break;
                

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
                            MoveHuman(data, FindCellInReach(data, _ptr->CurrentCell, 400, 800));
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
                    else if (data.CurrentHour < 20 && _ptr->IsAtHome())
                    {
                        if (_random.Next(20) == 19)
                            MoveHuman(data, FindCellInReach(data, _ptr->CurrentCell, 10, 50));
                    }
                    else if (data.CurrentHour == 20 && !_ptr->IsAtHome())
                    {
                        MoveHumanHome(data);
                    }
                    else
                    {
                        return;
                    }
                    

                    break;
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
                        MoveHuman(data, FindCellInReach(data, _ptr->CurrentCell, 125, 400));
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



                case PopulationData.EMindset.DayOff:
                    if (data.CurrentHour < 11)
                    {
                        //sleep
                        return;
                    }
                    else if (data.CurrentHour < 20 && _ptr->IsAtHome())
                    {
                        if (_random.Next(20) == 19)
                            MoveHuman(data, FindCellInReach(data, _ptr->CurrentCell, 10, 50));
                    }
                    else if (data.CurrentHour == 20 && !_ptr->IsAtHome())
                    {
                        MoveHumanHome(data);
                    }
                    else
                    {
                        return;
                    }
                    break;
            }
        }

        private int FindCellInReach(SimulationData data, int origincell, int minrange, int maxrange)
        {
            //TODO negativ movement also!

            //Horizontal Movement
            int x = minrange + _random.Next((maxrange - minrange));
            if (_random.Next(2) == 0)
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
            int y = ((minrange + _random.Next((maxrange - minrange))) * data.ImageWidth);


            if (_random.Next(2) == 0)
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