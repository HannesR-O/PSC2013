using System;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Components
{
    public class DateTimeComponent : SettingsComponent<DateTime>
    {
        private DateTimePicker _dateTimePicker;

        public DateTimeComponent()
        {
            _dateTimePicker = new DateTimePicker();
            _dateTimePicker.Width = DEFAULT_CONTROL_WIDTH;
            _dateTimePicker.Format = DateTimePickerFormat.Custom;
            _dateTimePicker.CustomFormat = "yyyy, MM, dd # hh";
            SetValueControl(_dateTimePicker);
            _dateTimePicker.Anchor |= AnchorStyles.Left;
        }

        public override DateTime GetValue()
        {
            return _dateTimePicker.Value;
        }

        public override void SetValue(DateTime value)
        {
            _dateTimePicker.Value = value;
        }
    }
}