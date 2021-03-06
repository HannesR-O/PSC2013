﻿using PSC2013.ES.Library.PopulationData;
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
        public int TicksPerLeapYear { get; private set; }
        public byte YearsPerTick { get; private set; }
        

        private int _counter;

        /// <summary>
        /// Creates a new AgeingSimulationComponent and sets the "hour-value" of one tick.
        /// </summary>
        /// <param name="ageLimit">A value specifying at what age Humans should die of aging</param>
        public AgeingComponent(int ageLimit)
            : base(ESimulationStage.AfterInfectedCalculation)
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
            _counter = ++_counter;

            if (_counter % TicksPerYear != 0) return;

            // Year(s) have passed
#if DEBUG
            Console.WriteLine(YearsPerTick.ToString() + " Year(s) have passed!");
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

                        EAge previousAge = human->GetAge();

                        if (_counter % TicksPerLeapYear == 0)
                            human->DoAgeTick((byte)(YearsPerTick + 1));                 // "LeapTick" we need to increase YearsPerTick for this tick
                        else
                            human->DoAgeTick((byte)YearsPerTick);

                        UpdateHumanChangeToCell(human, data, previousAge);
                        AssignProfession(human, previousAge);

                        if (human->GetAgeInYears() <= AgeLimit) return;

                        lock (deadPeople)
                        {
                            deadPeople.Add(HumanSnapshot.InitializeFromRuntime((byte)human->GetGender(),
                                (byte)human->GetAgeInYears(), (byte)human->GetProfession(),
                                human->HomeCell, human->CurrentCell, false));
                        }

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

                        lock (data.Cells[human->CurrentCell])
                        {
                            PopulationCell currentCell = data.Cells[human->CurrentCell];
                            currentCell.Data[genderIndex]--;
                            if (human->IsInfected())
                            {
                                --currentCell.Infecting;

                                if (human->IsSpreading())
                                    --currentCell.Spreading;
                                if (human->IsDiseased())
                                    --currentCell.Diseased;
                            }
                        }
                    });
            }

            lock (data.Deaths)
                data.AddDeadPeople(deadPeople);
#if DEBUG
            Console.WriteLine("Dead people this Iteration: " + deadPeople.Count);
            Console.WriteLine("Total dead people: " + data.DeathCount);
#endif
        }

        private unsafe void AssignProfession(Human* hptr, EAge previousAge)
        {
            EAge newAgegroup = hptr->GetAge();

            if (newAgegroup != previousAge)
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

        private unsafe void UpdateHumanChangeToCell(Human* hptr, SimulationData data, EAge previousAge)
        {
            EAge newAge = hptr->GetAge();

            if (previousAge != newAge)
            {
                
                lock (data.Cells[hptr->CurrentCell])
                {
                    PopulationCell currentcell = data.Cells[hptr->CurrentCell];

                    if (hptr->GetGender() == EGender.Female)
                    {
                        if (newAge == EAge.Child)
                        {
                            --currentcell.FemaleBabies;
                            ++currentcell.FemaleChildren;
                        }
                        else if (newAge == EAge.Adult)
                        {
                            --currentcell.FemaleChildren;
                            ++currentcell.FemaleAdults;
                        }
                        else if (newAge == EAge.Senior)
                        {
                            --currentcell.FemaleAdults;
                            ++currentcell.FemaleSeniors;
                        }
                    }
                    else
                    {
                        if (newAge == EAge.Child)
                        {
                            --currentcell.MaleBabies;
                            ++currentcell.MaleChildren;
                        }
                        else if (newAge == EAge.Adult)
                        {
                            --currentcell.MaleChildren;
                            ++currentcell.MaleAdults;
                        }
                        else if (newAge == EAge.Senior)
                        {
                            --currentcell.MaleAdults;
                            ++currentcell.MaleSeniors;
                        }
                    }
                }
            }
        }

        private void UpdateTicksPerYear()
        {
            TicksPerYear = 1;
            YearsPerTick = 1;
            TicksPerLeapYear = -1;

            if (_simulationIntervall < HOURS_PER_YEAR)
            {
                TicksPerYear = HOURS_PER_YEAR / _simulationIntervall;       // Less than 1 year passes per tick => trivial calculation
                return;
            }

            if (_simulationIntervall % HOURS_PER_YEAR == 0)
            {
                YearsPerTick = (byte)(_simulationIntervall / HOURS_PER_YEAR);   // _simulationIntervall is a true multiple of HOURS_PER_YEAR =>
                return;                                                         // exactly (_simulationIntervall / HOURS_PER_YEAR) years pass each tick
            }

            int tmp = _simulationIntervall;
            YearsPerTick = 0;
            do
            {
                tmp -= HOURS_PER_YEAR;
                YearsPerTick++;
                if (tmp % HOURS_PER_YEAR == 0)
                {
                    YearsPerTick += (byte)(tmp / HOURS_PER_YEAR);   // If we find a true multiple in the loop interrupt and set the correct value
                    return;
                }
            } while (tmp > HOURS_PER_YEAR);
            TicksPerLeapYear = HOURS_PER_YEAR / tmp;        /* Worst case: The components activates every tick with the amount of YearsPerTick
                                                             * Each TicksPerLeap's tick this amount is temporaly increased by 1 to compensate */
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