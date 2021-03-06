﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library
{
    public static class Constants
    {
        public static readonly ParallelOptions DEFAULT_PARALLELOPTIONS =
            new ParallelOptions()
            {
                MaxDegreeOfParallelism = (int)Math.Max(1, Environment.ProcessorCount * 0.75)
            };
    }

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
        /// Random integer in [0,int.MaxValue).
        /// </summary>
        public static int Next()
        {
            return Next(0, int.MaxValue);
        }

        /// <summary>
        /// Like the built-in one:
        /// Random integer in [0, max).
        /// </summary>
        public static int Next(int max)
        {
            return Next(0, max);
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
