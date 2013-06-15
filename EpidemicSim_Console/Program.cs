using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using PSC2013.ES.Library;
using PSC2013.ES.Library.DiseaseData;
using PSC2013.ES.Library.IO.OutputTargets;
using PSC2013.ES.Library.Simulation;
using PSC2013.ES.Library.Simulation.Components;
using PSC2013.ES.Library.Snapshot;
using PSC2013.ES.Library.Statistics;
using PSC2013.ES.Library.Statistics.Pictures;
using PSC2013.ES.Library.IO;

namespace PSC2013.ES.Cmd
{
    class Program
    {
        static volatile bool running = false;

        static readonly string DESKTOP_PATH = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        static void Main(string[] args)
        {
#if DEBUG
            Console.WriteLine("Welcome to the Epidemic-Simulator-Test-Console.");
            Console.WriteLine("Please select one of the following methods to call:");
            
            string[] methodnames = { "TestSimulation",
                "TestStats", "TestInfectionComponent", "TestEpidemicSimulator",
                "TestMemory", "TestDiseaseIO", "TestAllSnapshots", "TestComponents"};
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
                    TestInfectionComponent();
                    break;
                case 3:
                    TestEpidemicSimulator();
                    break;
                case 4:
                    TestMemory();
                    break;
                case 5:
                    TestDiseaseIO();
                    break;
                case 6:
                    TestAllSnapshots();
                    break;
                case 7:
                    TestComponents();
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
            // TODO | dj | remove this!
            Process.GetCurrentProcess().MaxWorkingSet = new IntPtr(4294967296); // should limit the RAM to ~4GB.

            FactorContainer fc = new FactorContainer(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 });
            var sim = EpidemicSimulator.Create(new Disease()
                {
                    Name = "TestDisease",
                    HealingFactor = fc,
                    ResistanceFactor = fc,
                    MortalityRate = fc,
                    Transferability = 75
                },
                "../../../EpidemicSim_InputDataParsers/germany.dep",
                new ConsoleOutputTarget(),
                DateTime.Now,
                new DebugInfectionComponent());
            sim.SetSimulationIntervall(1);
            sim.SetSnapshotIntervall(1);
            sim.ProcessFinished += (_, __) =>
                {
                    ReviewManager sm = new ReviewManager();
                    sm.OpenSimFile(DESKTOP_PATH + "\\TestDisease.sim");
                    sm.LoadTickSnapshot(sm.Entries[0]);
                    sm.CreateGraphics((EStatField)255, EColorPalette.Red, "testmap");
                    Console.WriteLine("DONE!");
                };
            sim.StartSimulation(DESKTOP_PATH + "\\dat.sim", InfectionInitState.Empty, 1);
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

        public static void TestDiseaseIO()
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
            DiseaseIOService.Save(disease, Environment.GetFolderPath(Environment.SpecialFolder.Desktop), true);

            var dis = DiseaseIOService.Load(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test_Disease.dis"));
            Console.WriteLine("Done");
        }

        public static void TestMemory()
        {
            var simData = new SimulationData(DateTime.Now);
            Console.WriteLine("Current size in MB: " + Process.GetCurrentProcess().PrivateMemorySize64 / (1024 * 1024));
            Console.WriteLine("Total Humancount in 1000: " + simData.Cells.Length * 8 / 1000);
        }

