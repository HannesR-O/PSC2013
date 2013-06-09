using PSC2013.ES.Library.Diseases;
using PSC2013.ES.Library.PopulationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulation.Components
{
    public class DiseaseEffectComponent : SimulationComponent
    {
        private SimulationData _data;

        public DiseaseEffectComponent()
            : base(ESimulationStage.AfterInfectedCalculation)
        {
        }

        public unsafe override void PerformSimulationStage(SimulationData data)
        {
            _data = data;

            fixed (Human* humanptr = data.Humans)
            {
                Human* startPtr = humanptr;
                Parallel.For(0, _data.Humans.Length, Constants.DEFAULT_PARALLELOPTIONS,
                    index =>
                    {
                        Human* ptr = startPtr + index;

                        if (ptr->IsDead())
                            return;

                        // Do the appropiate tick "_simulationIntervall-times" to secure correct counters
                        for (int i = 0; i < _simulationIntervall; i++)
                        {
                            HandleHuman(ptr);                            
                        }
                    });
            }
        }

        private unsafe void HandleHuman(Human* human)
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SimulationComponent);
        }

        public override bool Equals(SimulationComponent other)
        {
            var otherComponent = other as DiseaseEffectComponent;
            if (otherComponent == null)
                return false;

            return true;
        }
    }
}