using PSC2013.ES.Library.PopulationData;
using System;

namespace PSC2013.ES.Library.Simulation.Components
{
    public unsafe class InfectionCalculatorComponent : ISimulationComponent
    {
        public void PerformSimulationStage(SimulationData data)
        {
            //Let each Cell calculate what chance there is for an individual Human to get infected
            fixed (PopulationCell* cellptr = data.Cells)
            {
                for (PopulationCell* ptr = cellptr; ptr < cellptr + data.Cells.Length; ++ptr)
                {
                    ptr->CalculateProbability();
                }
            }

            //Let Humans get Infected by chance/ do their DiseaseTick
            fixed (Human* humanptr = data.Humans)
            {
                for (Human* ptr = humanptr; ptr < humanptr + data.Humans.Length; ++ptr)
                {
                    //If human isn't healthy 
                    if (ptr->IsInfected() || ptr->IsDiseased() || ptr->IsSpreading())
                    {
                        //TODO |h| Update InfectionCounter etc
                    }
                    else
                    {
                        //Pull chance to get infected use random to determine whether the human gets infected or not
                    }
                }
            }
        }

        public ESimulationStage SimulationStages { get { return ESimulationStage.InfectedCalculation; } }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ISimulationComponent);
        }

        public bool Equals(ISimulationComponent other)
        {
            var otherComponent = other as InfectionCalculatorComponent;
            if (otherComponent == null)
                return false;

            throw new NotImplementedException();
        }
    }
}