using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC2013.ES.Library.Statistics;

namespace PSC2013.ES.GUI.ReviewSimulation
{
    public partial class ReviewSimulationForm : Form
    {
        private string _simPath;
        private StatisticsManager _manager;

        private ReviewSimulationForm()
        {
            InitializeComponent();
        }

        public ReviewSimulationForm(string filepath) : this()
        {
            _simPath = filepath;

            _manager = new StatisticsManager();
        }

        // == EVENTS ====== \\

    }
}
