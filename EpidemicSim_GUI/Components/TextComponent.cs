using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Components
{
    public class TextComponent : SettingsComponent<string>
    {
        private TextBox _textBox;

        public TextComponent()
        {
            _textBox = new TextBox();
            _textBox.Width = DEFAULT_CONTROL_WIDTH;
            SetValueControl(_textBox);
        }

        public override string GetValue()
        {
            return _textBox.Text;
        }
    }
}
