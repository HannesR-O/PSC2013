using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC2013.ES.Library.Diseases;

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
            // TODO | dj | implement
        }

        public override FactorContainer GetValue()
        {
            return _container;
        }
    }
}
