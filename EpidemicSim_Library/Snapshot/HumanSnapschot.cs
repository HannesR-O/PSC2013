using PSC2013.ES.Library.PopulationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Snapshot
{
    /// <summary>
    /// A snapshot of a Human, containing only important data. Can only be created from given values and is immutable.
    /// </summary>
    public struct HumanSnapschot
    {
        // Need to use public readonly fields, since auto-properties cannot get initialized in struct-constructors
        public readonly EGender Gender;
        public readonly int Age;
        public readonly int HomeCell ;
        public readonly int DeathCell;      //TODO: |f| add more relevant fields?

        public HumanSnapschot(EGender gender, int age, int home) : this(gender, age, home, -1)  {}
        public HumanSnapschot(EGender gender, int age, int homeCell, int deathCell)
        {
            Gender = gender;
            Age = age;
            HomeCell = homeCell;
            DeathCell = deathCell;
        }
    }
}