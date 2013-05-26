﻿using System;
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

        private void EnableMaleCheckBoxes(bool enable)
        {
            var boxes = new CheckBox[] {
                CheckBox_S_MaleAdult,
                CheckBox_S_MaleBaby,
                CheckBox_S_MaleChild,
                CheckBox_S_MaleSenior
                };
            foreach (var box in boxes)
                box.Enabled = enable;
        }

        private void EnableFemaleCheckBoxes(bool enable)
        {
            var boxes = new CheckBox[] {
                CheckBox_S_FemaleAdult,
                CheckBox_S_FemaleBaby,
                CheckBox_S_FemaleChild,
                CheckBox_S_FemaleSenior
                };
            foreach (var box in boxes)
                box.Enabled = enable;
        }

        private void EnableAllCheckBoxes(bool enable)
        {
            CheckBox_S_Male.Enabled = enable;
            EnableMaleCheckBoxes(enable);
            CheckBox_S_Female.Enabled = enable;
            EnableFemaleCheckBoxes(enable);
        }

        private void CheckBox_S_All_CheckedChanged(object sender, EventArgs e)
        {
            EnableAllCheckBoxes(!CheckBox_S_All.Checked);
        }

        private void CheckBox_S_Male_CheckedChanged(object sender, EventArgs e)
        {
            EnableMaleCheckBoxes(!CheckBox_S_Male.Checked);
        }

        private void CheckBox_S_Female_CheckedChanged(object sender, EventArgs e)
        {
            EnableFemaleCheckBoxes(!CheckBox_S_Female.Checked);
        }

        private void CheckBox_S_IndPredix_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_S_IndPredix.Checked)
                TextBox_S_Prefix.Enabled = true;
            else
                TextBox_S_Prefix.Enabled = false;
        }        
    }
}
