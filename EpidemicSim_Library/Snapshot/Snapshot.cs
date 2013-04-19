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
        private CellSnapshot[] cells;
        //TODO | T |Implement

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