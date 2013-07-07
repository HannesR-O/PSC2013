using System;
using System.Collections.Generic;
using System.Drawing;
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
        /// Parses all Points belonging to each City.
        /// </summary>
        /// <param name="withcitypointcounts"></param>
        /// <param name="save"></param>
        /// <returns></returns>
        public static string _8ParseCityPoints(string withcitypointcounts, bool save, bool test)
        {
            String[] datenLines = Regex.Split(withcitypointcounts, "\r\n");
            StringBuilder builder = new StringBuilder();
            DepartmentPoint[] AllPoints = new DepartmentPoint[2814 * 3841];
            List<City> Cities = new List<City>(12000);

            //Collect Citypointcounts/Departmentpointcounts etc
            for (int i = 0; i < datenLines.Length; ++i)
            {
                string[] splitteddepline = datenLines[i].Split(';');
                if (splitteddepline[0].Length == 5)
                {
                    DepartmentPoint[] deppoints = new DepartmentPoint[int.Parse(splitteddepline[75])];
                    Department dep = new Department();
                    for (int j = 0; j < deppoints.Length; ++j)
                    {
                        int tmp = int.Parse(splitteddepline[76 + j].Split(':')[2]);
                        AllPoints[tmp] = new DepartmentPoint(tmp, dep);
                        deppoints[j] = AllPoints[tmp];
                    }

                    for (int j = i + 1; j < datenLines.Length; ++j)
                    {
                        string[] splittedcityline = datenLines[j].Split(';');
                        if (splittedcityline[0].Length == 8)
                        {
                            int pointcount = int.Parse(splittedcityline[75]);
                            string name = splittedcityline[1];
                            Cities.Add(new City(pointcount, j, name, AllPoints, deppoints, dep));
                        }
                        else
                            break;
                    }
                }
            }

            //Distribute Cities in Department
            for (int k = 0; k < Cities.Count; ++k)
            {
                Cities[k].AssignStartPoint();
                Cities[k].GrowCautious();
                Console.WriteLine("Grew Cautious:\t" + Cities[k].Name);
            }

            if (test)
            {
                Console.WriteLine("Starting to save Cautious-Image");
                Bitmap testimage = new Bitmap(2814, 3841);
                Random rand = new Random();
                foreach (City city in Cities)
                {
                    Color c = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                    foreach (DepartmentPoint point in city.AssignedPoints)
                        testimage.SetPixel(point.Coord % 2814, point.Coord / 2814, c);
                }
                testimage.Save(Program.DESTPATH + "cautious.png");
                Console.WriteLine("Saved Cautious-Image");
            }


            LinkedList<City> Failures = new LinkedList<City>();
            foreach (City city in Cities)
            {
                while (city.RemainingPoints > 0)
                {
                    if (!city.GrowBrutal(new List<City>()))
                    {
                        Console.WriteLine("Failed to Fully Grow:\t" + city.Name);
                        Failures.AddLast(city);
                        break;
                    }
                }
                Console.WriteLine("Grew Brutal:\t" + city.Name);
            }

            Console.WriteLine("Failcount :\t" + Failures.Count);

            //If nothing worked assign the remaining points random
            foreach (City city in Failures)
            {
                while (city.RemainingPoints > 0)
                {
                    city.AssignRandomPoint();
                }
            }

            if (test)
            {
                Console.WriteLine("Starting to save Brutal-Image");
                Bitmap testimage = new Bitmap(2814, 3841);
                Random rand = new Random();
                foreach (City city in Cities)
                {
                    Color c = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                    foreach (DepartmentPoint point in city.AssignedPoints)
                        testimage.SetPixel(point.Coord % 2814, point.Coord / 2814, c);
                }
                testimage.Save(Program.DESTPATH + "brutal.png");
            }


            for (int i = 0; i < datenLines.Length; ++i)
            {
                builder.Append(datenLines[i]);
                foreach (City city in Cities)
                {
                    if (city.LineIndexInFile == i)
                    {
                        foreach (DepartmentPoint point in city.AssignedPoints)
                        {
                            builder.Append(";" + point.Coord % 2814 + ":" + point.Coord / 2814 + ":" + point.Coord);

                        }
                        break;
                    }
                }
                builder.Append("\r\n");
            }

            if (save)
            {
                FileStream stream = File.OpenWrite(Program.DESTPATH + "8ParseCityPoints.txt");
                stream.Write(Encoding.Default.GetBytes(builder.ToString()), 0, Encoding.Default.GetByteCount(builder.ToString()));
                stream.Close();
            }
            return builder.ToString();
        }
    }
}
