using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using PSC2013.ES.Library.AreaData;
using PSC2013.ES.Library.PopulationData;
using Xunit;

namespace PSC2013.ES.Tests.AreaData
{
    public class MatrixGeneratorTest
    {
        private const int WIDTH = 15;
        private const int HEIGHT = 15;

        private DepartmentInfo[] _deps;
        private PopulationCell[] _pops;

        private void StartUp()
        {
            _deps = new DepartmentInfo[1];
            _pops = new PopulationCell[WIDTH * HEIGHT];

            DepartmentInfo dpi = new DepartmentInfo();
            dpi.Name = "TestDep";
            for (int i = 0; i < 8; i++)
                dpi.Population[i] = 10000;

            dpi.Coordinates = new Point[WIDTH * HEIGHT];

            for (int x = 0; x < WIDTH; x++)
                for (int y = 0; y < HEIGHT; y++)
                {
                    Point p = new Point(x, y);
                    dpi.Coordinates[x + (y * WIDTH)] = p;
                }

            _deps = new DepartmentInfo[1] { dpi };
        }

        [Fact]
        public void GenerateMatrix()
        {
            StartUp();

            MatrixGenerator.GenerateMatrix(_pops, _deps, WIDTH, HEIGHT);

#if DEBUG
            int[,] matrix = new int[WIDTH, HEIGHT];

            for (int x = 0; x < WIDTH; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    matrix[x, y] = _pops[x + (y * WIDTH)].Humans.Count(p => !p.IsDead());
                }
            }

            int[] snglMatrix = new int[WIDTH * HEIGHT];
            for (int i = 0; i < _pops.Length; i++)
            {
                snglMatrix[i] = _pops[i].Humans.Count(x => !x.IsDead());
            }

            Console.WriteLine("Matrix generated.");
#endif
            
        }
    }
}
