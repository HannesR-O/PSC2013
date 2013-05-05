using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library.Snapshot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSC2013.ES.Library.Simulation.Components
{
    public class AgeingSimulationComponent : ISimulationComponent
    {
        // Assumes 365 x 24 hour days
        private const int HOURS_PER_YEAR = 8544;
        public int TicksPerYear { get; private set; }
        public int AgeLimit { get; private set; }

        private int _counter;

        /// <summary>
        /// Creates a new AgeingSimulationComponent and sets the "hour-value" of one tick.
        /// </summary>
        /// <param name="hoursPerTick">A value specifying how many hours pass in one SimulationTick</param>
        /// <param name="ageLimit">A value specifying at what age Humans should day of aging</param>
        public AgeingSimulationComponent(int hoursPerTick, int ageLimit)
        {
            TicksPerYear = HOURS_PER_YEAR / hoursPerTick;        //TODO: |f| not the most accurate but should be enough for our purposes
            AgeLimit = ageLimit;
            _counter = 0;
        }

        public void PerformSimulationStage(SimulationData data)
        {
            _counter = ++_counter % TicksPerYear;

            if (_counter != 0) return;

            // One year passed
#if DEBUG
            Console.WriteLine("Year has passed!");
#endif
            var deadPeople = new List<HumanSnapshot>();

            for (int i = 0; i < data.Population.Count(); i++)
            {
                if (data.Population[i] == null) continue;

                deadPeople.AddRange(HandleSinglePopulationCell(data.Population[i], i));
            }

            data.AddDeadPeople(deadPeople);
#if DEBUG
            Console.WriteLine("Dead people this Iteration: " + deadPeople.Count);
            Console.WriteLine("Total dead people: " + data.DeathCount);
#endif
        }

        private IEnumerable<HumanSnapshot> HandleSinglePopulationCell(PopulationCell cell, int cellID)
        {
            var deadPeople = new List<HumanSnapshot>();

            for (int i = 0; i < cell.Humans.Length; i++)
            {
                if (cell.Humans[i].IsDead()) continue;

                cell.Humans[i].DoAgeTick();

                var human = cell.Humans[i];
                if (human.GetAgeInYears() <= AgeLimit) continue;

                // Human dies from over ageing                  //TODO: |f| Add percentage rates for dieing at high ages and kill human properly
                deadPeople.Add(HumanSnapshot.InitializeFromRuntime((byte)human.GetGender(), (byte)human.GetAgeInYears(), (byte)human.GetProfession(),
                    human.HomeCell, cellID, false));
                cell.Humans[i].KillHuman();
            }

            return deadPeople;
        }

        public ESimulationStage SimulationStages { get { return ESimulationStage.AfterInfectedCalculation; } }

        public bool Equals(ISimulationComponent other)
        {
            var otherComponent = other as AgeingSimulationComponent;
            if (otherComponent == null)
                return false;
            return this.TicksPerYear == otherComponent.TicksPerYear && this.AgeLimit == otherComponent.AgeLimit;
        }
    }
}