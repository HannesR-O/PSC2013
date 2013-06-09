using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Components
{
    public abstract partial class SettingsComponent<T> : UserControl, ISettingsComponent

    {
        public const int DEFAULT_CONTROL_WIDTH = 100;

        private Control _ctrl;

        public SettingsComponent()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
        }

        protected void SetValueControl(Control control)
        {
            _ctrl = control;
            int x = this.Width - _ctrl.Width - this.Padding.Right;
            int y = this.Padding.Top;
            _ctrl.Location = new Point(x, y);
            _ctrl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.Controls.Add(control);
            this.Size = new Size(this.Width,
                _ctrl.Height + this.Padding.Top + this.Padding.Bottom);
        }

        /// <summary>
        /// The tag of this component.
        /// </summary>
        public EComponentTag ComponentTag
        { get; set; }

        /// <summary>
        /// Sets the text of the label.
        /// </summary>
        public string LabelText
        {
            get { return Label.Text; }
            set { Label.Text = value; }
        }

        /// <summary>
        /// Sets the text of the tooltip.
        /// </summary>
        public string ToolTip
        {
            get { return ToolTipControl.GetToolTip(_ctrl); }
            set { ToolTipControl.SetToolTip(_ctrl, value); }
        }

        /// <summary>
        /// Returns the value of this component.
        /// </summary>
        public abstract T GetValue();

        /// <summary>
        /// Sets the value iof this components
        /// </summary>
        public abstract void SetValue(T value);
    }
}
