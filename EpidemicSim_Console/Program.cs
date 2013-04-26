using PSC2013.ES.Library;
using PSC2013.ES.Library.Diseases;
using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library.Simulation;
using PSC2013.ES.Library.Simulation.Component;
using PSC2013.ES.Library.Snapshot;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PSC2013.ES.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            //TestEpidemicSimulator();

            TestSnapshot();

            //TestCalculations();

            Console.ReadKey();
#endif
        }

        private static void TestEpidemicSimulator()
        {
            var sim = EpidemicSimulator.Create(new DebugSimulationComponent());
            sim.SimulationStarted += OnSimStartEvent;
            sim.TickFinished += OnTickfinishedEvent;
            sim.SimulationEnded += OnSimEndedEvent;
            sim.StartSimulation(Environment.CurrentDirectory, 5000);
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
            Disease d = new Library.Diseases.Disease();
            d.Name = "Test_Disease";
            d.IncubationPeriod = 238475;
            d.IdleTime = 123415;
            d.SpreadingTime = 123123;
            d.Transferability = 901237;
            d.MortalityRate = new FactorContainer(new[] {1, 2, 14, 151, 11515, 123,123, 120});
            d.HealingFactor= new FactorContainer(new[] { 1, 2, 14, 151, 11515, 123, 123, 120 });
            d.ResistanceFactor = new FactorContainer(new [] { 1, 2, 14, 151, 11515, 123, 123, 120 });
            SnapshotManager m = new SnapshotManager();
            m.Initialize(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), d);
            m.Finish();
        }

        public static void TestMemory()
        {
            var simData = new SimulationData();
            Console.WriteLine("Current size in MB: " + Process.GetCurrentProcess().PrivateMemorySize64 / (1024 * 1024));
            Console.WriteLine("Total Humancount in 1000: " + simData.Population.Length * 8 / 1000);
        }

        public static void TestCalculations()
        {
            var simData = new SimulationData();
            //simData.InitializeFromFile("../../../EpidemicSim_InputDataParsers/germany.dep");

#if DEBUG
            var watch = new Stopwatch();
            Console.WriteLine("Testing non-parallel..");
            watch.Start();
#endif
            var c = 0;
            foreach (PopulationCell cell in simData.Population)
            {
                foreach (Human human in cell.Humans)
                {
                    int value = human.GetAgeInYears() % 4;
                    value = human.GetAgeInYears() * 16;
                    if (!human.IsDead())
                        c++;
                }
            }
#if DEBUG
            watch.Stop();
            Console.WriteLine("Elapsed time: " + watch.ElapsedMilliseconds + "ms");
            Console.WriteLine();
            watch.Reset();
            Console.WriteLine("Testing parallel..");
            watch.Start();
#endif
            Parallel.ForEach(simData.Population, new ParallelOptions() { MaxDegreeOfParallelism = 1 }, (cell) =>
            {
                Parallel.ForEach(cell.Humans, new ParallelOptions() { MaxDegreeOfParallelism = 1 }, (human) =>
                {
                    int value = human.GetAgeInYears() % 4;
                    value = human.GetAgeInYears() * 16;
                });
            });
#if DEBUG
            watch.Stop();
            Console.WriteLine("Elapsed time: " + watch.ElapsedMilliseconds + "ms");
#endif
        }
    }
}