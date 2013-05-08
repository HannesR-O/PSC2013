using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.IO.Readers
{
    public class ContinuationEventArgs : EventArgs
    {
        public bool Continuing { get; set; }
        public bool Finished { get; set; }
    }
}
