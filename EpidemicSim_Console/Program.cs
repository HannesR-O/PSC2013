using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library.Simulation;
using PSC2013.ES.Library.Snapshot;
using System;
using System.Diagnostics;

namespace PSC2013.ES.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            testSnapshot();
#endif
        }

        public static void testSnapshot()
        {
            SnapshotManager m = new SnapshotManager();
            Library.Diseases.Disease d = new Library.Diseases.Disease();
            d.Name = "Illnes";
            m.InitalizeSimulation(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), d);
            m.Finish();
        }

        public static void testFlo()
        {
            var simData = new SimulationData();
            Console.WriteLine("Current size in MB: " + Process.GetCurrentProcess().PrivateMemorySize64 / (1024 * 1024));
            Console.WriteLine("Total Humancount in 1000: " + SimulationData.Population.Length * 8 / 1000);
            Console.ReadKey();
        }
    }
}