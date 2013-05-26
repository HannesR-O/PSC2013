using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PSC2013.ES.Library.PopulationData;
using System;
using System.Drawing;

namespace PSC2013.ES.Library.Simulation.Components
{
    public class InfectionCalculatorComponent : ISimulationComponent
    {
        private readonly Random _random;
        private int _simulationIntervall, _arrayHeight, _arrayWidth, _arrayMaxIndex;

        public InfectionCalculatorComponent()
        {
            _simulationIntervall = 1;
            _random = new Random((int)DateTime.Now.Ticks);
        }

        public unsafe void PerformSimulationStage(SimulationData data)
        {
            if (_arrayHeight == 0 /* || _arrayWidth == 0 */) //Checking one value should be enough, only happens in first round
            {
                _arrayHeight = data.ImageHeight;
                _arrayWidth = data.ImageWidth;
                _arrayMaxIndex = _arrayHeight * _arrayWidth;
            }

            //Let each Cell calculate its probability (currently Total/Spreading)
            for (int index = 0; index < data.Cells.Length; ++index)
            {
                PopulationCell cell = data.Cells[index];
                if (cell != null)
                    cell.Probability = CalculateProbability(data.Cells, index, data.CurrentDisease.Transferability);
            }

            //Let Humans get Infected by chance/ do their DiseaseTick
            fixed (Human* humanptr = data.Humans)
            {
                for (Human* ptr = humanptr; ptr < humanptr + data.Humans.Length; ++ptr)
                {
                    ptr->DoDiseaseTick();

                    //foreach (var cell in GetCorrespondingCells(ptr->CurrentCell, data.Cells))
                    // TODO | dj | ^ this one should not be necessary. the propability in each cell should be enough.
                    {
                        /* These are the (existing) cells surrounding the cell the human is currently staying in
                         * also the ssurroundings get calculated everytime again (for every human!!).. 
                         * might consider saving them but this will be memory intensive..  
                         * also i dont know what to do with them.. ;( */
                    }
                }
            }
        }

        private int CalculateProbability(PopulationCell[] cells, int currentCellIndex, int trans)
        {
            var surroundings = GetCorrespondingCells(currentCellIndex, cells);

            int prop = 0;
            foreach (PopulationCell cell in surroundings)
            {
                prop += (int)((cell.Total * 100f) / cell.Spreading * (trans / 100f));
            }

            prop = prop / surroundings.Count();

            // now the current cell is eqully treated like the surrounding...
            return prop;
        }

        private IEnumerable<PopulationCell> GetCorrespondingCells(int cell, PopulationCell[] allCells)
        {
            return (from cellIndex in GetSurroundingCellIndices(cell)       //dat LINQ...
                    where allCells[cellIndex] != null
                    select allCells[cellIndex]);
        }

        private int[] GetSurroundingCellIndices(int cellIndex)
        {
            Point indexPoint = cellIndex.DeFlatten(_arrayWidth);
            List<int> indices = new List<int>(8);

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    Point newCellPoint = new Point(indexPoint.X + i, indexPoint.Y + j);
                    if (CheckPoint(newCellPoint))
                        indices.Add(newCellPoint.Flatten(_arrayWidth));
                }
            }

            return indices.ToArray();
        }

        private bool CheckPoint(Point point)
        {
            return point.X >= 0 && point.X < _arrayWidth
                && point.Y >= 0 && point.X < _arrayHeight;
        }

        public void SetSimulationIntervall(int intervall)
        {
            _simulationIntervall = intervall;           //TODO: |f| make use of this ;) & add range checks?
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