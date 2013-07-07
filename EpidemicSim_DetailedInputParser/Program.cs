using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EpidemicSim_DetailedInputParser
{
    public class Program
    {
        public const string SRCPATH = "../../SRC/";
        public const string DESTPATH = "../../DEST/";

        public static void Main()
        {
            //SRC
            Parsing.ParsePointfile(true);

            //DEST
            //Racket Style :P
            Parsing._9CreateDepFile(
            Parsing._8ParseCityPoints(
            Parsing._7ParseCityPointCounts(
            Parsing._6MergeDepartmentPoints(
            Parsing._5FixCityStates(
            Parsing._4FixIslands(
            Parsing._3BuildAGS(
            Parsing._2RemoveuselessData(
            Parsing._1MergePopulationAndSpaceData(true), true), true), true), true), true), true), true, true));
        }
    }
}
