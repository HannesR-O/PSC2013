using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Converter
{
    /// <summary>
    /// Static Converter for longs to Human-Values
    /// </summary>
    public static class HumanConverter
    {
        /// <summary>
        /// Returns the Gender of an given Human
        /// </summary>
        /// <param name="input"></param>
        /// <returns>true if Female, false if male</returns>
        public static bool getGender(ulong input)
        {
            if ((input & 0x1) == 1)
                return true;
            else
                return false;
        }

        public static ulong getAge(ulong input)
        {
            return ((input & 0xFE) >> 1);
        }

        public static ulong getDefaultResistance(ulong input)
        {
            return ((input & 0x1F00) >> 8);
        }

        public static ulong getInfluence(ulong input)
        {
            return ((input & 0x1F000) >> 12);
        }

        public static ulong getHome(ulong input)
        {
            return ((input & 0x1FFFFFE0000) >> 17);
        }

        public static ulong getStatus(ulong input)
        {
            return ((input & 0x20000000000) >> 41);
        }

        public static ulong getSpreading(ulong input)
        {
            return ((input & 0x40000000000) >> 42);
        }

        public static ulong getDiseased(ulong input)
        {
            return ((input & 0x80000000000) >> 43);
        }

        public static ulong getTimeFormat(ulong input)
        {
            return ((input & 0x300000000000) >> 44);
        }

        public static ulong getCount(ulong input)
        {
            return ((input & 0xFC00000000000) >> 46);
        }
    }
}
