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
        private readonly int _ticksPerYear, _ageLimit;

        private int _counter;

        /// <summary>
        /// Creates a new AgeingSimulationComponent and sets the "hour-value" of one tick.
        /// </summary>
        /// <param name="hoursPerTick">A value specifying how many hours pass in one SimulationTick</param>
        /// <param name="ageLimit">A value specifying at what age Humans should day of aging</param>
        public AgeingSimulationComponent(int hoursPerTick, int ageLimit)
        {
            _ticksPerYear = HOURS_PER_YEAR / hoursPerTick;        //TODO: |f| not the most accurate but should be enough for our purposes
            _ageLimit = ageLimit;
            _counter = 0;
        }

        public void PerformSimulationStage(SimulationData data)
        {
            _counter = ++_counter % _ticksPerYear;

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
            Console.WriteLine("Total dead people: " + data.DeathCount);
#endif
        }

        private IEnumerable<HumanSnapshot> HandleSinglePopulationCell(PopulationCell cell, int cellID)
        {
            var deadPeople = new List<HumanSnapshot>();

            foreach (var human in cell.Humans.Where(human => !human.IsDead()))
            {
                human.DoAgeTick();

                if (human.GetAgeInYears() <= _ageLimit) continue;

                // Human dies from over ageing                              //TODO: |f| Add percentage rates for dieing at high ages
                deadPeople.Add(new HumanSnapshot(human.GetGender(), human.GetAgeInYears(), human.HomeCell, cellID, false));
            }

            return deadPeople;
        }

        public ESimulationStage SimulationStages { get { return ESimulationStage.AfterInfectedCalculation; } }
    }
}