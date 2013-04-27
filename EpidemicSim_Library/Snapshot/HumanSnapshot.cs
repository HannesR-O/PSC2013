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
        public readonly int Age;
        public readonly int HomeCell;
        public readonly int DeathCell;
        public readonly bool Cause; // 0 = Natural, 1 = Disease

        public HumanSnapshot(EGender gender, int age, int homeCell, int deathCell, bool cause)
        {
            Gender = gender;
            Age = age;
            HomeCell = homeCell;
            DeathCell = deathCell;
            Cause = cause;
        }
    }
}