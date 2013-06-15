using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.Snapshot;
using PSC2013.ES.Library.PopulationData;

namespace PSC2013.ES.Library.Statistics
{
    /// <summary>
    /// Provides Some Information for HumanSnapshots of a single Tick
    /// </summary>
    public static class HumanSnapshotStatistics
    {
        /// <summary>
        /// Returns how many Dead Humans had which Profession
        /// </summary>
        /// <param name="humans">The Dead Humans to be analyzed</param>
        /// <returns></returns>
        public static Dictionary<string, int> ProfessionInformation(HumanSnapshot[] humans)
        {
            Dictionary<string, int> profInf = new Dictionary<string, int>();

            foreach (EProfession prof in Enum.GetValues(typeof(EProfession)))
            {
                profInf.Add(prof.ToString(), humans.Count(x => x.Profession.Equals(prof)));
            }
            return profInf;
        }

        /// <summary>
        /// Return information about deathCauses
        /// </summary>
        /// <param name="humans">The Dead Humans to be analyzed</param>
        /// <returns></returns>
        public static string DeathInformation(HumanSnapshot[] humans)
        {
            return humans.Count(x => x.Cause) + " Humans died of the disease, " + humans.Count(x => !x.Cause) + " Humans died of their age...";
        }

        /// <summary>
        /// Returns, how many Humans died away from Home
        /// </summary>
        /// <param name="humans">The Dead Humans to be analyzed</param>
        /// <returns></returns>
        public static string HomeCellInformation(HumanSnapshot[] humans)
        {
            return humans.Count(x => x.HomeCell != x.DeathCell) + " out of " + humans.Length + " Humans died far away from home...";
        }
    }
}
