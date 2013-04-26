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

        public int CountFemaleBaby { get; private set; } // Females Baby
        public int CountFemaleChild { get; private set; } // Females Child
        public int CountFemaleAdult { get; private set; } // Females Adult
        public int CountFemaleSenior { get; private set; } // Females Senior      

        /// <summary>
        /// Creates an new Cellsnapshot, private becaus it's static
        /// </summary>
        /// <param name="param">The Population to be Snaped</param>
        private CellSnapshot(int[] infos)
        {
            CountMaleBaby = infos[0];
            CountMaleChild = infos[1];
            CountMaleAdult = infos[2];
            CountMaleSenior = infos[3];

            CountFemaleBaby = infos[4];
            CountFemaleChild = infos[5];
            CountFemaleAdult = infos[6];
            CountFemaleSenior = infos[7];

            Position = infos[8];
        }

        /// <summary>
        /// Creates an CellSnapshot from a PopulationCell
        /// </summary>
        /// <param name="input">Input Counts</param>
        /// <param name="position">Position of the cell</param>
        /// <param name="deaths">An array containing the dead people as strings</param>
        /// <returns></returns>
        public static CellSnapshot InitializeFromRuntime(PopulationCell input, int position)
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

            return new CellSnapshot(temp);
        }

        /// <summary>
        /// Creates an new CellSnapshot from Information parsed from an file
        /// </summary>
        /// <param name="counts">input counts</param>
        /// <param name="dead"></param>
        /// <returns>An array containing the dead people as strings</returns>
        public static CellSnapshot FromFile(int[] counts)
        {
            return new CellSnapshot(counts);
        }

        public byte[] getBytes()
        {
            byte[] output = new byte[36];
            Array.Copy(BitConverter.GetBytes(CountMaleBaby), 0, output, 0, 4);
            Array.Copy(BitConverter.GetBytes(CountMaleChild), 0, output, 4, 4);
            Array.Copy(BitConverter.GetBytes(CountMaleAdult), 0, output, 8, 4);
            Array.Copy(BitConverter.GetBytes(CountMaleSenior), 0, output, 12, 4);
            Array.Copy(BitConverter.GetBytes(CountFemaleBaby), 0, output, 16, 4);
            Array.Copy(BitConverter.GetBytes(CountFemaleChild), 0, output, 20, 4);
            Array.Copy(BitConverter.GetBytes(CountFemaleAdult), 0, output, 24, 4);
            Array.Copy(BitConverter.GetBytes(CountFemaleSenior), 0, output, 28, 4);
            Array.Copy(BitConverter.GetBytes(Position), 0, output, 32, 4);
            return output;
        }

        public static CellSnapshot InitializeFromFile(byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}
