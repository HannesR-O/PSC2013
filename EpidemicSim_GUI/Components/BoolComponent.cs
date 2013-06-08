using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Components
{
    public class BoolComponent : SettingsComponent<bool>
    {
        private CheckBox _chkBox;

        public BoolComponent()
        {
            _chkBox = new CheckBox();
            _chkBox.Height = 20;
            _chkBox.Width = _chkBox.Height;
            _chkBox.Text = "";
            SetValueControl(_chkBox);
        }

        public override bool GetValue()
        {
            return _chkBox.Checked;
        }

        public override void SetValue(bool value)
        {
            _chkBox.Checked = value;
        }
    }
}
