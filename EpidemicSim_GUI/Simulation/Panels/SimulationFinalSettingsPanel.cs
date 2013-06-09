using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Simulation.Panels
{
    public partial class SimulationFinalSettingsPanel : UserControl, ISimulationPanel<string>
    {
        public SimulationFinalSettingsPanel()
        {
            InitializeComponent();
        }

        public void SetDialog(CommonDialog dialog)
        {
            Comp_Destination.Dialog = dialog;
        }

        public Button TheButton
        {
            get { return Btn_Start; }
        }

        public string ContentInformation
        {
            get { return Comp_Destination.GetValue(); }
        }
    }
}
