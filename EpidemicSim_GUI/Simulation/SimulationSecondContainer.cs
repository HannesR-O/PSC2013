using System;
using System.Windows.Forms;
using PSC2013.ES.GUI.Miscellaneous;
using PSC2013.ES.GUI.Simulation.Panels;
using PSC2013.ES.Library;

namespace PSC2013.ES.GUI.Simulation
{
    public partial class SimulationSecondContainer : UserControl, IContainer
    {
        public event EventHandler<EventArgs> StartClick;

        public SimulationSecondContainer()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.WorkFlow.Padding = new Padding(PSC2013.ES.GUI.MainForm.PADDING);

            InitEvents();
        }

        public string InfoDestination
        {
            get { return this.simulationFinalSettingsPanel.ContentInformation; }
        }

        public SimulationOutputPanel OuputPanel
        {
            get { return this.simulationOutputPanel; }
        }

        #region button
        public void InitEvents()
        {
            this.simulationFinalSettingsPanel.TheButton.Click += OnStartClick;
        }

        private void OnStartClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(InfoDestination))
            {
                this.simulationFinalSettingsPanel.Enabled = false;
                this.simulationOutputPanel.Enabled = true;
                StartClick.Raise(sender, e);        // let the outersider react :P
            }
            else
            {
                MessageBox.Show("Please insert a valid destinationpath.", "Illegal input");
            }
        }
        #endregion

        #region resize
        private void ResizeComponents()
        {
            int height = WorkFlow.Height - 3 * WorkFlow.Padding.Top;
            int width = WorkFlow.Width / 3 - 3 * WorkFlow.Padding.Left;

            simulationFinalSettingsPanel.Width = width;
            simulationFinalSettingsPanel.Height = height;

            simulationOutputPanel.Width = width * 2 + 3 * WorkFlow.Padding.Left;
            simulationOutputPanel.Height = height;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeComponents();
        }
        #endregion

        public EContainer ContainerType
        {
            get { return EContainer.SimulationSecondContainer; }
        }
    }
}