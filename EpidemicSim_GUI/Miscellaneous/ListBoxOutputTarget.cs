using System;
using System.Windows.Forms;
using PSC2013.ES.Library.IO.OutputTargets;

namespace PSC2013.ES.GUI.Miscellaneous
{
    public class ListBoxOutputTarget : IOutputTarget
    {
        private ListBox _listBox;

        /// <summary>
        /// A new Outputtarget writing on the given
        /// Listbox.
        /// </summary>
        /// <param name="listbox">The listbox to write on.</param>
        public ListBoxOutputTarget(ListBox listbox)
        {
            if (listbox == null)
                throw new ArgumentNullException("listbox can not be null!");

            _listBox = listbox;
        }

        public void WriteToOutput(string message)
        {
            if (message == null)
                throw new ArgumentNullException("message", "Given message to write cannot be null!");

            _listBox.Invoke(new Action(() =>
                {
                    _listBox.Items.Add(message);
                    _listBox.TopIndex = _listBox.Items.Count - _listBox.ClientSize.Height / _listBox.ItemHeight + 1;
                }));
        }

        public bool Equals(IOutputTarget other)
        {
            var ot = other as ListBoxOutputTarget;
            if (ot == null)
                return false;
            return ot._listBox == _listBox;
        }
    }
}