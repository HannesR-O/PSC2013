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
        public DateTime _stamp;
        private CellSnapshot[] _cells;
        public String Head {get; private set;}

        public Snapshot(CellSnapshot[] cells)
        {
            _stamp = DateTime.Now;
            Head = "[" + _stamp.Hour + "-" + _stamp.Minute + "]";

            _cells = cells;

        }

        public byte[] GetBytes()
        {
            // TODO | T | Fill with data...
            System.Text.ASCIIEncoding conv = new ASCIIEncoding();
            return System.Text.Encoding.UTF8.GetBytes(0x2 + "|" + Head + "|");
        }


        public void InitializeFromFile(byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}