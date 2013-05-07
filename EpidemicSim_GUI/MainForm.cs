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

namespace PSC2013.ES.GUI
{
    public partial class MainForm : Form
    {
        private const string DEFAULT_DEP_EXTENSIONS = "Department-Files (*.dep)|*.dep|All files (*.*)|*.*";
        private const string NUMFIELD_NOT_IN_RANGE_EXCEPTION = "The given value is invalid. It must be in range of {0} and {1}.";

        private Disease _disease;
        private long _snapshotInterval;
        private long _simDuration;
        private int _realtimeTick;

        public MainForm()
        {
            InitializeComponent();

            _disease = new Disease();
        }

        private void OpenDepMap()
        {
            openFileDialog.Filter = DEFAULT_DEP_EXTENSIONS;
            openFileDialog.Title = "Select .dep-file.";
            DialogResult dr = openFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string filepath = openFileDialog.FileName;
                DepartmentMapReader reader = new DepartmentMapReader(filepath);
                Image img = reader.ReadImage();
                MainPanel_pictureBox.Image = img;
                Console.WriteLine("done - " + img);
            }
        }

        private void StartSimulation()
        {
            // TODO | dj | now delegate to start simulation
        }

        // == EVENTS ====== \\

        private void OpenDepMap_Click(object sender, EventArgs e)
        {
            OpenDepMap();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void btn_start_sim_Click(object sender, EventArgs e)
        {
            StartSimulation();
        }
    }
}
