using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EpidemicSim_DetailedInputParser
{
    public class Parsing
    {
        //TODO |h| make full use of stringbuilder instead of changing the string[]...
        public static string _6ParseCityPointCounts(string withdeppoints)
        {
            String[] datenLines = Regex.Split(withdeppoints, "\r\n");
            StringBuilder builder = new StringBuilder();
            Random rand = new Random();

            for (int i = 0; i < datenLines.Length; ++i)
            {
                string[] splittedLine = datenLines[i].Split(';');
                if (splittedLine[0].Length == 5)
                {
                    int cityspacesum = 0;
                    int deppointcount = int.Parse(splittedLine[75]);
                    double depspace = double.Parse(splittedLine[56]);
                    LinkedList<int> pointcounts = new LinkedList<int>();
                    for (int j = i + 1; j < datenLines.Length && datenLines[j].Split(';')[0].Length == 8; ++j)
                    {
                        double cityspace = double.Parse(datenLines[j].Split(';')[56]);
                        cityspacesum += (int)cityspace;
                        double percentage = cityspace / depspace;
                        double Dpointsforcity = percentage * deppointcount;

                        int pointsforcity = (int)(Math.Round(percentage * deppointcount));
                        if (pointsforcity == 0)
                            throw new Exception("A City didn't even get one single Point...");
                        pointcounts.AddLast(pointsforcity);
                    }


                    int totalcount = 0;
                    int[] pointcountsarr = null;
                    if (pointcounts.Count != 0)
                    {
                        foreach (int count in pointcounts)
                            totalcount += count;


                        pointcountsarr = pointcounts.ToArray();


                        if (totalcount == deppointcount)
                        {
                            Console.WriteLine("TOTAL MATCH!" + "\t" + pointcounts.Count + " Cities");
                        }
                        else if (totalcount < deppointcount)
                        {
                            Console.WriteLine("Smaller than Deppointcount:\t" + (deppointcount - totalcount) + "\t" + pointcounts.Count + " Cities");
                            int difference = deppointcount - totalcount;
                            for (int j = 0; j < difference; ++j)
                            {
                                ++pointcountsarr[rand.Next(pointcountsarr.Length)];
                                ++totalcount;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Greater than Deppointcount:\t" + (totalcount - deppointcount) + " \t" + pointcounts.Count + " Cities");
                            int difference = totalcount - deppointcount;
                            for (int j = 0; j < difference; ++j)
                            {
                                --pointcountsarr[rand.Next(pointcountsarr.Length)];
                                --totalcount;
                            }
                        }

                        foreach (int p in pointcounts)
                        {
                            if (p <= 0)
                                throw new Exception("One City has ZERO or LESS Points...");
                        }
                    }
                    else
                    {
                        Console.WriteLine("TOTAL MATCH!" + "\t" + pointcounts.Count + " Cities");
                    }


                    if (pointcounts.Count != 0)
                    {
                        //Assert Pointcount is right
                        if (deppointcount != totalcount)
                            throw new Exception("DepartmentPointCount != TotalCityPointCount!");

                        //Write Counts

                        for (int j = 1; j < pointcountsarr.Length + 1; ++j)
                        {
                            datenLines[i + j] = datenLines[i + j] + ";" + pointcountsarr[j - 1];
                        }
                    }
                }
            }

            foreach (string s in datenLines)
            {
                builder.Append(s + "\r\n");
            }

            Console.WriteLine("Finished");

            return builder.ToString();
        }
    }
}
