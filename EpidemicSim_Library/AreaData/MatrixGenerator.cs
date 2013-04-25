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
        private static readonly Random RANDOM = new Random();

        private static int WIDTH = 2814;
        private static int HEIGHT = 3841;
        
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
        /// <param name="width">width of the populationArray (used for offsets)</param>
        /// <param name="height">height of the populationArray (used for offsets)</param>
        /// <returns>The input-populationCell-array (modified).</returns>
        public static PopulationCell[] GenerateMatrix(
            PopulationCell[] populationArray,
            IEnumerable<DepartmentInfo> rawData,
            int width, int height)
        {
            WIDTH = width;
            HEIGHT = height;

            if (populationArray.Length != WIDTH * HEIGHT)
                throw new ArgumentException(
                    "The argument has to be an array if PopulationCell with a length of '" + WIDTH * HEIGHT + "'.",
                    "populationArray");

            // the parallel call.
            int degree = (Environment.ProcessorCount >> 1);     // half of processors (we don't wanna kill it :P)
            degree = Math.Max(1, degree);                       // but minimum of 1
            //degree = -1;
            Parallel.ForEach(rawData, new ParallelOptions() { MaxDegreeOfParallelism = degree },
                (item) =>
                {
                    PopulateDepartment(item, populationArray);
                });
            //foreach (var item in rawData)
            //{
            //    PopulateDepartment(item, populationArray);
            //}

            return populationArray;
        }

        private static void PopulateDepartment(DepartmentInfo depInfo, PopulationCell[] populationArray)
        {
#if DEBUG
            Console.WriteLine("Calculating " + depInfo.Name);
#endif
            Point initialPoint = CalculateInitialPoint(depInfo);

            byte avgFactor = 125;
            int areaSize = depInfo.Coordinates.Length;

            Tuple<int, PopulationCell>[] tmpInfo = new Tuple<int, PopulationCell>[areaSize];
            int tmpCounter = 0;
            //List<Tuple<int, PopulationCell>> tmpInfo = new List<Tuple<int, PopulationCell>>();

            Queue<Tuple<int, Point>> workingQueue = new Queue<Tuple<int, Point>>();
            workingQueue.Enqueue(new Tuple<int, Point>(0, initialPoint));

            while (workingQueue.Count > 0)
            {
                Tuple<int, Point> nTpl = workingQueue.Dequeue();
                int currentRun = nTpl.Item1;
                Point n = nTpl.Item2;

                int remainingTplOfSameRun = workingQueue.Count(x => x.Item1 == currentRun);

                int fn = FlattenPoint(n);
                //PopulationCell pc = populationArray[fn];
                PopulationCell pc = new PopulationCell();
                tmpInfo[tmpCounter++] = new Tuple<int, PopulationCell>(fn, pc);
                //tmpInfo.Add(new Tuple<int, PopulationCell>(fn, pc));

                for (int i = 0; i < 8; i++) // for each age-group
                {
                    int r = RANDOM.Next(10) - 5;
                    int possibles = (int)(depInfo.Population[i] / (float)areaSize);
                    int toSetCount = (int)(possibles * ((100f + (avgFactor + r)) / 100));

                    for (int j = 0; j < toSetCount; j++)                 // foreach human (which has to be set)
                    {
                        // Gender
                        EGender gender = (i < 4)? EGender.Male : EGender.Female;
                        
                        // Age
                        int lowerBound = 1;
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

                        Human h = Human.Create(gender, age, fn);
                        pc.AddHuman(h);
                        
                        // remove from DepartmentInfo
                        depInfo.Population[i] -= 1;
                    }
                }

                // - if remainingTpl... == 0? avgFactor -= x;
                if (remainingTplOfSameRun == 0)
                {
                    short rand = (short)(RANDOM.Next(75) - 65);
                    if (avgFactor + rand <= 0) rand = 7;
                    avgFactor = (byte)(avgFactor + rand);
                }
                areaSize--;
                if (areaSize > 0)
                {
                    currentRun++;
                    // - queue neighbours (8-way)
                    for (int y = -1; y <= 1; y++)
                    {
                        for (int x = -1; x <= 1; x++)
                        {
                            Point p = new Point(n.X + x, n.Y + y);
                            if (!p.Equals(n))
                                //if (CheckPoint(p, populationArray, depInfo.Coordinates, workingQueue))
                                if (Check(p, depInfo, tmpInfo, workingQueue))
                                    workingQueue.Enqueue(new Tuple<int, Point>(currentRun, p));
                        }
                    }
                }
            }

            lock (populationArray)
            {
                foreach (var item in tmpInfo)
                    if (item != null)                               // TODO | dj | this should not be necessary!
                        populationArray[item.Item1] = item.Item2;
            }

            tmpInfo = null;     // deleting reference to encourage GC...

#if DEBUG
            Console.WriteLine(" -- Finished " + depInfo.Name);
#endif
        }

        /// <summary>
        /// Returns the initial System.Drawing.Point of the
        /// given DepartmentInfo
        /// </summary>
        private static Point CalculateInitialPoint(DepartmentInfo depInfo)
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
            return initialPoint;
        }

        /// <summary>
        /// Flattens a 2D-Point to a 1D-index.
        /// </summary>
        private static int FlattenPoint(Point p)
        {
            return p.X + (p.Y * WIDTH);
        }

        private static bool Check(Point p, DepartmentInfo dep, Tuple<int, PopulationCell>[] arr, Queue<Tuple<int, Point>> queue)
        {
            if (!dep.Coordinates.Contains(p))
                return false;                   // not part of the department.
            
            if (arr.Select((tpl) => { return (tpl != null) ? tpl.Item1 : -1; }).Contains(FlattenPoint(p)))
                return false;                   // already calculated.
            //int i = 0;
            //while (i < arr.Length && arr[i] != null)
            //    if (arr[i++].Item1 == FlattenPoint(p))
            //        return false;

            if (queue.Select((tpl) => { return tpl.Item2; }).Contains(p))
                return false;                   // already in queue.
            //foreach (var item in queue)
            //    if (item.Item2.Equals(p))
            //        return false;

            return true;
        }

        /// <summary>
        /// Checks whether the Point is valid or not.
        /// </summary>
        [Obsolete]
        private static bool CheckPoint(Point p, PopulationCell[] arr, Point[] points, Queue<Tuple<int, Point>> queue)
        {
            bool result = false;
            Parallel.ForEach(queue, (tpl, state) =>
                {
                    if (tpl.Item2.Equals(p))
                    {
                        result = true;
                        state.Break();
                    }
                });
            if (result)
                return false;

            if (p.X < 0 ||
                p.Y < 0 ||
                p.X >= WIDTH ||
                p.Y >= HEIGHT)
                return false;                               // out of global bound

            if (!points.Contains(p))
                return false;                               // out of local bound

            if (arr[FlattenPoint(p)].Humans.Length > 0)
                return false;                               // already taken

            return true;
        }
    }
}
