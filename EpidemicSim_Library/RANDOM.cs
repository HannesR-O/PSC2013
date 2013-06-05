using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library
{
    /// <summary>
    /// Static threadsafe Random-class.
    /// Please use this one instead of the built-in Random.
    /// </summary>
    public static class RANDOM
    {
        private static Random _global = new Random();
        [ThreadStatic]
        private static Random _local;

        /// <summary>
        /// Like the built-in one:
        /// Random integer in [0,max).
        /// </summary>
        public static int Next(int max)
        {
            Random inst = _local;
            if (inst == null)
            {
                int seed;
                lock (_global) seed = _global.Next();
                _local = inst = new Random(seed);
            }
            return inst.Next(max);
        }

        /// <summary>
        /// Like the built-in one:
        /// Random integer in [min, max). 
        /// </summary>
        public static int Next(int min, int max)
        {
            Random inst = _local;
            if (inst == null)
            {
                int seed;
                lock (_global) seed = _global.Next();
                _local = inst = new Random(seed);
            }
            return inst.Next(min, max);
        }
    }

}
