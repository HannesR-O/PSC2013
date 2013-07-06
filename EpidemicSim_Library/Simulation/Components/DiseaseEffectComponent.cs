using PSC2013.ES.Library.PopulationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulation.Components
{
    public abstract class DiseaseEffectComponent : SimulationComponent
    {
        protected SimulationData _data;

        protected DiseaseEffectComponent() : base(ESimulationStage.AfterInfectedCalculation)
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

                        //Handle each Human like the component specifies through the HandleHuman method
                        for (int i = 0; i < _simulationIntervall; i++)
                        {
                            HandleHuman(ptr);
                        }
                    });
            }
        }

        protected abstract unsafe void HandleHuman(Human* human);

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
