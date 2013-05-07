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

namespace PSC2013.ES.GUI
{
    public partial class StartWindow : Form
    {
        private const string DEFAULT_EXTENSIONS_DEP = "Department-Files (*.dep)|*.dep|All files (*.*)|*.*";
        private const string FILEDIALOG_TITLE_DEP = "Select Department-file (.dep).";

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
                new NewSimulationForm(this, filepath).Show();
                this.Hide();
            }
        }
    }
}
