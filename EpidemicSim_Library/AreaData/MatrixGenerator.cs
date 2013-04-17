using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.PopulationData;

namespace PSC2013.ES.Library.AreaData
{
    public static class MatrixGenerator
    {
        /// <summary>
        /// Generates
        /// </summary>
        /// <param name="populationArray"></param>
        /// <param name="rawData"></param>
        /// <returns></returns>
        public static PopulationCell[] GenerateMatrix(
            PopulationCell[] populationArray,
            IEnumerable<DepartmentInfo> rawData)
        {
            if (populationArray.Length != 10808574)
                throw new ArgumentException(
                    "The argument has to be an array if PopulationCell with a length of '10808574'",
                    "populationArray");



            return populationArray;
        }
    }
}
