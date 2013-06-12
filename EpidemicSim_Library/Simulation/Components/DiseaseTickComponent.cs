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
            PopulationCell currentCell = _data.Cells[human->CurrentCell];

            var spreading = human->IsSpreading();
            var infecting = human->IsInfected();
            var diseased = human->IsDiseased();

            human->DoDiseaseTick((short)_data.DiseaseToSimulate.SpreadingTime);

            if (human->IsSpreading() != spreading)
            {
                if (spreading)
                    lock (currentCell) currentCell.Spreading--;
                else
                    lock (currentCell) currentCell.Spreading++;
            }

            if (human->IsInfected() != infecting)
            {
                if (infecting)
                    lock (currentCell) currentCell.Infecting--;
                else
                    lock (currentCell) currentCell.Infecting++;
            }

            if (human->IsDiseased() != diseased)
            {
                if (diseased)
                    lock (currentCell) currentCell.Diseased--;
                else
                    lock (currentCell) currentCell.Diseased++;
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