using System;
using System.Windows.Forms;
using PSC2013.ES.GUI.Miscellaneous;
using PSC2013.ES.GUI.Review.Panels;

namespace PSC2013.ES.GUI.Review
{
    public partial class ReviewSecondContainer : UserControl, IContainer
    {
        public ReviewSecondContainer()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.WorkFlow.Padding = new Padding(PSC2013.ES.GUI.MainForm.PADDING);
            
            reviewViewPanel.Enabled = false;
            reviewOutputPanel.TheButton.Click += (_, __) => reviewViewPanel.Enabled = true;
        }

        public ReviewOutputPanel OutputPanel
        {
            get { return reviewOutputPanel; }
        }

        public ReviewViewPanel ViewPanel
        {
            get { return reviewViewPanel; }
        }

        #region resize
        private void ResizeComponents()
        {
            int height = WorkFlow.Height - 3 * WorkFlow.Padding.Top;
            int width = WorkFlow.Width / 3 - 3 * WorkFlow.Padding.Left;

            reviewOutputPanel.Width = width;
            reviewOutputPanel.Height = height;

            reviewViewPanel.Width = 2 * width + 3 * WorkFlow.Padding.Left;
            reviewViewPanel.Height = height;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeComponents();
        }
        #endregion

        public EContainer ContainerType
        {
            get { return EContainer.ReviewSecondContainer; }
        }
    }
}