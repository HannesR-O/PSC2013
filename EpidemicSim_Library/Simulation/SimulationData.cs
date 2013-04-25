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
        public static PopulationCell[] Population;

        //AreaData
        public static Department[] Departments;
        public static FederalState[] FederalStates;

        //TimeConstants
        public static DayOfWeek CurrentDay;
        public static EMonth CurrentMonth;
        public static int CurrentTime;          // 0-23 Uhr

        //Used Disease
        public static Disease CurrentDisease;

        static SimulationData()
        {
            FederalStates = new FederalState[16];
            Departments = new Department[401];
            Population = new PopulationCell[10808574];
            Population.Initialize<PopulationCell>();

#if DEBUG
            for (int i = 0; i < 6861016; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Population[i].AddHuman(Human.Create(EGender.Female, 22, 1337));
                }
                if (i % 10000 == 0)
                    Console.WriteLine("Finished cell: " + i);
            }
#endif
        }

        /// <summary>
        /// Reads the information out of
        /// the given file and sets the
        /// corresponding variables.
        /// </summary>
        /// <param name="filePath">The path to the .dep-file.</param>
        /// <param name="matrix">The PopulationCell-array...</param>
        /// <exception cref="IOException">Might be thrown.</exception>
        public void UseData(string filePath, PopulationCell[] matrix)       // TODO | dj | might be extracted to another class...
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
            matrix = MatrixGenerator.GenerateMatrix(matrix, deps, img.Width, img.Height);
            Population = matrix; // not necessary, because GenerateMatrix is In-Place.
        }
    }
}