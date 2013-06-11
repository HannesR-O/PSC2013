using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulation.Components
{
    public class DiseaseHealingComponent : DiseaseEffectComponent
    {
        protected override unsafe void HandleHuman(PopulationData.Human* human)
        {
            //TODO: implement
            throw new NotImplementedException();
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