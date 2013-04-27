using System;

namespace PSC2013.ES.Library.Simulation
{
    public class SimulationException : Exception
    {
        public SimulationException() 
        {
            //TODO:  |f| add content, just a skeleton for now
        }
        public SimulationException(string message) : base(message) { }
        public SimulationException(string message, Exception inner) : base(message, inner) { }

    }
}