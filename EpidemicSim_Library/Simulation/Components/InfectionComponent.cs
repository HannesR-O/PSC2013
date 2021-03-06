﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PSC2013.ES.Library.PopulationData;
using System;
using System.Drawing;
using PSC2013.ES.Library.DiseaseData;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Simulation.Components
{
    public class InfectionComponent : SimulationComponent
    {
        private int _arrayHeight, _arrayWidth, _arrayMaxIndex;
        private SimulationData _data;

        public InfectionComponent() : base(ESimulationStage.InfectedCalculation)
        {

        }

        public override unsafe void PerformSimulationStage(SimulationData data)
        {
            _data = data;
            Disease disease = _data.DiseaseToSimulate;

            if (_arrayHeight == 0 /* || _arrayWidth == 0 */) //Checking one value should be enough, only happens in first round
            {
                _arrayHeight = _data.ImageHeight;
                _arrayWidth = _data.ImageWidth;
                _arrayMaxIndex = _arrayHeight * _arrayWidth;
            }

            //Let each Cell calculate its probability
            for (int index = 0; index < data.Cells.Length; ++index)
            {
                PopulationCell cell = data.Cells[index];
                if (cell != null)
                    cell.Probability = CalculateProbability(index, disease.Transferability);
            }

            //Let Humans get Infected by chance
            fixed (Human* humanptr = data.Humans)
            {
                Human* startPtr = humanptr;

                Parallel.For(0, _data.Humans.Length, Constants.DEFAULT_PARALLELOPTIONS,
                    index =>
                    {
                        Human* ptr = startPtr + index;

                        if (!ptr->IsDead() && !ptr->IsInfected())
                        {
                            int probability = 0;
                            lock (_data.Cells[ptr->CurrentCell])
                                probability = _data.Cells[ptr->CurrentCell].Probability;

                            TryInfection(ptr, disease, probability);
                        }
                    });
                //TODO: Old code for speed boost reference.. DELETE when done
                //for (Human* ptr = humanptr; ptr < humanptr + _data.Humans.Length; ++ptr)
                //{
                //    if (!ptr->IsDead() && !ptr->IsInfected())
                //    {
                //        TryInfection(ptr, disease, _data.Cells[ptr->CurrentCell].Probability);
                //    }
                //}
            }
        }

        private int CalculateProbability(int currentCellIndex, int transferability)
        {
            var surroundings = GetCorrespondingCells(currentCellIndex);

            double chance = 0;
            foreach (PopulationCell cell in surroundings)
            {
                if(cell.Spreading != 0)
                    chance += ((cell.Spreading * 100d / cell.Total * (transferability / 100d)));
            }

            chance = chance / surroundings.Count();

            // now the current cell is equally treated like the surrounding...
            return (int)chance;
        }

        private IEnumerable<PopulationCell> GetCorrespondingCells(int cell)
        {
            return (from cellIndex in GetSurroundingCellIndices(cell)       //dat LINQ...
                    where _data.Cells[cellIndex] != null
                    select _data.Cells[cellIndex]);
        }

        private int[] GetSurroundingCellIndices(int cellIndex)
        {
            Point indexPoint = cellIndex.DeFlatten(_arrayWidth);
            List<int> indices = new List<int>(8);

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (CheckPoint(indexPoint.X + i, indexPoint.Y + j))
                        indices.Add(indexPoint.X + i + ((indexPoint.Y + j) * _arrayWidth));
                }
            }

            return indices.ToArray();
        }

        private bool CheckPoint(int x, int y)
        {
            return x >= 0 && x < _arrayWidth
                && y >= 0 && y < _arrayHeight;
        }

        private unsafe void TryInfection(Human* human, Disease disease, int probability)
        {
            // get index for FactorContainer
            int ageIndex = (byte)human->GetAge() / 32;
            ageIndex += human->GetGender() == EGender.Male ? 0 : 4;

            int resistance = disease.ResistanceFactor.Data[ageIndex];

            if (resistance < probability)
            {
                int factor = probability - resistance;
                int rand = RANDOM.Next(100);
                if (rand <= factor)
                {
                    human->Infect((short)disease.IncubationPeriod, (short)disease.IdleTime);
                    lock (_data.Cells[human->CurrentCell])
                        _data.Cells[human->CurrentCell].Infecting++;
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
            var otherComponent = other as InfectionComponent;
            if (otherComponent == null)
                return false;

            throw new NotImplementedException();
        }
    }
}