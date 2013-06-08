using System;
using System.Windows.Forms;
using PSC2013.ES.GUI.Components;
using PSC2013.ES.Library.Diseases;

namespace PSC2013.ES.GUI.Simulation
{
    public partial class FactorContainerForm : Form
    {
        private FactorContainer _factors;

        public FactorContainer Factors
        {
            get
            {
                return _factors;
            }
            set
            {
                _factors = value;
                UpdateFields();
            }
        }

        public FactorContainerForm(FactorContainer factors)
            : this()
        {
            Factors = factors;
        }

        private FactorContainerForm()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            FetchFields();
            this.Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FetchFields()
        {
            IterateFields((i, comp) => Factors.Data[i] = comp.GetValue());
        }

        private void UpdateFields()
        {
            IterateFields((i, comp) => comp.SetValue(Factors.Data[i]));
        }

        private void IterateFields(Action<int, SettingsComponent<int>> action)
        {
            for (int i = 0; i < 8; ++i)
            {
                System.Windows.Forms.Control.ControlCollection cc = (i < 4)?
                    GrpBox_Male.Controls : GrpBox_Female.Controls;
                foreach (var item in cc)
                {
                    SettingsComponent<int> comp = item as SettingsComponent<int>;
                    if (comp != null)
                        if (comp.ComponentTag == (EComponentTag)i)
                            action(i, comp);
                }
            }
        }
    }
}