﻿using System;
using PSC2013.ES.Library.Simulation.Components;
using Xunit;

namespace PSC2013.ES.Tests.Simulation.Components
{
    public class AgeingSimulationComponentTest
    {
        private const int HOURS_PER_YEAR = 8544;
        private const int DEFAULT_HOURS_PER_TICK = 1;
        private const int DEFAULT_AGE_LIMIT = 110;

        private AgeingSimulationComponent _component;

        private void SetUp()
        {
            _component = new AgeingSimulationComponent(DEFAULT_HOURS_PER_TICK,  DEFAULT_AGE_LIMIT);
        }

        [Fact]
        public void AgeingComponentConstructorTest()
        {
            SetUp();

            Assert.Equal(HOURS_PER_YEAR/DEFAULT_HOURS_PER_TICK, _component.TicksPerYear);
            Assert.Equal(DEFAULT_AGE_LIMIT, _component.AgeLimit);

            int hoursPerTick = new Random().Next(1, HOURS_PER_YEAR);    // |f| Do not need to test outside of 1-8544
            int ageLimit = new Random().Next(125);                      // |f| Just to stay realistic :D

            _component = new AgeingSimulationComponent(hoursPerTick, ageLimit);

            Assert.Equal(HOURS_PER_YEAR/hoursPerTick, _component.TicksPerYear);
            Assert.Equal(ageLimit, _component.AgeLimit);
        }

        [Fact]
        public void AgeingComponentSimulationStagesTest()
        {
            SetUp();

            Assert.Equal(ESimulationStage.AfterInfectedCalculation, _component.SimulationStages);
        }
    }
}