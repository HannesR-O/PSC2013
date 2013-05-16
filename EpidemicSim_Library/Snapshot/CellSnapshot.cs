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

        public ushort[] Values { get; private set; }

        //[0] Males Baby
        //[1] Males Child
        //[2] Males Adult
        //[3] Males Senior

        //[4] Females Baby
        //[5] Females Child
        //[6] Females Adult
        //[7] Females Senior   

        //[8] Count of infected humans in this cell
        //[9] Count of diseased humans in this cell
   

        /// <summary>
        /// Creates an new Cellsnapshot, private becaus it's static
        /// </summary>
        /// <param name="infos">The Population to be snapshotted</param>
        /// <param name="position">The position of the Cell</param>
        private CellSnapshot(ushort[] infos, int position)
        {
            Values = new ushort[10];
            Values[0] = infos[0];
            Values[1] = infos[1];
            Values[2] = infos[2];
            Values[3] = infos[3];

            Values[4] = infos[4];
            Values[5] = infos[5];
            Values[6] = infos[6];
            Values[7] = infos[7];

            Values[8] = infos[8];
            Values[9] = infos[9];

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
            return new CellSnapshot(input.Data, position);
        }

        /// <summary>
        /// Initializes a new Cellsnapshot from an byte[] read from a file
        /// </summary>
        /// <param name="bytes">The read byte[]</param>
        /// <returns>A new CellSnapshot</returns>
        public static CellSnapshot InitializeFromFile(byte[] bytes)
        {
            //TODO | T | optimize
            ushort[] temp = new ushort[10];
            temp[0] = BitConverter.ToUInt16(bytes, 0);
            temp[1] = BitConverter.ToUInt16(bytes, 2);
            temp[2] = BitConverter.ToUInt16(bytes, 4);
            temp[3] = BitConverter.ToUInt16(bytes, 6);
            temp[4] = BitConverter.ToUInt16(bytes, 8);
            temp[5] = BitConverter.ToUInt16(bytes, 10);
            temp[6] = BitConverter.ToUInt16(bytes, 12);
            temp[7] = BitConverter.ToUInt16(bytes, 14);
            temp[8] = BitConverter.ToUInt16(bytes, 20);         // should be 16
            temp[9] = BitConverter.ToUInt16(bytes, 22);         // should be 18
            int position = BitConverter.ToInt32(bytes, 16);     // should be 20

            /* | dj | hint:
             * for (int i = 0; i <= 9; i++)
             *      temp[i] = BitConverter.ToUInt16(bytes, i * 2);
             * int position = BitConverter.ToInt32(bytes, tmp.Length * 2);
             */

            return new CellSnapshot(temp, position);
        }

        /// <summary>
        /// Returns the Snapshots informations in an byte[]
        /// </summary>
        /// <returns>Cellsnapshots Infos as byte[]</returns>
        public byte[] GetBytes()
        {
            byte[] output = new byte[LENGTH];

            Array.Copy(BitConverter.GetBytes(Values[0]), 0, output, 0, 2);
            Array.Copy(BitConverter.GetBytes(Values[1]), 0, output, 2, 2);
            Array.Copy(BitConverter.GetBytes(Values[2]), 0, output, 4, 2);
            Array.Copy(BitConverter.GetBytes(Values[3]), 0, output, 6, 2);
            Array.Copy(BitConverter.GetBytes(Values[4]), 0, output, 8, 2);
            Array.Copy(BitConverter.GetBytes(Values[5]), 0, output, 10, 2);
            Array.Copy(BitConverter.GetBytes(Values[6]), 0, output, 12, 2);
            Array.Copy(BitConverter.GetBytes(Values[7]), 0, output, 14, 2);
            Array.Copy(BitConverter.GetBytes(Position), 0, output, 16, 4);
            Array.Copy(BitConverter.GetBytes(Values[8]), 0, output, 20, 2);
            Array.Copy(BitConverter.GetBytes(Values[9]), 0, output, 22, 2);

            // | dj | hint: similar to .InitializeFormRuntime...

            return output;
        }
    }
}