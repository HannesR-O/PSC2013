using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Components
{
    public class PathComponent : SettingsComponent<string>
    {
        private TextBox _textBox;
        private Button _button;

        public PathComponent()
        {
            _textBox = new TextBox();
            _textBox.Width = DEFAULT_CONTROL_WIDTH;
            _textBox.ReadOnly = true;
            
            _button = new Button();
            _button.Text = "Browse...";
            _button.Click += OnBrowseClick;
            SetValueControl(_button);
            _button.Top = _textBox.Top + _textBox.Height + 3;

            SetValueControl(_textBox);
            _textBox.Anchor |= AnchorStyles.Left;

            this.Height += _button.Height + 3;
        }

        /// <summary>
        /// The used dialog in this component.
        /// </summary>
        public CommonDialog Dialog { get; set; }

        private void OnBrowseClick(object sender, EventArgs e)
        {
            if (Dialog == null) return;

            DialogResult dr = Dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (Dialog is FolderBrowserDialog)
                    _textBox.Text = (Dialog as FolderBrowserDialog).SelectedPath;
                else if (Dialog is SaveFileDialog)
                    _textBox.Text = (Dialog as SaveFileDialog).FileName;
                else if (Dialog is FileDialog)
                    _textBox.Text = (Dialog as FileDialog).FileName;
            }
        }

        public override string GetValue()
        {
            return _textBox.Text;
        }

        public override void SetValue(string value)
        {
            _textBox.Text = value;
        }
    }
}
