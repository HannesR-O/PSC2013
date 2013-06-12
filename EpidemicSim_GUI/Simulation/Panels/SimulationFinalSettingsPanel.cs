using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC2013.ES.GUI.Miscellaneous;

namespace PSC2013.ES.GUI.Simulation.Panels
{
    public partial class SimulationFinalSettingsPanel : UserControl, ISimulationPanel<FinalSettingsContainer>
    {
        public SimulationFinalSettingsPanel()
        {
            InitializeComponent();
        }

        public bool ValidateData()
        {
            return !String.IsNullOrEmpty(Comp_Destination.GetValue());
        }

        public Button TheButton
        {
            get { return Btn_Start; }
        }

        public FinalSettingsContainer ContentInformation
        {
            get { return GatherInformation(); }
        }

        private FinalSettingsContainer GatherInformation()
        {
            return new FinalSettingsContainer
                {
                    Destination = Comp_Destination.GetValue(),
                    StartTime = Comp_Starttime.GetValue()
                };
        }
    }
}
