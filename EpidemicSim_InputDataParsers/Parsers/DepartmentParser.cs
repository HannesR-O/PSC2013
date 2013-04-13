using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace PSC2013.ES.InputDataParsers.Parsers
{
    internal static class DepartmentParser
    {
        private static Color FILLEDCOLOR = Color.FromArgb(0x000000);

        /// <summary>
        /// Parses the image and returns the departments...
        /// </summary>
        /// <param name="imagepath">The image's path.</param>
        /// <param name="dictSource">The coordinates (from LandCircleParser)</param>
        /// <returns>Fancy shit.</returns>
        public static Dictionary<string, List<Point>> Parse(string imagepath, List<Tuple<string, Point>> source)
        {
            Bitmap img = new Bitmap(imagepath);

            Dictionary<string, List<Point>> dict = new Dictionary<string,List<Point>>();

            foreach (Tuple<string, Point> tpl in source)
            {
                Console.WriteLine(tpl.Item1);
                List<Point> points = Fill(img, tpl.Item2);
                if (dict.ContainsKey(tpl.Item1))
                    dict[tpl.Item1].AddRange(points);
                else
                    dict[tpl.Item1] = points;
            }

            // to see the modified file...
            //FileInfo fi = new FileInfo(imagepath);
            //string dir = fi.DirectoryName;
            //img.Save(dir + @"\testimg.bmp");

            return dict;
        }

        /// <summary>
        /// The flood fill algorithm to 
        /// </summary>
        private static List<Point> Fill(Bitmap img, Point point)
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
                    img.SetPixel(n.X, n.Y, FILLEDCOLOR);    // colour current pixel
                    points.Add(n);                          // add pixel to department

                    if (CheckPoint(img, n, -1, -1))
                        stack.Push(new Point(n.X-1, n.Y-1));        // north-west
                    if (CheckPoint(img, n, 0, -1))
                        stack.Push(new Point(n.X, n.Y-1));          // north
                    if (CheckPoint(img, n, 1, -1))
                        stack.Push(new Point(n.X + 1, n.Y - 1));    // north-east
                    if (CheckPoint(img, n, -1, 0))
                        stack.Push(new Point(n.X - 1, n.Y));        // west
                    if (CheckPoint(img, n, 1, 0))
                        stack.Push(new Point(n.X + 1, n.Y));        // east
                    if (CheckPoint(img, n, -1, 1))
                        stack.Push(new Point(n.X - 1, n.Y + 1));    // south-west
                    if (CheckPoint(img, n, 0, 1))
                        stack.Push(new Point(n.X, n.Y + 1));        // south
                    if (CheckPoint(img, n, 1, 1))
                        stack.Push(new Point(n.X + 1, n.Y + 1));    // south-east
                }
            }

            return points;
        }

        /// <summary>
        /// Shortener to get the color of a pixel.
        /// </summary>
        private static Color GetColor(Bitmap img, Point p)
        {
            return img.GetPixel(p.X, p.Y);
        }

        private static bool CheckPoint(Bitmap img, Point n, int x, int y)
        {
            int h = img.Height;
            int w = img.Width;

            return (n.X + x) >= 0 &&
                    (n.X + x) < w &&
                    (n.Y + y) >= 0 &&
                    (n.Y + y) < h;
        }
    }
}
