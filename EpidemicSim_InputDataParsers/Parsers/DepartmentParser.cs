using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.InputDataParsers.Parsers
{
    internal static class DepartmentParser
    {
        private const string FILEPATH = @"C:\Users\Dave\Desktop\GIT_repos\PSC2013_tests\departments_coloured_big.bmp";
        private static Color FILLEDCOLOR = Color.FromArgb(0x000000); // has to be a color, never used anywhere else...


        // Dictionary<string, Tuple<int, int>>
        //                           x ,  y
        public static Dictionary<string, List<Point>> Parse(Dictionary<string, Tuple<int, int>> dictSource)
        {
            Bitmap img = new Bitmap(FILEPATH);

            Dictionary<string, List<Point>> dict = new Dictionary<string,List<Point>>();

            foreach (string key in dictSource.Keys)
            {
                List<Point> points = Fill(img, dictSource[key]);
                dict[key] = points;
            }

            return dict;
        }

        /// <summary>
        /// The flood fill algorithm to 
        /// </summary>
        private static List<Point> Fill(Bitmap img, Tuple<int, int> tuple)
        {
            Point start = new Point(tuple.Item1, tuple.Item2);
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

                    stack.Push(new Point(n.X-1, n.Y-1));    // north-west
                    stack.Push(new Point(n.X, n.Y-1));      // north
                    stack.Push(new Point(n.X+1, n.Y-1));    // north-east
                    stack.Push(new Point(n.X-1, n.Y));      // west
                    stack.Push(new Point(n.X+1, n.Y));      // east
                    stack.Push(new Point(n.X-1, n.Y+1));    // south-west
                    stack.Push(new Point(n.X, n.Y+1));      // south
                    stack.Push(new Point(n.X+1, n.Y+1));    // south-east
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
    }
}
