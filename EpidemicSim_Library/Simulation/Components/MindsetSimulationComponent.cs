using PSC2013.ES.Library.PopulationData;
using System;

namespace PSC2013.ES.Library.Simulation.Components
{
    public unsafe class MindsetSimulationComponent : ISimulationComponent
    {
        private int _simulationIntervall;
        private Human* _ptr;
        private Random _random;

        MindsetSimulationComponent()
        {
            _random = new Random();
            _simulationIntervall = 1;
        }

        public void PerformSimulationStage(SimulationData data)
        {
            fixed (Human* humanptr = data.Humans)
            {
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
                                if (_random.Next(365) < 20)
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

        public void SetSimulationIntervall(int intervall)
        {
            _simulationIntervall = intervall;           //TODO: |f| make use of this ;) & add range checks?
        }

        public ESimulationStage SimulationStages
        {
            get { return ESimulationStage.BeforeInfectedCalculation; }
        }

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
            var otherComponent = other as MindsetSimulationComponent;
            if (otherComponent == null)
                return false;

            throw new NotImplementedException();
        }
    }
}