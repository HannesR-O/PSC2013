using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC2013.ES.Library.Statistics;
using PSC2013.ES.Library.Statistics.Pictures;

namespace PSC2013.ES.GUI.ReviewSimulation
{
    public partial class ReviewSimulationForm : Form
    {
        private delegate void ProgressBarUpdate(ProgressBar pb);

        private string _simPath;
        private string _targetPath;
        private StatisticsManager _manager;

        private ReviewSimulationForm()
        {
            InitializeComponent();
            
            cmbBox_palette.Items.AddRange(Enum.GetNames(typeof(EColorPalette)));
            cmbBox_palette.SelectedIndex = 0;

            cmbBox_dataset.Items.AddRange(Enum.GetNames(typeof(EStatField)));
            cmbBox_dataset.SelectedIndex = 0;
        }

        public ReviewSimulationForm(string filepath) : this()
        {
            _simPath = filepath;

            _manager = new StatisticsManager();
        }

        private void StartStatistics()
        {
            btn_start.Visible = false;
            ProgressBar progressBar = new ProgressBar();
            progressBar.Location = btn_start.Location;
            progressBar.Size = btn_start.Size;
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Maximum = lstBox_entries.SelectedItems.Count;
            progressBar.Parent = btn_start.Parent;

            EColorPalette palette = (EColorPalette)Enum.Parse(typeof(EColorPalette),
                (string)cmbBox_palette.SelectedItem, true);
            EStatField field = (EStatField)Enum.Parse(typeof(EStatField),
                (string)cmbBox_dataset.SelectedItem, true);
            List<string> entries = new List<string>(lstBox_entries.SelectedItems.Count);
            foreach (string entry in lstBox_entries.SelectedItems)
                entries.Add(entry);
            string prefix = txtBox_prefix.Text;

            Task.Run(() => StartInExtraThread(progressBar, palette, field, entries, prefix));
        }

        private void StartInExtraThread(ProgressBar progressBar, EColorPalette palette,
            EStatField field, List<string> entries, string prefix)
        {
            foreach (string entry in entries)
            {
                _manager.LoadTickSnapshot(entry);
                _manager.CreateGraphics(field, palette, prefix);
                progressBar.Invoke(new ProgressBarUpdate(
                    (pb) => pb.Increment(1)),
                    progressBar);
#if DEBUG
                Console.WriteLine("Finished {0}", entry);
#endif
            }
            progressBar.Invoke(new ProgressBarUpdate((pb) =>
                {
                    pb.Visible = false;
                    Button btn = new Button();
                    btn.Text = "Next >";
                    btn.Location = pb.Location;
                    btn.Size = pb.Size;
                    btn.Parent = pb.Parent;
                    btn.Focus();
                    btn.Click += btn_next_Click;
                }), progressBar);
        }

        // == EVENTS ====== \\

        private void txtBox_targetDirectory_TextChanged(object sender, EventArgs e)
        {
            _targetPath = txtBox_targetDirectory.Text;
            if (Directory.Exists(_targetPath))
            {
                _manager.OpenSimFile(_simPath, _targetPath);
                lstBox_entries.Items.Clear();
                lstBox_entries.Items.AddRange(_manager.Entries.ToArray());
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            StartStatistics();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBox_targetDirectory_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowseDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                txtBox_targetDirectory.Text = folderBrowseDialog.SelectedPath;
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            // TODO | dj | now show images?!
            Console.WriteLine("do next step");
        }
    }
}
