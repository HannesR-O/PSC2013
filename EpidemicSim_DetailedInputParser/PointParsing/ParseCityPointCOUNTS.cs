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
        /// Parses the number of points in the imagefile a City should have
        /// according to cityspace/departmentspace ratio
        /// </summary>
        /// <param name="withdeppoints"></param>
        /// <param name="save"></param>
        /// <returns></returns>
        public static string _7ParseCityPointCounts(string withdeppoints, bool save)
        {
            String[] datenLines = Regex.Split(withdeppoints, "\r\n");
            StringBuilder builder = new StringBuilder();
            Random rand = new Random();

            Console.WriteLine("Starting to Parse City-Pointcounts + Merging them with the collected data");
            for (int i = 0; i < datenLines.Length; ++i)
            {
                string[] splittedLine = datenLines[i].Split(';');
                if (splittedLine[0].Length == 5)
                {
                    int cityspacesum = 0;
                    int deppointcount = int.Parse(splittedLine[75]);
                    double depspace = double.Parse(splittedLine[56]);
                    LinkedList<CityPointContainer> pointcounts = new LinkedList<CityPointContainer>();
                    for (int j = i + 1; j < datenLines.Length && datenLines[j].Split(';')[0].Length == 8; ++j)
                    {
                        string name = datenLines[j].Split(';')[1];
                        double cityspace = double.Parse(datenLines[j].Split(';')[56]);
                        cityspacesum += (int)cityspace;
                        double percentage = cityspace / depspace;
                        double Dpointsforcity = percentage * deppointcount;

                        int pointsforcity = (int)(Math.Round(percentage * deppointcount));
                        if (pointsforcity == 0)
                            throw new Exception("A City didn't even get one single Point...");
                        pointcounts.AddLast(new CityPointContainer(name, pointsforcity));
                    }


                    int totalcount = 0;
                    CityPointContainer[] pointcountsarr = null;
                    if (pointcounts.Count != 0)
                    {
                        foreach (CityPointContainer city in pointcounts)
                            totalcount += city.PointCount;


                        pointcountsarr = pointcounts.ToArray();


                        if (totalcount == deppointcount)
                        {
                            Console.WriteLine("Total Match" + "\t" + pointcounts.Count + " Cities");
                        }
                        else if (totalcount < deppointcount)
                        {
                            Console.WriteLine("Smaller than Deppointcount:\t" + (deppointcount - totalcount) + "\t" + pointcounts.Count + " Cities");
                            int difference = deppointcount - totalcount;
                            for (int j = 0; j < difference; ++j)
                            {
                                ++pointcountsarr[rand.Next(pointcountsarr.Length)].PointCount;
                                ++totalcount;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Greater than Deppointcount:\t" + (totalcount - deppointcount) + " \t" + pointcounts.Count + " Cities");
                            int difference = totalcount - deppointcount;
                            for (int j = 0; j < difference; ++j)
                            {
                                --pointcountsarr[rand.Next(pointcountsarr.Length)].PointCount;
                                --totalcount;
                            }
                        }

                        foreach (CityPointContainer city in pointcounts)
                        {
                            if (city.PointCount <= 0)
                                throw new Exception("One City has ZERO or LESS Points...");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Total Match!" + "\t" + pointcounts.Count + " Cities");
                    }


                    if (pointcounts.Count != 0)
                    {
                        //Assert Pointcount is right
                        if (deppointcount != totalcount)
                            throw new Exception("DepartmentPointCount != TotalCityPointCount!");

                        //Write Counts
                        for (int j = i + 1; j < i + 1 + pointcountsarr.Length; ++j)
                        {
                            datenLines[j] += ";" + (pointcountsarr[j - i - 1].PointCount);
                        }
                    }
                }
            }

            for (int i = 0; i < datenLines.Length; ++i)
            {
                builder.Append(datenLines[i]);
                if (i != datenLines.Length - 1)
                    builder.Append("\r\n");
            }

            Console.WriteLine("Finished Parsing City-Pointcounts");

            if (save)
            {
                FileStream stream = File.OpenWrite(Program.DESTPATH + "7ParseCityPointCounts.txt");
                stream.Write(Encoding.Default.GetBytes(builder.ToString()), 0, Encoding.Default.GetByteCount(builder.ToString()));
                stream.Close();
            }
            return builder.ToString();
        }

    }
    
}
