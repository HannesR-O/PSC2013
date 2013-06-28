using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EpidemicSim_DetailedInputParser
{
    public class CityPointParsing
    {
        public static Random rand = new Random();
        public static string _7ParseCityPoints(string withcitypointcount)
        {
            Bitmap test = (Bitmap)Bitmap.FromFile(Program.SRCPATH + "emptymap.png");
            String[] datenLines = Regex.Split(withcitypointcount, "\r\n");
            Random rand = new Random();
            DepartmentPoint[] allpoints = null;

            for (int i = 0; i < datenLines.Length; ++i)
            {
                string[] splittedLine = datenLines[i].Split(';');

                if (splittedLine[0].Length == 5)
                {
                    //Recreate Whole Pointmap
                    allpoints = new DepartmentPoint[2814 * 3841];

                    //Read All Points from Department into map
                    int deppointcount = int.Parse(splittedLine[75]);
                    int[] deppoints = new int[deppointcount];

                    for (int j = 0; j < deppointcount; ++j)
                    {
                        int coord = int.Parse(splittedLine[76 + j].Split(':')[2]);
                        allpoints[coord] = new DepartmentPoint(coord);
                        deppoints[j] = coord;
                    }


                    //Init Cities
                    int citycount = 0;
                    for (int j = 0; i + j + 1 < datenLines.Length && datenLines[i + j + 1].Split(';')[0].Length == 8; ++j)
                    {
                        ++citycount;
                    }

                    City[] Cities = new City[citycount];
                    int citypointcount = 0;

                    for (int j = 0; j < citycount; ++j)
                    {
                        Cities[j] = new City(int.Parse(datenLines[i + j + 1].Split(';')[75]), i + j + 1, datenLines[i + j + 1].Split(';')[1]);
                        citypointcount += Cities[j].RemainingPoints;
                    }

                    ///////ASSERT
                    if (citycount > 0 && citypointcount != deppointcount)
                    {
                        throw new Exception();
                    }
                    ///////ASSERT

                    //First try to Grow all cities without giving space
                    for (int j = 0; j < Cities.Length; ++j)
                    {
                        Cities[j].AssignStartPoint(deppoints, allpoints);

                        while (Cities[j].RemainingPoints > 0)
                        {
                            if (!Cities[j].TryToGrow(allpoints, false, null))
                                break;
                        }
                    }

                    LinkedList<DepartmentPoint> Unassignedpoints = new LinkedList<DepartmentPoint>(); //isn't needed if everything works right..

                    for (int k = 0; k < deppoints.Length; ++k)
                    {
                        if (allpoints[deppoints[k]].Owner == null)
                        {
                            Unassignedpoints.AddLast(allpoints[deppoints[k]]);
                        }
                    }


                    for (int j = 0; j < Cities.Length; ++j)
                    {
                        if (Cities[j].RemainingPoints == 0)
                            continue;

                        //Dirty Solution...
                        while (Cities[j].RemainingPoints > 0)
                        {
                            Cities[j].AssignedPoints.AddLast(Unassignedpoints.First.Value);
                            Unassignedpoints.RemoveFirst();
                            --Cities[j].RemainingPoints;
                        }

                        //Cities[j].TryToGrow(allpoints, true, new LinkedList<City>());
                    }

                    foreach (City city in Cities)
                    {
                        Color color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                        foreach (DepartmentPoint point in city.AssignedPoints)
                        {
                            test.SetPixel(point.Coord % 2814, point.Coord / 2814, color);
                        }
                    }
                    Console.WriteLine("Finnished " + datenLines[i].Split(';')[1]);
                    test.Save(Program.DESTPATH + "Cityoverview.png", ImageFormat.Png);

                    foreach (City city in Cities)
                    {
                        StringBuilder builder = new StringBuilder();
                        builder.Append(datenLines[city.LineIndexInFile]);
                        foreach (DepartmentPoint point in city.AssignedPoints)
                        {
                            builder.Append(";" + point.Coord % 2814 + ":" + point.Coord / 2814 + ":" + point.Coord);
                        }
                        datenLines[city.LineIndexInFile] = builder.ToString();
                    }
                }
            }

            StringBuilder builder2 = new StringBuilder();

            foreach (string s in datenLines)
            {
                builder2.Append(s);
                builder2.Append("\r\n");
            }

            Console.WriteLine("Finnished");
            return builder2.ToString();
        }


    }


    class DepartmentPoint
    {
        public City Owner;
        public int Coord;
        public bool CanGrowRight;
        public bool CanGrowLeft;
        public bool CanGrowUp;
        public bool CanGrowDown;


        public DepartmentPoint(int coord)
        {
            Coord = coord;
            Owner = null;
        }
    }

    class City
    {
        public int LineIndexInFile;
        public DepartmentPoint[] GrowablePoints { get { if (_growablelist.Count != 0)return _growablelist.ToArray(); else return null; } }
        private LinkedList<DepartmentPoint> _growablelist;
        public int RemainingPoints;
        public LinkedList<DepartmentPoint> AssignedPoints;
        public string Name;

        public City(int pointcount, int lineindex, string name)
        {
            RemainingPoints = pointcount;
            LineIndexInFile = lineindex;
            AssignedPoints = new LinkedList<DepartmentPoint>();
            _growablelist = new LinkedList<DepartmentPoint>();
            Name = name;
        }

        public void AssignStartPoint(int[] deppoints, DepartmentPoint[] allpoints)
        {
            DepartmentPoint startpoint = null;
            do
            {
                startpoint = allpoints[deppoints[CityPointParsing.rand.Next(deppoints.Length)]];
            } while (startpoint.Owner != null);

            startpoint.Owner = this;
            AssignedPoints.AddLast(startpoint);
            --RemainingPoints;

        }

        public void UpdateGrowablePoints(DepartmentPoint[] allpoints)
        {
            //TODO diagonal!
            _growablelist.Clear();
            foreach (DepartmentPoint point in AssignedPoints)
            {
                point.CanGrowDown = false;
                point.CanGrowLeft = false;
                point.CanGrowRight = false;
                point.CanGrowUp = false;

                int right = point.Coord + 1;
                int left = point.Coord - 1;
                int up = point.Coord - 2814;
                int down = point.Coord + 2814;

                bool cangrow = false;

                if (allpoints[right] != null && allpoints[right].Owner == null)
                {
                    point.CanGrowRight = true;
                    cangrow = true;
                }
                if (allpoints[left] != null && allpoints[left].Owner == null)
                {
                    point.CanGrowLeft = true;
                    cangrow = true;
                }
                if (allpoints[up] != null && allpoints[up].Owner == null)
                {
                    point.CanGrowUp = true;
                    cangrow = true;
                }
                if (allpoints[down] != null && allpoints[down].Owner == null)
                {
                    point.CanGrowDown = true;
                    cangrow = true;
                }

                if (cangrow)
                    _growablelist.AddLast(point);
            }
        }

        public bool TryToGrow(DepartmentPoint[] allpoints, bool havetoGrow, LinkedList<City> AlreadyTried)
        {
            UpdateGrowablePoints(allpoints);
            DepartmentPoint[] growablearr = GrowablePoints;
            if (growablearr == null)
            {
                if (havetoGrow)
                {
                    City[] neighbours = GetNeighbours(allpoints, AlreadyTried);

                    for (int j = 0; j < neighbours.Length; ++j)
                    {
                        if (neighbours[j].TryToGrow(allpoints, false, AlreadyTried))
                        {
                            DepartmentPoint[] BorderPoints = GetBorderPointsFor(allpoints, neighbours[j]);
                            DepartmentPoint chosen = allpoints[BorderPoints[CityPointParsing.rand.Next(BorderPoints.Length)].Coord];
                            chosen.Owner = this;
                            AssignedPoints.AddLast(chosen);
                            --RemainingPoints;
                            return true;
                        }
                    }

                    City chosenneighbour = neighbours[CityPointParsing.rand.Next(neighbours.Length)];

                    if (chosenneighbour.TryToGrow(allpoints, true, AlreadyTried))
                    {
                        DepartmentPoint[] BorderPoints = GetBorderPointsFor(allpoints, chosenneighbour);
                        DepartmentPoint chosen = allpoints[BorderPoints[CityPointParsing.rand.Next(BorderPoints.Length)].Coord];
                        chosen.Owner = this;
                        AssignedPoints.AddLast(chosen);
                        --RemainingPoints;
                        return true;
                    }
                    else
                        throw new Exception();

                }
                else
                    return false;
            }
            else
            {

                DepartmentPoint chosen = growablearr[CityPointParsing.rand.Next(growablearr.Length)];

                int direction = CityPointParsing.rand.Next(4);
                if (direction == 0 && chosen.CanGrowRight)
                {
                    allpoints[chosen.Coord + 1].Owner = this;
                    AssignedPoints.AddLast(allpoints[chosen.Coord + 1]);
                }
                else if (direction == 1 && chosen.CanGrowLeft)
                {
                    allpoints[chosen.Coord - 1].Owner = this;
                    AssignedPoints.AddLast(allpoints[chosen.Coord - 1]);
                }
                else if (direction == 2 && chosen.CanGrowUp)
                {
                    allpoints[chosen.Coord - 2814].Owner = this;
                    AssignedPoints.AddLast(allpoints[chosen.Coord - 2814]);
                }
                else if (direction == 3 && chosen.CanGrowDown)
                {
                    allpoints[chosen.Coord + 2814].Owner = this;
                    AssignedPoints.AddLast(allpoints[chosen.Coord + 2814]);
                }
                //DIRTY
                else if (chosen.CanGrowRight)
                {
                    allpoints[chosen.Coord + 1].Owner = this;
                    AssignedPoints.AddLast(allpoints[chosen.Coord + 1]);
                }
                else if (chosen.CanGrowLeft)
                {
                    allpoints[chosen.Coord - 1].Owner = this;
                    AssignedPoints.AddLast(allpoints[chosen.Coord - 1]);
                }
                else if (chosen.CanGrowUp)
                {
                    allpoints[chosen.Coord - 2814].Owner = this;
                    AssignedPoints.AddLast(allpoints[chosen.Coord - 2814]);
                }
                else if (chosen.CanGrowDown)
                {
                    allpoints[chosen.Coord + 2814].Owner = this;
                    AssignedPoints.AddLast(allpoints[chosen.Coord + 2814]);
                }
                else
                    throw new Exception();



                if (RemainingPoints > 0)
                    --RemainingPoints;
                else
                    throw new Exception("This Exception will be useless if everything works");

                return true;
            }
        }

        private DepartmentPoint[] GetBorderPointsFor(DepartmentPoint[] allpoints, City city)
        {
            LinkedList<DepartmentPoint> borderpoints = new LinkedList<DepartmentPoint>();

            foreach (DepartmentPoint point in AssignedPoints)
            {
                int right = point.Coord + 1;
                int left = point.Coord - 1;
                int up = point.Coord - 2814;
                int down = point.Coord + 2814;

                if (allpoints[right] != null && allpoints[right].Owner == city)
                {
                    borderpoints.AddLast(allpoints[right]);
                }
                if (allpoints[left] != null && allpoints[left].Owner == city)
                {
                    borderpoints.AddLast(allpoints[left]);
                }
                if (allpoints[up] != null && allpoints[up].Owner == city)
                {
                    borderpoints.AddLast(allpoints[up]);
                }
                if (allpoints[down] != null && allpoints[down].Owner == city)
                {
                    borderpoints.AddLast(allpoints[down]);
                }
            }

            return borderpoints.ToArray();
        }

        private City[] GetNeighbours(DepartmentPoint[] allpoints, LinkedList<City> alreadytried)
        {
            LinkedList<City> neighbours = new LinkedList<City>();

            foreach (DepartmentPoint point in AssignedPoints)
            {
                int right = point.Coord + 1;
                int left = point.Coord - 1;
                int up = point.Coord - 2814;
                int down = point.Coord + 2814;

                if (allpoints[right] != null && allpoints[right].Owner != this && allpoints[right].Owner != null)
                {
                    if (!neighbours.Contains(allpoints[right].Owner) && !alreadytried.Contains(allpoints[right].Owner))
                        neighbours.AddLast(allpoints[right].Owner);

                }
                if (allpoints[left] != null && allpoints[left].Owner != this && allpoints[left].Owner != null)
                {
                    if (!neighbours.Contains(allpoints[left].Owner) && !alreadytried.Contains(allpoints[left].Owner))
                        neighbours.AddLast(allpoints[left].Owner);
                }
                if (allpoints[up] != null && allpoints[up].Owner != this && allpoints[up].Owner != null)
                {
                    if (!neighbours.Contains(allpoints[up].Owner) && !alreadytried.Contains(allpoints[up].Owner))
                        neighbours.AddLast(allpoints[up].Owner);
                }
                if (allpoints[down] != null && allpoints[down].Owner != this && allpoints[down].Owner != null)
                {
                    if (!neighbours.Contains(allpoints[down].Owner) && !alreadytried.Contains(allpoints[down].Owner))
                        neighbours.AddLast(allpoints[down].Owner);
                }
            }

            if (neighbours.Count == 0)
                Console.WriteLine();
            return neighbours.ToArray();
        }

    }
}
