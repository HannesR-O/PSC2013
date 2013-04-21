using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulation
{
    public interface ISimulationComponent
    {
        /// <summary>
        /// The main operation which gets called by EpidemicSimulation during each tick.
        /// </summary>
        /// <param name="data">The data for the simulation to work with</param>
        void PerformSimulationStage(ref SimulationData data);

        ESimulationStage GetSimulationStage();
    }
}
