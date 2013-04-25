using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Diseases
{
    /// <summary>
    /// A container to hold the
    /// factors for each gender
    /// and age-group.
    /// </summary>
    public struct FactorContainer
    {
        public int Male_Baby;
        public int Male_Child;
        public int Male_Adult;
        public int Male_Senior;

        public int Female_Baby;
        public int Female_Child;
        public int Female_Adult;
        public int Female_Senior;

        /// <summary>
        /// A new FactorContainer
        /// </summary>
        /// <param name="args">Arguments in following order: 
        /// Males: 
        /// Baby, Child, Adult, Senior | 
        /// Females: 
        /// Baby, Child, Adult, Senior
        /// </param>
        public FactorContainer(params int[] args)
        {
            if (args.Length != 8)
                throw new ArgumentException(
                    "The argument has to be an Integer-Array of length '8'",
                    "args");

            Male_Baby = args[0];
            Male_Child = args[1];
            Male_Adult = args[2];
            Male_Senior = args[3];

            Female_Baby = args[4];
            Female_Child = args[5];
            Female_Adult = args[6];
            Female_Senior = args[7];
        }
    }
}
