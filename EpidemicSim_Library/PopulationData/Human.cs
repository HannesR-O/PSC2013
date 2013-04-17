using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.PopulationData
{
    public struct Human
    {
        private const byte MASK_GENDER  = 0x80;             // 1000 0000
        private const byte MASK_AGE     = 0x7F;             // 0111 1111

        /// <summary>
        /// HomeCell of the Human
        /// </summary>
        public readonly int HomeCell;

        private byte _data0;
        private byte _data1;
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
        /// Performes an age-tick on the human. Increases its age in years and decides wether the Human dies from ageing.
        /// </summary>
        /// <returns>True if the ageing process was completed sucessfully (the Human is still alive)
        /// False if the Human died in the process (age > 110)</returns>
        public bool DoAgeTick()
        {
            int currentAge = _data0 & MASK_AGE;
            if (currentAge > 110)
                return KillHuman();
            SetAge(currentAge + 1);
            return true;
        }

        private bool KillHuman()
        {
            //TODO: |f| set death flag and return false;

            return false;
        }
    }
}
