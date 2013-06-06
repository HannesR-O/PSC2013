using PSC2013.ES.Library.PopulationData;
using System;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulation.Components
{
    public unsafe class MindsetComponent : SimulationComponent
    {
        private Human* _ptr;

        public MindsetComponent() : base(ESimulationStage.BeforeInfectedCalculation)
        {
            _simulationIntervall = 1;
        }

        public unsafe override void PerformSimulationStage(SimulationData data)
        {
            fixed (Human* humanptr = data.Humans)
            {
                // TODO | dj & h | no parallel possible because of exemplar-variable!
                for (_ptr = humanptr; _ptr < humanptr + data.Humans.Length; ++_ptr)
                {
                    if (_ptr->IsAtHome())
                    {
                        if (_ptr->IsDiseased())
                        {
                            if (_ptr->GetAge() == EAge.Senior || _ptr->GetAge() == EAge.Baby)
                                _ptr->SetMindset(EMindset.Stationary);
                            else
                                _ptr->SetMindset(EMindset.HomeStaying);
                        }
                        else
                        {
                            if (data.CurrentDay != DayOfWeek.Saturday && data.CurrentDay != DayOfWeek.Sunday)
                            {
                                if (RANDOM.Next(365) < 20)
                                    _ptr->SetMindset(EMindset.Vacationing);
                                else
                                    _ptr->SetMindset(EMindset.Working);
                            }
                            else
                            {
                                _ptr->SetMindset(EMindset.DayOff);
                            }
                        }
                    }
                }
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