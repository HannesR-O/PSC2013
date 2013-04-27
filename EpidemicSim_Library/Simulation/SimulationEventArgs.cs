using System;

namespace PSC2013.ES.Library.Simulation
{
    public class SimulationEventArgs : EventArgs
    {
        public bool SimulationRunning { get; set; }
        public long SimulationRound { get; set; }
        //TODO: |f| what fields do we need? do we need aditional EventArgs?
    }
}