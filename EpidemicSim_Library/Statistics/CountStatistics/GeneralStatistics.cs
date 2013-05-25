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
