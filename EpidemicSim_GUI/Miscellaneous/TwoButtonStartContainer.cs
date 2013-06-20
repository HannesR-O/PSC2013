using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Miscellaneous
{
    public partial class TwoButtonStartContainer : UserControl, IContainer
    {
        public TwoButtonStartContainer()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public Button TheSimulationButton
        {
            get { return Btn_Simulation; }
        }

        public Button TheReviewButton
        {
            get { return Btn_Review; }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeButtons();
        }

        private void ResizeButtons()
        {
            Btn_Simulation.Height = this.Height / 2;
            Btn_Review.Height = this.Height / 2;
        }

        public EContainer ContainerType
        {
            get { throw new NotSupportedException(); }
        }
    }
}
