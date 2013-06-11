using System;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace PSC2013.ES.InputDataParsers.Parsers
{
    internal static class LandCircleParser
    {
        /// <summary>
        /// Parses the given textfile for it's "LandCircles"
        /// and coordinates
        /// </summary>
        /// <param name="file">The file to parse</param>
        /// <returns>Best construct ever...</returns>
        public static List<Tuple<string, Point>> ParseCircles (String file)
        {
            // Not Tested! | T
            if (!File.Exists(file))
                throw new FileNotFoundException("File could not be found", file);

            List<Tuple<string, Point>> list = new List<Tuple<string, Point>>();

            using (StreamReader dataFile = new StreamReader(file, Encoding.UTF8))
            {
                string line;
                while ((line = dataFile.ReadLine()) != null)
                {
                    // Split between '|' => String[]
                    // [x][y][landkreis]
                    string[] temp = line.Split(new Char[] { '|' });
                    Point p = new Point(int.Parse(temp[0]), int.Parse(temp[1]));
                    list.Add(new Tuple<string, Point>(temp[2], p));
                }
            }

            return list;
        }
    }
}
