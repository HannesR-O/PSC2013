using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC2013.ES.GUI.Simulation;
using PSC2013.ES.Library.DiseaseData;

namespace PSC2013.ES.GUI.Components
{
    public class FactorComponent : SettingsComponent<FactorContainer>
    {
        private Button _button;
        private FactorContainer _container;

        public FactorComponent()
        {
            _container = new FactorContainer(new int[]{0,0,0,0, 0,0,0,0});

            _button = new Button();
            _button.Text = "Specify...";
            _button.Width = DEFAULT_CONTROL_WIDTH;
            _button.Click += Specify_Click;
            SetValueControl(_button);
        }

        void Specify_Click(object sender, EventArgs e)
        {
            FactorContainerForm fcf = new FactorContainerForm(_container);
            fcf.Text = this.LabelText;
            DialogResult dr = fcf.ShowDialog();
            if (dr == DialogResult.OK)
                _container = fcf.Factors;
        }

        public override FactorContainer GetValue()
        {
            return _container;
        }

        public override void SetValue(FactorContainer value)
        {
            _container = value;
        }
    }
}
