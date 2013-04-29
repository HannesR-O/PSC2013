using System;
using System.Linq;
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
        /// <param name="infos">The Population to be snapshotted</param>
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
        /// <returns></returns>
        public static CellSnapshot InitializeFromRuntime(PopulationCell input, int position)
        {
            int[] temp = new int[9];

            temp[0] = input.Humans.Count(x => x.GetGender() == EGender.Male && x.GetAge() == EAge.Baby && (x.IsDead() == false));
            temp[1] = input.Humans.Count(x => x.GetGender() == EGender.Male && x.GetAge() == EAge.Child && (x.IsDead() == false));
            temp[2] = input.Humans.Count(x => x.GetGender() == EGender.Male && x.GetAge() == EAge.Adult && (x.IsDead() == false));
            temp[3] = input.Humans.Count(x => x.GetGender() == EGender.Male && x.GetAge() == EAge.Senior && (x.IsDead() == false));
            temp[4] = input.Humans.Count(x => x.GetGender() == EGender.Female && x.GetAge() == EAge.Baby && (x.IsDead() == false));
            temp[5] = input.Humans.Count(x => x.GetGender() == EGender.Female && x.GetAge() == EAge.Child && (x.IsDead() == false));
            temp[6] = input.Humans.Count(x => x.GetGender() == EGender.Female && x.GetAge() == EAge.Adult && (x.IsDead() == false));
            temp[7] = input.Humans.Count(x => x.GetGender() == EGender.Female && x.GetAge() == EAge.Senior && (x.IsDead() == false));
            temp[8] = position;

            return new CellSnapshot(temp);
        }

        public static CellSnapshot InitializeFromFile(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public byte[] GetBytes()
        {
            var output = new byte[36];
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
    }
}