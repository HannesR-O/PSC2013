using System;
using System.Linq;
using System.Drawing;
using PSC2013.ES.Library.AreaData;
using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library;
using Xunit;

namespace PSC2013.ES.Tests.AreaData
{
    public class MatrixGeneratorTest
    {
        private const int WIDTH = 15;
        private const int HEIGHT = 15;

        private DepartmentInfo[] _departments;
        private PopulationCell[] _populationCells;
        private int _originalCount;

        private void StartUp()
        {
            _departments = new DepartmentInfo[1];
            _populationCells = new PopulationCell[WIDTH * HEIGHT];
            _populationCells.Initialize<PopulationCell>();

            DepartmentInfo depInfo = new DepartmentInfo();
            depInfo.Name = "TestDep";
            Random rand = new Random();
            for (int i = 0; i < 8; i++)
                depInfo.Population[i] = rand.Next(100, 10000);

            depInfo.Coordinates = new Point[(WIDTH * HEIGHT)];

            for (int x = 0; x < WIDTH; x++)
                for (int y = 0; y < HEIGHT; y++)
                {
                    Point p = new Point(x, y);
                    depInfo.Coordinates[x + (y * WIDTH)] = p;
                }

            _departments = new DepartmentInfo[1] { depInfo };

            foreach (DepartmentInfo item in _departments)
                _originalCount += item.Population.Sum();
        }

        [Fact]
        public void GenerateMatrix()
        {
            StartUp();

            MatrixGenerator.GenerateMatrix(_populationCells, _departments, WIDTH, HEIGHT);
            
            int actualCount = 0;
            foreach (PopulationCell item in _populationCells)
                actualCount += item.Humans.Count(x => !x.IsDead());

#if DEBUG
            int[,] matrix = _populationCells.To2DIntArray(WIDTH);
#endif
            // Test allows 1%-difference. (having 80000 people it results into +-800...)
            Assert.True(actualCount <= _originalCount * 1.01 && actualCount >= _originalCount * 0.99);
            
        }
    }
}
