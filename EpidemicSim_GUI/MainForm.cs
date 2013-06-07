using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PSC2013.ES.GUI.Simulation;

namespace PSC2013.ES.GUI
{
    public partial class MainForm : Form
    {
        public const int PADDING = 3;
        
        /// <summary>
        /// Represents the WorkingArea.
        /// </summary>
        public Control WorkingArea
        {
            get
            {
                return _workPanel.Controls[0];
            }
            set
            {
                _workPanel.Controls.Clear();
                _workPanel.Controls.Add(value);
            }
        }

        public MainForm()
        {
            InitializeComponent();
            
            ShowFirstSimulationPage();
        }

        private void ShowFirstSimulationPage()
        {
            var firstContainer = new SimulationFirstContainer();

            WorkingArea = firstContainer;
        }

        // EVENTS \\

    }
}
