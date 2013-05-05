using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PSC2013.ES.Library.IO.Readers;

namespace PSC2013.ES.GUI
{
    public partial class MainForm : Form
    {
        private const string DEFAULT_DEP_EXTENSIONS = "Department-Files (*.dep)|*.dep|All files (*.*)|*.*";

        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenDepMap()
        {
            openFileDialog.Filter = DEFAULT_DEP_EXTENSIONS;
            openFileDialog.Title = "Select .dep-file.";
            DialogResult dr = openFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string filepath = openFileDialog.FileName;
                DepartmentMapReader reader = new DepartmentMapReader(filepath);
                Image img = reader.ReadImage();
                // TODO | dj | now do something...
                Console.WriteLine("done - " + img);
            }
        }

        // == EVENTS ====== \\

        private void openDepMap_Click(object sender, EventArgs e)
        {
            OpenDepMap();
        }
    }
}
