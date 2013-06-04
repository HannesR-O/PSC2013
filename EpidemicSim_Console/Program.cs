﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using PSC2013.ES.Library;
using PSC2013.ES.Library.Diseases;
using PSC2013.ES.Library.IO.OutputTargets;
using PSC2013.ES.Library.Simulation;
using PSC2013.ES.Library.Simulation.Components;
using PSC2013.ES.Library.Snapshot;
using PSC2013.ES.Library.Statistics;
using PSC2013.ES.Library.Statistics.CountStatistics;
using PSC2013.ES.Library.Statistics.Pictures;

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
                "TestStats", "TestMovementComponent", "TestEpidemicSimulator",
                "TestMemory", "TestSnapshot", "TestAllSnapshots", "TestComponents"};
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
                new DebugInfectionComponent());
            sim.SetSimulationIntervall(1);
            sim.SetSnapshotIntervall(1);
            sim.AddOutputTarget(new ConsoleOutputTarget());
            sim.ProcessFinished += (_, __) =>
                {
                    StatisticsManager sm = new StatisticsManager();
                    sm.OpenSimFile(DESKTOP_PATH + "\\TestDisease.sim");
                    sm.LoadTickSnapshot(sm.Entries[0]);
                    sm.CreateGraphics((EStatField)255, EColorPalette.Red, "testmap");
                    Console.WriteLine("DONE!");
                };
            sim.StartSimulation(DESKTOP_PATH, InfectionInitState.Empty, 1);
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
                Name = "Dat",
                IncubationPeriod = 10,
                IdleTime = 3,
                SpreadingTime = 8,
                Transferability = 50,
                MortalityRate = new FactorContainer(new []{ 1, 2, 14, 151, 11515, 123, 123, 120}),
                HealingFactor = new FactorContainer(new[] { 1, 2, 14, 151, 11515, 123, 123, 120 }),
                ResistanceFactor = new FactorContainer(new[] { 1, 2, 14, 151, 11515, 123, 123, 120 })
            };
            var sim = EpidemicSimulator.Create(disease,
                "../../../EpidemicSim_InputDataParsers/germany.dep",
                new AgeingComponent(110),
                //new DiseaseEffectComponent(),
                new MindsetComponent(),
                new MovementComponent(),
                //new InfectionComponent(),
                new DebugInfectionComponent());
            sim.SetSimulationIntervall(1);
            sim.SetSnapshotIntervall(1);
            sim.AddOutputTarget(new ConsoleOutputTarget());
            sim.SimulationStarted += OnSimStartEvent;
            sim.TickFinished += OnTickfinishedEvent;
            sim.SimulationEnded += OnSimEndedEvent;

            var dict = new Dictionary<int, int>();
            dict.Add(10808574 / 2, 25); // not enough!
            InfectionInitState iis = new InfectionInitState { DesiredInfection = dict };
            
            sim.StartSimulation(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), iis);
        }

        public static void TestMovementComponent()
        {
            //too slow at the moment
            var data = new SimulationData();
            var movecmp = new MovementComponent();
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

                Dictionary<string, int> am = 
                    GeneralStatistics.AgeGroups(manager.LoadedSnapshot);
                
                int sum = 0;
                foreach (string group in am.Keys)
                {
                    Console.WriteLine(group + ": " + am[group]);
                    sum += am[group];
                }
                Console.WriteLine("Sum: {0}", sum);

                //manager.CreateDeathGraphics(field, pal, prefix);
                Dictionary<string, Color> legend = manager.CreateGraphics(field, pal, prefix);

                foreach (string str in legend.Keys)
                {
                    Console.WriteLine(str + " with " + legend[str].ToString());
                }

                Console.WriteLine("Finished!");
            }
        }

        public static void TestAllSnapshots()
        {
            var manager = new StatisticsManager();

            Console.WriteLine("Please enter the name of your .sim file:");
            string file = Console.ReadLine();
            if (file.EndsWith(".sim")) file = file.Remove(file.Length - 4);

            Console.WriteLine("Please enter target directory (default is Desktop):");
            string target = Console.ReadLine();
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

            var entries = manager.Entries;
            int count = entries.Count;
            int i = 0;
            foreach (var entry in entries)
            {
                manager.LoadTickSnapshot(entry);
                manager.CreateGraphics(field, pal, prefix);
                Console.WriteLine("{0,3}/{1} snapshots done...", ++i, count);
            }

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
                { new AgeingComponent(110), new DiseaseEffectComponent(), new MindsetComponent(), new MovementComponent() };
            var debugComp = new DebugInfectionComponent();

            var infectValues = new Dictionary<int, int>();
            int start = 10808574 / 2;
            for (int i = -5; i < 5; i++)
			{
                infectValues.Add(start + i, 10);
			}

            var initialInfection = new InfectionInitState()
            {
                DesiredInfection = infectValues
            };

            

            EpidemicSimulator sim;
            Console.WriteLine("Testing all Components seperately");
            Console.WriteLine("Testing InfectionComponent");
            for (int i = -1; i < components.Length + 1; i++)
            {
                if (i == -1)
                    sim = EpidemicSimulator.Create(disease, dep, new InfectionComponent());
                else
                {
                    disease.Name = "ComponentTest_" + componentNames[i];
                    sim = EpidemicSimulator.Create(disease, dep, debugComp);
                    sim.AddSimulationComponent(components[i]);
                    Console.WriteLine("Testing " + componentNames[i]);
                }
                sim.AddOutputTarget(new ConsoleOutputTarget());
                sim.SetSimulationIntervall(1);
                sim.SetSnapshotIntervall(1);
                sim.ProcessFinished += FinishedComponentSimulation;
                sim.StartSimulation(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/componentTests/", initialInfection, 4);
                running = true;

                while (running) ;
                Console.WriteLine("Finished component!");
            }
            Console.WriteLine("All done!");
        }

        private static void FinishedComponentSimulation(object sender, EventArgs e)
        {
            running = false;
        }
    }
}