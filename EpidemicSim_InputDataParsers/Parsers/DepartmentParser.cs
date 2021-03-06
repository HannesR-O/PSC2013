﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace PSC2013.ES.InputDataParsers.Parsers
{
    internal static class DepartmentParser
    {
        private static Color FILLEDCOLOR = Color.FromArgb(0x000000);

        /// <summary>
        /// Parses the image and returns the departments...
        /// </summary>
        /// <param name="imageFile">The image file to use</param>
        /// <param name="dictSource">The coordinates (from LandCircleParser)</param>
        /// <returns>Fancy shit.</returns>
        public static Dictionary<string, List<Point>> Parse(string imageFile, List<Tuple<string, Point>> source)
        {
            Bitmap img = new Bitmap(imageFile);
#if DEBUG
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("Intializing Image-Array...");
#endif
            Color[,] imgArray = new Color[img.Width, img.Height];
            // might not be the best way (e.g. LockBit(...) possible)
            for (int x = 0; x < img.Width; x++)
                for (int y = 0; y < img.Height; y++)
                    imgArray[x, y] = img.GetPixel(x, y);

#if DEBUG
            Console.WriteLine("Image-Array initialized.");
#endif

            Dictionary<string, List<Point>> dict = new Dictionary<string,List<Point>>();

//            foreach (Tuple<string, Point> tpl in source)
//            {
//#if DEBUG
//                Console.WriteLine(tpl.Item1);
//#endif

//                TaskWorking(img, tpl, dict);
//            } // 00:02:12.7397335

            int degree = (Environment.ProcessorCount >> 1);     // half of processors (we don't wanna kill it :P)
            degree = Math.Max(1, degree);                       // but minimum of 1
            
            Parallel.ForEach(source,
                new ParallelOptions() { MaxDegreeOfParallelism = degree },
                item =>
                {
#if DEBUG
                    Console.WriteLine(item.Item1);
#endif
                    TaskWorking(imgArray, item, dict);
                });
            // 4 -- 00:00:04.5294358
            // 4 (including copying image) -- 00:00:14.0000079 // 00:00:13.9494022
            // -1(8) -- 00:00:03.8231940

            //vvv single way by using multiple Bitmaps or one Bitmap and lock-conditions...
            // 2 -- 00:01:23.8058131
            // 3 -- 00:01:10.0338862 // 00:01:00.9140840 // 00:01:09.9917304
            // 4 -- 00:00:56.4766085 // 00:00:52.2842363
            // 4 uses 1.5GB Memory => Out of Memory

            // to see the modified file... (doesn't work now, because of array-usage)
            //FileInfo fi = new FileInfo(imagepath);
            //string dir = fi.DirectoryName;
            //img.Save(dir + @"\testimg.bmp");

#if DEBUG
            sw.Stop();
            Console.WriteLine("Stopwatch: " + sw.Elapsed);
#endif
            return dict;
        }

        private static void TaskWorking(Color[,] img,
            Tuple<string, Point> tpl, Dictionary<string, List<Point>> dict)
        {
            List<Point> points = Fill(img, tpl.Item2);
            lock (typeof(DepartmentParser))
            {
                if (dict.ContainsKey(tpl.Item1))
                    dict[tpl.Item1].AddRange(points);
                else
                    dict[tpl.Item1] = points;
            }
        }

        /// <summary>
        /// The flood fill algorithm to detect the connected parts.
        /// </summary>
        private static List<Point> Fill(Color[,] img, Point point)
        {
            Point start = point;
            Color currentColor = GetColor(img, start);
            List<Point> points = new List<Point>();

            Stack<Point> stack = new Stack<Point>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                Point n = stack.Pop();
                if (GetColor(img, n).Equals(currentColor))
                {
                    lock (typeof(DepartmentParser))
                    {
                        img[n.X, n.Y] = FILLEDCOLOR;        // color current pixel
                    }
                    points.Add(n);                          // add pixel to department

                    Step(stack, img, n, currentColor);      // step to the neighbours...
                }
            }

            return points;
        }

        /// <summary>
        /// Shortener to get the color of a pixel.
        /// </summary>
        private static Color GetColor(Color[,] img, Point p)
        {
            return img[p.X, p.Y];
        }

        /// <summary>
        /// Steps to the neighbours and puts the on the stack.
        /// But only if they fulfil the conditions...
        /// </summary>
        private static void Step(Stack<Point> stack, Color[,] img,
            Point currentPoint, Color currentColor)
        {
            for (int y = -1; y <= 1; y++)                                                       // height traversal
            {
                for (int x = -1; x <= 1; x++)                                                   // width traversal
                {
                    if (!(y == 0 && x == 0))                                                    // anything but the current point
                    {
                        if (Allowed(true, x, y))                                                // four or eight ways...
                        {
                            if (CheckPoint(img, currentPoint, x, y))                            // valid point
                            {
                                Point p = new Point(currentPoint.X + x, currentPoint.Y + y);    // neighbour-point
                                if (GetColor(img, p).Equals(currentColor))                      // ^-color = target
                                {
                                    stack.Push(p);                                              // finally put onto the stack
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Validates the point (so it stays in boundaries).
        /// </summary>
        private static bool CheckPoint(Color[,] img, Point n, int x, int y)
        {
            int h = img.GetLength(1);
            int w = img.GetLength(0);

            return (n.X + x) >= 0 &&
                    (n.X + x) < w &&
                    (n.Y + y) >= 0 &&
                    (n.Y + y) < h;
        }

        /// <summary>
        /// Fancy shit to determine wether the direction is allowed
        /// on a four-way-run or not. If eight is true, all ways are
        /// allowed.
        /// </summary>
        private static bool Allowed(bool eight, int x, int y)
        {
            if (!eight)
            {
                bool northwest = (x == -1 && y == -1);
                bool northeast = (x == 1 && y == -1);
                bool southwest = (x == -1 && y == 1);
                bool southeast = (x == 1 && y == 1);

                return !(northwest || northeast || southwest || southeast);
            }
            return true;
        }
    }
}
