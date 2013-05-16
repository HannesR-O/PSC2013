using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC2013.ES.GUI.NewSimulation;
using PSC2013.ES.GUI.ReviewSimulation;

namespace PSC2013.ES.GUI
{
    public partial class StartWindow : Form
    {
        private const string DEFAULT_EXTENSIONS_DEP = "Department-Files (*.dep)|*.dep|All files (*.*)|*.*";
        private const string FILEDIALOG_TITLE_DEP = "Select Department-file (.dep).";
        private const string DEFAULT_EXTENSIONS_SIM = "Simulation-Files (*.sim)|*.sim|All files (*.*)|*.*";
        private const string FILEDIALOG_TITLE_SIM = "Select Simulation-file (.sim).";

        public StartWindow()
        {
            InitializeComponent();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = DEFAULT_EXTENSIONS_DEP;
            openFileDialog.Title = FILEDIALOG_TITLE_DEP;
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filepath = openFileDialog.FileName;
                var form = new NewSimulationForm(filepath);
                form.FormClosing += (_,__) => this.Show();
                form.Show();
                this.Hide();
            }
        }

        private void btn_review_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = DEFAULT_EXTENSIONS_SIM;
            openFileDialog.Title = FILEDIALOG_TITLE_SIM;
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filepath = openFileDialog.FileName;
                var form = new ReviewSimulationForm(filepath);
                form.FormClosing += (_, __) => this.Show();
                form.Show();
                this.Hide();
            }
        }
    }
}
