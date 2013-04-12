using PSC2013.ES.InputDataParsers.Data;
using System;
using System.IO;
using System.Windows.Forms;

namespace PSC2013.ES.InputDataParsers.UI
{
    public partial class MainFrm : Form
    {
        private Parsers.PopulationParser _pp;

        public MainFrm()
        {
            InitializeComponent();
            txBoxPopulationFile.Text = "../../population_data.csv";
        }

        private void txBoxPopulationFile_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(txBoxPopulationFile.Text))
                btnParse.Enabled = true;
            else
                btnParse.Enabled = false;
        }
        
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (fileDlg == null)
                fileDlg = new OpenFileDialog();

            if (fileDlg.ShowDialog() == DialogResult.OK)
                txBoxPopulationFile.Text = fileDlg.FileName;
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            if (_pp == null)
                _pp = new Parsers.PopulationParser();

            foreach (CityPopulationInfo info in _pp.ParseFile(txBoxPopulationFile.Text))
            {
                lBoxCities.Items.Add(info);
            }
        }
    }
}
