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
        //TODO | T |Implement

        public Snapshot()
        {
            _stamp = DateTime.Now;
            Head = "[" + _stamp.ToString() + "].";
        }

        public byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        public void InitializeFromFile(byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}