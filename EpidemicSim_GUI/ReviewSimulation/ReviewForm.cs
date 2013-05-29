using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC2013.ES.Library.Snapshot;
using PSC2013.ES.Library.Statistics;
using PSC2013.ES.Library.Statistics.Pictures;
using PSC2013.ES.Library.Statistics.CountStatistics;

namespace PSC2013.ES.GUI.ReviewSimulation
{
    public partial class ReviewForm : Form
    {
        private StatisticsManager _manager;

        /// <summary>
        /// Creates a new ReviewForm and opens the Given File
        /// </summary>
        /// <param name="file">The File to be opened</param>
        public ReviewForm(string file)
        {
            InitializeComponent();
            _manager = new StatisticsManager();

            foreach (EColorPalette color in Enum.GetValues(typeof(EColorPalette))) // Filing ComboBox Defaults with Colors;
                ComboBox_DefaultPalette.Items.Add(color);
            ComboBox_DefaultPalette.SelectedItem = EColorPalette.Red; // Red is default. Satisfied, mr. Wilkens?

            foreach (EColorPalette color in Enum.GetValues(typeof(EColorPalette))) // Filling ComboBox S_Ind with Colors
                ComboBox_S_IndPalette.Items.Add(color);
            ComboBox_S_IndPalette.SelectedItem = EColorPalette.Red;

            OpenFile(file);
        }

        private void Btn_SaveTo_Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog.ShowDialog();
            TextBox_SaveTo.Text = FolderBrowserDialog.SelectedPath;
        }

        private void TooStripOpen_Click(object sender, EventArgs e)
        {
            FileChooser.ShowDialog();

            string file = FileChooser.FileName;
            OpenFile(file);
        }

        private void Btn_LoadTick_Click(object sender, EventArgs e)
        {
            _manager.LoadTickSnapshot(ComboBox_Entries.Text);
            RefreshTickInformation();
        }

        private void OpenFile(string file)
        {
            _manager.OpenSimFile(file);

            RefreshSimInformation();
            RefreshTickInformation();

            ComboBox_Entries.Enabled = true;
            Btn_LoadTick.Enabled = true;
            Btn_Create_S.Enabled = true;
            TabControl_MapCreator.Enabled = true;
        }

        private void RefreshSimInformation()
        {
            foreach (string entry in _manager.Entries)
                ComboBox_Entries.Items.Add(entry);

            ComboBox_Entries.Text = _manager.Entries[0];

            Label_DiseaseName.Text = _manager.SimInfo.Disease.Name;
            Label_Incubation.Text = _manager.SimInfo.Disease.IncubationPeriod + " Hours";
            Label_Idle.Text = _manager.SimInfo.Disease.IdleTime + " Hours";
            Label_Spreading.Text = _manager.SimInfo.Disease.SpreadingTime + " Hours";
        }

        private void RefreshTickInformation()
        {
            Label_DeathInformation.Text = HumanSnapshotStatistics.DeathInformation(_manager.LoadedSnapshot.Deaths);
        }

        private void CheckBox_S_All_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_S_All.Checked)
            {
                CheckBox_S_Female.Checked = true;
                CheckBox_S_Male.Checked = true;
            }
            else
            {
                CheckBox_S_Female.Checked = false;
                CheckBox_S_Male.Checked = false;
            }
        }

        private void CheckBox_S_Male_CheckedChanged(object sender, EventArgs e)
        {
            //EnableMaleCheckBoxes(!CheckBox_S_Male.Checked);
        }

        private void CheckBox_S_Female_CheckedChanged(object sender, EventArgs e)
        {
            //EnableFemaleCheckBoxes(!CheckBox_S_Female.Checked);
        }

        private void CheckBox_S_IndPredix_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_S_IndPredix.Checked)
                TextBox_S_Prefix.Enabled = true;
            else
                TextBox_S_Prefix.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_S_IndPalette.Checked)
                ComboBox_S_IndPalette.Enabled = true;
            else
                ComboBox_S_IndPalette.Enabled = false;
        }
    }
}
