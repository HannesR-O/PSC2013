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
            this.Comp_EnableAgeing.SetValue(true);
            this.Comp_EnableInfection.SetValue(true);
            this.Comp_EnableDiseaseEffect.SetValue(true);
            this.Comp_EnableMindset.SetValue(true);
            this.Comp_EnableMovement.SetValue(true);
        }
    }
}
