using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
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
        /// <summary>
        /// Generates a Dummy-Matrix. All cells will
        /// be department-wide even filled.
        /// 
        /// For parameters see GenerateMatrix.
        /// </summary>
        public static void GenerateDummyMatrix(
            PopulationCell[] populationArray,
            Human[] humanArray,
            IEnumerable<DepartmentInfo> rawData,
            int width, int height)
        {
            WIDTH = width;
            HEIGHT = height;

            Combiner comb = new Combiner(populationArray, humanArray);

            int degree = (Environment.ProcessorCount >> 1);     // half of processors (we don't wanna kill it :P)
            degree = Math.Max(1, degree);                       // but minimum of 1
            //degree = -1;
            Parallel.ForEach(rawData, new ParallelOptions() { MaxDegreeOfParallelism = degree },
                (item) =>
                {
//#if DEBUG
//                    Console.WriteLine("Started " + item.Name);
//#endif
                    Human[] humans;
                    var res = DummyPopulate(item, out humans);
                    comb.Enqueue(res, humans);
                    //lock (populationArray)
                    //{
                    //    foreach (var tpl in res)
                    //        populationArray[tpl.Item1] = tpl.Item2;
                    //}
                    //lock (humanArray)
                    //{
                    //    for (int i = Array.FindIndex(humanArray, x => x.IsDead()), j = 0;
                    //        j < humans.Length; i++, j++)
                    //    {
                    //        humanArray[i] = humans[j];
                    //    }
                    //}

                    res = null;
//#if DEBUG
//                    Console.WriteLine(" -- Finished " + item.Name);
//#endif
                });
#if DEBUG
            Console.WriteLine("Waiting for transferring data...");
#endif
            comb.Wait();
            comb.Dispose();
        }

        private static Tuple<int, PopulationCell>[] DummyPopulate(DepartmentInfo depInfo, out Human[] humanArray)
        {
            int areaSize = depInfo.Coordinates.Length;

            Tuple<int, PopulationCell>[] tmpArray = new Tuple<int, PopulationCell>[areaSize];
            int tmpCounter = 0;
            humanArray = new Human[depInfo.GetTotal()];
            int humanCounter = 0;
            
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
                        humanArray[humanCounter++] = Human.Create(gender, thisAge, point.Flatten(WIDTH));
                        cell.Data[i]++;
                    }
                }

                tmpArray[tmpCounter++] = new Tuple<int, PopulationCell>(point.Flatten(WIDTH), cell);

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
            // TODO | dj | continue...
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
                    var res = PopulateDepartment(item);         // populate the department.
                    lock (populationArray) {                    // store the new info in the original array.
                        foreach (var tpl in res)
                            populationArray[tpl.Item1] = tpl.Item2;
                    }

                    res = null;
#if DEBUG
                    Console.WriteLine(" -- Finished " + item.Name);
