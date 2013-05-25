using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PSC2013.ES.Library.PopulationData;
using System;

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
            foreach (var cell in data.Cells.NotNullIterator())
            {
                //TODO: |f & h| Calculate Probability or sth similar for each cell
                cell.Probability = CalculateProbability(cell);
            }

            //Let Humans get Infected by chance/ do their DiseaseTick
            fixed (Human* humanptr = data.Humans)
            {
                for (Human* ptr = humanptr; ptr < humanptr + data.Humans.Length; ++ptr)
                {
                    ptr->DoDiseaseTick();

                    foreach (var cell in GetCorrespondingCells(ptr->CurrentCell, data.Cells))
                    {
                        /* These are the (existing) cells surrounding the cell the human is currently staying in
                         * also the ssurroundings get calculated everytime again (for every human!!).. 
                         * might consider saving them but this will be memory intensive..  
                         * also i dont know what to do with them.. ;( */
                    }
                }
            }
        }

        private IEnumerable<PopulationCell> GetCorrespondingCells(int cell, PopulationCell[] allCells)
        {
            return (from cellIndex in GetSurroundingCellIndices(cell)       //dat LINQ...
                    where cellIndex != -1
                    where allCells[cellIndex] != null
                    select allCells[cellIndex]);
        }

        private int[] GetSurroundingCellIndices(int cell)
        {
            Tuple<int, int> index = ExpandIndex(cell);
            var indices = new int[9];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var calulatedIndex = FlattenIndex(index.Item1 + (i - 1), index.Item2 + (j - 1));
                    indices[3 * i + j] = calulatedIndex >= 0  && calulatedIndex < _arrayMaxIndex? calulatedIndex : -1;
                }
            }

            return indices;
        }

        private Tuple<int, int> ExpandIndex(int index)
        {
            int x = index % _arrayWidth;
            int y = index / x;              //TODO: Should be correct, but better check
            return new Tuple<int, int>(x, y);
        }

        private int FlattenIndex(int x, int y)
        {
            return x + (y * _arrayWidth);
        }

        private int CalculateProbability(PopulationCell cell)
        {
            //TODO: |anyone| insert better probability calculation
            return (cell.Total * 100) / cell.Spreading;
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