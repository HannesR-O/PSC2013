using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using PSC2013.ES.Library.Snapshot;

namespace PSC2013.ES.Library.Statistics
{
    public class StatisticsManager
    {
        public int[] Humans;
        public int[] MaleBabys;
        public int[] MaleChildren;
        public int[] MaleAdults;
        public int[] MaleSeniors;
        public int[] FemaleBabys;
        public int[] FemaleChildren;
        public int[] FemaleAdults;
        public int[] FemaleSeniors;

        public int[] Infected;
        public int[] Diseased;

        /// <summary>
        /// Creates a new StatisticsManager and analyzes the Sim
        /// </summary>
        /// <param name="path">The path to the Simfile</param>
        public StatisticsManager(string path)
        {
            AnalyizeSimulation(path);
        }

        /// <summary>
        /// Analyzes the Simulation 
        /// </summary>
        /// <param name="path">The path to the Simfile</param>
        private void AnalyizeSimulation(string path)
        {
            ReviewManager manager = new ReviewManager(); // Dirty I know, but has to be quick
            manager.OpenSimFile(path);

            int size = manager.EntryCount;

            Humans = new int[size];
            MaleBabys = new int[size];
            MaleChildren = new int[size];
            MaleAdults = new int[size];
            MaleSeniors = new int[size];
            FemaleBabys = new int[size];
            FemaleChildren = new int[size];
            FemaleAdults = new int[size];
            FemaleSeniors = new int[size];
            Infected = new int[size];
            Diseased = new int[size];

            List<string> ent = manager.Entries;
            
            for (int i = 1; i < manager.EntryCount; ++i)
            {
                manager.LoadTickSnapshot(ent[i]);
                foreach (CellSnapshot cell in manager.LoadedSnapshot.Cells)
                {
                    MaleBabys[i] += cell.Values[0];
                    MaleChildren[i] += cell.Values[1];
                    MaleAdults[i] += cell.Values[2];
                    MaleSeniors[i] += cell.Values[3]; 
                    FemaleBabys[i] += cell.Values[4];
                    FemaleChildren[i] += cell.Values[5];
                    FemaleAdults[i] += cell.Values[6];
                    FemaleSeniors[i] += cell.Values[7];
                    for (int j = 0; j < 8; ++j)
                        Humans[i] += cell.Values[j];                        
                    Infected[i] += cell.Values[8];
                    Diseased[i] += cell.Values[9];
                }
            }
        }
    }
}