#endif
                });

            return populationArray;
        }

        /// <summary>
        /// Populate the given department.
        /// </summary>
        private static Tuple<int, PopulationCell>[] PopulateDepartment(DepartmentInfo depInfo)
        {
            int areaSize = depInfo.Coordinates.Length;                      // number of points to be populated.
            Tuple<int, PopulationCell>[] resultArray =                      // the array which will be returned.
                new Tuple<int,PopulationCell>[areaSize];
            int resultArrayIndex = 0;                                       // running index for the array.

            Point origin = CalculateInitialPoint(depInfo.Coordinates);      // the origin as an fixpoint for every point.

            int maximumDistance = depInfo.Coordinates.Max(                  // the maximum distance possible.
                point => point.Distance(origin)) + 1;

            int[] factors = new int[maximumDistance];                       // array of factor for each distance.
            factors[0] = 225;                                               // start factor.
            for (int i = 1; i < maximumDistance; i++)                       // creating every factor for each distance.
            {
                int previousFactor = factors[i - 1];
                int minus = (int)(previousFactor / 3f / 6);
                int random = RANDOM.Next(previousFactor / 3) - minus;
                random = (int)(random * (1 - i / (float)maximumDistance));
                if (previousFactor - random <= 0) random = 5;
                factors[i] = previousFactor - random;
            }

            foreach (Point currentPoint in depInfo.Coordinates)
            {
                int currentDistance = currentPoint.Distance(origin);        // distance of this point to the origin.
                PopulationCell currentCell = new PopulationCell();

                for (int i = 0; i < 8; i++)                                 // for each age-group.
                {
                    int additionalRand = RANDOM.Next(10) - 5;
                    int numberForEvenSpread =                               // number of humans if everything would be even/the same.
                        (int)(depInfo.Population[i] / (float)areaSize);
                    int numberOfPeopleToSet =                               // number of humans to be set for this age-group.
                        (int)(numberForEvenSpread *
                        (factors[currentDistance] + additionalRand) / 100f);

                    EGender gender = (i < 4) ?                              // the first four are male, the last female.
                        EGender.Male : EGender.Female;

                    var bounds = GetBounds(i);                              // the age-boundaries for the corresponding age-group.
                    int lowerAgeBound = bounds.Item1;
                    int upperAgeBound = bounds.Item2;

                    for (int setCount = 0; setCount < numberOfPeopleToSet; setCount++)
                    {
                        int thisAge = RANDOM.Next(lowerAgeBound, upperAgeBound + 1);
                        Human thisHuman = Human.Create(
                            gender, thisAge, currentPoint.Flatten(WIDTH));
                        //currentCell.AddHuman(thisHuman);                    // add the human to its cell.

                        depInfo.Population[i]--;                            // 'removes' the human out of the population.
                    }
                }

                areaSize--;                                                 // 'removes' point from rest-area.

                resultArray[resultArrayIndex++] = new Tuple<int, PopulationCell>(
                        currentPoint.Flatten(WIDTH), currentCell);
            }

            return resultArray;
        }

        /// <summary>
        /// Returns the age-boundaries for the given age-group.
        /// </summary>
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
    }

    class Combiner
    {
        private ConcurrentQueue<Tuple<int, PopulationCell>[]> _queueCells;
        private ConcurrentQueue<Human[]> _queueHumans;
        private Task _taskCells;
        private Task _taskHumans;
        private Human[] _humans;
        private PopulationCell[] _cells;

        private int _humanPoint;

        public Combiner(PopulationCell[] cellArray, Human[] humanArray)
        {
            _cells = cellArray;
            _humans = humanArray;
            _humanPoint = 0;
            _queueCells = new ConcurrentQueue<Tuple<int, PopulationCell>[]>();
            _queueHumans = new ConcurrentQueue<Human[]>();
        }

        public void Enqueue(Tuple<int, PopulationCell>[] cells, Human[] humans)
        {
            _queueCells.Enqueue(cells);
            _queueHumans.Enqueue(humans);

            if (_taskCells == null || _taskCells.Status != TaskStatus.Running)
                _taskCells = Task.Run(() => AddCells());
            if (_taskHumans == null || _taskHumans.Status != TaskStatus.Running)
                _taskHumans = Task.Run(() => AddHumans());
        }

        public void Wait()
        {
            Task[] tasks = new Task[2];
            int i = 0;
            if (_taskCells != null && _taskCells.Status == TaskStatus.Running)
                tasks[i++] = _taskCells;
            if (_taskHumans != null && _taskHumans.Status == TaskStatus.Running)
                tasks[i++] = _taskHumans;
            Task[] taskArr = new Task[tasks.Count(x => x != null)];
            for (int j = 0; j < taskArr.Length; ++j)
                taskArr[j] = tasks[j];
            Task.WaitAll(taskArr);
        }

        public void Dispose()
        {
            if (_taskCells != null)
                _taskCells.Dispose();
            if (_taskHumans != null)
                _taskHumans.Dispose();
            _taskCells = null;
            _taskHumans = null;
        }

        private void AddCells()
        {
            while (!_queueCells.IsEmpty)
            {
                Tuple<int, PopulationCell>[] tpls;
                if (_queueCells.TryDequeue(out tpls))
                {
                    foreach (var tpl in tpls)
                        _cells[tpl.Item1] = tpl.Item2;
                }
            }
        }

        private unsafe void AddHumans()
        {
            while (!_queueHumans.IsEmpty)
            {
                Human[] humans;
                if (_queueHumans.TryDequeue(out humans))
                {
                    int i = _humanPoint;
                    //Interlocked.Add(ref _humanPoint, humans.Length);
                    _humanPoint += humans.Length;
                    fixed (Human* humanPtr = _humans)
                    {
                        fixed (Human* miniHumanPtr = humans)
                        {
                            for (Human* human = humanPtr + i, miniHuman = miniHumanPtr;
                                miniHuman < miniHumanPtr + humans.Length; ++human, ++miniHuman)
                            {
                                *human = *miniHuman;
                            }
                        }
                    }
                }
            }
        }
    }
}