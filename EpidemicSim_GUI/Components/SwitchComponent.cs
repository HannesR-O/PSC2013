using System;
using System.Drawing;
using System.Windows.Forms;
using PSC2013.ES.Library;

namespace PSC2013.ES.GUI.Components
{
    public class SwitchComponent : SettingsComponent<bool>
    {
        public event EventHandler<EventArgs> Changed;

        private CheckBox _btn1;
        private CheckBox _btn2;
        private bool _2Checked;

        public SwitchComponent()
        {
            int width = DEFAULT_CONTROL_WIDTH / 3 * 2;

            _btn1 = new CheckBox();
            _btn1.Appearance = Appearance.Button;
            _btn1.Text = "BUTTON_1";
            _btn1.TextAlign = ContentAlignment.MiddleCenter;
            _btn1.Width = width;
            _btn1.Checked = true;

            _btn2 = new CheckBox();
            _btn2.Appearance = Appearance.Button;
            _btn2.Text = "BUTTON_2";
            _btn2.TextAlign = ContentAlignment.MiddleCenter;
            _btn2.Width = width;

            SetValueControl(_btn1);
            _btn1.Left = _btn1.Left - _btn1.Width - 3;
            SetValueControl(_btn2);

            InitEvents();
        }

        private void InitEvents()
        {
            _btn1.Click += OnButtonClick;
            _btn2.Click += OnButtonClick;
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            _btn1.Checked = _2Checked;
            _2Checked = !_2Checked;
            _btn2.Checked = _2Checked;

            Changed.Raise(this, e);
        }

        public string Text_1
        {
            get { return _btn1.Text; }
            set { _btn1.Text = value; }
        }

        public string Text_2
        {
            get { return _btn2.Text; }
            set { _btn2.Text = value; }
        }

        /// <summary>
        /// True if first button checked. false else.
        /// </summary>
        public override bool GetValue()
        {
            return !_2Checked;
        }

        public override void SetValue(bool value)
        {
            throw new NotSupportedException("This method is as a lack of consistence not supported.");
        }
    }
}