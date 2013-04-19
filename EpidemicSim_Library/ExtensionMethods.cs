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

        public static int GetIntFromBase64(string base64)
        {
            return BitConverter.ToInt32(Convert.FromBase64String(base64), 0);
        }

        public static string ToBase64(this int value)
        {
            return Convert.ToBase64String(BitConverter.GetBytes(value));
        }

        public static short GetShortFromBase64(string base64)
        {
            return BitConverter.ToInt16(Convert.FromBase64String(base64), 0);
        }

        public static string ToBase64(this short value)
        {
            return Convert.ToBase64String(BitConverter.GetBytes(value));
        }
    }
}
