using System;
using System.Windows.Forms;
using PSC2013.ES.Library.IO.OutputTargets;

namespace PSC2013.ES.GUI.Misc
{
    class ListBoxOutputTarget : IOutputTarget
    {
        private readonly ListBox _lBox;

        /// <summary>
        /// Creates a new ListBoxOutputTarget wrapping a give ListBox
        /// </summary>
        /// <param name="outputBox">ListBox to write messages to</param>
        public ListBoxOutputTarget(ListBox outputBox)
        {
            if (outputBox == null)
                throw new ArgumentNullException("outputBox");

            _lBox = outputBox;
        }

        public bool Equals(IOutputTarget other)
        {
            var otherTarget = other as ListBoxOutputTarget;
            if (otherTarget == null)
                return false;

            return _lBox == otherTarget._lBox;
        }

        public void WriteToOutput(string message)
        {
            _lBox.Items.Add(message);
        }
    }
}