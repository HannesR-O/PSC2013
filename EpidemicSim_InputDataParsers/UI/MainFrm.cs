using PSC2013.ES.InputDataParsers.Data;
using System;
using System.IO;
using System.Windows.Forms;
using PSC2013.ES.InputDataParsers.Parsers;
using System.Collections.Generic;
using System.Drawing;

namespace PSC2013.ES.InputDataParsers.UI
{
    public partial class MainFrm : Form
    {
        private Parsers.PopulationParser _pp;

        public MainFrm()
        {
            InitializeComponent();
            txBoxPopulationFile.Text = "../../population_data.csv";
            txBoxTextfile.Text = "../../testcoords.txt";
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

        private void btnBrowseText_Click(object sender, EventArgs e)
        {
            if (fileDlg == null)
                fileDlg = new OpenFileDialog();

            if (fileDlg.ShowDialog() == DialogResult.OK)
                txBoxTextfile.Text = fileDlg.FileName;
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            if (fileDlg == null)
                fileDlg = new OpenFileDialog();

            if (fileDlg.ShowDialog() == DialogResult.OK)
                txBoxImage.Text = fileDlg.FileName;
        }

        private void btnParseCoord_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txBoxTextfile.Text))
                throw new FileNotFoundException(txBoxTextfile.Text);
            if (!File.Exists(txBoxImage.Text))
                throw new FileNotFoundException(txBoxImage.Text);

            List<Tuple<string, Point>> source =
                LandCircleParser.ParseCircles(txBoxTextfile.Text);
            Dictionary<string, List<Point>> result =
                DepartmentParser.Parse(txBoxImage.Text, source);

            foreach (string key in result.Keys)
            {
                List<Point> list = result[key];
                lBoxDepartments.Items.Add(key + " | Count: " + list.Count
                    + " | First Point: " + list[0].ToString());
            }
        }
    }
}
