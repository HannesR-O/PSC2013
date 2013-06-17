using System;
using System.Windows.Forms;
using PSC2013.ES.GUI.Miscellaneous;
using PSC2013.ES.GUI.Review.Panels;
using PSC2013.ES.Library;
using PSC2013.ES.Library.Statistics.Pictures;

namespace PSC2013.ES.GUI.Review
{
    public partial class ReviewFirstContainer : UserControl, IContainer
    {
        public event EventHandler<EventArgs> FinalClick;

        public ReviewFirstContainer()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.WorkFlow.Padding = new Padding(PSC2013.ES.GUI.MainForm.PADDING);

            InitEvents();
            // TODO | dj | continue...
        }

        public ReviewSnapshotSelectPanel SnapshotsSelectPanel
        {
            get { return reviewSnapshotSelectPanel; }
        }

        #region info

        public ReviewSettingsContainer InfoSettings
        {
            get { return reviewSettingsPanel.ContentInformation; }
        }

        public EStatField InfoInformation
        {
            get { return reviewInformationPanel.ContentInformation; }
        }

        public string[] InfoSnapshots
        {
            get { return reviewSnapshotSelectPanel.ContentInformation; }
        }

        #endregion info

        #region buttons
        private void InitEvents()
        {
            reviewSettingsPanel.TheButton.Click += OnPanelDone;
            reviewInformationPanel.TheButton.Click += OnPanelDone;
            reviewSnapshotSelectPanel.TheButton.Click += OnPanelDone;
        }

        private void OnPanelDone(object sender, EventArgs e)
        {
            IRawReviewPanel panel = (IRawReviewPanel)(sender as Button).Parent.Parent.Parent;
            if (panel == reviewSnapshotSelectPanel)
            {
                if (InfoSnapshots.Length > 0)
                {
                    PanelDone(panel as Control);
                    FinalClick.Raise(this, e);
                }
            }
            else
                PanelDone(panel as Control);
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

        #endregion resize

        public EContainer ContainerType
        {
            get { return EContainer.ReviewFirstContainer; }
        }
    }
}