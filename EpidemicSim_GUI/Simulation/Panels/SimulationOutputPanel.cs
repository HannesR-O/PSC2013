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

        public bool ValidateData()
        {
            throw new NotSupportedException("This method is not supported in this panel!");
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
            if (ProgressBar_Main.Value + 1 <= ProgressBar_Main.Maximum)
                SetProgressBarValue(ProgressBar_Main.Value + 1);
        }

        public int GetProgressBarMax()
        {
            return ProgressBar_Main.Maximum;
        }

        public int GetProgressBarValue()
        {
            return ProgressBar_Main.Value;
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