        public static void TestSimulation()
        {
            var disease = new Disease
            {
                Name = "Dat",
                IncubationPeriod = 1,
                IdleTime = 1,
                SpreadingTime = 12,
                Transferability = 100,
                MortalityRate = new FactorContainer(new[] { 10, 20, 20, 10, 10, 20, 20, 10 }),
                HealingFactor = new FactorContainer(new[] { 0, 5, 5, 0, 0, 3, 3, 0 }),
                ResistanceFactor = new FactorContainer(new[] { 0, 5, 5, 0, 0, 3, 3, 0})
            };
            var sim = EpidemicSimulator.Create(disease,
                "../../../EpidemicSim_InputDataParsers/germany.dep",  
                new ConsoleOutputTarget(),
                DateTime.Now,
                new AgeingComponent(110),
                new DiseaseTickComponent(),
                new DiseaseDeathComponent(),
                new DiseaseHealingComponent(),
                new MindsetComponent(),
                new MovementComponent(),
                new InfectionComponent()
                );
            sim.SetSimulationIntervall(1);
            sim.SetSnapshotIntervall(1);
            sim.SimulationStarted += OnSimStartEvent;
            sim.TickFinished += OnTickfinishedEvent;
            sim.SimulationEnded += OnSimEndedEvent;

            sim.StartSimulation(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\dat.sim", GetExampleInitialInfection(), 48);
        }

        public static void TestInfectionComponent()
        {
            string dep = "../../../EpidemicSim_InputDataParsers/germany.dep";

            var disease = new Disease() 
            {
                Name = "Inf_Test",
                IdleTime = 6,
                IncubationPeriod = 6,
                SpreadingTime = 12,
                Transferability = 100,
                MortalityRate = new FactorContainer(new []{ 1, 2, 14, 151, 11515, 123, 123, 120}),
                HealingFactor = new FactorContainer(new[] { 1, 2, 14, 151, 11515, 123, 123, 120 }),
                ResistanceFactor = new FactorContainer(new[] { 0, 0, 0, 0, 0, 0, 0, 0 })
            };

            var sim = EpidemicSimulator.Create(disease, dep, new ConsoleOutputTarget(), DateTime.Now, new InfectionComponent());
            sim.AddSimulationComponent(new DiseaseTickComponent());
            sim.SetSimulationIntervall(3);
            sim.SetSnapshotIntervall(3);
            sim.StartSimulation(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\dat.sim", GetExampleInitialInfection(), 24);
        }

        public static void TestStats()
        {
            var manager = new ReviewManager();

            Console.WriteLine("Please enter the name of your .sim file:");

            string file = Console.ReadLine();
            if (file.EndsWith(".sim")) file = file.Remove(file.Length - 4);

            manager.OpenSimFile(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/"
                + file + ".sim");

            var entries = manager.Entries;
            
            while (true) // I am Evil, I know |T|
            {
                foreach (string s in entries)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("Please type a entryname:");
                string name = Console.ReadLine();

                if (!entries.Contains(name))
                    foreach (string entry in entries)
                        if (entry.StartsWith(name))
                        {
                            name = entry;
                            break;
                        }

                Console.WriteLine("Please enter number of Field to paint (AllHumans is 255)");
                int num = int.Parse(Console.ReadLine());
                EStatField field = (EStatField)num;

                Console.WriteLine("Please type a color scheme (Red, Blue, RedGreen[default]):");
                string palette = Console.ReadLine();
                EColorPalette pal = EColorPalette.RedGreen;
                if (palette.ToLower().Equals("red"))
                    pal = EColorPalette.Red;
                else if (palette.ToLower().Equals("blue"))
                    pal = EColorPalette.Blue;

                Console.WriteLine("Please insert desired File-Prefix:");
                string prefix = Console.ReadLine();

                manager.LoadTickSnapshot(name);

                Console.WriteLine("Normal(0) or Deathmap (1)");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 0:
                        manager.CreateGraphics(field, pal, prefix);
                        break;
                    case 1:
                        manager.CreateDeathGraphics(field, pal, prefix);
                        break;
                    default:
                        manager.CreateGraphics(field, pal, prefix);
                        break;
                }
                Dictionary<string, Color> legend = manager.GetCaption();

                foreach (string str in legend.Keys)
                {
                    Console.WriteLine(str + " with " + legend[str].ToString());
                }

                Console.WriteLine("Finished!");
            }
        }

        public static void TestAllSnapshots()
        {
            OutputTargetManager.GetInstance().RegisterTarget(new ConsoleOutputTarget());

            var manager = new ReviewManager();

            Console.WriteLine("Please enter the name of your .sim file:");
            string file = Console.ReadLine();
            if (file.EndsWith(".sim")) file = file.Remove(file.Length - 4);

            Console.WriteLine("Please enter target directory (default is Desktop):");
            string target = Console.ReadLine();
            target = target == "" ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) : target;
            if (!Directory.Exists(target))
                Directory.CreateDirectory(target);

            Console.WriteLine("Please enter number of Field to paint (AllHumans is 255)");
            int num = int.Parse(Console.ReadLine());
            EStatField field = (EStatField)num;

            Console.WriteLine("Please type a color scheme (Red, Blue, RedGreen[default]):");
            string palette = Console.ReadLine();
            EColorPalette pal = EColorPalette.RedGreen;
            if (palette.ToLower().Equals("red"))
                pal = EColorPalette.Red;
            else if (palette.ToLower().Equals("blue"))
                pal = EColorPalette.Blue;

            Console.WriteLine("Please insert desired File-Prefix:");
            string prefix = Console.ReadLine();

            manager.OpenSimFile(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/"
                + file + ".sim");

            manager.SetNewDestination(target);

            manager.CreateMulipleGraphics(manager.Entries, field, pal, prefix);

            Console.WriteLine("DONE!");
        }

