﻿using PSC2013.ES.Library;
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

            //TestSnapshot();

            TestCalculations();

            Console.WriteLine("Finished!");
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
            var disease = new Disease
                {
                    Name = "Test_Disease",
                    IncubationPeriod = 238475,
                    IdleTime = 123415,
                    SpreadingTime = 123123,
                    Transferability = 901237,
                    MortalityRate = new FactorContainer(new[] {1, 2, 14, 151, 11515, 123, 123, 120}),
                    HealingFactor = new FactorContainer(new[] {1, 2, 14, 151, 11515, 123, 123, 120}),
                    ResistanceFactor = new FactorContainer(new[] {1, 2, 14, 151, 11515, 123, 123, 120})
                };
            var mgr = new SnapshotManager();
            mgr.Initialize(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), disease);
            mgr.Finish();
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
            simData.InitializeFromFile("../../../EpidemicSim_InputDataParsers/germany.dep");

            foreach (PopulationCell cell in simData.Population)
            {
                var watch = new Stopwatch();
                Console.WriteLine("Testing non-parallel..");
                watch.Start();
      
                foreach (Human hu in cell.Humans)
                {
                    int value = hu.GetAgeInYears() % 4;
                }
         
                watch.Stop();
                Console.WriteLine("Elapsed time: " + watch.ElapsedMilliseconds + "ms");
                watch.Reset();
                Console.WriteLine("Testing parallel..");
                watch.Start();
      
                Parallel.ForEach(cell.Humans, (human) =>
                    {
                        int value = human.GetAgeInYears() % 4;
                    });
         
                watch.Stop();
                Console.WriteLine("Elapsed time: " + watch.ElapsedMilliseconds + "ms");
      
            }
        }
    }
}