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
        /// Generates the ultimative matrix. It
        /// spreads the people ALLL over their departments.
        /// Might also include Department[].
        /// 
        /// **In-Place**
        /// </summary>
        /// <param name="populationArray">The PopulationCell-matrix which will be
        /// used for most stuff. This array will be modified!</param>
        /// <param name="rawData">The raw DepartmentInfos. This array will be modified!</param>
        /// <returns>The input-populationCell-array (modified).</returns>
        public static PopulationCell[] GenerateMatrix(
            PopulationCell[] populationArray,
            IEnumerable<DepartmentInfo> rawData)
        {
            if (populationArray.Length != WIDTH * HEIGHT)
                throw new ArgumentException(
                    "The argument has to be an array if PopulationCell with a length of '10808574'",
                    "populationArray");

            // TODO | dj | this could be done parallel
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
            
            int avgX = (maxX + minX) / 2;
            int avgY = (maxY + minY) / 2;

            Point initialPoint = new Point(avgX, avgY);

            /* If the average point is not in the area
             * of the department, the first - hand
             * gathered - coordinate will be chosen.
             * This is most times near the center.
             */
            if (!depInfo.Coordinates.Any(p => p.Equals(initialPoint)))
                initialPoint = depInfo.Coordinates[0];

            short avgFactor = 115;
            int areaSize = depInfo.Coordinates.Length;
            int currentRun = 0;

            Queue<Tuple<int, Point>> workingQueue = new Queue<Tuple<int, Point>>();
            workingQueue.Enqueue(new Tuple<int, Point>(currentRun, initialPoint));

            while (workingQueue.Count > 0)
            {
                Tuple<int, Point> n = workingQueue.Dequeue();

                int remainingTplOfSameRun = workingQueue.Count(x => x.Item1 == currentRun);
                int possibles = depInfo.GetTotal() / areaSize / remainingTplOfSameRun;
                
                // - fill (with random?!)

                // - if remainingTpl... == 0? avgFactor -= x;
                
                // - queue neighbours
            }

            // TODO | dj | continue..
        }

        /// <summary>
        /// Flattens a 2D-Point to a 1D-index.
        /// </summary>
        private static int FlattenPoint(Point p)
        {
            return p.X + (p.Y * WIDTH);
        }
    }
}
