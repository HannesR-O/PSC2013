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
            txBoxTextfile.Text = "../../landcirclecoords.txt";
            txBoxImage.Text = "../../departments_coloured_big.png";
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

            foreach (RegionPopulationInfo info in _pp.ParsePopulationFile(txBoxPopulationFile.Text))
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

            int count = 0;
            foreach (string key in result.Keys)
            {
                List<Point> list = result[key];
                lBoxDepartments.Items.Add(key + " | Count: " + list.Count
                    + " | First Point: " + list[0].ToString());
                count += list.Count;
            }
            lBoxDepartments.Items.Add("Total point: " + count);
        }

        private void btnParseMatch_Click(object sender, EventArgs e)
        {
            ParseAndMatch();
        }

        private void btnMatchWrite_Click(object sender, EventArgs e)
        {
            var res = ParseAndMatch();
            var writer = new IO.DataWriter(null);
            writer.StoreMatchedData(res.Item1);
            writer.StoreMapImage(txBoxImage.Text);
            Console.WriteLine("Stored!");
        }

        private Tuple<List<RegionPopulationInfo>, List<string>> ParseAndMatch()
        {
            if (_pp == null)
                _pp = new Parsers.PopulationParser();

            var result = _pp.ParseCompleteSimulationInputData(txBoxPopulationFile.Text, txBoxTextfile.Text, txBoxImage.Text);

            txBoxMatchResults.Text += "Following regions could get matched: (" + result.Item1.Count + ")" + Environment.NewLine;
            //lBoxMatches.Items.Add("Following regions could get matched:");
            foreach (var item in result.Item1)
            {
                txBoxMatchResults.Text += item.Name + Environment.NewLine;
                //lBoxMatches.Items.Add(item.Name);
            }
            //lBoxMatches.Items.Add("Follwing regions could not be matched: (check for typos)");
            txBoxMatchResults.Text += "Following regions could not be matched: (" + result.Item2.Count + ") (check for typos)" + Environment.NewLine;
            foreach (var item in result.Item2)
            {
                txBoxMatchResults.Text += item + Environment.NewLine;
                //lBoxMatches.Items.Add(item);
            }

            return result;
        }
    }
}
