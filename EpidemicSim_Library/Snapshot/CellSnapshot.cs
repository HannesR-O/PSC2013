using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.PopulationData;

namespace PSC2013.ES.Library.Snapshot
{
    /// <summary>
    /// Snapshot of a single PopulationCell. Can be created from File or from a Cell; Usable both Ways.
    /// </summary>
    public class CellSnapshot
    {
        public int Position { get; private set; } // Position in Array (If 1-dimensional)    

        public int CountMaleBaby { get; private set; } // Males Baby
        public int CountMaleChild { get; private set; } // Males Child
        public int CountMaleAdult { get; private set; } // Males Adult
        public int CountMaleSenior { get; private set; } // Males Senior

        public int CountF00 { get; private set; } // Females Baby
        public int CountF01 { get; private set; } // Females Child
        public int CountF10 { get; private set; } // Females Adult
        public int CountF11 { get; private set; } // Females Senior

        public HumanSnapshot[] Dead{ get; private set; } // base64-string of humans that died in this snapshot. Should contain Death-Cause, Age and Gender

        /// <summary>
        /// Creates an new Cellsnapshot, private becaus it's static
        /// </summary>
        /// <param name="param">The Population to be Snaped</param>
        private CellSnapshot(int[] infos, HumanSnapshot[] dead)
        {
            CountMaleBaby = infos[0];
            CountMaleChild = infos[1];
            CountMaleAdult = infos[2];
            CountMaleSenior = infos[3];

            CountF00 = infos[4];
            CountF01 = infos[5];
            CountF10 = infos[6];
            CountF11 = infos[7];

            Position = infos[8];

            Dead = dead;
        }

        /// <summary>
        /// Creates an CellSnapshot from a PopulationCell
        /// </summary>
        /// <param name="input">Input Counts</param>
        /// <param name="position">Position of the cell</param>
        /// <param name="deaths">An array containing the dead people as strings</param>
        /// <returns></returns>
        public static CellSnapshot FromCell(PopulationCell input, int position, HumanSnapshot[] deaths)
        {
            int[] temp = new int[9];

            temp[0] = input.Humans.Count(x => x.GetGender() == EGender.Male && x.GetAge() == EAge.Baby);
            temp[1] = input.Humans.Count(x => x.GetGender() == EGender.Male && x.GetAge() == EAge.Child);
            temp[2] = input.Humans.Count(x => x.GetGender() == EGender.Male && x.GetAge() == EAge.Adult);
            temp[3] = input.Humans.Count(x => x.GetGender() == EGender.Male && x.GetAge() == EAge.Senior);
            temp[4] = input.Humans.Count(x => x.GetGender() == EGender.Female && x.GetAge() == EAge.Baby);
            temp[5] = input.Humans.Count(x => x.GetGender() == EGender.Female && x.GetAge() == EAge.Child);
            temp[6] = input.Humans.Count(x => x.GetGender() == EGender.Female && x.GetAge() == EAge.Adult);
            temp[7] = input.Humans.Count(x => x.GetGender() == EGender.Female && x.GetAge() == EAge.Senior);
            temp[8] = position; 

            return new CellSnapshot(temp, deaths);
        }

        /// <summary>
        /// Creates an new CellSnapshot from Information parsed from an file
        /// </summary>
        /// <param name="counts">input counts</param>
        /// <param name="dead"></param>
        /// <returns>An array containing the dead people as strings</returns>
        public static CellSnapshot FromFile(int[] counts, HumanSnapshot[] dead)
        {
            return new CellSnapshot(counts, dead);
        }

        public byte[] getBytes()
        {
            return System.Text.Encoding.UTF8.GetBytes(Position + "|" + CountMaleBaby + "|" + CountMaleChild + "|"+ CountMaleAdult);
        }
    }
}
