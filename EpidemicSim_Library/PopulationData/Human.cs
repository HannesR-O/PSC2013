using System;

namespace PSC2013.ES.Library.PopulationData
{
    public struct Human
    {
        private const byte MASK_GENDER      = 0x80;            // 1000 0000
        private const byte MASK_AGE         = 0x7F;            // 0111 1111

        private const byte MASK_INFECTED    = 0x80;            // 1000 0000
        private const byte MASK_SPREADING   = 0x40;            // 0100 0000
        private const byte MASK_DISEASED    = 0x20;            // 0010 0000
        private const byte MASK_DEATH       = 0x10;            // 0001 0000
        private const byte MASK_TRAVELLING  = 0x08;            // 0000 1000

        private const byte MASK_PROFESSION  = 0xF0;            // 1111 0000
        private const byte MASK_MINDSET     = 0x0F;            // 0000 1111

        /// <summary>
        /// Human's HomeCell where he will return to after some time dependent on his MindSet
        /// </summary>
        public int HomeCell { get { return _homeCell; } }
        private readonly int _homeCell;
        /// <summary>
        /// Human's current position in the simulated area
        /// </summary>
        public int CurrentCell 
        { 
            get 
            { 
                return _currentCell; 
            } 
            set 
            { 
                _currentCell = value;
            }
        }
        public int DesiredCell;

        private int _currentCell;
        public byte TravellingCounter;

        private byte _data0;    // Age & Gender
        private byte _data1;    // Infected & Spreading & Diseased & Death
        private byte _data2;    // Profession & Mindset 

        private short _counterInfect;   // bad name for IncubationCounter
        private short _counterSpreading;

        /// <summary>
        /// Needs to be an extra constructor, because HomeCell is readonly
        /// </summary>
        /// <param name="homeCell"></param>
        private Human(int homeCell)
        {
            _homeCell = homeCell;
            _currentCell = homeCell;
            _data0 = 0;
            _data1 = 0;
            _data2 = 0;
            _counterInfect = 0;
            _counterSpreading = 0;
            TravellingCounter = 0;
            DesiredCell = 0;
        }

        /// <summary>
        /// Factory method from which Humans are created
        /// </summary>
        /// <param name="gender">Gender of the Human to create</param>
        /// <param name="age">Age in Years of the Human to create (1-110)</param>
        /// <param name="homeCell">HomeCell of the Human to create</param>
        /// <returns>The newly created Human struct</returns>
        public static Human Create(EGender gender, int age, int homeCell)
        {
            var human = new Human(homeCell);

            human.SetGender(gender);
            human.SetAge(age);
            human.SetDeath(false);
            if (human.GetAge() == EAge.Baby)
            {
                human.SetMindset(EMindset.Stationary);
            }
            else if (human.GetAge() == EAge.Child)
            {
                human.SetProfession(EProfession.Pupil);
                human.SetMindset(EMindset.Working);
            }
            else if (human.GetAge() == EAge.Adult)
            {
                int result = RANDOM.Next(100);
                if (result < 10)
                {
                    human.SetProfession(EProfession.Student); //10%
                    human.SetMindset(EMindset.Working);
                }
                else if (result < 35)
                {
                    human.SetProfession(EProfession.Plumber); //25%
                    human.SetMindset(EMindset.Working);
                }
                else if (result < 60)
                {
                    human.SetProfession(EProfession.DeskJobber); //25%
                    human.SetMindset(EMindset.Working);
                }
                else if (result < 80)
                {
                    human.SetProfession(EProfession.Commuter); //20%
                    human.SetMindset(EMindset.Working);
                }
                else if (result < 90)
                {
                    human.SetProfession(EProfession.TravellingSalesman);//10%
                    human.SetMindset(EMindset.Working);
                }
                else
                {
                    human.SetProfession(EProfession.Housewife); //10%
                    human.SetMindset(EMindset.Working);
                }
            }
            else if (human.GetAge() == EAge.Senior)
            {
                human.SetProfession(EProfession.Unemployed);
                human.SetMindset(EMindset.HomeStaying);
            }


            return human;
        }

        /// <summary>
        /// Returns whether the human is currently at Home or not
        /// </summary>
        /// <returns>True if home, false if not</returns>
        public bool IsAtHome()
        {
            return CurrentCell == HomeCell;
        }

        /// <summary>
        /// Returns the Human's Gender
        /// </summary>
        /// <returns>The Gender</returns>
        public EGender GetGender()
        {
            return (EGender)(_data0 & MASK_GENDER);
        }

        private void SetGender(EGender gender)
        {
            _data0 = (byte)((_data0 & ~MASK_GENDER) + (byte)gender);
        }

        /// <summary>
        /// Return the Human's Age as PopulationData.EAge
        /// </summary>
        /// <returns>The Age</returns>
        public EAge GetAge()
        {
            int value = GetAgeInYears();

            var age = EAge.Baby;

            if (value <= 6)
                age = EAge.Baby;
            else if (value <= 25)
                age = EAge.Child;
            else if (value <= 60)
                age = EAge.Adult;
            else
                age = EAge.Senior;

            return age;
        }

        /// <summary>
        /// Returns the Human's age in years
        /// </summary>
        /// <returns>Human's age as int</returns>
        public int GetAgeInYears()
        {
            return _data0 & MASK_AGE;
        }

