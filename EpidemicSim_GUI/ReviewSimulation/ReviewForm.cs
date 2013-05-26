using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.ReviewSimulation
{
    public partial class ReviewForm : Form
    {
        public ReviewForm()
        {
            InitializeComponent();
        }

        private void CheckBox_S_All_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_S_All.Checked)
            {
                CheckBox_S_Male.Checked = true;
                CheckBox_S_Female.Checked = true;
            }
            else
            {
                CheckBox_S_Male.Checked = false;
                CheckBox_S_Female.Checked = false;
            }
        }

        private void CheckBox_S_Male_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_S_Male.Checked)
            {
                CheckBox_S_MaleBaby.Checked = true;
                CheckBox_S_MaleChild.Checked = true;
                CheckBox_S_MaleAdult.Checked = true;
                CheckBox_S_MaleSenior.Checked = true;
            }
            else
            {
                CheckBox_S_MaleBaby.Checked = false;
                CheckBox_S_MaleChild.Checked = false;
                CheckBox_S_MaleAdult.Checked = false;
                CheckBox_S_MaleSenior.Checked = false;
            }
        }

        private void CheckBox_S_Female_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_S_Female.Checked)
            {
                CheckBox_S_FemaleBaby.Checked = true;
                CheckBox_S_FemaleChild.Checked = true;
                CheckBox_S_FemaleAdult.Checked = true;
                CheckBox_S_FemaleSenior.Checked = true;
            }
            else
            {
                CheckBox_S_FemaleBaby.Checked = false;
                CheckBox_S_FemaleChild.Checked = false;
                CheckBox_S_FemaleAdult.Checked = false;
                CheckBox_S_FemaleSenior.Checked = false;
            }
        }        
    }
}
