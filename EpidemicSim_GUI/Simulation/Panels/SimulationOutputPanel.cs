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
    public partial class SimulationOutputPanel : UserControl, ISimulationPanel<string>
    {
        public SimulationOutputPanel()
        {
            InitializeComponent();
        }

        public ListBox GetOutputListBox()
        {
            return ListBox_Output;
        }

        #region ProgressBar
        public void SetProgressBarStyle(ProgressBarStyle style)
        {
            ProgressBar_Main.Style = style;
        }

        public void IncreaseProgressBarValue()
        {
            ProgressBar_Main.Value++;
        }

        public int GetProgressBarMax()
        {
            return ProgressBar_Main.Maximum;
        }

        public void SetProgressBarToMaxValue()
        {
            ProgressBar_Main.Value = ProgressBar_Main.Maximum;
        }

        public void SetProgressBarValue(int i)
        {
            ProgressBar_Main.Value = i;
        }

        public void SetProgressBarMax(int i)
        {
            ProgressBar_Main.Maximum = i;
        }
        #endregion

        public Button TheButton
        {
            get { return Btn_Abort; }
        }

        public string ContentInformation
        {
            get { throw new NotSupportedException(); }
        }
    }
}
