using PSC2013.ES.Library.PopulationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulation.Components
{
    public class DiseaseHealingComponent : DiseaseEffectComponent
    {
        protected override unsafe void HandleHuman(Human* human)
        {
            if (!human->IsInfected())
                return;

            var rand = RANDOM.Next(100);
            int ageGroup = (int)human->GetAge() / 32;

            if (human->GetGender() == EGender.Female)
                ageGroup += 4;

            if (rand <= _data.DiseaseToSimulate.HealingFactor[ageGroup])
            {
                lock (_data.Cells[human->CurrentCell])
                {
                    if (human->IsSpreading())
                        --_data.Cells[human->CurrentCell].Spreading;
                    if(human->IsDiseased())
                        --_data.Cells[human->CurrentCell].Diseased;

                    --_data.Cells[human->CurrentCell].Infecting;
                }
                human->HealHuman();
            }
        }
        
        public override bool Equals(SimulationComponent other)
        {
            var otherComponent = other as DiseaseHealingComponent;
            if (otherComponent == null)
                return false;

            return true;
        }
    }
}