        public static void TestComponents()
        {
            string dep = "../../../EpidemicSim_InputDataParsers/germany.dep";

            var disease = new Disease() 
            {
                Name = "ComponentTest_InfectionComponent",
                IdleTime = 1,
                IncubationPeriod = 1,
                SpreadingTime = 6,
                Transferability = 100,
                MortalityRate = new FactorContainer(new []{ 1, 2, 14, 151, 11515, 123, 123, 120}),
                HealingFactor = new FactorContainer(new[] { 1, 2, 14, 151, 11515, 123, 123, 120 }),
                ResistanceFactor = new FactorContainer(new[] { 1, 2, 14, 151, 11515, 123, 123, 120 })
            };

            string[] componentNames = 
                {"AgeingComponent", "DiseaseEffectComponent", "MindsetComponent", "MovementComponent"};
            SimulationComponent[] components = 
                { new AgeingComponent(110), new DiseaseTickComponent(), new MindsetComponent(), new MovementComponent() };
            var debugComp = new DebugInfectionComponent();

            EpidemicSimulator sim;
            Console.WriteLine("Testing all Components seperately");
            Console.WriteLine("Testing InfectionComponent");
            for (int i = -1; i < components.Length; i++)
            {
                if (i == -1)
                    sim = EpidemicSimulator.Create(disease, dep, new ConsoleOutputTarget(), DateTime.Now, new InfectionComponent());
                else
                {
                    disease.Name = "ComponentTest_" + componentNames[i];
                    sim = EpidemicSimulator.Create(disease, dep, new ConsoleOutputTarget(), DateTime.Now, debugComp);
                    sim.AddSimulationComponent(components[i]);
                    Console.WriteLine("Testing " + componentNames[i]);
                }
                sim.SetSimulationIntervall(1);
                sim.SetSnapshotIntervall(1);
                sim.ProcessFinished += FinishedComponentSimulation;
                sim.StartSimulation(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/componentTests/" + "\\dat.sim", GetExampleInitialInfection(), 4);
                running = true;

                while (running) ;
                Console.WriteLine("Finished component!");
            }
            Console.WriteLine("All done!");
        }

        private static InfectionInitState GetExampleInitialInfection()
        {
            var infectValues = new Dictionary<int, int>();

            int start = 10808574 / 2;
            for (int i = -5; i < 5; i++)
            {
                infectValues.Add(start + i, 10);
            }

            return new InfectionInitState() { DesiredInfection = infectValues };
        }

        private static void FinishedComponentSimulation(object sender, EventArgs e)
        {
            running = false;
        }
    }
}