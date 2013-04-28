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
        public readonly EGender Gender;
        public readonly int Age, HomeCell, DeathCell;
        public readonly bool Cause; // 0 = Natural, 1 = Disease

        public HumanSnapshot(EGender gender, int age, int homeCell, int deathCell, bool cause)
        {
            Gender = gender;
            Age = age;
            HomeCell = homeCell;
            DeathCell = deathCell;
            Cause = cause;
        }

        public byte[] getBytes()
        {
            byte[] output = new byte[17];
            Array.Copy(BitConverter.GetBytes((int)Gender), 0, output, 0, 4);
            Array.Copy(BitConverter.GetBytes(Age), 0, output, 4, 4);
            Array.Copy(BitConverter.GetBytes(HomeCell), 0, output, 8, 4);
            Array.Copy(BitConverter.GetBytes(DeathCell), 0, output, 12, 4);
            Array.Copy(BitConverter.GetBytes(Cause), 0, output, 16, 1);
            return output;
        }
    }
}