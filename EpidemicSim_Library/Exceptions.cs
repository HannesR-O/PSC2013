using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library
{
    /// <summary>
    /// SimFile is Corrupted, if something is missing inside a .Sim. Doesn't consider
    /// whether archive itself is corrupt
    /// </summary>
    public sealed class SimFileCorruptException : Exception
    {
        public SimFileCorruptException() { }
        public SimFileCorruptException(string message) : base(message) { }
        public SimFileCorruptException(string message, System.Exception innerException) : base(message, innerException) { }
    }

    /// <summary>
    /// Header is Corrupted, if it doesn't match the desired file formating
    /// </summary>
    public sealed class HeaderCorruptException : Exception
    {
        public HeaderCorruptException() { }
        public HeaderCorruptException(string message) : base(message) { }
        public HeaderCorruptException(string message, System.Exception innerException) : base(message, innerException) { }
    }

    public sealed class SimulationException : Exception
    {
        public SimulationException()
        {
            //TODO:  |f| add content, just a skeleton for now
        }
        public SimulationException(string message) : base(message) { }
        public SimulationException(string message, Exception inner) : base(message, inner) { }
    }
}
