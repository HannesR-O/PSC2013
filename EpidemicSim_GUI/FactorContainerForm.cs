using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSC2013.ES.GUI
{
    public partial class FactorContainerForm : Form
    {
        private FactorContainerForm()
        {
            InitializeComponent();
        }

        public FactorContainerForm(string name) : this()
        {
            this.Text = name + this.Text;
        }
    }
}
