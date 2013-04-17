using PSC2013.ES.Library.AreaData;
using PSC2013.ES.Library.Diseases;
using PSC2013.ES.Library.PopulationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulator
{
    public class SimulationData
    {
        //PopulationData
        public static PopulationCell[] Population;

        //AreaData
        public static Departement[] Departements;
        public static FederalState[] FederalStates;

        //TimeConstants
        public static Day CurrentDay;
        public static Month CurrentMonth;
        public static DayTime CurrentDayTime;
        public static int CurrentTime; // 0-23 Uhr

        //Used Disease
        public static Disease CurrentDisease;
        


        static SimulationData()
        {

            FederalStates = new FederalState[16];
            Departements = new Departement[401];
            Population = new PopulationCell[10808574];

            for (int i = 0; i < Population.Length; ++i)
                Population[i].Init();

        }

    }
}
