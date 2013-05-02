﻿using System;
using System.Linq;
using PSC2013.ES.Library.IO.Files;

namespace PSC2013.ES.Library.Snapshot
{
    /// <summary>
    /// A Snapshot, taken during one tick of the simulation
    /// </summary>
    public class Snapshot : IBinaryFile
    {
        private const byte CONSTLENGTH = 17; // Header 1, Tick 8, countCells = 4, countDeaths = 4; => 17

        private const byte HEADER = 0x2;
        public DateTime Stamp { get; private set; }
        public long Tick { get; private set; }
        public String Head { get; private set; }
        private CellSnapshot[] _cells;
        private HumanSnapshot[] _deaths;

        /// <summary>
        /// Creates a new Snapshot
        /// </summary>
        /// <param name="tick">The Tick, needed to sort 
        /// them later; only incremented</param>
        /// <param name="cells">The Cells during the tick</param>
        /// <param name="deaths">The dead humans since the last tick</param>
        private Snapshot(long tick, CellSnapshot[] cells, HumanSnapshot[] deaths)
        {
            Stamp = DateTime.Now;
            Tick = tick;
            Head = Tick + "_[" + Stamp.ToString("HH-mm-ss") + "]";

            _cells = cells;
            _deaths = deaths;
        }

        /// <summary>
        /// Initializes a new Snapshot from Runtime
        /// </summary>
        /// <param name ="tick">Tick</param>
        /// <param name ="cells">Cells to be saved</param>
        /// <param name ="deaths">Dead Humans</param>
        /// <returns></returns>
        public static Snapshot IntitializeFromRuntime(long tick, CellSnapshot[] cells, HumanSnapshot[] deaths)
        {
            return new Snapshot(tick, cells, deaths);
        }

        /// <summary>
        /// Initializes a new Snapshot from a file
        /// </summary>
        /// <param name="bytes">the byte[] from a file</param>
        /// <returns>A new Snapshot</returns>
        public static void InitializeFromFile(byte[] bytes)
        {
            // BitConvert.toInt32 (byte[] , startindex) => problem solved i thinks
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the Snapshots information in an byte[]
        /// </summary>
        /// <returns>Snapshots Infos as byte[]</returns>
        public byte[] GetBytes()
        {
            int cellCount = _cells.Count(x => x != null);
            int deathCount = _deaths.Count(x => x != null);

            byte[] output = new byte[CONSTLENGTH +
                (cellCount * CellSnapshot.LENGTH) +
                (deathCount * HumanSnapshot.LENGTH)];

            output[0] = HEADER; //Writing Header in 0

            Array.Copy(BitConverter.GetBytes(Tick), 0, output, 1, 8); // Writing the tick in 1-8
            Array.Copy(BitConverter.GetBytes(cellCount), 0, output, 9, 4); // Writing Count of Cells, necessary for reading (offset) in 9 - 12

            for (int i = 0; i < cellCount; ++i)
                Array.Copy(_cells[i].GetBytes(), 0, output,
                    (i * CellSnapshot.LENGTH) + CONSTLENGTH,
                    CellSnapshot.LENGTH); // Writing the Cellsnapshots

            Array.Copy(BitConverter.GetBytes(deathCount), 0, output,
                cellCount * CellSnapshot.LENGTH + CONSTLENGTH,
                4); // Writing count of deaths, necessary for reading again

            int offset = cellCount * CellSnapshot.LENGTH + CONSTLENGTH;
            for (int j = 0; j < deathCount; ++j)
                Array.Copy(_deaths[j].getBytes(), 0, output,
                    (j * HumanSnapshot.LENGTH) + offset,
                    HumanSnapshot.LENGTH);

            return output;
        }
    }
}