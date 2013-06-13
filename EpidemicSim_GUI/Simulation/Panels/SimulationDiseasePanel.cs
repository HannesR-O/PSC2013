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
using PSC2013.ES.Library.DiseaseData;
using PSC2013.ES.Library.IO;

namespace PSC2013.ES.GUI.Simulation.Panels
{
    public partial class SimulationDiseasePanel : UserControl, ISimulationPanel<Disease>
    {
        public SimulationDiseasePanel()
        {
            InitializeComponent();
            this.Comp_Transferability.ToolTip += Environment.NewLine + "(e.g. a disease being transferred per air might" +
                Environment.NewLine + "get a higher value than one per contact)";

            this.Comp_ImExPort.Export += OnExportDisease;
            this.Comp_ImExPort.Import += OnImportDisease;
        }

        public bool ValidateData()
        {
            Disease dis = ContentInformation;

            return !String.IsNullOrEmpty(dis.Name);
        }

        public Button TheButton
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

            ForeachComponent((comp) =>
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
                });

            return disease;
        }

        private void OnExportDisease(object sender, EventArgs e)
        {
            string path = this.Comp_ImExPort.Path;
            DiseaseIOService.Save(ContentInformation, path, true);
        }

        private void OnImportDisease(object sender, EventArgs e)
        {
            string path = this.Comp_ImExPort.Path;
            Disease dis = DiseaseIOService.Load(path);

            ForeachComponent((comp) =>
                {
                    switch (comp.ComponentTag)
                    {
                        case EComponentTag.DiseaseName:
                            (comp as SettingsComponent<string>).SetValue(dis.Name);
                            break;
                        case EComponentTag.IncubationPeriod:
                            (comp as SettingsComponent<int>).SetValue(dis.IncubationPeriod);
                            break;
                        case EComponentTag.IdleTime:
                            (comp as SettingsComponent<int>).SetValue(dis.IdleTime);
                            break;
                        case EComponentTag.SpreadingTime:
                            (comp as SettingsComponent<int>).SetValue(dis.SpreadingTime);
                            break;
                        case EComponentTag.Transferability:
                            (comp as SettingsComponent<int>).SetValue(dis.Transferability);
                            break;
                        case EComponentTag.HealingFactors:
                            (comp as SettingsComponent<FactorContainer>).SetValue(dis.HealingFactor);
                            break;
                        case EComponentTag.MortalityFactors:
                            (comp as SettingsComponent<FactorContainer>).SetValue(dis.MortalityRate);
                            break;
                        case EComponentTag.ResistanceFactors:
                            (comp as SettingsComponent<FactorContainer>).SetValue(dis.ResistanceFactor);
                            break;
                        default:
                            break;
                    }
                });
        }

        private void ForeachComponent(Action<ISettingsComponent> action)
        {
            foreach (var item in this.GrpBox_Main.Controls)
            {
                ISettingsComponent comp = item as ISettingsComponent;
                if (comp != null)
                {
                    action.Invoke(comp);
                }
            }
        }
    }
}
