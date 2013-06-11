using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library.Snapshot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulation.Components
{
    public class DiseaseDeathComponent : DiseaseEffectComponent
    {
        public DiseaseDeathComponent() : base()
        {
        }

        protected override unsafe void HandleHuman(Human* human)
        {
            if(!human->IsInfected())
                return;

            //TODO: |f| pretty basic stuff right here might wanna spice this up a little
            var rand = RANDOM.Next(100);
            int ageGroup = (int)human->GetAge() / 32;

            if (human->GetGender() == EGender.Female)
                ageGroup += 4;

            if (rand <= _data.DiseaseToSimulate.MortalityRate[ageGroup])
            {
                human->KillHuman();
                _data.AddDeadPeople(new List<HumanSnapshot>()
                {
                    HumanSnapshot.InitializeFromRuntime(
                    (byte)human->GetGender(), 
                    (byte)human->GetAgeInYears(), 
                    (byte)human->GetProfession(), 
                    human->HomeCell, 
                    human->CurrentCell, 
                    true)
                });
            }
        }

        public override bool Equals(SimulationComponent other)
        {
            var otherComponent = other as DiseaseDeathComponent;
            if (otherComponent == null)
                return false;

            return true;
        }
    }
}