using System;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Components
{
    public class LongComponent : SettingsComponent<long>
    {
        private NumericUpDown _numBox;

        public LongComponent()
        {
            _numBox = new NumericUpDown();
            _numBox.Width = DEFAULT_CONTROL_WIDTH;
            _numBox.Maximum = Int64.MaxValue;
            _numBox.Minimum = 0;
            _numBox.DecimalPlaces = 0;
            SetValueControl(_numBox);
        }

        public override long GetValue()
        {
            return (long)_numBox.Value;
        }

        public override void SetValue(long value)
        {
            _numBox.Value = value;
        }
    }
}