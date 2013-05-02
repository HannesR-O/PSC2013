using System;
using System.Linq;
using PSC2013.ES.Library.PopulationData;

namespace PSC2013.ES.Library.Snapshot
{
    /// <summary>
    /// A snapshot of a Human, containing only important data. Can only be created from given values and is immutable.
    /// </summary>
    public class HumanSnapshot
    {
        // Need to use public readonly fields, since auto-properties cannot get initialized in struct-constructors
        public readonly int HomeCell, DeathCell;
        public readonly byte Gender, Age, Profession;
        public readonly bool Cause; // 0 = Natural, 1 = Disease

        /// <summary>
        /// ...
        /// </summary>
        /// <param name="gender">The gender</param>
        /// <param name="age">The age</param>
        /// <param name="profession">The profession</param>
        /// <param name="homeCell">The HomeCell</param>
        /// <param name="deathCell">The DeathCell</param>
        /// <param name="cause">The CauseOfDeath</param>
        public HumanSnapshot(EGender gender, byte age,
            EProfession profession, int homeCell, int deathCell, bool cause)
        {
            Gender = (byte)gender;
            Age = age;
            Profession = (byte)profession;
            HomeCell = homeCell;
            DeathCell = deathCell;
            Cause = cause;
        }

        public byte[] getBytes()
        {
            byte[] output = new byte[12];
            Array.Copy(BitConverter.GetBytes(Gender), 0, output, 0, 1);
            Array.Copy(BitConverter.GetBytes(Age), 0, output, 1, 1);
            Array.Copy(BitConverter.GetBytes(Profession), 0, output, 2, 1);
            Array.Copy(BitConverter.GetBytes(HomeCell), 0, output, 3, 4);
            Array.Copy(BitConverter.GetBytes(DeathCell), 0, output, 7, 4);
            Array.Copy(BitConverter.GetBytes(Cause), 0, output, 11, 1);
            return output;
        }
    }
}