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
        public const byte LENGTH = 24; 

        public int Position { get; private set; } // Position in Array (If 1-dimensional)    

        public ushort Infected { get; private set; } // Count of infected humans in this cell
        public ushort Diseased { get; private set; } // Count of diseased humans in this cell

        public ushort CountMaleBaby { get; private set; } // Males Baby
        public ushort CountMaleChild { get; private set; } // Males Child
        public ushort CountMaleAdult { get; private set; } // Males Adult
        public ushort CountMaleSenior { get; private set; } // Males Senior

        public ushort CountFemaleBaby { get; private set; } // Females Baby
        public ushort CountFemaleChild { get; private set; } // Females Child
        public ushort CountFemaleAdult { get; private set; } // Females Adult
        public ushort CountFemaleSenior { get; private set; } // Females Senior      

        /// <summary>
        /// Creates an new Cellsnapshot, private becaus it's static
        /// </summary>
        /// <param name="infos">The Population to be snapshotted</param>
        /// <param name="position">The position of the Cell</param>
        private CellSnapshot(ushort[] infos, int position)
        {
            CountMaleBaby = infos[0];
            CountMaleChild = infos[1];
            CountMaleAdult = infos[2];
            CountMaleSenior = infos[3];

            CountFemaleBaby = infos[4];
            CountFemaleChild = infos[5];
            CountFemaleAdult = infos[6];
            CountFemaleSenior = infos[7];

            Infected = infos[8];
            Diseased = infos[9];

            Position = position;
        }

        /// <summary>
        /// Creates an CellSnapshot from a PopulationCell
        /// </summary>
        /// <param name="input">Input Counts</param>
        /// <param name="position">Position of the cell</param>
        /// <returns>A new CellSnapshot</returns>
        public static CellSnapshot InitializeFromRuntime(PopulationCell input, int position)
        {
            ushort[] temp = new ushort[10];

            temp[0] = (ushort)input.Humans.Count(x => x.GetGender() == EGender.Male && x.GetAge() == EAge.Baby && (x.IsDead() == false));
            temp[1] = (ushort)input.Humans.Count(x => x.GetGender() == EGender.Male && x.GetAge() == EAge.Child && (x.IsDead() == false));
            temp[2] = (ushort)input.Humans.Count(x => x.GetGender() == EGender.Male && x.GetAge() == EAge.Adult && (x.IsDead() == false));
            temp[3] = (ushort)input.Humans.Count(x => x.GetGender() == EGender.Male && x.GetAge() == EAge.Senior && (x.IsDead() == false));
            temp[4] = (ushort)input.Humans.Count(x => x.GetGender() == EGender.Female && x.GetAge() == EAge.Baby && (x.IsDead() == false));
            temp[5] = (ushort)input.Humans.Count(x => x.GetGender() == EGender.Female && x.GetAge() == EAge.Child && (x.IsDead() == false));
            temp[6] = (ushort)input.Humans.Count(x => x.GetGender() == EGender.Female && x.GetAge() == EAge.Adult && (x.IsDead() == false));
            temp[7] = (ushort)input.Humans.Count(x => x.GetGender() == EGender.Female && x.GetAge() == EAge.Senior && (x.IsDead() == false));

            temp[8] = (ushort)input.Humans.Count(x => x.IsInfected());
            temp[9] = (ushort)input.Humans.Count(x => x.IsDiseased());

            return new CellSnapshot(temp, position);
        }

        /// <summary>
        /// Initializes a new Cellsnapshot from an byte[] read from a file
        /// </summary>
        /// <param name="bytes">The read byte[]</param>
        /// <returns>A new CellSnapshot</returns>
        public static CellSnapshot InitializeFromFile(byte[] bytes)
        {
            ushort[] temp = new ushort[10];
            temp[0] = BitConverter.ToUInt16(bytes, 0);
            temp[1] = BitConverter.ToUInt16(bytes, 2);
            temp[2] = BitConverter.ToUInt16(bytes, 4);
            temp[3] = BitConverter.ToUInt16(bytes, 6);
            temp[4] = BitConverter.ToUInt16(bytes, 8);
            temp[5] = BitConverter.ToUInt16(bytes, 10);
            temp[6] = BitConverter.ToUInt16(bytes, 12);
            temp[7] = BitConverter.ToUInt16(bytes, 14);
            temp[8] = BitConverter.ToUInt16(bytes, 20);
            temp[9] = BitConverter.ToUInt16(bytes, 22);
            int position = BitConverter.ToInt32(bytes, 16);

            return new CellSnapshot(temp, position);
        }

        /// <summary>
        /// Returns the Snapshots informations in an byte[]
        /// </summary>
        /// <returns>Cellsnapshots Infos as byte[]</returns>
        public byte[] GetBytes()
        {
            byte[] output = new byte[LENGTH];

            Array.Copy(BitConverter.GetBytes(CountMaleBaby), 0, output, 0, 2);
            Array.Copy(BitConverter.GetBytes(CountMaleChild), 0, output, 2, 2);
            Array.Copy(BitConverter.GetBytes(CountMaleAdult), 0, output, 4, 2);
            Array.Copy(BitConverter.GetBytes(CountMaleSenior), 0, output, 6, 2);
            Array.Copy(BitConverter.GetBytes(CountFemaleBaby), 0, output, 8, 2);
            Array.Copy(BitConverter.GetBytes(CountFemaleChild), 0, output, 10, 2);
            Array.Copy(BitConverter.GetBytes(CountFemaleAdult), 0, output, 12, 2);
            Array.Copy(BitConverter.GetBytes(CountFemaleSenior), 0, output, 14, 2);
            Array.Copy(BitConverter.GetBytes(Position), 0, output, 16, 4);
            Array.Copy(BitConverter.GetBytes(Infected), 0, output, 20, 2);
            Array.Copy(BitConverter.GetBytes(Diseased), 0, output, 22, 2);

            return output;
        }
    }
}