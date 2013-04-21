using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulation
{
    public class SimulationEventArgs : EventArgs
    {
        public bool SimulationRunning { get; set; }
        //TODO: |f| what fields do we need? do we need aditional EventArgs?
    }
}