using PSC2013.ES.Library;
using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library.Simulation;
using PSC2013.ES.Library.Simulation.Component;
using PSC2013.ES.Library.Snapshot;
using System;
using System.Diagnostics;
using System.Threading;

namespace PSC2013.ES.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            //TestEpidemicSimulator();

            TestSnapshot();
#endif
        }

        private static void TestEpidemicSimulator()
        {
            var sim = EpidemicSimulator.Create(new DebugSimulationComponent());
            sim.SimulationStarted += new EventHandler<SimulationEventArgs>(OnSimStartEvent);
            sim.TickFinished += new EventHandler<SimulationEventArgs>(OnTickfinishedEvent);
            sim.SimulationEnded += new EventHandler<SimulationEventArgs>(OnSimEndedEvent);
            sim.StartSimulation(Environment.CurrentDirectory, 5000);

            Console.ReadKey();
        }

        public static void OnSimStartEvent(object sender, SimulationEventArgs e)
        {
            Console.WriteLine("Received SimulationStarted event");
        }

        public static void OnTickfinishedEvent(object sender, SimulationEventArgs e)
        {
            Console.WriteLine("Received TickFinished event");
        }

        public static void OnSimEndedEvent(object sender, SimulationEventArgs e)
        {
            Console.WriteLine("Received SimulationEnded event");
        }

        public static void TestSnapshot()
        {
            SnapshotManager m = new SnapshotManager();
            Library.Diseases.Disease d = new Library.Diseases.Disease();
            d.Name = "Illnes";
            d.IncubationPeriod = 12;
            d.IdleTime = 13;
            d.SpreadingTime = 24;
            d.Transferability = 13;
            m.InitalizeSimulation(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), d);
            m.Finish();
        }

        public static void TestMemory()
        {
            var simData = new SimulationData();
            Console.WriteLine("Current size in MB: " + Process.GetCurrentProcess().PrivateMemorySize64 / (1024 * 1024));
            Console.WriteLine("Total Humancount in 1000: " + simData.Population.Length * 8 / 1000);
            Console.ReadKey();
        }

        public static void TestCalculations()
        {

        }
    }
}