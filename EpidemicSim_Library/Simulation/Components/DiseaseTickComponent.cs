using PSC2013.ES.Library.DiseaseData;
using PSC2013.ES.Library.PopulationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulation.Components
{
    public class DiseaseTickComponent : DiseaseEffectComponent
    {
        public DiseaseTickComponent() : base()
        {
        }

        protected unsafe override void HandleHuman(Human* human)
        {
            var spreading = human->IsSpreading();
            var infecting = human->IsInfected();
            var diseased = human->IsDiseased();

            human->DoDiseaseTick((short)_data.DiseaseToSimulate.SpreadingTime);

            if (human->IsSpreading() != spreading)
            {
                if (spreading)
                    lock (_data.Cells[human->CurrentCell]) _data.Cells[human->CurrentCell].Spreading--;
                else
                    lock (_data.Cells[human->CurrentCell]) _data.Cells[human->CurrentCell].Spreading++;
            }

            if (human->IsInfected() != infecting)
            {
                if (infecting)
                    lock (_data.Cells[human->CurrentCell]) _data.Cells[human->CurrentCell].Infecting--;
                else
                    lock (_data.Cells[human->CurrentCell]) _data.Cells[human->CurrentCell].Infecting++;
            }

            if (human->IsDiseased() != diseased)
            {
                if (diseased)
                    lock (_data.Cells[human->CurrentCell]) _data.Cells[human->CurrentCell].Diseased--;
                else
                    lock (_data.Cells[human->CurrentCell]) _data.Cells[human->CurrentCell].Diseased++;
            }
        }

        public override bool Equals(SimulationComponent other)
        {
            var otherComponent = other as DiseaseTickComponent;
            if (otherComponent == null)
                return false;

            return true;
        }
    }
}