using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EpidemicSim_DetailedInputParser
{
    public static partial class Parsing
    {
        /// <summary>
        /// Reads the parsed Points from "Points.txt"
        /// and merges them into the previously collected Data.
        /// </summary>
        /// <param name="citystatesfixed"></param>
        /// <returns></returns>
        public static string _6MergeDepartmentPoints(string citystatesfixed, bool save)
        {
            String[] pointLines = File.ReadAllLines(Program.SRCPATH + "Points.txt", Encoding.Default);
            String[] datenLines = Regex.Split(citystatesfixed, "\r\n");
            StringBuilder builder = new StringBuilder();

            LinkedList<Match> Matched = new LinkedList<Match>();
            LinkedList<Match> Unmatched = new LinkedList<Match>();
            Console.WriteLine("Starting to Merge collected Points with the Population/Space-Data");

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
            if (Unmatched.Count > 0)
                Console.WriteLine("Some Departments couldn't be matched:");

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


            for (int i = 0; i < datenLines.Length; ++i)
            {
                builder.Append(datenLines[i]);
                if (i != datenLines.Length - 1)
                    builder.Append("\r\n");
            }

            Console.WriteLine("Finished Merging points with Population/Space-Data");

            if (save)
            {
                FileStream stream = File.OpenWrite(Program.DESTPATH + "6MergeDepartmentPoints.txt");
                stream.Write(Encoding.Default.GetBytes(builder.ToString()), 0, Encoding.Default.GetByteCount(builder.ToString()));
                stream.Close();
            }
            return builder.ToString();
        }

        struct Match
        {
            public int IndexInPointFile;
            public int IndexInDataFile;
        }
    }
}
