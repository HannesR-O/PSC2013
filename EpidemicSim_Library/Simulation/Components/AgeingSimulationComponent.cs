using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library.Snapshot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSC2013.ES.Library.Simulation.Components
{
    public unsafe class AgeingSimulationComponent : ISimulationComponent
    {
        // Assumes 365 x 24 hour days
        private const int HOURS_PER_YEAR = 8544;
        public int AgeLimit { get; private set; }public int TicksPerYear { get; private set; }
        

        private int _counter;

        /// <summary>
        /// Creates a new AgeingSimulationComponent and sets the "hour-value" of one tick.
        /// </summary>
        /// <param name="ageLimit">A value specifying at what age Humans should die of aging</param>
        /// <param name="hoursPerTick">A value specifying how many hours pass in one simulation tick</param>
        public AgeingSimulationComponent(int ageLimit, int hoursPerTick)
        {
            AgeLimit = ageLimit;
            TicksPerYear = HOURS_PER_YEAR / hoursPerTick;        //TODO: |f| not the most accurate but should be enough for our purposes
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

            fixed (Human* humanptr = data.Humans)
            {
                for (Human* ptr = humanptr; ptr < humanptr + data.Humans.Length; ++ptr)
                {
                    if (ptr->IsDead())
                        continue;

                    ptr->DoAgeTick();

                    if (!(ptr->GetAgeInYears() <= AgeLimit))
                    {
                        deadPeople.Add(HumanSnapshot.InitializeFromRuntime((byte)ptr->GetGender(), (byte)ptr->GetAgeInYears(), (byte)ptr->GetProfession(),
                                                    ptr->HomeCell, ptr->CurrentCell, false));
                        ptr->KillHuman();
                    }
                }
            }

            data.AddDeadPeople(deadPeople);
#if DEBUG
            Console.WriteLine("Dead people this Iteration: " + deadPeople.Count);
            Console.WriteLine("Total dead people: " + data.DeathCount);
#endif
        }

        public ESimulationStage SimulationStages { get { return ESimulationStage.AfterInfectedCalculation; } }

        public override int GetHashCode()
        {
            return AgeLimit.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ISimulationComponent);
        }

        public bool Equals(ISimulationComponent other)
        {
            var otherComponent = other as AgeingSimulationComponent;
            if (otherComponent == null)
                return false;

            return this.TicksPerYear == otherComponent.TicksPerYear && this.AgeLimit == otherComponent.AgeLimit;
        }
    }
}