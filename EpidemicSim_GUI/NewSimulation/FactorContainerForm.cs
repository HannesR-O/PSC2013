using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC2013.ES.Library.Diseases;

namespace PSC2013.ES.GUI.NewSimulation
{
    public partial class FactorContainerForm : Form
    {
        public FactorContainer FactorContainer { get; private set; }

        private FactorContainerForm()
        {
            InitializeComponent();
        }

        public FactorContainerForm(string name) : this()
        {
            this.Text = name + this.Text;
        }

        /// <summary>
        /// Gets the information out of the form and
        /// stores it in the FactorContainer.
        /// </summary>
        private void GatherInformation()
        {
            int[] array = new int[]
            {
                (int)numField_male_baby.Value,
                (int)numField_male_child.Value,
                (int)numField_male_adult.Value,
                (int)numField_male_senior.Value,
                (int)numField_female_baby.Value,
                (int)numField_female_child.Value,
                (int)numField_female_adult.Value,
                (int)numField_female_senior.Value
            };

            FactorContainer = new FactorContainer(array);
        }

        // == EVENTS == \\

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            GatherInformation();
            this.Close();
        }
    }
}
