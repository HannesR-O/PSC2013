using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library.Snapshot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulation.Components
{
    public class AgeingComponent : SimulationComponent
    {
        // Assumes 365 x 24 hour days
        private const int HOURS_PER_YEAR = 8544;
        public int AgeLimit { get; private set; }
        public int TicksPerYear { get; private set; }
        public int YearsPerTick { get; private set; } //TODO: |f| need to add logic to that but im lazy

        private int _counter;

        /// <summary>
        /// Creates a new AgeingSimulationComponent and sets the "hour-value" of one tick.
        /// </summary>
        /// <param name="ageLimit">A value specifying at what age Humans should die of aging</param>
        public AgeingComponent(int ageLimit) : base(ESimulationStage.AfterInfectedCalculation)
        {
            AgeLimit = ageLimit;
            UpdateTicksPerYear();        
            _counter = 0;
        }

        public override void SetSimulationIntervall(int intervall)
        {
            base.SetSimulationIntervall(intervall);
            UpdateTicksPerYear();
        }

        public unsafe override void PerformSimulationStage(SimulationData data)
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
                Human* startPtr = humanptr;

                Parallel.For(0, data.Humans.Length, Constants.DEFAULT_PARALLELOPTIONS,
                    index =>
                    {
                        Human* human = startPtr + index;

                        if (human->IsDead())
                            return;

                        human->DoAgeTick(1);            //TODO: |f| fixme im dirty nonsense

                        if (human->GetAgeInYears() <= AgeLimit) return;

                        deadPeople.Add(HumanSnapshot.InitializeFromRuntime((byte)human->GetGender(),
                            (byte)human->GetAgeInYears(), (byte)human->GetProfession(),
                            human->HomeCell, human->CurrentCell, false));

                        human->KillHuman();
                        var genderIndex = (int)human->GetGender();
                        genderIndex = genderIndex == 128 ? 0 : 4;
                        switch (human->GetAge())
                        {
                            case EAge.Baby:
                                break;
                            case EAge.Child:
                                genderIndex++;
                                break;
                            case EAge.Adult:
                                genderIndex += 2;
                                break;
                            case EAge.Senior:
                                genderIndex += 3;
                                break;
                        }
                        data.Cells[human->CurrentCell].Data[genderIndex]--;
                    });
            }

            data.AddDeadPeople(deadPeople);
#if DEBUG
            Console.WriteLine("Dead people this Iteration: " + deadPeople.Count);
            Console.WriteLine("Total dead people: " + data.DeathCount);
#endif
        }

        private void UpdateTicksPerYear()
        {
            TicksPerYear = HOURS_PER_YEAR / _simulationIntervall;
        }

        public override int GetHashCode()
        {
            return AgeLimit.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SimulationComponent);
        }

        public override bool Equals(SimulationComponent other)
        {
            var otherComponent = other as AgeingComponent;
            if (otherComponent == null)
                return false;

            return this.TicksPerYear == otherComponent.TicksPerYear && this.AgeLimit == otherComponent.AgeLimit;
        }
    }
}