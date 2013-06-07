using System;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Components
{
    public class IntComponent : SettingsComponent<int>
    {
        private NumericUpDown _numBox;

        public IntComponent()
        {
            _numBox = new NumericUpDown();
            _numBox.Width = DEFAULT_CONTROL_WIDTH;
            _numBox.Maximum = Int32.MaxValue;
            _numBox.Minimum = 0;
            _numBox.DecimalPlaces = 0;
            SetValueControl(_numBox);
        }

        public override int GetValue()
        {
            return (int)_numBox.Value;
        }
    }
}