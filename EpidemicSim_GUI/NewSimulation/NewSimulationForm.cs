using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PSC2013.ES.Library.IO.Readers;
using PSC2013.ES.Library.Diseases;
using System.Threading.Tasks;
using PSC2013.ES.Library.AreaData;

namespace PSC2013.ES.GUI.NewSimulation
{
    public partial class NewSimulationForm : Form
    {
        private const string NUMFIELD_NOT_IN_RANGE_EXCEPTION = "The given value is invalid. It must be in range of {0} and {1}.";

        private Form _owner;

        private long _snapshotInterval;
        private long _simDuration;
        private int _realtimeTick;

        private Disease _disease;
        private string _depFilePath;
        private DepartmentMapReader _departmentReader;

        private NewSimulationForm()
        {
            InitializeComponent();
        }

        public NewSimulationForm(Form owner, string filepath) : this()
        {
            _owner = owner;

            _depFilePath = filepath;
            _disease = new Disease();
            _departmentReader = new DepartmentMapReader(_depFilePath);

            OpenDepMap();
        }

        private void OpenDepMap()
        {
            Image img = _departmentReader.ReadImage();
            MainPanel_pictureBox.Image = img;
        }

        // == EVENTS ====== \\

        protected override void OnClosing(CancelEventArgs e)
        {
            _owner.Show();
            base.OnClosing(e);
        }

        private void btn_mortality_Click(object sender, EventArgs e)
        {
            var dialog = new FactorContainerForm("Mortality");
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
                _disease.MortalityRate = dialog.FactorContainer;
        }

        private void btn_healing_Click(object sender, EventArgs e)
        {
            var dialog = new FactorContainerForm("Healing");
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
                _disease.HealingFactor = dialog.FactorContainer;
        }

        private void btn_resistance_Click(object sender, EventArgs e)
        {
            var dialog = new FactorContainerForm("Resistance");
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
                _disease.ResistanceFactor = dialog.FactorContainer;
        }

        private void numField_Int_ValueChanged(object sender, EventArgs e)
        {
            var numUpDown = sender as NumericUpDown;
            if (numUpDown != null)
            {
                decimal value = numUpDown.Value;
                if (value < 0 || value > int.MaxValue)
                    throw new ArgumentOutOfRangeException("Value",
                        string.Format(NUMFIELD_NOT_IN_RANGE_EXCEPTION, 0, int.MaxValue));
                int intValue = (int)value;
                if (numUpDown == numField_incubationperiod)
                    _disease.IncubationPeriod = intValue;
                else if (numUpDown == numField_idle)
                    _disease.IdleTime = intValue;
                else if (numUpDown == numField_spreading)
                    _disease.SpreadingTime = intValue;
                else if (numUpDown == numField_transferability)
                    _disease.Transferability = intValue;
                else if (numUpDown == numField_realtimetick)
                    _realtimeTick = intValue;
            }
        }

        private void numField_long_ValueChanged(object sender, EventArgs e)
        {
            var numUpDown = sender as NumericUpDown;
            if (numUpDown != null)
            {
                decimal value = numUpDown.Value;
                if (value < 0 || value > long.MaxValue)
                    throw new ArgumentOutOfRangeException("Value",
                        string.Format(NUMFIELD_NOT_IN_RANGE_EXCEPTION, 0, long.MaxValue));
                long longValue = (long)value;
                if (numUpDown == numField_simduration)
                    _simDuration = longValue;
                else if (numUpDown == numField_snapshotInterval)
                    _snapshotInterval = longValue;
            }
        }

        private void txBox_name_TextChanged(object sender, EventArgs e)
        {
            _disease.Name = txBox_name.Text;
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            this.MainSidePanel.Visible = false;
            var dlp = new DiseaseLocationPanel();
            dlp.Dock = DockStyle.Right;
            this.Controls.Add(dlp);
            _departmentReader.IterationPassed += (s, arg) =>
            {
                var evArg = arg as ContinuationEventArgs;
                if (evArg != null)
                    if (evArg.Finished)
                        dlp.ProgressBar.Invoke(new ProgressBarDelegate(FinishProgressBar), dlp.ProgressBar);
            };

            // TODO | dj | not nice... this should not be allowed to get those information?!
            Task.Factory.StartNew(() => { return _departmentReader.ReadFile(); })                       // reading file
                .ContinueWith((information) => dlp.ListBoxDepartments.Invoke(                           // continuing with
                    new ListBoxDelegate(FinishListBox), dlp.ListBoxDepartments, information.Result));   // adding result to list

            // TODO | dj | continue.
        }

        private delegate void ProgressBarDelegate(ProgressBar pb);
        private delegate void ListBoxDelegate(ListBox lb, DepartmentInfo[] info);

        private void FinishProgressBar(ProgressBar progressBar)
        {
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Value = 100;
        }

        private void FinishListBox(ListBox lb, DepartmentInfo[] info)
        {
            lb.Items.AddRange(info.Select(x => x.Name).ToArray());
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
