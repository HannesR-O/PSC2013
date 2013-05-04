using PSC2013.ES.Library.Snapshot;

namespace PSC2013.ES.Library.Statistics
{
    /// <summary>
    /// Manages taken SimulationSnapshots and creates Statistics out of its contents
    /// </summary>
    public class StatisticsManager
    {
        private SimulationInfo _simInfo;
        private TickSnapshot[] _snapshots;

        /// <summary>
        /// Opens a new .sim File and restores the contents to Runtime;
        /// Only one can be opened at a time
        /// </summary>
        /// <param name="path">The path where the file is located</param>
        public void OpenSimFile(string path)
        {
 
        }

        public void CreateGraphics(TickSnapshot snapshot)
        { 
        }
    }
}