        private void SetAge(int age)
        {
            if (age < 1 || age > 127)
                throw new ArgumentOutOfRangeException("age", "Age to set has to be in range of 1-127!");

            _data0 = (byte)((_data0 & ~MASK_AGE) + age);
        }

        /// <summary>
        /// Returns whether the human is infected or not
        /// </summary>
        /// <returns>true if infected, false if not</returns>
        public bool IsInfected()
        {
            return ((_data1 & MASK_INFECTED) == 128);
        }

        private void SetInfected(bool infected)
        {
            _data1 = (byte)((_data1 & ~MASK_INFECTED) + (infected ? 128 : 0));
        }

        /// <summary>
        /// Returns whether the human is spreading or not
        /// </summary>
        /// <returns>true if spreading, false if not</returns>
        public bool IsSpreading()
        {
            return ((_data1 & MASK_SPREADING) == 64);
        }

        private void SetSpreading(bool spreading)
        {
            _data1 = (byte)((_data1 & ~MASK_SPREADING) + (spreading ? 64 : 0));
        }

        /// <summary>
        /// Returns whether the human is diseased or not
        /// </summary>
        /// <returns>true if diseased, false if not</returns>
        public bool IsDiseased()
        {
            return ((_data1 & MASK_DISEASED) == 32);
        }

        private void SetDiseased(bool diseased)
        {
            _data1 = (byte)((_data1 & ~MASK_DISEASED) + (diseased ? 32 : 0));
        }

        /// <summary>
        /// Returns whether the human is dead or not
        /// </summary>
        /// <returns>True if the Human is dead, false if not</returns>
        public bool IsDead()
        {
            return ((_data1 & MASK_DEATH) == 0);
        }

        private void SetDeath(bool death)
        {
            _data1 = (byte)((_data1 & ~MASK_DEATH) + (!death ? 16 : 0));
        }

        /// <summary>
        /// Returns whether the human is currently travelling or not
        /// </summary>
        /// <returns>True if the human is travelling, false if not</returns>
        public bool IsTravelling()
        {
            return ((_data1 & MASK_TRAVELLING) == 8);
        }   //TODO: shouldnt that be return CurrentCell == HomeCell? So we dont need a setter

        public void SetTravelling(bool travelling)
        {
            _data1 = (byte)((_data1 & ~MASK_TRAVELLING) + (travelling ? 8 : 0));
        }   

        /// <summary>
        /// Returns the current Profession of the human
        /// </summary>
        /// <returns>the Profession</returns>
        public EProfession GetProfession()
        {
            return (EProfession)(_data2 >> 4);
        }

        public void SetProfession(EProfession profession)
        {
            _data2 = (byte)(_data2 & ~MASK_PROFESSION + ((byte)profession) << 4);
        }

        /// <summary>
        /// Returns the current MindSet of the human
        /// </summary>
        /// <returns>Human's Mindset</returns>
        public EMindset GetMindset()
        {
            return (EMindset)(_data2 & MASK_MINDSET);
        }

        /// <summary>
        /// Sets the current MindSet of the human to the desired value
        /// </summary>
        /// <param name="mindset">MindSet to set</param>
        public void SetMindset(EMindset mindset)
        {
            _data2 = (byte)((_data2 & ~MASK_MINDSET) +  (byte)mindset);
        }

        /// <summary>
        /// Infects the human with the appropiate counters from the Disease
        /// </summary>
        public void Infect(short infectionCounter, short idleCounter)  //TODO: do we need more parameters?
        {
            SetInfected(true);

            _counterInfect = infectionCounter;
            _counterSpreading = idleCounter;
        }

        /// <summary>
        /// Performes an age-tick on the human and increases his age by 1 year
        /// </summary>
        public void DoAgeTick(byte count)
        {
            SetAge(GetAgeInYears() + count);
        }

        /// <summary>
        /// Performes a disease-tick on the human and increases his counters if appropiate
        /// </summary>
        /// <param name="spreadingTime">Disease's spreading time. Needs to get passed, so Human doesn't need another field.</param>
        public void DoDiseaseTick(short spreadingTime)
        {
            //TODO: Are the checks correct? does counterInfect get updated when human is infected?
            // |f| I think they are, since David fixed the method some time ago..
            if (IsInfected())
            {
                if (_counterInfect > 0)
                    _counterInfect--;

                if (_counterSpreading > 0)
                    _counterSpreading--;
                else if (_counterSpreading == 0)
                {
                    if (!IsSpreading())
                    {
                        _counterSpreading = spreadingTime;
                        SetSpreading(true);
                    }
                    else
                    {
                        SetSpreading(false);
                        _counterSpreading = -1;
                    }
                }
                if (_counterInfect == 0)
                    SetDiseased(true);
            }
        }

        /// <summary>
        /// Kills the Human. Pretty simple stuff..
        /// </summary>
        public void KillHuman()
        {
            SetDeath(true);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Human))
                return false;

            var other = (Human)obj;
            return (this.HomeCell == other.HomeCell) && (this._data0 == other._data0) && (this._data1 == other._data1) &&
                (this._data2 == other._data2) && (this._counterInfect == other._counterInfect) && (this._counterSpreading == other._counterSpreading);
        }

        public override int GetHashCode()
        {
            return (_data0 + _data1);
        }

        public override string ToString()
        {
            //TODO: |f| Add later
            return base.ToString();
        }
    }
}