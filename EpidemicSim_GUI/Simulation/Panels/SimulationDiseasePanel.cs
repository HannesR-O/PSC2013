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
    public partial class SimulationDiseasePanel : UserControl
    {
        public SimulationDiseasePanel()
        {
            InitializeComponent();
            this.Comp_Transferability.ToolTip += Environment.NewLine + "(e.g. a disease being transferred per air might" +
                Environment.NewLine + "get a higher value than one per contact)";
        }
    }
}
