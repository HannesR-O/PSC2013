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
using PSC2013.ES.Library.Diseases;

namespace PSC2013.ES.GUI.Simulation.Panels
{
    public partial class SimulationDiseasePanel : UserControl, ISimulationPanel<Disease>
    {
        public SimulationDiseasePanel()
        {
            InitializeComponent();
            this.Comp_Transferability.ToolTip += Environment.NewLine + "(e.g. a disease being transferred per air might" +
                Environment.NewLine + "get a higher value than one per contact)";
        }

        public Button NextButton
        {
            get { return this.Btn_Next; }
        }

        public Disease ContentInformation
        {
            get { return GatherInformation(); }
        }

        private Disease GatherInformation()
        {
            Disease disease = new Disease();

            foreach (Control item in this.GrpBox_Main.Controls)
            {
                ISettingsComponent comp = item as ISettingsComponent;
                if (comp != null)
                {
                    switch (comp.ComponentTag)
                    {
                        case EComponentTag.DiseaseName:
                            disease.Name = (comp as SettingsComponent<string>).GetValue();
                            break;
                        case EComponentTag.IncubationPeriod:
                            disease.IncubationPeriod = (comp as SettingsComponent<int>).GetValue();
                            break;
                        case EComponentTag.IdleTime:
                            disease.IdleTime = (comp as SettingsComponent<int>).GetValue();
                            break;
                        case EComponentTag.SpreadingTime:
                            disease.SpreadingTime = (comp as SettingsComponent<int>).GetValue();
                            break;
                        case EComponentTag.Transferability:
                            disease.Transferability = (comp as SettingsComponent<int>).GetValue();
                            break;
                        case EComponentTag.HealingFactors:
                            disease.HealingFactor = (comp as SettingsComponent<FactorContainer>).GetValue();
                            break;
                        case EComponentTag.MortalityFactors:
                            disease.MortalityRate = (comp as SettingsComponent<FactorContainer>).GetValue();
                            break;
                        case EComponentTag.ResistanceFactors:
                            disease.ResistanceFactor = (comp as SettingsComponent<FactorContainer>).GetValue();
                            break;
                        default:
                            break;
                    }
                }
            }

            return disease;
        }
    }
}
