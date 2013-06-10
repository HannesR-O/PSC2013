﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC2013.ES.Library;

namespace PSC2013.ES.GUI.Simulation.Panels
{
    public partial class SimulationStartlocationPanel : UserControl, ISimulationPanel<InfectionInitState>
    {
        public SimulationStartlocationPanel()
        {
            InitializeComponent();
        }

        public void SetProgressBarStyle(ProgressBarStyle style)
        {
            ProgressBar_Main.Style = style;
        }

        public void SetImage(Image img)
        {
            PictBox_SelectedDepartments.Image = img;
        }

        public ListBox TheListBox
        {
            get { return ListBox_Departments; }
        }

        public Button TheButton
        {
            get { return this.Btn_Next; }
        }

        public InfectionInitState ContentInformation
        {
            get { return new InfectionInitState { DesiredInfection = GatherInformation() }; }
        }

        private Dictionary<int, int> GatherInformation()
        {
            var dict = new Dictionary<int, int>();

            // TODO | dj | not sure, whether a InfectionInitState will be possible
            // TODO | dj | CONTINUE WORK!

            return dict;
        }
    }
}
