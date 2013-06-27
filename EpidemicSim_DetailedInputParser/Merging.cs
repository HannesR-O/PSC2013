using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EpidemicSim_DetailedInputParser
{
    public class Merging
    {
        /// <summary>
        /// Merges the PopulationdataFile with the File
        /// containing the spaces of each City
        /// </summary>
        /// <returns></returns>
        public static string _1MergeEinwohnerFlaeche()
        {
            String[] einwohnerLines = File.ReadAllLines(Program.SRCPATH + "einwohnerzahl.txt", Encoding.Default);
            String[] flaechenLines = File.ReadAllLines(Program.SRCPATH + "fläche.txt", Encoding.Default);
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < einwohnerLines.Length; ++i)
            {
                string[] splittedEinwohner = einwohnerLines[i].Split(';');
                string[] splittedFlaeche = flaechenLines[i].Split(';');
                if (!(splittedEinwohner[2].Equals(splittedFlaeche[1]) && splittedEinwohner[1].Equals(splittedFlaeche[0])))
                {
                    throw new Exception("The lines from the two files do not match although they should be Equal...");
                }
                else
                {
                    for (int j = 1; j < splittedEinwohner.Length; ++j)
                    {
                        builder.Append(splittedEinwohner[j] + ";");
                    }

                    for (int j = 2; j < splittedFlaeche.Length; ++j)
                    {
                        builder.Append(splittedFlaeche[j]);
                        if (!(j == splittedFlaeche.Length - 1))
                            builder.Append(";");
                    }
                    if(i != einwohnerLines.Length - 1)
                        builder.Append("\r\n");
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// Reads the parsed Points from "Points.txt"
        /// and merges them into the file.
        /// </summary>
        /// <param name="citystatesfixed"></param>
        /// <returns></returns>
        public static string _5MergeDepartmentPoints(string citystatesfixed)
        {
            //Try matching departments YAY! Could be optimized i guess
            String[] pointLines = File.ReadAllLines(Program.SRCPATH + "Points.txt", Encoding.Default);
            String[] datenLines = Regex.Split(citystatesfixed, "\r\n");
            StringBuilder builder = new StringBuilder();

            LinkedList<Match> Matched = new LinkedList<Match>();
            LinkedList<Match> Unmatched = new LinkedList<Match>();

            //Search unique Matches first...
            for (int i = 0; i < pointLines.Length; ++i)
            {
                String[] splittedPoints = pointLines[i].Split(';');

                LinkedList<Match> matchesThisRound = new LinkedList<Match>();
                Match match = new Match();

                if (splittedPoints[0].Contains(" (Stadt)"))
                    splittedPoints[0] = splittedPoints[0].Substring(0, splittedPoints[0].Length - 8);

                for (int j = 0; j < datenLines.Length; ++j)
                {
                    String[] splittedDaten = datenLines[j].Split(';');

                    if (splittedDaten[0].Length == 5 && splittedDaten[1].Contains(splittedPoints[0]))
                    {
                        match.IndexInDataFile = j;
                        match.IndexInPointFile = i;
                        matchesThisRound.AddLast(match);
                    }
                }

                if (matchesThisRound.Count == 1)
                {
                    Matched.AddFirst(match);
                }
                else
                {
                    for (int j = 0; j < matchesThisRound.Count; ++j)
                        Unmatched.AddLast(matchesThisRound.ElementAt(j));
                }


            }
            //////////////////////////////////////////////////////
            //User decision
            LinkedList<Match> Remaining = new LinkedList<Match>();
            while (Unmatched.Count != 0)
            {
                Match m = Unmatched.First.Value;
                bool success = false;

                for (int i = 1; i < Unmatched.Count; ++i)
                {
                    Match m2 = Unmatched.ElementAt(i);

                    if (m2.IndexInPointFile == m.IndexInPointFile)
                    {
                        //Print names
                        Console.WriteLine(pointLines[m.IndexInPointFile].Split(';')[0]);
                        Console.WriteLine("1: " + datenLines[m.IndexInDataFile].Split(';')[1]);
                        Console.WriteLine("2: " + datenLines[m2.IndexInDataFile].Split(';')[1]);
                        Console.WriteLine("0: isn't a match");
                        string decision = Console.ReadLine();
                        success = true;
                        if (decision.Contains("1"))
                        {
                            Matched.AddLast(m);
                            Unmatched.RemoveFirst();
                            Unmatched.Remove(m2);
                            break;
                        }
                        else if (decision.Contains("2"))
                        {
                            Unmatched.RemoveFirst();
                            Matched.AddLast(m2);
                            Unmatched.Remove(m2);
                            break;
                        }
                        else
                        {
                            Unmatched.RemoveFirst();
                            Unmatched.Remove(m2);
                            break;
                        }
                    }
                    else
                    {

                    }
                }
                if (!success)
                {
                    Unmatched.RemoveFirst();
                    Remaining.AddLast(m);
                }


            }

            foreach (Match m in Remaining)
                Console.WriteLine(pointLines[m.IndexInPointFile].Split(';')[0] + "|" + datenLines[m.IndexInDataFile].Split(';')[1]);


            foreach (Match m in Matched)
            {
                string line = pointLines[m.IndexInPointFile];
                string points = line.Substring(line.IndexOf(';'));
                datenLines[m.IndexInDataFile] += points;
            }

            foreach (string s in datenLines)
            {
                builder.Append(s + "\r\n");
            }

            Console.WriteLine("FinishedWriting");

            return builder.ToString();
        }

        struct Match
        {
            public int IndexInPointFile;
            public int IndexInDataFile;
        }


    }
}
