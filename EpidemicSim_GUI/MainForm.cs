using System;
using System.Windows.Forms;
using PSC2013.ES.GUI.Miscellaneous;
using PSC2013.ES.GUI.Review;
using PSC2013.ES.GUI.Review.Services;
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
            WorkingArea = new Review.ReviewFirstContainer();
        }

        // EVENTS \\

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (_service == null || _service.CanClose)
                base.OnClosing(e);
            else
            {
                MessageBox.Show("The window can not be closed yet. There is still something running.", "Nope. Not yet.");
                e.Cancel = true;
            }
        }

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

        private void MenuStrip_Main_File_OpenSim_Click(object sender, EventArgs e)
        {
            DialogResult dr = OpenSimFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string path = OpenSimFileDialog.FileName;

                _service = new ReviewService(path);
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
                        WorkingArea = new ReviewFirstContainer();
                        break;
                    case EContainer.ReviewSecondContainer:
                        // TODO | dj | resume work here...
                        break;
                    default:
                        break;
                }
                service.ReactToAnswer(WorkingArea);
            }
        }
    }
}