﻿using System;

namespace PSC2013.ES.Library.Simulation.Components
{
    public class DebugSimulationComponent : ISimulationComponent
    {
        void ISimulationComponent.PerformSimulationStage(SimulationData data)
        {
#if DEBUG
            Console.WriteLine("DEBUG SIMULATION TICK");
#endif
        }

        ESimulationStage ISimulationComponent.SimulationStages
        {
            get { return ESimulationStage.InfectedCalculation; }
        }

        public bool Equals(ISimulationComponent other)
        {
            return (other as DebugSimulationComponent) != null;
        }
    }
}