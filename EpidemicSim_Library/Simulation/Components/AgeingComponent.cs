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

                        EAge previousAgegroup = human->GetAge();

                        human->DoAgeTick(1);            //TODO: |f| fixme im dirty nonsense

                        AssignProfession(human, previousAgegroup);

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
                        PopulationCell currentCell = data.Cells[human->CurrentCell];
                        lock (currentCell) currentCell.Data[genderIndex]--;
                    });
            }

            data.AddDeadPeople(deadPeople);
#if DEBUG
            Console.WriteLine("Dead people this Iteration: " + deadPeople.Count);
            Console.WriteLine("Total dead people: " + data.DeathCount);
#endif
        }

        private unsafe void AssignProfession(Human* hptr, EAge previousAgegroup)
        {
            EAge newAgegroup = hptr->GetAge();

            if (newAgegroup != previousAgegroup)
            {
                if (newAgegroup == EAge.Child)
                {
                    hptr->SetProfession(EProfession.Pupil);
                }
                else if (newAgegroup == EAge.Adult)
                {
                    int choice = RANDOM.Next(6);
                    switch (choice)
                    {
                        case 0: hptr->SetProfession(EProfession.Student); break;
                        case 1: hptr->SetProfession(EProfession.Plumber); break;
                        case 2: hptr->SetProfession(EProfession.Commuter); break;
                        case 3: hptr->SetProfession(EProfession.DeskJobber); break;
                        case 4: hptr->SetProfession(EProfession.TravellingSalesman); break;
                        case 5: hptr->SetProfession(EProfession.Housewife); break;
                    }
                }
                else if (newAgegroup == EAge.Senior)
                {
                    hptr->SetProfession(EProfession.Housewife);
                }
                else
                {
                    throw new Exception("Someone seemed to have found the fountain of Youth" +
                    "atleast he wasn't a baby before this Agetick and now he is. MAGIC!");
                }
            }
            else
            {
                if (hptr->GetProfession() == EProfession.Student && hptr->GetAgeInYears() >= 30)
                {
                    int choice = RANDOM.Next(5);
                    switch (choice)
                    {
                        case 0: hptr->SetProfession(EProfession.Plumber); break;
                        case 1: hptr->SetProfession(EProfession.Commuter); break;
                        case 2: hptr->SetProfession(EProfession.DeskJobber); break;
                        case 3: hptr->SetProfession(EProfession.TravellingSalesman); break;
                        case 4: hptr->SetProfession(EProfession.Housewife); break;
                    }
                }
            }
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