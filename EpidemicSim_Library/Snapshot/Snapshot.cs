﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.IO.Document;

namespace PSC2013.ES.Library.Snapshot
{
    public class Snapshot : IDocument
    {
        private CellSnapshot[] cells;
        //TODO | T |Implement

        byte[] IDocument.GetBytes()
        {
            throw new NotImplementedException();
        }
    }
}