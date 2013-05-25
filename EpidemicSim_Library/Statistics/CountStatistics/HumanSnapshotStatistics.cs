using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.Snapshot;
using PSC2013.ES.Library.PopulationData;

namespace PSC2013.ES.Library.Statistics.HumanSnapshotStatistics
{
    public static class HumanSnapshotStatistics
    {
        public static void GeneralInformation(HumanSnapshot[] humans)
        { 
        }

        public static Dictionary<string, int> ProfessionInformation(HumanSnapshot[] humans)
        {
            Dictionary<string, int> profInf = new Dictionary<string, int>();

            foreach (EProfession prof in Enum.GetValues(typeof(EProfession)))
            {
                profInf.Add(prof.ToString(), humans.Count(x => x.Profession.Equals(prof)));
            }
            return profInf;
        }

        public static void DeathInformation(HumanSnapshot[] humans)
        { 
        }

        public static void HomeCellInformation(HumanSnapshot[] humans)
        { 
        }
    }
}
