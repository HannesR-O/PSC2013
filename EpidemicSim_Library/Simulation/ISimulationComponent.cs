using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulation
{
    public interface ISimulationComponent
    {
        void PerformSimulationStage(ref SimulationData data);

        ESimulationStage GetSimulationStage();
    }
}
