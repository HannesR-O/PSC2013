using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library.Simulation;
using System;
using System.Diagnostics;

namespace PSC2013.ES.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            var simData = new SimulationData();
            Console.WriteLine("Current size in MB: " + Process.GetCurrentProcess().PrivateMemorySize64 / (1024 * 1024));
            Console.WriteLine("Total Humancount in 1000: " + SimulationData.Population.Length * 8 / 1000);
            Console.ReadKey();
#endif
        }
    }
}