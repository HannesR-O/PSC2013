using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC2013.ES.GUI.Components;

namespace PSC2013.ES.GUI.Simulation.Panels
{
    public partial class SimulationSettingsPanel : UserControl
    {
        public SimulationSettingsPanel()
        {
            InitializeComponent();
            InitComponents();
        }

        private void InitComponents()
        {
            this.Comp_SimulationDuration.SetText("Simulation duration:");
            this.Comp_SimulationDuration.SetToolTip("The hours, the simulation shall emulate.");
            this.Comp_SimulationDuration.ComponentTag = EComponentTag.SimulationDuration;

            this.Comp_SimulationIntervall.SetText("Simulation intervall:");
            this.Comp_SimulationIntervall.SetToolTip("The hours, one tick shall emulate.");
            this.Comp_SimulationIntervall.ComponentTag = EComponentTag.SimulationIntervall;

            this.Comp_SnapshotIntervall.SetText("Snapshot intervall:");
            this.Comp_SnapshotIntervall.SetToolTip("The intervall in hours a snapshot will be taken.");
            this.Comp_SnapshotIntervall.ComponentTag = EComponentTag.SnapshotIntervall;
        }
    }
}
