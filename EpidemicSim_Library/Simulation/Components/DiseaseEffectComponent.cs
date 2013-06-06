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
        public DiseaseEffectComponent() : base(ESimulationStage.AfterInfectedCalculation)
        {
        }

        public unsafe override void PerformSimulationStage(SimulationData data)
        {
            Disease disease = data.DiseaseToSimulate;

            fixed (Human* humanptr = data.Humans)
            {
                Human* startPtr = humanptr;
                Parallel.For(0, data.Humans.Length, Constants.DEFAULT_PARALLELOPTIONS,
                    index =>
                    {
                        Human* ptr = startPtr + index;

                        PopulationCell currentCell = data.Cells[ptr->CurrentCell];

                        var spreading = ptr->IsSpreading();
                        var infecting = ptr->IsInfected();
                        var diseased = ptr->IsDiseased();

                        if (!ptr->IsDead())
                        {
                            // TODO | dj & f | take hour-tick-time relationship into account...
                            ptr->DoDiseaseTick((short)disease.SpreadingTime, _simulationIntervall);
                        }

                        if (ptr->IsSpreading() != spreading)
                        {
                            if (spreading)
                                lock (currentCell) currentCell.Spreading--;
                            else
                                lock (currentCell) currentCell.Spreading++;
                        }

                        if (ptr->IsInfected() != infecting)
                        {
                            if (infecting)
                                lock (currentCell) currentCell.Infecting--;
                            else
                                lock (currentCell) currentCell.Infecting++;
                        }

                        if (ptr->IsDiseased() != diseased)
                        {
                            if (diseased)
                                lock (currentCell) currentCell.Diseased--;
                            else
                                lock (currentCell) currentCell.Diseased++;
                        }
                    });
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

            throw new NotImplementedException();
        }
    }
}