using PSC2013.ES.Library.AreaData;
using PSC2013.ES.Library.PopulationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulator
{
    public class SimulationData
    {
        private static PopulationCell[] Population;
        private static LandCircle[] LandCircles;
        private static FederalState[] FederalStates;

        static SimulationData()
        {

            FederalStates = new FederalState[16];
            LandCircles = new LandCircle[401];
            Population = new PopulationCell[10808574];
        }

    }
}
