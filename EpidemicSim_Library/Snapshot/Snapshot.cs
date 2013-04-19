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
        private DateTime _stamp;
        private CellSnapshot[] _cells;
        private String _head;
        //TODO | T |Implement

        public Snapshot()
        {
            _stamp = DateTime.Now;
            _head = "This Snapshot was created on [" + _stamp.ToString() + "].";
        }

        byte[] IBinaryFile.GetBytes()
        {
            throw new NotImplementedException();
        }


        void IBinaryFile.InitializeFromFile(byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}