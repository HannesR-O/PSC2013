using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Components
{
    public class ColorRangeComponent : SettingsComponent<Color>
    {
        private Panel _panel;

        public ColorRangeComponent()
        {
            _panel = new Panel();
            _panel.Width = DEFAULT_CONTROL_WIDTH / 2;
            _panel.Height = 25;
            SetValueControl(_panel);
        }

        public override Color GetValue()
        {
            return _panel.BackColor;
        }

        public override void SetValue(Color value)
        {
            _panel.BackColor = value;
        }
    }
}
