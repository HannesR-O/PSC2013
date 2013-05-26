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

namespace PSC2013.ES.GUI.ReviewSimulation
{
    public partial class ReviewForm : Form
    {
        private StatisticsManager _manager;

        public ReviewForm()
        {
            InitializeComponent();
            _manager = new StatisticsManager();
        }

        private void EnableMaleCheckBoxes(bool enable)
        {
            var boxes = new CheckBox[] {
                CheckBox_S_MaleAdult,
                CheckBox_S_MaleBaby,
                CheckBox_S_MaleChild,
                CheckBox_S_MaleSenior
                };
            foreach (var box in boxes)
                box.Enabled = enable;
        }

        private void EnableFemaleCheckBoxes(bool enable)
        {
            var boxes = new CheckBox[] {
                CheckBox_S_FemaleAdult,
                CheckBox_S_FemaleBaby,
                CheckBox_S_FemaleChild,
                CheckBox_S_FemaleSenior
                };
            foreach (var box in boxes)
                box.Enabled = enable;
        }

        private void EnableAllCheckBoxes(bool enable)
        {
            CheckBox_S_Male.Enabled = enable;
            EnableMaleCheckBoxes(enable);
            CheckBox_S_Female.Enabled = enable;
            EnableFemaleCheckBoxes(enable);
        }

        private void CheckBox_S_All_CheckedChanged(object sender, EventArgs e)
        {
            EnableAllCheckBoxes(!CheckBox_S_All.Checked);
        }

        private void CheckBox_S_Male_CheckedChanged(object sender, EventArgs e)
        {
            EnableMaleCheckBoxes(!CheckBox_S_Male.Checked);
        }

        private void CheckBox_S_Female_CheckedChanged(object sender, EventArgs e)
        {
            EnableFemaleCheckBoxes(!CheckBox_S_Female.Checked);
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

        private void Btn_SaveTo_Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog.ShowDialog();
            TextBox_SaveTo.Text = FolderBrowserDialog.SelectedPath;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileChooser.ShowDialog();

            _manager.OpenSimFile(FileChooser.FileName);

            Label_DiseaseName.Text = _manager.SimInfo.Disease.Name;

            foreach (string entry in _manager.Entries)
                ComboBox_Entries.Items.Add(entry);
            ComboBox_Entries.Text = _manager.Entries[0];

            Btn_LoadTick.Enabled = true;
            Btn_Create_S.Enabled = true;
        }

        private void Btn_LoadTick_Click(object sender, EventArgs e)
        {
            _manager.LoadTickSnapshot(ComboBox_Entries.Text);
        }        
    }
}
