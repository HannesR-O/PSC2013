using PSC2013.ES.Library.AreaData;
using PSC2013.ES.Library.Diseases;
using PSC2013.ES.Library.PopulationData;
using System;

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
        public static int CurrentTime; // 0-23 Uhr

        //Used Disease
        public static Disease CurrentDisease;

        static SimulationData()
        {
            FederalStates = new FederalState[16];
            Departments = new Department[401];
            Population = new PopulationCell[10808574];

            for (int i = 0; i < Population.Length; ++i)
                Population[i].Init();
        }
    }
}