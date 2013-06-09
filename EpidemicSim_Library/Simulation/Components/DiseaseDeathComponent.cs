using PSC2013.ES.Library.PopulationData;
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
            throw new NotImplementedException();
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