using System;
using System.Windows.Forms;
using PSC2013.ES.GUI.Miscellaneous;
using PSC2013.ES.Library.Diseases;
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
        public SettingsContainer InfoSettings
        {
            get { return simulationSettingsPanel.ContentInformation; }
        }

        public Disease InfoDisease
        {
            get { return simulationDiseasePanel.ContentInformation; }
        }

        public object InfoStartlocations // TODO | dj | rework!!
        {
            get { return simulationStartlocationPanel.ContentInformation; }
        }
        #endregion

        #region buttons
        private void InitEvents()
        {
            simulationSettingsPanel.TheButton.Click += OnPanelDone;
            simulationDiseasePanel.TheButton.Click += OnPanelDone;
            simulationStartlocationPanel.TheButton.Click += (s, e) => FinalClick.Raise(s, e); // TODO | dj | damnit why?
        }

        private void OnPanelDone(object sender, EventArgs e)
        {
            this.SuspendLayout();
            
            var senderControl = (sender as Button).Parent.Parent.Parent;
            if (senderControl == null) return;
            senderControl.Enabled = false;
            
            var nextControl = GetNextControl(senderControl, true);
            if (nextControl == null) return;
            nextControl.Enabled = true;
            nextControl.Focus();
            
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