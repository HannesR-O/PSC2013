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
        //PopulationData
        public PopulationCell[] Population { get; private set; }

        //AreaData
        public Department[] Departments { get; private set; }
        public FederalState[] FederalStates { get; private set; }

        //TimeConstants
        public DayOfWeek CurrentDay { get; private set; }
        public EMonth CurrentMonth { get; private set; }
        public int CurrentTime { get; private set; }                // 0-23 Uhr

        //Used Disease
        public Disease CurrentDisease;

        public SimulationData()
        {
            FederalStates = new FederalState[16];
            Departments = new Department[401];
            Population = new PopulationCell[10808574];
            Population.Initialize<PopulationCell>();

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
            DepartmentMapReader dmr = new DepartmentMapReader(filePath);
#if DEBUG
            Console.WriteLine("Reading File...");
#endif
            DepartmentInfo[] deps = dmr.ReadFile();
            Image img = dmr.ReadImage();
#if DEBUG
            Console.WriteLine("Generating Matrix...");
#endif
            MatrixGenerator.GenerateMatrix(Population, deps, img.Width, img.Height);
        }
    }
}