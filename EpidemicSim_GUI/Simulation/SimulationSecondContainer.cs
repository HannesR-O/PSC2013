using System;
using System.Windows.Forms;
using PSC2013.ES.GUI.Miscellaneous;

namespace PSC2013.ES.GUI.Simulation
{
    public partial class SimulationSecondContainer : UserControl, IContainer
    {
        public SimulationSecondContainer()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.WorkFlow.Padding = new Padding(PSC2013.ES.GUI.MainForm.PADDING);
        }

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