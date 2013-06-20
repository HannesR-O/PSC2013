using System;
using System.Windows.Forms;
using PSC2013.ES.GUI.Miscellaneous;
using PSC2013.ES.Library.DiseaseData;
using PSC2013.ES.Library;
using PSC2013.ES.GUI.Simulation.Panels;

namespace PSC2013.ES.GUI.Simulation
{
    public partial class SimulationFirstContainer : UserControl, IContainer
    {
        public event EventHandler<EventArgs> FinalClick;

        public SimulationFirstContainer()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.WorkFlow.Padding = new Padding(PSC2013.ES.GUI.MainForm.PADDING);

            InitEvents();
        }

        public SimulationStartlocationPanel StartlocationPanel
        { 
            get { return simulationStartlocationPanel; }
        }

        #region info
        public SimulationSettingsContainer InfoSettings
        {
            get { return simulationSettingsPanel.ContentInformation; }
        }

        public Disease InfoDisease
        {
            get { return simulationDiseasePanel.ContentInformation; }
        }

        public InfectionInitState InfoStartlocations
        {
            get { return simulationStartlocationPanel.ContentInformation; }
        }
        #endregion

        #region buttons
        private void InitEvents()
        {
            simulationSettingsPanel.TheButton.Click += OnPanelDone;
            simulationDiseasePanel.TheButton.Click += OnPanelDone;
            simulationStartlocationPanel.TheButton.Click += OnPanelDone;
        }

        private void OnPanelDone(object sender, EventArgs e)
        {
            IRawSimulationPanel panel = (IRawSimulationPanel)(sender as Button).Parent.Parent.Parent;
            if (panel.ValidateData())
                PanelDone(panel as Control);
            if (panel == simulationStartlocationPanel)
                FinalClick.Raise(this, e);
        }

        private void PanelDone(Control control)
        {
            this.SuspendLayout();

            if (control == null) return;
            control.Enabled = false;

            Control nxtCtrl = GetNextControl(control, true);
            if (nxtCtrl == null) return;
            nxtCtrl.Enabled = true;
            nxtCtrl.Focus();

            this.ResumeLayout();
        }
        #endregion

        #region resize
        private void ResizeComponents()
        {
            foreach (Control item in WorkFlow.Controls)
            {
                item.Width = WorkFlow.Width / 3 - 3 * WorkFlow.Padding.Left;
                item.Height = WorkFlow.Height - 3 * WorkFlow.Padding.Top;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeComponents();
        }
        #endregion

        public EContainer ContainerType
        {
            get { return EContainer.SimulationFirstContainer; }
        }
    }
}