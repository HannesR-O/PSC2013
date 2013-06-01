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
                for (Human* ptr = humanptr; ptr < humanptr + data.Humans.Length; ++ptr)
                {
                    if (!ptr->IsDead())
                    {
                        // TODO | dj | take hour-tick-time relationship into account...
                        ptr->DoDiseaseTick((short)disease.SpreadingTime, _simulationIntervall);
                    }
                    // TODO | dj | TEST!!!!
                }
            }
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