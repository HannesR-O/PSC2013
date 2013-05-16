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
        private string _simPath;
        private StatisticsManager _manager;
        private Dictionary<string, Color[]> _colors;

        private ReviewSimulationForm()
        {
            InitializeComponent();
            _colors = new Dictionary<string, Color[]>();
            _colors.Add("Red", ColorPalette.RED);
            _colors.Add("Blue", ColorPalette.BLUE);

            foreach (string key in _colors.Keys)
                cmbBox_palette.Items.Add(key);
        }

        public ReviewSimulationForm(string filepath) : this()
        {
            _simPath = filepath;

            _manager = new StatisticsManager();
        }

        // == EVENTS ====== \\

        private void txtBox_targetDirectory_TextChanged(object sender, EventArgs e)
        {
            // TODO | dj | rework with dialog.
            string txt = txtBox_targetDirectory.Text;
            if (Directory.Exists(txt))
            {
                _manager.OpenSimFile(_simPath, txt);
                lstBox_entries.Items.Clear();
                lstBox_entries.Items.AddRange(_manager.Entrys.ToArray());
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            var palette = _colors[(string)cmbBox_palette.SelectedItem];
            foreach (string entry in lstBox_entries.SelectedItems)
            {
                _manager.LoadTickSnapshot(entry);
                _manager.CreateGraphics(
                    EStatField.MaleBaby, // TODO | dj | dynamic!
                    palette,
                    txtBox_prefix.Text);
            }
        }
    }
}
