using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.PopulationData
{
    public struct Human
    {
        private const byte MASK_GENDER  = 0x80;              // 1000 0000
        private const byte MASK_AGE     = 0x7F;              // 0111 1111

        private const byte MASK_INFECTED = 0x80;             // 1000 0000
        private const byte MASK_SPREADING = 0x40;            // 0100 0000
        private const byte MASK_DISEASED = 0x20;             // 0010 0000
        private const byte MASK_DEATH = 0x10;                // 0001 0000

        /// <summary>
        /// HomeCell of the Human
        /// </summary>
        public readonly int HomeCell;

        private byte _data0;  // Age & Gender
        private byte _data1;  // Infected & Spreading & Diseased & Death
        private byte _data2;

        private short _counter1;
        private short _counter2;

        ///// <summary>
        ///// Only for explicit purposes. Initializes everything to 0.
        ///// </summary>
        //private Human()
        //{
        //    HomeCell = 0;

        //    _data0 = 0;
        //    _data1 = 0;
        //    _data2 = 0;

        //    _counter1 = 0;
        //    _counter2 = 0;
        //}

        /// <summary>
        /// Needs to be an extra constructor, because HomeCell is readonly
        /// </summary>
        /// <param name="homeCell"></param>
        private Human(int homeCell)
        {
            HomeCell = homeCell;
            _data0 = 0;
            _data1 = 0;
            _data2 = 0;
            _counter1 = 1;
            _counter2 = 2;
        }

        /// <summary>
        /// Factory method from which Humans are created
        /// </summary>
        /// <param name="gender">Gender of the Human to create</param>
        /// <param name="age">Age in Years of the Human to create (1-110)</param>
        /// <param name="homeCell">HomeCell of the Human to create</param>
        /// <returns>The newly created Human struct</returns>
        public static Human CreateHuman(Gender gender, int age, int homeCell)
        {
            Human human = new Human(homeCell);

            human.SetGender(gender);
            human.SetAge(age);

            return human;
        }

        /// <summary>
        /// Returns the Human's Gender
        /// </summary>
        /// <returns>The Gender</returns>
        public Gender GetGender()
        {
            return (Gender)(_data0 & MASK_GENDER);
        }

        private void SetGender(Gender gender)
        {
            _data0 = (byte)(_data0 & ~MASK_GENDER + (byte)gender);
        }

        /// <summary>
        /// Return the Human's Age as PopulationData.Age
        /// </summary>
        /// <returns>The Age</returns>
        public Age GetAge()
        {
            int value = _data0 & MASK_AGE;

            Age age = Age.Baby;

            if (value < 25)
                age = Age.Child;
            else if (value < 60)
                age = Age.Adult;
            else
                age = Age.Senior;

            return age;
        }

        private void SetAge(int age)
        {
            if (age < 1 || age > 110)
                throw new ArgumentOutOfRangeException("Age has to be in 1-110", "age");

            _data0 = (byte)(_data0 & MASK_AGE + age);
        }

        /// <summary>
        /// Returns whether the human is infected or not
        /// </summary>
        /// <returns>true if infected, false if not</returns>
        public bool IsInfected()
        {
            return ((_data1 & MASK_INFECTED) == 0);
        }

        private void SetInfected(bool infected)
        {
            _data1 = (byte)((_data1 & ~MASK_INFECTED) + (infected ? 1 : 0) << 7);
        }

        /// <summary>
        /// Returns whether the human is spreading or not
        /// </summary>
        /// <returns>true if spreading, false if not</returns>
        public bool IsSpreading()
        {
            return ((_data1 & MASK_SPREADING) == 2);
        }

        private void SetSpreading(bool spreading)
        {
            _data1 = (byte)((_data1 & ~MASK_SPREADING) + (spreading ? 1 : 0) << 6);
        }

        /// <summary>
        /// Returns whether the human is diseased or not
        /// </summary>
        /// <returns>true if diseased, false if not</returns>
        public bool IsDiseased()
        {
            return ((_data1 & MASK_DISEASED) == 4);
        }

        private void SetDiseased(bool diseased)
        {
            _data1 = (byte)((_data1 & ~MASK_DISEASED) + (diseased ? 1 : 0) << 5);
        }

        /// <summary>
        /// Returns whether the human is dead or not
        /// </summary>
        /// <returns>true if dead, false if not</returns>
        public bool IsDead()
        {
            return ((_data1 & MASK_DEATH) == 8);
        }

        private void SetDeath(bool death)
        {
            _data1 = (byte)((_data1 & ~MASK_DEATH) + (death ? 1 : 0) << 4);
        }

        /// <summary>
        /// Performes an age-tick on the human. Increases its age in years and decides whether the Human dies from ageing.
        /// </summary>
        /// <returns>True if the ageing process was completed sucessfully (the Human is still alive)
        /// False if the Human died in the process (age > 110)</returns>
        public bool DoAgeTick()
        {
            int currentAge = _data0 & MASK_AGE;
            if (currentAge > 109)
                return KillHuman();
            SetAge(currentAge + 1);
            return true;
        }

        private bool KillHuman()
        {
            SetDeath(true);
            //TODO T |Anything else? Always return False?
            return false;
        }
    }
}
