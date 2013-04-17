using PSC2013.ES.Library.Simulator;
using System;
using System.Diagnostics;

namespace PSC2013.ES.Console
{
    class Program
    {
        static void Main(string[] args)
        {

#if DEBUG
           // System.Console.ReadKey();
            System.Console.WriteLine(SimulationData.CurrentDay);
            System.Console.ReadLine();

#endif
        }
    }
}
