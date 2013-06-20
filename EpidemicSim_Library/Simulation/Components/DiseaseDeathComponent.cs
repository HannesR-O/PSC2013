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
            if(!human->IsDiseased())
                return;

            //TODO: |f| pretty basic stuff right here might wanna spice this up a little
            var rand = RANDOM.Next(100);
            int ageGroup = (int)human->GetAge() / 32;

            if (human->GetGender() == EGender.Female)
                ageGroup += 4;

            if (rand <= _data.DiseaseToSimulate.MortalityRate[ageGroup])
            {
                human->KillHuman();
                lock (_data.Cells[human->CurrentCell])
                {
                    if (human->IsSpreading())
                        --_data.Cells[human->CurrentCell].Spreading;
                    --_data.Cells[human->CurrentCell].Infecting;
                    --_data.Cells[human->CurrentCell].Diseased;

                    int agegroup = (int)human->GetAge() / 32 +
                        ((human->GetGender() == 0)? 4 : 0);
                    _data.Cells[human->CurrentCell].Data[agegroup]--;
                }

                lock (_data.Deaths)
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