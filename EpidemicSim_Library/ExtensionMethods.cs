using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Extension method to simplify event raises
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="eventHandler">EventHandler of the event to raise</param>
        /// <param name="sender">Sender of the event to raise</param>
        /// <param name="e">EventArgs of the event to raise</param>
        public static void Raise<T>(this EventHandler<T> eventHandler, Object sender, T e) where T : EventArgs
        {
            if (eventHandler != null)
            {
                eventHandler(sender, e);
            }
        }
    }
}
