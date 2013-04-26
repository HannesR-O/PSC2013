﻿using System;
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
        private HumanSnapshot[] _deaths;

        private Snapshot(long tick, CellSnapshot[] cells, HumanSnapshot[] deaths)
        {
            Stamp = DateTime.Now;
            Head = Tick + "_-_[" + Stamp.Hour + "-" + Stamp.Minute + "]";

            _cells = cells;
            _deaths = deaths;
        }

        public byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public static Snapshot IntitializeFromRuntime(long tick, CellSnapshot[] cells, HumanSnapshot[] deaths)
        {
            return new Snapshot(tick, cells, deaths);    
        }

        public static void InitializeFromFile(byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}