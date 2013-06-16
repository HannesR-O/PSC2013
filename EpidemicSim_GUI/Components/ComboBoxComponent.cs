using System;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Components
{
    public class ComboBoxComponent : SettingsComponent<object>
    {
        private ComboBox _cmbBox;

        public ComboBoxComponent()
        {
            _cmbBox = new ComboBox();
            _cmbBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _cmbBox.Width = DEFAULT_CONTROL_WIDTH;
            SetValueControl(_cmbBox);
        }

        public void ClearItems()
        {
            _cmbBox.Items.Clear();
        }

        public void Add(object obj)
        {
            _cmbBox.Items.Add(obj);
        }

        public void AddRange(object[] obj)
        {
            _cmbBox.Items.AddRange(obj);
        }

        public override object GetValue()
        {
            return _cmbBox.SelectedItem;
        }

        public override void SetValue(object value)
        {
            _cmbBox.SelectedItem = value;
        }
    }
}