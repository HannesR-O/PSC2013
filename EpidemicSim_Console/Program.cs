using System.Drawing;
using PSC2013.ES.Library;
using PSC2013.ES.Library.Diseases;
using PSC2013.ES.Library.IO;
using PSC2013.ES.Library.Simulation;
using PSC2013.ES.Library.Simulation.Components;
using PSC2013.ES.Library.Snapshot;
using PSC2013.ES.Library.Statistics;
using PSC2013.ES.Library.Statistics.Pictures;
using System;
using System.Diagnostics;

namespace PSC2013.ES.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            Console.WriteLine("Welcome to the Epidemic-Simulator-Test-Console.");
            Console.WriteLine("Please select one of the following methods to call:");
            
            string[] methodnames = { "TestSimulation",
                "TestStats", "TestMovementComponent", "TestEpidemicSimulator",
                "TestMemory", "TestSnapshot"};
            for (int i = 0; i < methodnames.Length; i++)
                Console.WriteLine("{0} - {1}", i, methodnames[i]);

            int input = int.Parse(Console.ReadLine());

            Console.Clear();
            switch (input)
            {
                case 0:
                    TestSimulation();
                    break;
                case 1:
                    TestStats();
                    break;
                case 2:
                    TestMovementComponent();
                    break;
                case 3:
                    TestEpidemicSimulator();
                    break;
                case 4:
                    TestMemory();
                    break;
                case 5:
                    TestSnapshot();
                    break;
                default:
                    Console.WriteLine("wrong input");
                    break;
            }

            Console.ReadKey();
#endif
        }

        private static void TestEpidemicSimulator()
        {
            var sim = EpidemicSimulator.Create(new Disease(),
                "../../../EpidemicSim_InputDataParsers/germany.dep",
                new DebugSimulationComponent());
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
            var disease = new Disease
                {
                    Name = "Test_Disease",
                    IncubationPeriod = 238475,
                    IdleTime = 123415,
                    SpreadingTime = 123123,
                    Transferability = 901237,
                    MortalityRate = new FactorContainer(new[] { 1, 2, 14, 151, 11515, 123, 123, 120 }),
                    HealingFactor = new FactorContainer(new[] { 1, 2, 14, 151, 11515, 123, 123, 120 }),
                    ResistanceFactor = new FactorContainer(new[] { 1, 2, 14, 151, 11515, 123, 123, 120 })
                };
            var mgr = new SnapshotManager();
            mgr.Initialize(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), disease, 0, 0); // Uses Default MapSize
        }

        public static void TestMemory()
        {
            var simData = new SimulationData();
            Console.WriteLine("Current size in MB: " + Process.GetCurrentProcess().PrivateMemorySize64 / (1024 * 1024));
            Console.WriteLine("Total Humancount in 1000: " + simData.Cells.Length * 8 / 1000);
        }

        public static void TestSimulation()
        {
            var disease = new Disease
            {
                Name = "Test_Disease",
                IncubationPeriod = 238475,
                IdleTime = 123415,
                SpreadingTime = 123123,
                Transferability = 901237,
                MortalityRate = new FactorContainer(new []{ 1, 2, 14, 151, 11515, 123, 123, 120}),
                HealingFactor = new FactorContainer(new[] { 1, 2, 14, 151, 11515, 123, 123, 120 }),
                ResistanceFactor = new FactorContainer(new[] { 1, 2, 14, 151, 11515, 123, 123, 120 })
            };
            var sim = EpidemicSimulator.Create(disease,
                "../../../EpidemicSim_InputDataParsers/germany.dep",
                new DebugSimulationComponent(),
                new AgeingSimulationComponent(110),
                new MovementSimulationComponent());
            sim.SetSimulationIntervall(4272);
            sim.SetSnapshotIntervall(8544);
            sim.AddOutputTarget(new ConsoleOutputTarget());
            sim.SimulationStarted += OnSimStartEvent;
            sim.TickFinished += OnTickfinishedEvent;
            sim.SimulationEnded += OnSimEndedEvent;
            sim.StartSimulation(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }

        public static void TestMovementComponent()
        {
            //too slow at the moment
            var data = new SimulationData();
            var movecmp = new MovementSimulationComponent();
            data.InitializeFromFile("../../../EpidemicSim_InputDataParsers/germany.dep");

            for (int i = 0; i < 48; ++i)
            {
                movecmp.PerformSimulationStage(data);
                data.DoTick(1);
            }


        }

        public static void TestStats()
        {
            var manager = new StatisticsManager();
            Console.WriteLine("Please enter the name of your .sim file:");
            string file = Console.ReadLine();
            if (file.EndsWith(".sim")) file = file.Remove(file.Length - 4);
            manager.OpenSimFile(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/"
                + file + ".sim", 
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            var entries = manager.Entrys;
            foreach (string s in entries)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("Please type a filename:");
            string name = Console.ReadLine();            

            if (!entries.Contains(name))
                foreach (string entry in entries)
                    if (entry.StartsWith(name))
                    {
                        name = entry;
                        break;
                    }

            Console.WriteLine("Please type a color scheme (RED, BLUE):");
            string palette = Console.ReadLine();
            Color[] pal = palette == "BLUE" ? ColorPalette.BLUE : ColorPalette.RED;

            manager.LoadTickSnapshot(name);

            Console.WriteLine("Please insert desired File-Prefix:");
            string prefix = Console.ReadLine();

            manager.CreateGraphics(EStatField.AllMale, pal, prefix);

            Console.WriteLine("Finished!");
        }
    }
}