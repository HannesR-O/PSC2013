using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.Snapshot;

namespace PSC2013.ES.Library.Statistics.CountStatistics
{
    public static class GeneralStatistics
    {
        public static int HumanCount(TickSnapshot snap)
        {
            int count = 0;
            foreach (CellSnapshot cell in snap.Cells)
            { 
                for (int i = 0; i < 8; ++i)
                    count += cell.Values[i];
            }
            return count;
        }

        public static int Deaths(TickSnapshot snap)
        {
            return snap.Deaths.Length;
        }

        public static Dictionary<String, int> AgeGroups(TickSnapshot snap)
        {
            int[] counts = new int[8];

            foreach (CellSnapshot cell in snap.Cells)
            {
                for (int i = 0; i < 8; ++i)
                    counts[i] += cell.Values[i];
            }
            Dictionary<string, int> output = new Dictionary<string, int>();

            output.Add("Male Babys", counts[0]);
            output.Add("Male Children", counts[1]);
            output.Add("Male Adults", counts[2]);
            output.Add("Male Seniors", counts[3]);
            output.Add("Female Babys", counts[4]);
            output.Add("Female Children", counts[5]);
            output.Add("Female Adults", counts[6]);
            output.Add("Female Seniors", counts[7]);

            return null;
        }

        public static int DiseasedCount(TickSnapshot snap)
        {
            int count = 0;
            foreach (CellSnapshot cell in snap.Cells)
            {
                count += cell.Values[9];
            }
            return count;
        }

        public static int InfectedCount(TickSnapshot snap)
        {
            int count = 0;
            foreach (CellSnapshot cell in snap.Cells)
            {
                count += cell.Values[8];
            }
            return count;
        }

        public static int CellCount(TickSnapshot snap)
        {
            return snap.Cells.Length;
        }
    }
}
