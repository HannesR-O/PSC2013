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

        private string _defaultPrefix = "Map";
        private EColorPalette _defaultPalette = EColorPalette.Red;

        private Dictionary<string, Color> _currentLegend;

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

            TextBox_SaveTo.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Btn_ApplySettings.Enabled = false;

            OpenFile(file);
        }

        private void ToolStripOpen_Click(object sender, EventArgs e)
        {
            if (FileChooser.ShowDialog() == DialogResult.OK)
            {
                OpenFile(FileChooser.FileName);
            }
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
            Label_Transfer.Text = _manager.SimInfo.Disease.Transferability + " %";
        }

        private void RefreshTickInformation()
        {
            Label_DeathInformation.Text = HumanSnapshotStatistics.DeathInformation(_manager.LoadedSnapshot.Deaths);
        }

        // Create Standard Map

        private void Btn_Create_S_Click(object sender, EventArgs e)
        {
            if ((int)EnumFromSelection() > 0)
            {
                _currentLegend = _manager.CreateGraphics(
                    EnumFromSelection(),
                    (CheckBox_S_IndPalette.Checked ? (EColorPalette)ComboBox_S_IndPalette.SelectedItem : _defaultPalette),
                    (CheckBox_S_IndPredix.Checked ? TextBox_S_Prefix.Text : _defaultPrefix));
            }        
        }

        // Checkboxes

        private EStatField EnumFromSelection()
        {
            EStatField selection = 0;

            // Well, this is awkward...!?
            if (CheckBox_S_MaleBaby.Checked)
                selection = selection | EStatField.MaleBaby;
            if (CheckBox_S_MaleChild.Checked)
                selection = selection | EStatField.MaleChild;
            if (CheckBox_S_MaleAdult.Checked)
                selection = selection | EStatField.MaleAdult;
            if (CheckBox_S_MaleSenior.Checked)
                selection = selection | EStatField.MaleSenior;
            if (CheckBox_S_FemaleBaby.Checked)
                selection = selection | EStatField.FemaleBaby;
            if (CheckBox_S_FemaleChild.Checked)
                selection = selection | EStatField.FemaleChild;
            if (CheckBox_S_FemaleAdult.Checked)
                selection = selection | EStatField.FemaleAdult;
            if (CheckBox_S_FemaleSenior.Checked)
                selection = selection | EStatField.FemaleSenior;
            if (CheckBox_S_Infected.Checked)
                selection = selection | EStatField.Infected;
            if (CheckBox_S_Diseased.Checked)
                selection = selection | EStatField.Diseased;

            return selection;
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
            if (CheckBox_S_Male.Checked)
            {
                CheckBox_S_MaleBaby.Checked = true;
                CheckBox_S_MaleChild.Checked = true;
                CheckBox_S_MaleAdult.Checked = true;
                CheckBox_S_MaleSenior.Checked = true;
            }
            else
            {
                CheckBox_S_MaleBaby.Checked = false;
                CheckBox_S_MaleChild.Checked = false;
                CheckBox_S_MaleAdult.Checked = false;
                CheckBox_S_MaleSenior.Checked = false;
            }
        }

        private void CheckBox_S_Female_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_S_Female.Checked)
            {
                CheckBox_S_FemaleBaby.Checked = true;
                CheckBox_S_FemaleChild.Checked = true;
                CheckBox_S_FemaleAdult.Checked = true;
                CheckBox_S_FemaleSenior.Checked = true;
            }
            else
            {
                CheckBox_S_FemaleBaby.Checked = false;
                CheckBox_S_FemaleChild.Checked = false;
                CheckBox_S_FemaleAdult.Checked = false;
                CheckBox_S_FemaleSenior.Checked = false;
            }
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

        // Defaults tab

        private void Btn_SaveTo_Browse_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                TextBox_SaveTo.Text = FolderBrowserDialog.SelectedPath; 
            }
        }

        private void Btn_ApplySettings_Click(object sender, EventArgs e)
        {
            _manager.SetNewDestination(TextBox_SaveTo.Text);
            _defaultPrefix = TextBox_DefaultPrefix.Text;
            _defaultPalette = (EColorPalette)ComboBox_DefaultPalette.SelectedItem;

            Btn_ApplySettings.Enabled = false;
        }

        private void TextBox_DefaultPrefix_TextChanged(object sender, EventArgs e)
        {
            Btn_ApplySettings.Enabled = true;
        }

        private void ComboBox_DefaultPalette_SelectedValueChanged(object sender, EventArgs e)
        {
            Btn_ApplySettings.Enabled = true;
        }

        private void TextBox_SaveTo_TextChanged(object sender, EventArgs e)
        {
            Btn_ApplySettings.Enabled = true;
        }
    }
}
