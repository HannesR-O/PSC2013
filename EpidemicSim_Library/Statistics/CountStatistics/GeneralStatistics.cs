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

        public static string[] AgeGroups(TickSnapshot snap)
        {
            int[] counts = new int[8];

            foreach (CellSnapshot cell in snap.Cells)
            {
                for (int i = 0; i < 8; ++i)
                    counts[i] += cell.Values[i];
            }
           string[] output = new string[8];

            output[0] = "Male Babys: " + counts[0];
            output[1] = "Male Children: " + counts[1];
            output[2] = "Male Adults: " + counts[2];
            output[3] = "Male Seniors: " + counts[3];
            output[4] = "Female Babys: " + counts[4];
            output[5] = "Female Children: " + counts[5];
            output[6] = "Female Adults: " + counts[6];
            output[7] = "Female Seniors: " + counts[7];

            return output;
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
