using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC2013.ES.GUI.Miscellaneous;

namespace PSC2013.ES.GUI.Simulation
{
    public partial class SimulationFirstContainer : UserControl
    {
        public SimulationFirstContainer()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.WorkFlow.Padding = new Padding(PSC2013.ES.GUI.MainForm.PADDING);
        }

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
    }
}
