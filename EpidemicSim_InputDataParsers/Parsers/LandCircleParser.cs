using System;
using System.Collections.Generic;
using System.IO;

namespace PSC2013.ES.InputDataParsers.Parsers
{
    internal static class LandCircleParser
    {
        public static Dictionary<String, Tuple<int, int>> parseCircles (String file)
        {
            // Not Tested! | T
            if (!File.Exists(file))
                throw new FileNotFoundException("File could not be found", file);

            Dictionary<String, Tuple<int,int>> dict = new Dictionary<string,Tuple<int,int>>();

            using (StreamReader dataFile = new StreamReader(file))
            {
                string line;
                while ((line = dataFile.ReadLine()) != null)
                {
                    // Split between '|' => String[]
                    // [x][y][landkreis]
                    string[] temp = line.Split(new Char[] { '|' });
                    Tuple<int, int> temp2 = new Tuple<int, int>(int.Parse(temp[0]), int.Parse(temp[1]));
                    dict.Add(temp[2], temp2);
                }
            }

            return dict;
        }
    }
}
