using System;
using System.Windows.Forms;

namespace PSC2013.ES.GUI
{
    public static class ExtensionMethods
    {
        public static void Invoke(this Control control, Action action)
        {
            control.Invoke(action);
        }
    }
}
