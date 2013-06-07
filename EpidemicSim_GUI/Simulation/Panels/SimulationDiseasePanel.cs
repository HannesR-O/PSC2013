using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC2013.ES.GUI.Components;

namespace PSC2013.ES.GUI.Simulation.Panels
{
    public partial class SimulationDiseasePanel : UserControl
    {
        public SimulationDiseasePanel()
        {
            InitializeComponent();
            InitComponents();
        }

        private void InitComponents()
        {
            this.Comp_DiseaseName.SetText("Disease name:");
            this.Comp_DiseaseName.SetToolTip("The name of the disease");
            this.Comp_DiseaseName.ComponentTag = EComponentTag.DiseaseName;

            this.Comp_IncubationPeriod.SetText("Incubation period:");
            this.Comp_IncubationPeriod.SetToolTip("The incubation time of the disease in hours.");
            this.Comp_IncubationPeriod.ComponentTag = EComponentTag.IncubationPeriod;

            this.Comp_IdleTime.SetText("Idle time:");
            this.Comp_IdleTime.SetToolTip("The hours until a subject spreads the disease after being infected.");
            this.Comp_IdleTime.ComponentTag = EComponentTag.IdleTime;

            this.Comp_SpreadingTime.SetText("Spreading time:");
            this.Comp_SpreadingTime.SetToolTip("The hours a subject is spreading the disease.");
            this.Comp_SpreadingTime.ComponentTag = EComponentTag.SpreadingTime;
        }
    }
}
