using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EpidemicSim_DetailedInputParser
{
    class Program
    {
        public static readonly string SRCPATH = "../../SRC/";
        public static readonly string DESTPATH = "../../DEST/";

        static void Main(string[] args)
        {
            //Creating needed Sourcefiles
            Flood.ParsePointfile();
            Flood.TestPointResults();

            //Creating the map itself
            string mergedPopSpace = Merging._1MergeEinwohnerFlaeche();
            string removeuseless = Correction._2RemoveuselessData(mergedPopSpace);
            string allhaveags = Correction._3BuildAGS(removeuseless);
            string citystatesfixed = Correction._4FixCityStates(allhaveags);
            string withdeppoints = Merging._5MergeDepartmentPoints(citystatesfixed);
            string withcitypointcount = Parsing._6ParseCityPointCounts(withdeppoints);
            string withcitypoints = CityPointParsing._7ParseCityPoints(withcitypointcount);
            CreateMapFile(withcitypoints);

            Console.WriteLine("GG");
            Console.ReadLine();
        }

        //TODO ZIP-ARCHIVE
        private static void CreateMapFile(string ready)
        {
            string[] datalines = Regex.Split(ready, "\r\n");
            FileStream stream = File.OpenWrite(DESTPATH + "map");
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < datalines.Length; ++i)
            {
                string[] splittedLine = datalines[i].Split(';');
                if (splittedLine[0].Length == 5 && i + 1 < datalines.Length && datalines[i + 1].Split(';')[0].Length != 8)
                {
                    builder.Append(splittedLine[1]);

                    int mb = int.Parse(splittedLine[20]) + int.Parse(splittedLine[21]);

                    int mc = int.Parse(splittedLine[22]) + int.Parse(splittedLine[23]) +
                             int.Parse(splittedLine[24]) + int.Parse(splittedLine[25]);

                    int ma = int.Parse(splittedLine[26]) + int.Parse(splittedLine[27]) +
                             int.Parse(splittedLine[28]) + int.Parse(splittedLine[29]) +
                             int.Parse(splittedLine[30]) + int.Parse(splittedLine[31]) +
                             int.Parse(splittedLine[32]) + int.Parse(splittedLine[33]);

                    int ms = int.Parse(splittedLine[34]) + int.Parse(splittedLine[35]) +
                             int.Parse(splittedLine[36]);

                    int fb = int.Parse(splittedLine[38]) + int.Parse(splittedLine[39]);

                    int fc = int.Parse(splittedLine[40]) + int.Parse(splittedLine[41]) +
                             int.Parse(splittedLine[42]) + int.Parse(splittedLine[43]);

                    int fa = int.Parse(splittedLine[44]) + int.Parse(splittedLine[45]) +
                             int.Parse(splittedLine[46]) + int.Parse(splittedLine[47]) +
                             int.Parse(splittedLine[48]) + int.Parse(splittedLine[49]) +
                             int.Parse(splittedLine[50]) + int.Parse(splittedLine[51]);

                    int fs = int.Parse(splittedLine[52]) + int.Parse(splittedLine[53]) +
                             int.Parse(splittedLine[54]);

                    builder.Append("|" + mb + "|" + mc + "|" + ma + "|" + ms +
                                   "|" + fb + "|" + fc + "|" + fa + "|" + fs);

                    int pointcount = int.Parse(splittedLine[75]);
                    for (int j = 0; j < pointcount; ++j)
                    {
                        string[] coord = splittedLine[76 + j].Split(':');
                        builder.Append("|" + coord[0] + ":" + coord[1]);
                    }
                    builder.Append("\n");
                }
                else if (splittedLine[0].Length == 8)
                {
                    builder.Append(splittedLine[1]);
                    int mb = int.Parse(splittedLine[20]) + int.Parse(splittedLine[21]);

                    int mc = int.Parse(splittedLine[22]) + int.Parse(splittedLine[23]) +
                             int.Parse(splittedLine[24]) + int.Parse(splittedLine[25]);

                    int ma = int.Parse(splittedLine[26]) + int.Parse(splittedLine[27]) +
                             int.Parse(splittedLine[28]) + int.Parse(splittedLine[29]) +
                             int.Parse(splittedLine[30]) + int.Parse(splittedLine[31]) +
                             int.Parse(splittedLine[32]) + int.Parse(splittedLine[33]);

                    int ms = int.Parse(splittedLine[34]) + int.Parse(splittedLine[35]) +
                             int.Parse(splittedLine[36]);

                    int fb = int.Parse(splittedLine[38]) + int.Parse(splittedLine[39]);

                    int fc = int.Parse(splittedLine[40]) + int.Parse(splittedLine[41]) +
                             int.Parse(splittedLine[42]) + int.Parse(splittedLine[43]);

                    int fa = int.Parse(splittedLine[44]) + int.Parse(splittedLine[45]) +
                             int.Parse(splittedLine[46]) + int.Parse(splittedLine[47]) +
                             int.Parse(splittedLine[48]) + int.Parse(splittedLine[49]) +
                             int.Parse(splittedLine[50]) + int.Parse(splittedLine[51]);

                    int fs = int.Parse(splittedLine[52]) + int.Parse(splittedLine[53]) +
                             int.Parse(splittedLine[54]);

                    builder.Append("|" + mb + "|" + mc + "|" + ma + "|" + ms +
                                   "|" + fb + "|" + fc + "|" + fa + "|" + fs);

                    int pointcount = int.Parse(splittedLine[75]);
                    for (int j = 0; j < pointcount; ++j)
                    {
                        string[] coord = splittedLine[76 + j].Split(':');
                        builder.Append("|" + coord[0] + ":" + coord[1]);
                    }
                    builder.Append("\n");
                }
            }

            stream.Write(Encoding.Default.GetBytes(builder.ToString()), 0, Encoding.Default.GetByteCount(builder.ToString()));
            stream.Close();
        }

    }
}
