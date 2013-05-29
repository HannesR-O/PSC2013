using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library.Snapshot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSC2013.ES.Library.Simulation.Components
{
    public class AgeingSimulationComponent : SimulationComponent
    {
        // Assumes 365 x 24 hour days
        private const int HOURS_PER_YEAR = 8544;
        public int AgeLimit { get; private set; }
        public int TicksPerYear { get; private set; }
        

        private int _counter;

        /// <summary>
        /// Creates a new AgeingSimulationComponent and sets the "hour-value" of one tick.
        /// </summary>
        /// <param name="ageLimit">A value specifying at what age Humans should die of aging</param>
        public AgeingSimulationComponent(int ageLimit) : base(ESimulationStage.AfterInfectedCalculation)
        {
            AgeLimit = ageLimit;
            UpdateTicksPerYear();        
            _counter = 0;
        }

        private void UpdateTicksPerYear()
        {
            TicksPerYear = HOURS_PER_YEAR / _simulationIntervall;
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
                for (Human* human = humanptr; human < humanptr + data.Humans.Length; ++human)
                {
                    if (human->IsDead())
                        continue;

                    human->DoAgeTick();

                    if (human->GetAgeInYears() <= AgeLimit) continue;

                    deadPeople.Add(HumanSnapshot.InitializeFromRuntime((byte)human->GetGender(), (byte)human->GetAgeInYears(), (byte)human->GetProfession(),
                                                                       human->HomeCell, human->CurrentCell, false));
                    human->KillHuman();
                    var index = (int)human->GetGender();
                    index = index == 128 ? 0 : 4;
                    switch (human->GetAge())
                    {
                        case EAge.Baby:
                            break;
                        case EAge.Child:
                            index++;
                            break;
                        case EAge.Adult:
                            index += 2;
                            break;
                        case EAge.Senior:
                            index += 3;
                            break;
                    }
                    data.Cells[human->CurrentCell].Data[index]--;
                }
            }

            data.AddDeadPeople(deadPeople);
#if DEBUG
            Console.WriteLine("Dead people this Iteration: " + deadPeople.Count);
            Console.WriteLine("Total dead people: " + data.DeathCount);
#endif
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
            var otherComponent = other as AgeingSimulationComponent;
            if (otherComponent == null)
                return false;

            return this.TicksPerYear == otherComponent.TicksPerYear && this.AgeLimit == otherComponent.AgeLimit;
        }
    }
}