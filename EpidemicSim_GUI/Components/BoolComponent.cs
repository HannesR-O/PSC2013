using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC2013.ES.Library;

namespace PSC2013.ES.GUI.Components
{
    public class BoolComponent : SettingsComponent<bool>
    {
        public event EventHandler<EventArgs> Clicked;
        public event EventHandler<EventArgs> Changed;

        private CheckBox _chkBox;

        public BoolComponent()
        {
            _chkBox = new CheckBox();
            _chkBox.Height = 20;
            _chkBox.Width = _chkBox.Height;
            _chkBox.Text = "";
            _chkBox.Click += (_, e) => Clicked.Raise(this, e);
            _chkBox.CheckedChanged += (_, e) => Changed.Raise(this, e);
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
