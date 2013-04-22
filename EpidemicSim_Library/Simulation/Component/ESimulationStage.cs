using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulation.Component
{
    /// <summary>
    /// Enum to determine when the ISimulationComponent should exeute. [Flags] to allow multiple stages
    /// </summary>
    [Flags]
    public enum ESimulationStage
    {
        BeforeInfectedCalculation   = 1,
        InfectedCalculation         = 2,
        AfterInfectedCalculation    = 4
    }
}