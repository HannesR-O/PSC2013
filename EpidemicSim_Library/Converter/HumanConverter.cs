using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Converter
{
    public static class HumanConverter
    {
        public static bool getGender(long input)
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
    }
}
