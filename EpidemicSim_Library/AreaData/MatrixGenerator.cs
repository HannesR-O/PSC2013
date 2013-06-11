using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PSC2013.ES.Library;
using PSC2013.ES.Library.IO.OutputTargets;
using PSC2013.ES.Library.PopulationData;

namespace PSC2013.ES.Library.AreaData
{
    public class GeneratorEvent : EventArgs
    {
        public string Name { get; set; }
        public int Total { get; set; }
    }

    // TODO | dj | can't implement OutputTargetWriter as a cause of static...
    public class MatrixGenerator : OutputTargetWriter
    {
        private int WIDTH = 2814;
        private int HEIGHT = 3841;

        private bool _dummy;

        public event EventHandler<GeneratorEvent> DepartmentCalculationFinished;

        public MatrixGenerator() : base("MG")
        {
            _dummy = false;
        }

        public MatrixGenerator(bool dummy) : this()
        {
            _dummy = dummy;
        }


        /// <summary>
        /// Generates the ultimative matrix. It spreads
        /// the people ALLL over their departments.
        /// 
        /// **In-Place**
        /// </summary>
        /// <param name="populationArray">The already initialized
        /// PopulationCell-matrix which will be used for most stuff.
        /// This array will be modified!</param>
        /// <param name="humanArray">The array of Humans. This array will be modified!</param>
        /// <param name="rawData">The raw DepartmentInfos. This array will be modified!</param>
        /// <param name="width">width of the populationArray (used for offsets)</param>
        /// <param name="height">height of the populationArray (used for offsets)</param>
        /// <returns>The input-populationCell-array (modified).</returns>
        public void GenerateMatrix(
            PopulationCell[] populationArray,
            Human[] humanArray,
            IEnumerable<DepartmentInfo> rawData,
            int width, int height)
        {
            WIDTH = width;
            HEIGHT = height;

            if (populationArray.Length != WIDTH * HEIGHT)
                throw new ArgumentException(
                    "The argument has to be an array of PopulationCell with a length of '" + WIDTH * HEIGHT + "'.",
                    "populationArray");

            Combiner comb = new Combiner(populationArray, humanArray);
            int departmentsCount = rawData.Count();

            // the parallel call.
            Parallel.ForEach(rawData, Constants.DEFAULT_PARALLELOPTIONS,
                (item) => {
                    Human[] humans;
                    var res = _dummy? DummyPopulate(item, out humans)
                                    : Populate(item, out humans);         // populate the department.
                    comb.Enqueue(res, humans);
                    res = null;
                    humans = null;
                    
                    DepartmentCalculationFinished.Raise(this, new GeneratorEvent
                    {
                        Name = item.Name,
                        Total = departmentsCount
                    });
                    WriteMessage("Calculated: " + item.Name);
                });
            comb.Wait();
            comb.Dispose();
        }

