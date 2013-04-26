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

        #region DUMMY METHODS
        public static void GenerateDummyMatrix(
            PopulationCell[] populationArray,
            IEnumerable<DepartmentInfo> rawData,
            int width, int height)
        {
            WIDTH = width;
            HEIGHT = height;

            int degree = (Environment.ProcessorCount >> 1);     // half of processors (we don't wanna kill it :P)
            degree = Math.Max(1, degree);                       // but minimum of 1
            degree = -1;
            Parallel.ForEach(rawData, new ParallelOptions() { MaxDegreeOfParallelism = degree },
                (item) =>
                {
#if DEBUG
                    Console.WriteLine("Started " + item.Name);
#endif
                    var res = DummyPopulate(item);
                    lock (populationArray)
                    {
                        foreach (var tpl in res)
                            populationArray[tpl.Item1] = tpl.Item2;
                    }

                    res = null;
#if DEBUG
                    Console.WriteLine(" -- Finished " + item.Name);
#endif
                });
            //foreach (var item in rawData)
            //{
            //    Console.Write("Started " + item.Name);
            //    var res = DummyPopulate(item);
            //    foreach (var tpl in res)
            //        populationArray[tpl.Item1] = tpl.Item2;
            //    Console.WriteLine(" -- finished");
            //}
        }

        private static Tuple<int, PopulationCell>[] DummyPopulate(DepartmentInfo depInfo)
        {
            int areaSize = depInfo.Coordinates.Length;

            Tuple<int, PopulationCell>[] tmpArray = new Tuple<int, PopulationCell>[areaSize];
            int tmpCounter = 0;

            int[] popsPerPoint = depInfo.Population.Select(x => x / areaSize).ToArray();

            foreach (Point point in depInfo.Coordinates)
            {
                PopulationCell cell = new PopulationCell();

                for (int i = 0; i < 8; i++)
                {
                    EGender gender = (i < 4) ? EGender.Male : EGender.Female;

                    var bounds = GetBounds(i);
                    int lowerAgeBound = bounds.Item1;
                    int upperAgeBound = bounds.Item2;

                    for (int n = 0; n < popsPerPoint[i]; n++)
                    {
                        int thisAge = RANDOM.Next(lowerAgeBound, upperAgeBound + 1);
                        Human thisHuman = Human.Create(gender, thisAge, FlattenPoint(point));
                        cell.AddHuman(thisHuman);
                    }
                }

                tmpArray[tmpCounter++] = new Tuple<int, PopulationCell>(FlattenPoint(point), cell);

            }

            return tmpArray;
        }
        #endregion DUMMY METHODS

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
                (item) => {
#if DEBUG
                    Console.WriteLine("Started " + item.Name);
#endif
                    var res = Populate(item);
                    lock (populationArray) {
                        foreach (var tpl in res)
                            if (tpl != null)    // TODO | dj | this should never have to be necessary... -.-
                                populationArray[tpl.Item1] = tpl.Item2;
                    }

                    res = null;
#if DEBUG
                    Console.WriteLine(" -- Finished " + item.Name);
#endif
                });
            //foreach (var item in rawData)
            //{
            //    PopulateDepartment(item, populationArray);
            //}

            return populationArray;
        }

        private static Tuple<int, PopulationCell>[] Populate(DepartmentInfo depInfo)
        {
            int areaSize = depInfo.Coordinates.Length;                      // number of point to be populated.

            Tuple<int, PopulationCell>[] finishedArray =                    // the array which will also be returned.
                new Tuple<int, PopulationCell>[areaSize];
            int arrayCounter = 0;                                           // the working counter/index for the above array.

            Queue<Tuple<int, Point>> workingQueue =                         // the queue for the points an their run-number.
                new Queue<Tuple<int, Point>>();

            Point initialPoint = CalculateInitialPoint(depInfo.Coordinates);// the start point for the algorithm.
            workingQueue.Enqueue(new Tuple<int, Point>(0, initialPoint));   // enqueuing the first point with the run-number 0.

            int approxMaxRuns =                                             // the approx. maximum of runs, needed for this department.
                CalculateMaxRuns(initialPoint, depInfo.Coordinates) + 1;

            int runDifferenceFactor = 225;                                  // factor for the drop-like behaviour. changes every run.

            while (workingQueue.Count > 0)                                  // while there are still points to be used, do magic.
            {
                var currentTuple = workingQueue.Dequeue();                  // dequeuing first item for usage.
                int currentRun = currentTuple.Item1;
                Point currentPoint = currentTuple.Item2;
                int currentIndex = FlattenPoint(currentPoint);

                PopulationCell currentCell = new PopulationCell();          // the PopulationCell to work on.

                for (int i = 0; i < 8; i++)                                 // for each age-group
                {
                    int additionalRand = RANDOM.Next(10) - 5;
                    int numberForEvenSpread =                               // number of humans if everything would be even/the same.
                        (int)(depInfo.Population[i] / (float)areaSize);
                    int numberOfPeopleToSet =                               // number of humans to be set for this age-group.
                        (int)(numberForEvenSpread *
                        (runDifferenceFactor + additionalRand) / 100f);

                    EGender gender = (i < 4) ?                              // the first four are male, the last female.
                        EGender.Male : EGender.Female;

                    var bounds = GetBounds(i);                              // the age-boundaries for the corresponding age-group.
                    int lowerAgeBound = bounds.Item1;
                    int upperAgeBound = bounds.Item2;

                    for (int setCount = 0; setCount < numberOfPeopleToSet; setCount++)
                    {
                        int thisAge = RANDOM.Next(lowerAgeBound, upperAgeBound + 1);
                        Human thisHuman = Human.Create(gender, thisAge, currentIndex);
                        currentCell.AddHuman(thisHuman);                    // add the human to its cell.

                        depInfo.Population[i]--;                            // 'removes' the human out of the population.
                    }
                }

                areaSize--;                                                 // 'removes' point from rest-area.
                // human-creation is done here. now only management of the next points.

                /* got an idea how to do it in another way: use instead of the run only the factor... */
                if (workingQueue.Count(tpl => tpl.Item1 == currentRun) == 0)// number of points of the same 'run' has to be 0.
                {
                    int randomDown = 0 - RANDOM.Next(runDifferenceFactor / 3) + 10;
                    randomDown = (int)(randomDown * (1 - (float)currentRun / approxMaxRuns + 0.01));
                    if (runDifferenceFactor + randomDown <= 0) randomDown = 5;
                    runDifferenceFactor += randomDown;                      // adjusting the factor for a new run.
                }

                if (areaSize > 0)
                {
                    currentRun++;
                                                                            // 8-way
                    for (int y = -1; y <= 1; y++)
                    {
                        for (int x = -1; x <= 1; x++)
                        {
                            if (!(x == 0 && y == 0))
                            {
                                Point pointToBeAdded =                      // the possible new Point.
                                    new Point(currentPoint.X + x, currentPoint.Y + y);
                                if (Check(pointToBeAdded, depInfo.Coordinates, finishedArray, workingQueue))
                                    workingQueue.Enqueue(new Tuple<int, Point>(currentRun, pointToBeAdded));
                            }
                        }
                    }
                }

                // do magic

                finishedArray[arrayCounter++] =                             // 'adding' the cell to the finished array.
                    new Tuple<int, PopulationCell>(currentIndex, currentCell);
            }
            return finishedArray;
        }

        private static int CalculateMaxRuns(Point zeroP, Point[] points)
        {
            int maxX = points.Max(p => p.X) - zeroP.X;
            int minX = zeroP.X - points.Min(p => p.X);
            int maxY = points.Max(p => p.Y) - zeroP.Y;
            int minY = zeroP.Y - points.Min(p => p.Y);

            int extremumX = Math.Max(maxX, minX);
            int extremumY = Math.Max(maxY, minY);

            return Math.Max(extremumX, extremumY);
        }

        private static Tuple<int, int> GetBounds(int i)
        {
            int lower = 1;
            int upper = 110;
            // if is to be called faster than switch...
            if (i % 4 == 0)         // first age-group
                upper = 6;
            else if (i % 4 == 1)    // second age-group
            {
                lower = 7;
                upper = 25;
            }
            else if (i % 4 == 2)    // third age-group
            {
                lower = 26;
                upper = 60;
            }
            else
                lower = 61;
            return new Tuple<int, int>(lower, upper);
        }

        [Obsolete]
        private static void PopulateDepartment(DepartmentInfo depInfo, PopulationCell[] populationArray)
        {
#if DEBUG
            Console.WriteLine("Calculating " + depInfo.Name);
#endif
            Point initialPoint = CalculateInitialPoint(depInfo.Coordinates);

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
                                if (Check(p, depInfo.Coordinates, tmpInfo, workingQueue))
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
        private static Point CalculateInitialPoint(Point[] coords)
        {
            int minX = WIDTH;
            int minY = HEIGHT;
            int maxX = 0;
            int maxY = 0;

            foreach (Point item in coords)
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
            if (!coords.Any(p => p.Equals(initialPoint)))
                initialPoint = coords[0];
            return initialPoint;
        }

        /// <summary>
        /// Flattens a 2D-Point to a 1D-index.
        /// </summary>
        private static int FlattenPoint(Point p)
        {
            return p.X + (p.Y * WIDTH);
        }

        /// <summary>
        /// Checks whether the Point is valid or not.
        /// </summary>
        private static bool Check(Point p, Point[] coords, Tuple<int, PopulationCell>[] arr, Queue<Tuple<int, Point>> queue)
        {
            if (!coords.Contains(p))
                return false;                   // not part of the department.
            
            if (arr.Select((tpl) => { return (tpl != null) ? tpl.Item1 : -1; }).Contains(FlattenPoint(p)))
                return false;                   // already calculated.

            if (queue.Select((tpl) => { return tpl.Item2; }).Contains(p))
                return false;                   // already in queue.

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
