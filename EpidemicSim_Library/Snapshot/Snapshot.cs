using System;
using System.Linq;
using PSC2013.ES.Library.IO.Files;

namespace PSC2013.ES.Library.Snapshot
{
    public class Snapshot : IBinaryFile
    {
        private const byte HEADERSIZE = 17; // Header 1, Tick 8, countCells = 4, countDeaths = 4; => 17

        private const byte HEADER = 0x2;
        public DateTime Stamp { get; private set; }
        public long Tick { get; private set; }
        public String Head { get; private set; }
        private CellSnapshot[] _cells;
        private HumanSnapshot[] _deaths;

        private Snapshot(long tick, CellSnapshot[] cells, HumanSnapshot[] deaths)
        {
            Stamp = DateTime.Now;
            Tick = tick;
            Head = Tick + "_[" + Stamp.Hour + "-" + Stamp.Minute + "]";

            _cells = cells;
            _deaths = deaths;
        }

        public byte[] GetBytes()
        {
            //Offsets!
            int cellCount = _cells.Count(x => x != null);
            int deathCount = _deaths.Count(x => x != null);

            byte[] output = new byte[HEADERSIZE +
                (cellCount * CellSnapshot.BYTEARRAYSIZE) +
                (deathCount * HumanSnapshot.BYTEARRAYSIZE)];

            output[0] = HEADER; //Writing Header in 0

            Array.Copy(BitConverter.GetBytes(Tick), 0, output, 1, 8); // Writing the tick in 1-8
            Array.Copy(BitConverter.GetBytes(cellCount), 0, output, 9, 4); // Writing Count of Cells, necessary for reading (offset) in 9 - 12
            
            for (int i = 0; i < cellCount; ++i)
                Array.Copy(_cells[i].GetBytes(), 0, output,
                    (i * CellSnapshot.BYTEARRAYSIZE) + HEADERSIZE,
                    CellSnapshot.BYTEARRAYSIZE); // Writing the Cellsnapshots
            
            Array.Copy(BitConverter.GetBytes(deathCount), 0, output,
                cellCount * CellSnapshot.BYTEARRAYSIZE + HEADERSIZE,
                4); // Writing count of deaths, necessary for reading again
            
            int offset = cellCount * CellSnapshot.BYTEARRAYSIZE + HEADERSIZE;
            for (int j = 0; j < deathCount; ++j)
                Array.Copy(_deaths[j].getBytes(), 0, output,
                    (j * HumanSnapshot.BYTEARRAYSIZE) + offset,
                    HumanSnapshot.BYTEARRAYSIZE);
            
            return output;
        }

        public static Snapshot IntitializeFromRuntime(long tick, CellSnapshot[] cells, HumanSnapshot[] deaths)
        {
            return new Snapshot(tick, cells, deaths);
        }

        public static void InitializeFromFile(byte[] bytes)
        {
            // BitConvert.toInt32 (byte[] , startindex) => problem solved i thinks
            throw new NotImplementedException();
        }
    }
}