﻿using PSC2013.ES.Library.AreaData;
using PSC2013.ES.Library.DiseaseData;
using PSC2013.ES.Library.IO.Readers;
using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library.Snapshot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using PSC2013.ES.Library.IO.OutputTargets;

namespace PSC2013.ES.Library.Simulation
{
    public class SimulationData : OutputTargetWriter
    {
        private const int ARRAY_DEATHS_DEFAULT_SIZE = 0x8; 
        private const float ARRAY_DEATHS_EXPAND_FACTOR = 1.5f;

        private DateTime _time;

        // Event
        public event EventHandler<GeneratorEventArgs> DepartmentCalculated;
        public event EventHandler<ContinuationEventArgs> ReadFileIterationPassed;

        //IOData
        public int ImageWidth { get; private set; }
        public int ImageHeight { get; private set; }

        //PopulationData
        public PopulationCell[] Cells { get; private set; }
        public Human[] Humans { get; private set;}

        //Dead Humans
        public HumanSnapshot[] Deaths { get; private set; }
        public int DeathCount { get; private set; }

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

        public SimulationData(DateTime startTime) : base("SD")
        {
            Cells = new PopulationCell[0];          //  10808574
            Humans = new Human[0];                  // ~82000000
            Deaths = new HumanSnapshot[0];
            DeathCount = 0;

            _time = startTime;
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
            reader.IterationPassed += ReadFileIterationPassed.Raise;

            DepartmentInfo[] deps = reader.ReadFile();
            
            Image img = reader.ReadImage();
            ImageWidth = img.Width;
            ImageHeight = img.Height;

            WriteMessage("Calculating Total-Population...");
            int maxPopulation = deps.Sum(x => x.GetTotal());        // getting maximum population
            Humans = new Human[(int)(maxPopulation * 1.05f)];       // adding 5% :)

            WriteMessage("Generating Matrix...");
            Cells = new PopulationCell[ImageWidth * ImageHeight]; 

            MatrixGenerator mg = new MatrixGenerator(false);
            mg.DepartmentCalculationFinished += DepartmentCalculated.Raise;
            mg.GenerateMatrix(Cells, Humans, deps, ImageWidth, ImageHeight);

            WriteMessage("...Matrix generated.");
        }

        /// <summary>
        /// Resets Deaths
        /// </summary>
        public void ClearDeaths()
        {
            Deaths = new HumanSnapshot[0];
            DeathCount = 0;
        }

        /// <summary>
        /// Adds the given list of humansnapshots to the simulationdata
        /// </summary>
        /// <param name="deadPeople">The list of dead people to add</param>
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