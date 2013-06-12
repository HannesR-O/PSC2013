using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PSC2013.ES.GUI.Components;
using PSC2013.ES.GUI.Miscellaneous;

namespace PSC2013.ES.GUI.Simulation.Panels
{
    public partial class SimulationSettingsPanel : UserControl, ISimulationPanel<SettingsContainer>
    {
        public SimulationSettingsPanel()
        {
            InitializeComponent();
            this.Comp_SimulationIntervall.SetValue(1);
            this.Comp_SnapshotIntervall.SetValue(1);
            this.Comp_EnableAgeing.SetValue(true);
            this.Comp_EnableInfection.SetValue(true);
            this.Comp_EnableDiseaseTick.SetValue(true);
            this.Comp_EnableDiseaseDeath.SetValue(true);
            this.Comp_EnableDiseaseHealing.SetValue(true);
            this.Comp_EnableMindset.SetValue(true);
            this.Comp_EnableMovement.SetValue(true);
        }

        public bool ValidateData()
        {
            SettingsContainer sc = ContentInformation;

            return sc.SimulationDuration >= 0 &&
                sc.SnapshotIntervall % sc.SimulationIntervall == 0;
        }

        public Button TheButton
        {
            get { return this.Btn_Next; }
        }

        public SettingsContainer ContentInformation
        {
            get { return GatherInformation(); }
        }

        private SettingsContainer GatherInformation()
        {
            SettingsContainer sc = new SettingsContainer();
            List<EComponentTag> comps = new List<EComponentTag>();

            foreach (Control item in this.GrpBox_Main.Controls)
            {
                ISettingsComponent comp = item as ISettingsComponent;
                if (comp != null)
                {
                    switch (comp.ComponentTag)
                    {
                        case EComponentTag.SimulationDuration:
                            sc.SimulationDuration = (comp as SettingsComponent<long>).GetValue();
                            break;
                        case EComponentTag.SimulationIntervall:
                            sc.SimulationIntervall = (comp as SettingsComponent<int>).GetValue();
                            break;
                        case EComponentTag.SnapshotIntervall:
                            sc.SnapshotIntervall = (comp as SettingsComponent<int>).GetValue();
                            break;
                        case EComponentTag.AgeingComponent:
                        case EComponentTag.InfectionComponent:
                        case EComponentTag.DiseaseTickComponent:
                        case EComponentTag.DiseaseDeathComponent:
                        case EComponentTag.DiseaseHealingComponent:
                        case EComponentTag.MindsetComponent:
                        case EComponentTag.MovementComponent:
                            if ((comp as SettingsComponent<bool>).GetValue())
                                comps.Add(comp.ComponentTag);
                            break;
                        default:
                            break;
                    }
                }
            }

            sc.Components = comps.ToArray();

            return sc;
        }
    }
}