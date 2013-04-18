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
        public int Position { get; private set; }

        public int Count { get; private set; }
        public int CountMale { get; private set; }
        public int CountFemale { get; private set; }

        public int CountM00 { get; private set; }
        public int CountM01 { get; private set; }
        public int CountM10 { get; private set; }
        public int CountM11 { get; private set; }

        public int CountF00 { get; private set; }
        public int CountF01 { get; private set; }
        public int CountF10 { get; private set; }
        public int CountF11 { get; private set; }

        public string[] Dead{ get; private set; }

        /// <summary>
        /// Creates an new Cellsnapshot, private becaus it's static
        /// </summary>
        /// <param name="param">The Population to be Snaped</param>
        private CellSnapshot(int[] infos, string[] dead)
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

            Dead = dead;
        }

        /// <summary>
        /// Creates an CellSnapshot from a PopulationCell
        /// </summary>
        /// <param name="input">Input Counts</param>
        /// <param name="position">Position of the cell</param>
        /// <param name="deaths">An array containing the dead people as strings</param>
        /// <returns></returns>
        public static CellSnapshot FromCell(PopulationCell input, int position, string[] deaths)
        {
            int[] temp = new int[12];

            temp[0] = input.HumanCount;
            temp[1] = input.Humans.Count(x => x.GetGender() == EGender.Male);
            temp[2] = input.Humans.Count(x => x.GetGender() == EGender.Female);
            temp[3] = input.Humans.Count(x => x.GetGender() == EGender.Male && x.GetAge() == EAge.Baby);
            temp[4] = input.Humans.Count(x => x.GetGender() == EGender.Male && x.GetAge() == EAge.Child);
            temp[5] = input.Humans.Count(x => x.GetGender() == EGender.Male && x.GetAge() == EAge.Adult);
            temp[6] = input.Humans.Count(x => x.GetGender() == EGender.Male && x.GetAge() == EAge.Senior);
            temp[7] = input.Humans.Count(x => x.GetGender() == EGender.Female && x.GetAge() == EAge.Baby);
            temp[8] = input.Humans.Count(x => x.GetGender() == EGender.Female && x.GetAge() == EAge.Child);
            temp[9] = input.Humans.Count(x => x.GetGender() == EGender.Female && x.GetAge() == EAge.Adult);
            temp[10] = input.Humans.Count(x => x.GetGender() == EGender.Female && x.GetAge() == EAge.Senior);
            temp[11] = position; 

            return new CellSnapshot(temp, deaths);
        }

        /// <summary>
        /// Creates an new CellSnapshot from Information parsed from an file
        /// </summary>
        /// <param name="counts">input counts</param>
        /// <param name="dead"></param>
        /// <returns>An array containing the dead people as strings</returns>
        public static CellSnapshot FromFile(int[] counts, string[] dead)
        {
            return new CellSnapshot(counts, dead);
        }
    }
}
