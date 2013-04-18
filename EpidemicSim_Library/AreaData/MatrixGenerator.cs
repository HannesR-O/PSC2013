using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.PopulationData;

namespace PSC2013.ES.Library.AreaData
{
    public static class MatrixGenerator
    {
        private const int WIDTH = 2814;
        private const int HEIGHT = 3841;

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
            if (populationArray.Length != WIDTH * HEIGHT)
                throw new ArgumentException(
                    "The argument has to be an array if PopulationCell with a length of '10808574'",
                    "populationArray");

            foreach (DepartmentInfo item in rawData)
                PopulateDepartment(item, populationArray);

            return populationArray;
        }

        private static void PopulateDepartment(DepartmentInfo depInfo, PopulationCell[] populationArray)
        {
            int minX = WIDTH;
            int minY = HEIGHT;
            int maxX = 0;
            int maxY = 0;

            foreach (Point item in depInfo.Coordinates)
            {
                minX = Math.Min(minX, item.X);
                minY = Math.Min(minY, item.Y);
                maxX = Math.Max(maxX, item.X);
                maxY = Math.Max(maxY, item.Y);
            }



            // TODO | dj | continue..
        }
    }
}
