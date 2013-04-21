using PSC2013.ES.Library.Snapshot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.PopulationData
{
    public struct Human
    {
        private const byte MASK_GENDER  = 0x80;               // 1000 0000
        private const byte MASK_AGE     = 0x7F;               // 0111 1111

        private const byte MASK_INFECTED = 0x80;              // 1000 0000
        private const byte MASK_SPREADING = 0x40;             // 0100 0000
        private const byte MASK_DISEASED = 0x20;              // 0010 0000
        private const byte MASK_DEATH = 0x10;                 // 0001 0000

        private const byte MASK_PROFESSION = 0xF0;            // 1111 0000
        private const byte MASK_MINDSET = 0x0F;               // 0000 1111

        /// <summary>
        /// HomeCell of the Human
        /// </summary>
        public readonly int HomeCell;

        private byte _data0;    // Age & Gender
        private byte _data1;    // Infected & Spreading & Diseased & Death
        private byte _data2;    // Profession & Mindset 

        private short _counterInfect;
        private short _counterSpreading;

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
            _counterInfect = 1;
            _counterSpreading = 2;
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
            Human human = new Human(homeCell);

            human.SetGender(gender);
            human.SetAge(age);

            return human;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Human))
                return false;

            Human other = (Human)obj;
            return (this.HomeCell == other.HomeCell) && (this._data0 == other._data0) && (this._data1 == other._data1) &&
                (this._data2 == other._data2) && (this._counterInfect == other._counterInfect) && (this._counterSpreading == other._counterSpreading);
        }

        public override int GetHashCode()
        {
            return (int)(_data0 + _data1);
        }

        public override string ToString()
        {
            //TODO: |f| Add later
            return base.ToString();
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
        /// Return the Human's Age as PopulationData.Age
        /// </summary>
        /// <returns>The Age</returns>
        public EAge GetAge()
        {
            int value = GetAgeInYears();

            EAge age = EAge.Baby;

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
            if (age < 1 || age > 110)
                throw new ArgumentOutOfRangeException("Age has to be in 1-110", "age");

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
        /// <returns>True if the Human is alive, false if not</returns>
        public bool IsAlive()
        {
            return ((_data1 & MASK_DEATH) == 16);
        }

        private void SetDeath(bool death)
        {
            _data1 = (byte)((_data1 & ~MASK_DEATH) + (death ? 16 : 0));
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
        /// Returns the current Mindset of the human
        /// </summary>
        /// <returns>the Mindset</returns>
        public EMindset GetMindset()
        {
            return (EMindset)(_data2 & MASK_MINDSET);
        }

        public void SetMindset(EMindset mindset)
        {
            _data2 = (byte)((_data2 & ~MASK_MINDSET) +  (byte)mindset);
        }

        /// <summary>
        /// Performes an age-tick on the human. Increases its age in years and decides whether the Human dies from ageing.
        /// </summary>
        /// <returns>True if the ageing process was completed sucessfully (the Human is still alive)
        /// False if the Human died in the process (age > 110)</returns>
        public bool DoAgeTick()
        {
            int currentAge = GetAgeInYears();
            if (currentAge > 109)
                return KillHuman();
            SetAge(currentAge + 1);
            return true;
        }

        public bool KillHuman()
        {
            SetDeath(true);
            //TODO T |Anything else? Always return False?
            return false;
        }

        /// <summary>
        /// Returns a Base64 string representing the human
        /// </summary>
        /// <returns>The Base64 representation</returns>
        public string ToBase64()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(HomeCell.ToBase64());
            sb.Append(',');
            sb.Append(Convert.ToBase64String(new byte[] {_data0, _data1, _data2 }));
            sb.Append(',');
            sb.Append(_counterInfect.ToBase64());
            sb.Append(',');
            sb.Append(_counterSpreading.ToBase64());

            return sb.ToString();
        }

        /// <summary>
        /// Creates a new Human based on a given Base64 representation string
        /// </summary>
        /// <param name="base64">The string containing the Human info</param>
        /// <returns>The newly created Human</returns>
        public static Human FromBase64(string base64)
        {
            string[] parts = base64.Split(',');

            var human = new Human(ExtensionMethods.GetIntFromBase64(parts[0]));
            byte[] data = Convert.FromBase64String(parts[1]);
            human._data0 = data[0];
            human._data1 = data[1];
            human._data2 = data[2];
            human._counterInfect = ExtensionMethods.GetShortFromBase64(parts[2]);
            human._counterSpreading = ExtensionMethods.GetShortFromBase64(parts[3]);

            return human;
        }
    }
}
