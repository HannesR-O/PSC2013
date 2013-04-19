using PSC2013.ES.Library.AreaData;
using PSC2013.ES.Library.Diseases;
using PSC2013.ES.Library.PopulationData;
using System;

namespace PSC2013.ES.Library.Simulation
{
    public class SimulationData
    {
        private static string defaultHuman = Human.CreateHuman(EGender.Female, 23, 1337).ToBase64();

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
                    Population[i].AddHuman(Human.FromBase64(defaultHuman));
                }
                if (i % 10000 == 0)
                    Console.WriteLine("Finished cell: " + i);
            }
#endif
        }
    }
}