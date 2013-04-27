﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library.Snapshot;

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
            //Console.WriteLine("Year has passed!");
#endif
            var deadPeople = new List<HumanSnapshot>();
            Parallel.For<List<HumanSnapshot>>(0, data.Population.Count(), () => new List<HumanSnapshot>(), (i, loop, tmpResult) =>
            {
                if (data.Population[i] == null) return tmpResult;

                tmpResult.AddRange(HandleSinglePopulationCell(data.Population[i], i));
                return tmpResult;
            },
            deadPeople.AddRange
            );
            
            data.AddDeadPeople(deadPeople);

            //for (int i = 0; i < data.Population.Count(); i++)
            //{
            //    if (data.Population[i] == null) continue;

            //    var tmpResult = HandleSinglePopulationCell(data.Population[i], i);

            //    lock (data.Population)
            //        data.AddDeadPeople(tmpResult);
            //}
#if DEBUG
            //Console.WriteLine("Total dead people: " + data.DeathCount);
#endif
        }

        private IEnumerable<HumanSnapshot> HandleSinglePopulationCell(PopulationCell cell, int cellID)
        {
            var deadPeople = new List<HumanSnapshot>();

            Parallel.ForEach<Human, List<HumanSnapshot>>(cell.Humans,
                () => new List<HumanSnapshot>(),
                (human, loop, tmpResult) =>
                {
                    if (human.IsDead()) return tmpResult;
                    human.DoAgeTick();
                    
                    if (human.GetAgeInYears() <= _ageLimit) return tmpResult;

                    // Human dies from over ageing
                    tmpResult.Add(new HumanSnapshot(human.GetGender(), human.GetAgeInYears(), human.HomeCell, cellID, false));
                    return tmpResult;
                },
                deadPeople.AddRange
                );

            return deadPeople;
        }

        public ESimulationStage SimulationStages { get { return ESimulationStage.AfterInfectedCalculation; } }
    }
}