using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Statistics
{
    public class StatisticsManager
    {
        #region ### Counts ###
        private int _cells;

        private int[] _humans;
        private int[] _maleBabys;
        private int[] _maleChildren;
        private int[] _maleAdults;
        private int[] _maleSeniors;
        private int[] _femaleBabys;
        private int[] _femaleChildren;
        private int[] _femaleAdults;
        private int[] _femaleSeniors;

        private int[] _infected;
        private int[] _diseased;

        private int[] _traveling;
        #endregion

        /// <summary>
        /// Creates a new StatisticsManager and analyzes the Sim
        /// </summary>
        /// <param name="path"></param>
        public StatisticsManager(string path)
        {
            AnalyizeSimulation(path);
        }

        private void AnalyizeSimulation(string path)
        {
            ReviewManager manager = new ReviewManager();
            manager.OpenSimFile(path);


            _infected = new int[manager.EntryCount];
            List<string> ent = manager.Entries;
            
            for (int i = 1; i < manager.EntryCount; ++i)
            {
                manager.LoadTickSnapshot(ent[i]);
                _infected[i] = manager.LoadedSnapshot.Cells.Sum(x => x.Values[8]);
            }
        }
    }
}