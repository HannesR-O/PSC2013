﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
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

        private DepartmentInfo[] _deps;
        private PopulationCell[] _pops;
        private int _depC;

        private void StartUp()
        {
            _deps = new DepartmentInfo[1];
            _pops = new PopulationCell[WIDTH * HEIGHT];
            _pops.Initialize<PopulationCell>();

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

            foreach (DepartmentInfo item in _deps)
                _depC += item.Population.Sum();
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
            
            int cn = 0;
            foreach (PopulationCell item in _pops)
                cn += item.Humans.Count(x => !x.IsDead());
            Console.WriteLine("Is: " + cn);
            Console.WriteLine("Wanted: " + _depC);
#endif
            
        }
    }
}