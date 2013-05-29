using PSC2013.ES.Library.AreaData;
using PSC2013.ES.Library.Diseases;
using PSC2013.ES.Library.IO.Readers;
using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library.Snapshot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace PSC2013.ES.Library.Simulation
{
    public class SimulationData
    {
        private const int ARRAY_DEATHS_DEFAULT_SIZE = 0x8; 
        private const float ARRAY_DEATHS_EXPAND_FACTOR = 1.5f;

        private DateTime _time;

        //IOData
        public int ImageWidth { get; private set; }
        public int ImageHeight { get; private set; }

        //PopulationData
        public PopulationCell[] Cells { get; private set; }
        public Human[] Humans { get; private set;}

        //Dead Humans
        public HumanSnapshot[] Deaths { get; private set; }
        public int DeathCount { get; private set; }

        //AreaData
        public Department[] Departments { get; private set; }
        public FederalState[] FederalStates { get; private set; }

        //TimeConstants
        public EMonth CurrentMonth { get { return (EMonth)_time.Month; } }
        public DayOfWeek CurrentDay { get { return _time.DayOfWeek; } }
        public int CurrentHour { get { return _time.Hour; } }                // 0-23 Uhr

        //Used Disease
        public Disease DiseaseToSimulate { get; set; }

        // Used to check whether the currently set data is ready for simulating
        //TODO: |f| add relevant checks
        public bool IsValid
        {
            get { return DiseaseToSimulate != null && Cells != null; }
        }

        public SimulationData()
        {
            Cells = new PopulationCell[0];          //  10808574
            Humans = new Human[0];                  // ~82000000
            Deaths = new HumanSnapshot[0];
            DeathCount = 0;

            FederalStates = new FederalState[0];    // 16
            Departments = new Department[0];        // 401

            _time = DateTime.Now;
        }

        /// <summary>
        /// Reads the information out of
        /// the given file and sets the
        /// corresponding values.
        /// </summary>
        /// <param name="filePath">The path to the .dep-file.</param>
        /// <exception cref="IOException">Might be thrown.</exception>
        public void InitializeFromFile(string filePath)
        {
            var reader = new DepartmentMapReader(filePath);

#if DEBUG
            Console.WriteLine("Reading File...");
#endif
            DepartmentInfo[] deps = reader.ReadFile();
            
            Image img = reader.ReadImage();
            ImageWidth = img.Width;
            ImageHeight = img.Height;

#if DEBUG
            Console.WriteLine("Calculating Total-Population...");
#endif
            int maxPopulation = deps.Sum(x => x.GetTotal());        // getting maximum population
            Humans = new Human[(int)(maxPopulation * 1.05f)];       // adding 5% :)

#if DEBUG
            Console.WriteLine("Generating Matrix...");
#endif
            // TODO | dj | should be changed back to .GenerateMatrix...
            Cells = new PopulationCell[ImageWidth * ImageHeight];
            MatrixGenerator.GenerateMatrix(Cells, Humans, deps, ImageWidth, ImageHeight);
#if DEBUG
            Console.WriteLine("...Matrix generated.");
#endif
        }

        public void AddDeadPeople(IList<HumanSnapshot> deadPeople)
        {
            while (DeathCount + deadPeople.Count > Deaths.Length)
                ExpandDeathArray();

            foreach (HumanSnapshot deadOne in deadPeople)
            {
                Deaths[DeathCount++] = deadOne;
            }
        }

        private void ExpandDeathArray()
        {
            var newArray = new HumanSnapshot[(int) (Deaths.Length <= 1 ? ARRAY_DEATHS_DEFAULT_SIZE : Deaths.Length*ARRAY_DEATHS_EXPAND_FACTOR)];
            Deaths.CopyToOtherArray(newArray);
            Deaths = newArray;
        }

        /// <summary>
        /// Performs a Tick on the SimulationData.
        /// </summary>
        /// <param name="hourCount">A value determining how many hours pass in this tick.</param>
        public void DoTick(int hourCount)
        {
            if(hourCount < 1)
                throw new ArgumentOutOfRangeException("hourCount", "The given hourCount must be greater than 1.");

            _time = _time.AddHours(hourCount);
        }
    }
}