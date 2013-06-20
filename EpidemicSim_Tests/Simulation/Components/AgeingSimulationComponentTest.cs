using System;
using PSC2013.ES.Library.Simulation.Components;
using Xunit;
using PSC2013.ES.Library;

namespace PSC2013.ES.Tests.Simulation.Components
{
    public class AgeingSimulationComponentTest
    {
        private const int HOURS_PER_YEAR = 8544;

        private const int DEFAULT_AGE_LIMIT = 110;
        private const int DEFAULT_HOURS_PER_TICK = 1;
        private const int DEFAULT_YEARS_PER_TICK = 1;
        private const int DEFAULT_TICKS_PER_LEAP_YEAR = 1;

        private AgeingComponent _component;

        private void SetUp()
        {
            _component = new AgeingComponent(DEFAULT_AGE_LIMIT);
            _component.SetSimulationIntervall(DEFAULT_HOURS_PER_TICK);
        }

        [Fact]
        public void ConstructorTest()
        {
            SetUp();

            Assert.Equal(ESimulationStage.AfterInfectedCalculation, _component.SimulationStages);
            Assert.Equal(HOURS_PER_YEAR/DEFAULT_HOURS_PER_TICK, _component.TicksPerYear);
            Assert.Equal(DEFAULT_AGE_LIMIT, _component.AgeLimit);

            int ageLimit = RANDOM.Next(125);                              // |f| Just to stay realistic :D
            int simulationIntervall = RANDOM.Next(1, HOURS_PER_YEAR);     // |f| Do not need to test outside of 1-8544

            _component = new AgeingComponent(ageLimit);
            _component.SetSimulationIntervall(simulationIntervall);

            Assert.Equal(HOURS_PER_YEAR/simulationIntervall, _component.TicksPerYear);
            Assert.Equal(ageLimit, _component.AgeLimit);
        }

        [Fact]
        public void SimulationIntervallBoundariesTest()
        {
            SetUp();

            for (int i = 1; i < 50; i++)                                // TODO: |f| need to figure out aquivalents
            {
                _component.SetSimulationIntervall(HOURS_PER_YEAR / i);
                Assert.Equal(i, _component.TicksPerYear);
                Assert.Equal(1, _component.YearsPerTick);
                Assert.Equal(-1, _component.TicksPerLeapYear);
            }

            for (int i = 1; i < 50; i++)                                // TODO: |f| need to figure out aquivalents
            {
                _component.SetSimulationIntervall(HOURS_PER_YEAR + i);
                Assert.Equal(1, _component.TicksPerYear);
                Assert.Equal(1, _component.YearsPerTick);
                Assert.Equal(HOURS_PER_YEAR / i, _component.TicksPerLeapYear);
            }

            for (int i = 1; i < 50; i++)                                // TODO: |f| need to figure out aquivalents
            {
                _component.SetSimulationIntervall(HOURS_PER_YEAR * i);
                Assert.Equal(1, _component.TicksPerYear);
                Assert.Equal(i, _component.YearsPerTick);
                Assert.Equal(-1, _component.TicksPerLeapYear);
            }
        }

        [Fact]
        public void AgeingComponentSimulationStagesTest()
        {
            SetUp();

            Assert.Equal(ESimulationStage.AfterInfectedCalculation, _component.SimulationStages);
        }
    }
}