using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.IO.Files;

namespace PSC2013.ES.Library.Snapshot
{
    public class Snapshot : IBinaryFile
    {
        public DateTime Stamp { get; private set; }
        public long Tick { get; private set; }
        public String Head { get; private set; }
        private CellSnapshot[] _cells;


        private Snapshot(long tick, CellSnapshot[] cells)
        {
            Stamp = DateTime.Now;
            Head = Tick + "_-_[" + Stamp.Hour + "-" + Stamp.Minute + "]";

            _cells = cells;
        }

        public byte[] GetBytes()
        {
            // TODO | T | Fill with data...
            System.Text.ASCIIEncoding conv = new ASCIIEncoding();
            return System.Text.Encoding.UTF8.GetBytes(0x2 + "|" + Head + "|");
        }


        public static Snapshot IntitializeFromRuntime(long tick, CellSnapshot[] cells)
        {
            return new Snapshot(tick, cells);    
        }

        public static void InitializeFromFile(byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}