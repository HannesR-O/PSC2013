using PSC2013.ES.Library.AreaData;
using PSC2013.ES.Library.Diseases;
using PSC2013.ES.Library.PopulationData;
using System;
using PSC2013.ES.Library.IO.Readers;
using System.Drawing;

namespace PSC2013.ES.Library.Simulation
{
    public class SimulationData
    {
        private DateTime _time;

        //PopulationData
        public PopulationCell[] Population { get; private set; }

        //Dead Humans
        public Tuple<Human, int, bool>[] Deaths { get; private set; } // Human, DeathCell, CauseOfDeath ( 0 = natural, 1 = disease) //TODO |t| Maybe not the best solution...

        //AreaData
        public Department[] Departments { get; private set; }
        public FederalState[] FederalStates { get; private set; }

        //TimeConstants
        public EMonth CurrentMonth { get { return (EMonth)_time.Month; } }
        public DayOfWeek CurrentDay { get { return _time.DayOfWeek; } }
        public int CurrentHour { get { return _time.Hour; } }                // 0-23 Uhr

        //Used Disease
        public Disease CurrentDisease;

        // Used to check whether the currently set data is ready for simulating
        //TODO: |f| add relevant checks
        public bool IsValid
        {
            get { return CurrentDisease != null && Population != null; }
        }

        public SimulationData()
        {
            FederalStates = new FederalState[16];
            Departments = new Department[401];
            Population = new PopulationCell[10808574];
            Population.Initialize<PopulationCell>();

            _time = DateTime.Now;

#if DEBUG
            foreach (var item in Population)
            {
                for (int i = 0; i < 8; i++)
                {
                    item.AddHuman(Human.Create(EGender.Female, 60, 7331));
                }
            }
#endif
        }

        /// <summary>
        /// Reads the information out of
        /// the given file and sets the
        /// corresponding values.
        /// </summary>
        /// <param name="filePath">The path to the .dep-file.</param>
        /// <exception cref="IOException">Might be thrown.</exception>
        public void InitializeFromFile(string filePath)       // TODO | dj | might be extracted to another class...
        {
            var reader = new DepartmentMapReader(filePath);
#if DEBUG
            Console.WriteLine("Reading File...");
#endif
            DepartmentInfo[] deps = reader.ReadFile();
            Image img = reader.ReadImage();
#if DEBUG
            Console.WriteLine("Generating Matrix...");
#endif
            MatrixGenerator.GenerateMatrix(Population, deps, img.Width, img.Height);
        }

        public void Tick()
        {
            //TODO: |f| consider adding tick timspan
            _time = _time.AddHours(1);
        }
    }
}