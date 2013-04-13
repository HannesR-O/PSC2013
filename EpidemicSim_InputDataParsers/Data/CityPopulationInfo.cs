using System.Linq;

namespace PSC2013.ES.InputDataParsers.Data
{
    internal class CityPopulationInfo
    {
        private int[] _populationInfo;

        /// <summary>
        /// Name of the city
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Wraps the populationinfo to calculate the correct total value
        /// </summary>
        /// <param name="index">[0] - [3] => male, [4] - [7] => female, [8] => total</param>
        /// <returns>The populationcount of the selected group</returns>
        public int this[int index]
        {
            get
            {
                return _populationInfo[index];
            }
            set
            {
                _populationInfo[index] = value;
                UpdateTotal();
            }
        }

        public CityPopulationInfo()
        {
            _populationInfo = new int[9];
        }

        private void UpdateTotal()
        {
            _populationInfo[8] = _populationInfo.Sum() - _populationInfo[8];
        }

        public override string ToString()
        {
            // |f| Feel free to optimize this expression :D
            return Name + ": " +
                _populationInfo[0] + "/" + _populationInfo[1] + "/" + _populationInfo[2] + "/" + _populationInfo[3] + ", " +
                _populationInfo[4] + "/" + _populationInfo[5] + "/" + _populationInfo[6] + "/" + _populationInfo[7] + " " +
                _populationInfo[8];
        }
    }
}
