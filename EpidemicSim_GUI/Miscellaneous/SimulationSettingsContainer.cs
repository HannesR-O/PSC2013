using System;
using PSC2013.ES.GUI.Components;

namespace PSC2013.ES.GUI.Miscellaneous
{
    public class SimulationSettingsContainer
    {
        public long SimulationDuration { get; set; }

        public int SimulationIntervall { get; set; }

        public int SnapshotIntervall { get; set; }

        public EComponentTag[] Components { get; set; }
    }
}