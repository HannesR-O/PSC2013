using PSC2013.ES.Library.PopulationData;
using System;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulation.Components
{
    public unsafe class MindsetComponent : SimulationComponent
    {
        public MindsetComponent() : base(ESimulationStage.BeforeInfectedCalculation)
        {
            _simulationIntervall = 1;
        }

        public unsafe override void PerformSimulationStage(SimulationData data)
        {
            fixed (Human* humanptr = data.Humans)
            {
                Human* startPtr = humanptr;
                Parallel.For(0, data.Humans.Length, Constants.DEFAULT_PARALLELOPTIONS,
                    index =>
                    {
                        Human* ptr = startPtr + index;

                        if (ptr->IsAtHome())
                        {
                            if (ptr->IsDiseased())
                            {
                                if (ptr->GetAge() == EAge.Senior || ptr->GetAge() == EAge.Baby)
                                    ptr->SetMindset(EMindset.Stationary);
                                else
                                    ptr->SetMindset(EMindset.HomeStaying);
                            }
                            else
                            {
                                if (data.CurrentDay != DayOfWeek.Saturday && data.CurrentDay != DayOfWeek.Sunday)
                                {
                                    if (RANDOM.Next(365) < 20)
                                        ptr->SetMindset(EMindset.Vacationing);
                                    else
                                        ptr->SetMindset(EMindset.Working);
                                }
                                else
                                {
                                    ptr->SetMindset(EMindset.DayOff);
                                }
                            }
                        }
                    });
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SimulationComponent);
        }

        public override bool Equals(SimulationComponent other)
        {
            var otherComponent = other as MindsetComponent;
            if (otherComponent == null)
                return false;

            throw new NotImplementedException();
        }
    }
}