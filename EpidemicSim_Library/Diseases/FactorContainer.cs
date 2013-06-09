using System;

namespace PSC2013.ES.Library.Diseases
{
    /// <summary>
    /// A container to hold the
    /// factors for each gender
    /// and age-group.
    /// </summary>
    public struct FactorContainer
    {
        /// <summary>
        /// Factor for male babies.
        /// </summary>
        public int Male_Baby { get { return _data[0]; } }
        /// <summary>
        /// Factor for male children.
        /// </summary>
        public int Male_Child { get { return _data[1]; } }
        /// <summary>
        /// Factor for male adults.
        /// </summary>
        public int Male_Adult { get { return _data[2]; } }
        /// <summary>
        /// Factor for male seniors.
        /// </summary>
        public int Male_Senior { get { return _data[3]; } }

        /// <summary>
        /// Factor for female babies.
        /// </summary>
        public int Female_Baby { get { return _data[4]; } }
        /// <summary>
        /// Factor for female children.
        /// </summary>
        public int Female_Child { get { return _data[5]; } }
        /// <summary>
        /// Factor for female adults.
        /// </summary>
        public int Female_Adult { get { return _data[6]; } }
        /// <summary>
        /// Factor for female seniors.
        /// </summary>
        public int Female_Senior { get { return _data[7]; } }

        /// <summary>
        /// Factors as array. Order as told in constructor.
        /// </summary>
        public int[] Data
        {
            get
            {
                int[] returnArray = new int[8];
                _data.CopyToOtherArray(returnArray);
                return returnArray;
            }
        }

        /// <summary>
        /// Provides comfortable access to the FactirContainer's values
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int this[int index] 
        {
            get 
            { 
                return _data[index];
            }
        }

        private int[] _data;

        /// <summary>
        /// A new FactorContainer
        /// </summary>
        /// <param name="data">The data in following order: 
        /// Males: 
        /// Baby, Child, Adult, Senior | 
        /// Females: 
        /// Baby, Child, Adult, Senior
        /// </param>
        public FactorContainer(int[] data)
        {
            if (data.Length != 8)
                throw new ArgumentException(
                    "The argument has to be an Integer-Array of length '8'",
                    "data");

            _data = new int[8];

            data.CopyToOtherArray(_data);
        }
    }
}