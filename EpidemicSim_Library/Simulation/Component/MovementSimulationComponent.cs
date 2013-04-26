using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulation.Component
{
    /// <summary>
    /// SimulationComponent to move the entire human population 
    /// according to their Mindset, Profession, Healthstatus and SimulationTime
    /// </summary>
    public class MovementSimulationComponent : ISimulationComponent
    {
        public void PerformSimulationStage(SimulationData data)
        {
            for (int i = 0; i < data.Population.Length; ++i)
            {
                for (int j = 0; j < data.Population[i].Humans.Length; ++j)
                {
                    switch (data.Population[i].Humans[j].GetProfession())
                    {
                        case PopulationData.EProfession.Pupil: MovePupil(data, i, j); break;
                    }
                }
            }
        }

        private void MovePupil(SimulationData data , int cell, int human)
        {
            switch(data.Population[cell].Humans[human].GetMindset())
            {
                case PopulationData.EMindset.Working: break;
                case PopulationData.EMindset.HomeStaying: break;
                case PopulationData.EMindset.Shopping: break;
                case PopulationData.EMindset.Stationary: break;
                case PopulationData.EMindset.Travelling: break;
                case PopulationData.EMindset.Vacationing: break;
            }
        }

        private void MoveStudent(SimulationData data, int cell, int human)
        {

            switch (data.Population[cell].Humans[human].GetMindset())
            {
                case PopulationData.EMindset.Working: break;
                case PopulationData.EMindset.HomeStaying: break;
                case PopulationData.EMindset.Shopping: break;
                case PopulationData.EMindset.Stationary: break;
                case PopulationData.EMindset.Travelling: break;
                case PopulationData.EMindset.Vacationing: break;
            }
        }

        private void MovePlumber(SimulationData data, int cell, int human)
        {

            switch (data.Population[cell].Humans[human].GetMindset())
            {
                case PopulationData.EMindset.Working: break;
                case PopulationData.EMindset.HomeStaying: break;
                case PopulationData.EMindset.Shopping: break;
                case PopulationData.EMindset.Stationary: break;
                case PopulationData.EMindset.Travelling: break;
                case PopulationData.EMindset.Vacationing: break;
            }
        }

        private void MoveDeskJobber(SimulationData data , int cell, int human)
        {

            switch(data.Population[cell].Humans[human].GetMindset())
            {
                case PopulationData.EMindset.Working: break;
                case PopulationData.EMindset.HomeStaying: break;
                case PopulationData.EMindset.Shopping: break;
                case PopulationData.EMindset.Stationary: break;
                case PopulationData.EMindset.Travelling: break;
                case PopulationData.EMindset.Vacationing: break;
            }
        }

        private void MoveHousewife(SimulationData data, int cell, int human)
        {

            switch (data.Population[cell].Humans[human].GetMindset())
            {
                case PopulationData.EMindset.Working: break;
                case PopulationData.EMindset.HomeStaying: break;
                case PopulationData.EMindset.Shopping: break;
                case PopulationData.EMindset.Stationary: break;
                case PopulationData.EMindset.Travelling: break;
                case PopulationData.EMindset.Vacationing: break;
            }
        }

        private void MoveTravellingSalesman(SimulationData data, int cell, int human)
        {

            switch (data.Population[cell].Humans[human].GetMindset())
            {
                case PopulationData.EMindset.Working: break;
                case PopulationData.EMindset.HomeStaying: break;
                case PopulationData.EMindset.Shopping: break;
                case PopulationData.EMindset.Stationary: break;
                case PopulationData.EMindset.Travelling: break;
                case PopulationData.EMindset.Vacationing: break;
            }
        }

        public ESimulationStage GetSimulationStages()
        {
            return ESimulationStage.BeforeInfectedCalculation;
        }
    }
}
