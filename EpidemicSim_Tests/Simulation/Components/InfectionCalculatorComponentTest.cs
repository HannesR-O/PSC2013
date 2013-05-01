using System;
using PSC2013.ES.Library.Simulation.Components;
using Xunit;

namespace PSC2013.ES.Tests.Simulation.Components
{
    public class InfectionCalculatorComponentTest
    {
        private InfectionCalculatorComponent _component;

        private void SetUp()
        {
            _component = new InfectionCalculatorComponent();
        }

        [Fact]
        public void InfectionCalculatorComponentSimulationStagesTest()
        {
            SetUp();

            Assert.Equal(ESimulationStage.InfectedCalculation, _component.SimulationStages);
        }
    }
}