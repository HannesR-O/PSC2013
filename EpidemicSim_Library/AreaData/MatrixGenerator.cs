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
        private static readonly Random RANDOM = new Random();

        /// <summary>
        /// Generates the ultimative matrix. It
        /// spreads the people ALLL over their departments.
        /// Might also include Department[].
        /// 
        /// **In-Place**
        /// </summary>
        /// <param name="populationArray">The already initialized
        /// PopulationCell-matrix which will be used for most stuff.
        /// This array will be modified!</param>
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

            byte avgFactor = 20;
            int areaSize = depInfo.Coordinates.Length;

            Queue<Tuple<int, Point>> workingQueue = new Queue<Tuple<int, Point>>();
            workingQueue.Enqueue(new Tuple<int, Point>(0, initialPoint));

            while (workingQueue.Count > 0)
            {
                Tuple<int, Point> nTpl = workingQueue.Dequeue();
                int currentRun = nTpl.Item1;
                Point n = nTpl.Item2;

                int remainingTplOfSameRun = workingQueue.Count(x => x.Item1 == currentRun);

                for (int i = 0; i < 8; i++) // for each age-group
                {
                    int r = RANDOM.Next(10) - 5;
                    int possibles = depInfo.Population[i] / areaSize / remainingTplOfSameRun;
                    int toSetCount = (int)(possibles * (100f - (avgFactor + r)));

                    int fn = FlattenPoint(n);
                    PopulationCell pc = populationArray[fn];

                    for (int j = 0; j < toSetCount; j++)                 // foreach human (which has to be set)
                    {
                        // Gender
                        EGender gender = (i < 4)? EGender.Male : EGender.Female;
                        
                        // Age
                        int lowerBound = 0;
                        int upperBound = 110;
                        if (i % 4 == 0)
                            upperBound = 6;
                        else if (i % 4 == 1)
                        {
                            lowerBound = 7;
                            upperBound = 25;
                        }
                        else if (i % 4 == 2)
                        {
                            lowerBound = 26;
                            upperBound = 60;
                        }
                        else
                            lowerBound = 61;
                        int age = RANDOM.Next(lowerBound, upperBound + 1);

                        Human h = Human.CreateHuman(gender, age, fn);
                        pc.AddHuman(h);
                    }
                }
                // TODO | dj | current ^^^

                // - if remainingTpl... == 0? avgFactor -= x;
                if (remainingTplOfSameRun == 0)
                {
                    short rand = (short)(RANDOM.Next(15) - 5);
                    if (avgFactor + rand <= 0) rand = 7;
                    avgFactor = (byte)(avgFactor + rand);
                    
                }
                
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
