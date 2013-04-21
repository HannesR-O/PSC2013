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
    public struct HumanSnapshot
    {
        // Need to use public readonly fields, since auto-properties cannot get initialized in struct-constructors
        public readonly EGender Gender;
        public readonly int Age;
        public readonly int HomeCell;
        public readonly int DeathCell;      //TODO: |f| add more relevant fields?
        public readonly bool Infected;
        public readonly bool Spreading;

        public HumanSnapshot(EGender gender, int age, int homeCell, int deathCell, bool infected, bool spreading)
        {
            Gender = gender;
            Age = age;
            HomeCell = homeCell;
            DeathCell = deathCell;
            Infected = infected;
            Spreading = spreading;
        }
    }
}