        /// <summary>
        /// The standard method to populate.
        /// </summary>
        private Tuple<int, PopulationCell>[] Populate(DepartmentInfo depInfo, out Human[] humanArray)
        {
            // the count of cells.
            int areaSize = depInfo.Coordinates.Length;

            // precalculating humans. (~ +- 10%)
            for (int i = 0; i < depInfo.Population.Length; ++i)
                depInfo.Population[i] = (int)Math.Round(
                    depInfo.Population[i] * (1 - (RANDOM.Next(20) - 10) / 100f));

            // initializing array.
            var resultArray = new Tuple<int, PopulationCell>[areaSize];
            int resultIndex = 0;

            // the origin used as fixpoint.
            Point origin = CalculateInitialPoint(depInfo.Coordinates);

            // maximum distance possible. (returns a relative small number)
            int maxDistance = depInfo.Coordinates.Max(p => p.Distance(origin)) + 1;

            // array of factors
            double[] factors = new double[maxDistance];
            factors[0] = 1.5;                           // start factor.
            for (int i = 1; i < maxDistance; i++)       // creating every factor for each distance.
            {
                //TODO | dj | randomise
                // (-(1/maxDistance * i)^2 + 1.75) * 100
                double one = 1d / maxDistance * i;
                double two = Math.Pow(one, 2);
                double three = factors[0];
                double four = three - two;
                factors[i] = four;
            }
            
            // array for each age-group, holding a list of Tuple of cell-indices and count.
            Queue<Tuple<int, ushort>>[] agesOfCells = new Queue<Tuple<int, ushort>>[8];
            agesOfCells.Initialize<Queue<Tuple<int, ushort>>>();

            int humanCount = 0;

            // going through all points and set the counts.
            foreach (Point point in depInfo.Coordinates)
            {
                PopulationCell cell = new PopulationCell();
                int cellIndex = point.Flatten(WIDTH);

                double factor = factors[point.Distance(origin)];
                for (int i = 0; i < 8; ++i)
                {
                    ushort toSet = (ushort)Math.Round(depInfo.Population[i] / (double)areaSize * factor);
                    cell.Data[i] = toSet;
                    agesOfCells[i].Enqueue(new Tuple<int,ushort>(cellIndex, toSet));
                    depInfo.Population[i] -= toSet;
                    //if (cell.Data[i] == 0)
                    //    Console.WriteLine("0 people in {0}", cellIndex);
                }
                if (cell.Total == 0 && depInfo.Population.Sum() != 0)
                {
                    int j = 0;
                    do
                    {
                        j = RANDOM.Next(8);
                    } while (depInfo.Population[j] == 0);

                    cell.Data[j] = 1;
                    agesOfCells[j].Enqueue(new Tuple<int,ushort>(cellIndex, 1));
                    depInfo.Population[j] -= 1;
                }
                areaSize--;

                humanCount += cell.Total;

                resultArray[resultIndex++] = new Tuple<int,PopulationCell>(cellIndex, cell);
            }

            // initializing human array
            humanArray = new Human[humanCount];
            int humanIndex = 0;

            // going through all ages and creating the humans.
            for (int i = 0; i < 8; ++i)
            {
                var queue = agesOfCells[i];
                var bounds = GetAgeBounds(i);

                // age-bounds (for random).
                int lowerAge = bounds.Item1;
                int upperAge = bounds.Item2;

                // gender.
                EGender gender = (i < 4) ? EGender.Male : EGender.Female;

                // for each cell.
                while (queue.Count > 0)
                //foreach (Tuple<int, ushort> cellTuple in queue)
                {
                    var cellTuple = queue.Dequeue();

                    int cellIndex = cellTuple.Item1;
                    ushort count = cellTuple.Item2;

                    // for each human (who shall be created).
                    ushort c = count;
                    while (c-- > 0)
                    //for (int c = 0; c < count; ++c)
                    {
                        int thisHumanAge = RANDOM.Next(lowerAge, upperAge + 1);
                        Human thisHuman = Human.Create(gender, thisHumanAge, cellIndex);
                        humanArray[humanIndex++] = thisHuman;
                    }
                }

                agesOfCells[i] = null;  // not necessary, but who knows :P
            }

            return resultArray;
        }

        /// <summary>
        /// The Dummy-implementation.
        /// </summary>
        private Tuple<int, PopulationCell>[] DummyPopulate(DepartmentInfo depInfo, out Human[] humanArray)
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

                    var bounds = GetAgeBounds(i);
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

        # region OBSOLETE
        /// <summary>
        /// Populate the given department.
        /// </summary>
        [Obsolete] // just here because it is a cool one :P
        private Tuple<int, PopulationCell>[] PopulateDepartment(DepartmentInfo depInfo, out Human[] humanArray)
        {
            List<Human> humanList = new List<Human>(depInfo.GetTotal());

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

                    var bounds = GetAgeBounds(i);                              // the age-boundaries for the corresponding age-group.
                    int lowerAgeBound = bounds.Item1;
                    int upperAgeBound = bounds.Item2;

                    for (int setCount = 0; setCount < numberOfPeopleToSet; setCount++)
                    {
                        int thisAge = RANDOM.Next(lowerAgeBound, upperAgeBound + 1);
                        Human thisHuman = Human.Create(gender, thisAge, currentPoint.Flatten(WIDTH));
                        humanList.Add(thisHuman);
                        currentCell.Data[i]++;                              // 'adds' the human to its cell.

                        depInfo.Population[i]--;                            // 'removes' the human out of the population.
                    }
                }

                areaSize--;                                                 // 'removes' point from rest-area.

                resultArray[resultArrayIndex++] = new Tuple<int, PopulationCell>(
                        currentPoint.Flatten(WIDTH), currentCell);
            }

            humanArray = humanList.ToArray();
            humanList = null;
            return resultArray;
        }
        #endregion

        #region Help methods
        /// <summary>
        /// Returns the age-boundaries for the given age-group.
        /// </summary>
        private Tuple<int, int> GetAgeBounds(int i)
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
        private Point CalculateInitialPoint(Point[] coords)
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
        #endregion
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
                    humans = null; // release...
                }
            }
        }
    }
}