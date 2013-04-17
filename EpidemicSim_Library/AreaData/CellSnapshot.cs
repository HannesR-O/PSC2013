using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.PopulationData;

namespace PSC2013.ES.Library.AreaData
{
    public class CellSnapshot
    {
        public static int Position { get; private set; }

        public static int Count { get; private set; }
        public static int CountMale { get; private set; }
        public static int CountFemale { get; private set; }

        public static int CountM00 { get; private set; }
        public static int CountM01 { get; private set; }
        public static int CountM10 { get; private set; }
        public static int CountM11 { get; private set; }

        public static int CountF00 { get; private set; }
        public static int CountF01 { get; private set; }
        public static int CountF10 { get; private set; }
        public static int CountF11 { get; private set; }

        public static List<Tuple<bool, Age, int>> Deaths { get; private set; }

        /// <summary>
        /// Creates an new Cellsnapshot
        /// </summary>
        /// <param name="param">The Population to be Snaped</param>
        private CellSnapshot(int[] infos)
        {
            Count = infos[0];
            CountMale = infos[1];
            CountFemale = infos[2];

            CountM00 = infos[3];
            CountM01 = infos[4];
            CountM10 = infos[5];
            CountM11 = infos[6];

            CountF00 = infos[7];
            CountF01 = infos[8];
            CountF10 = infos[9];
            CountF11 = infos[10];

            Position = infos[11];

            //TODO Deaths
        }

        public static CellSnapshot FromCell(PopulationCell input, int position)
        {
            int[] temp = new int[12];
            temp[0] = input.HumanCount;
            temp[1] = input.Humans.Count(x => x.GetGender() == Gender.Male);
            temp[2] = input.Humans.Count(x => x.GetGender() == Gender.Female);
            temp[11] = position;

            return new CellSnapshot(temp);
        }

        public static CellSnapshot FromFile(int[] input)
        {
            return null; //TODO 
        }
    }
}
