using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.IO
{
    public enum DocumentType
    {
        Other           = -1,
        ConfigFile      = 0,
        SimulationInput = 1,
        SimulationData  = 2
    }
}
