﻿using System;
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

        /// <summary>
        ///[0] Males Baby<para/>
        ///[1] Males Child<para/>
        ///[2] Males Adult<para/>
        ///[3] Males Senior<para/>
        ///[4] Females Baby<para/>
        ///[5] Females Child<para/>
        ///[6] Females Adult<para/>
        ///[7] Females Senior   <para/>
        ///[8] Count of infected humans in this cell<para/>
        ///[9] Count of diseased humans in this cell   
        /// </summary>
        public ushort[] Values { get; private set; } 

        /// <summary>
        /// Creates an new Cellsnapshot, private becaus it's static
        /// </summary>
        /// <param name="infos">The Population to be snapshotted</param>
        /// <param name="position">The position of the Cell</param>
        private CellSnapshot(ushort[] infos, int position)
        {
            Values = infos;
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
            ushort[] temp = new ushort[10];

            for (int i = 0; i < 10; ++i)
            {
                temp[i] = BitConverter.ToUInt16(bytes, i * 2);
            }

            int position = BitConverter.ToInt32(bytes, 20);

            return new CellSnapshot(temp, position);
        }

        /// <summary>
        /// Returns the Snapshots informations in an byte[]
        /// </summary>
        /// <returns>Cellsnapshots Infos as byte[]</returns>
        public byte[] GetBytes()
        {
            byte[] output = new byte[LENGTH];

            for (int i = 0; i < 10; ++i)
            {
                Array.Copy(BitConverter.GetBytes(Values[i]), 0, output, i * 2, 2);
            }

            Array.Copy(BitConverter.GetBytes(Position), 0, output, 20, 4);

            return output;
        }
    }
}