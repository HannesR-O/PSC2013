using System;
using System.Windows.Forms;
using PSC2013.ES.GUI.Miscellaneous;
using PSC2013.ES.GUI.Simulation;
using PSC2013.ES.GUI.Simulation.Services;

namespace PSC2013.ES.GUI
{
    public partial class MainForm : Form
    {
        public const int PADDING = 3;

        private IService _service;

        /// <summary>
        /// Represents the WorkingArea.
        /// </summary>
        public IContainer WorkingArea
        {
            get
            {
                return (IContainer)_workPanel.Controls[0];
            }
            set
            {
                _workPanel.Controls.Clear();
                _workPanel.Controls.Add((Control)value);
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        // EVENTS \\

        private void MenuStrip_Main_File_NewSim_Click(object sender, EventArgs e)
        {
            DialogResult dr = OpenDepFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string path = OpenDepFileDialog.FileName;

                _service = new SimulationService(path);
                _service.ChangeWorkingArea += OnServiceChangeWA;
                _service.StartService();
            }
        }

        void OnServiceChangeWA(object sender, ServiceEventArgs e)
        {
            IService service = sender as IService;
            if (service != null)
            {
                switch (e.RequestedContainer)
                {
                    case EContainer.NONE:
                        WorkingArea = null;
                        break;
                    case EContainer.SimulationFirstContainer:
                        WorkingArea = new SimulationFirstContainer();
                        break;
                    case EContainer.SimulationSecondContainer:
                        WorkingArea = new SimulationSecondContainer();
                        break;
                    case EContainer.ReviewFirstContainer:
                        // TODO | dj | resume work here...
                        break;
                    case EContainer.ReviewSecondContainer:
                        break;
                    default:
                        break;
                }
                service.ReactToAnswer(WorkingArea);
            }
        }
    }
}