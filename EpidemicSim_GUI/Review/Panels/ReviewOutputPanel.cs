using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Review.Panels
{
    public partial class ReviewOutputPanel : UserControl, IReviewPanel<string>
    {
        public ReviewOutputPanel()
        {
            InitializeComponent();
        }

        public bool ValidateData()
        {
            // obviously always correct...
            return true;
        }

        public ListBox TheListBox
        {
            get { return ListBox_Output; }
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

        public string ContentInformation
        {
            get { throw new NotSupportedException(); }
        }

        public Button TheButton
        {
            get { return Btn_Next; }
        }
    }
}
