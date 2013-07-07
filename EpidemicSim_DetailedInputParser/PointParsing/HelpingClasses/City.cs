using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemicSim_DetailedInputParser
{
    public class City
    {
        private static Random rand = new Random();
        public DepartmentPoint[] AllPoints;
        public DepartmentPoint[] DepartmentPoints;
        public int LineIndexInFile;
        public List<DepartmentPoint> GrowablePoints;
        public int RemainingPoints;
        public List<DepartmentPoint> AssignedPoints;
        public string Name;
        public Department Department;

        public City(int pointcount, int lineindex, string name, DepartmentPoint[] allpoints, DepartmentPoint[] deppoints, Department dep)
        {
            RemainingPoints = pointcount;
            LineIndexInFile = lineindex;
            AssignedPoints = new List<DepartmentPoint>(500);
            GrowablePoints = new List<DepartmentPoint>(100);
            Name = name;
            AllPoints = allpoints;
            DepartmentPoints = deppoints;
            Department = dep;
        }

        public void GrowCautious()
        {
            UpdateGrowablePoints();
            while (RemainingPoints > 0 && GrowablePoints.Count > 0)
            {
                DepartmentPoint chosenpoint = GrowablePoints[rand.Next(GrowablePoints.Count)];
                int chosencoord = chosenpoint.GrowableCoords[rand.Next(chosenpoint.GrowableCoords.Count)];
                AllPoints[chosencoord].Owner = this;
                AssignedPoints.Add(AllPoints[chosencoord]);
                --RemainingPoints;
                UpdateGrowablePoints();
            }
        }

        public bool GrowBrutal(List<City> AlreadyTried)
        {
            bool first = AlreadyTried.Count == 0;
            if (!AlreadyTried.Contains(this))
                AlreadyTried.Add(this);

            UpdateGrowablePoints();
            if (GrowablePoints.Count == 0)
            {
                List<City> neighbours = GetNeighbours(AlreadyTried);
                if (neighbours.Count == 0)
                    return false;
                foreach (City neighbour in neighbours)
                {
                    neighbour.UpdateGrowablePoints();
                    if (neighbour.GrowablePoints.Count != 0)
                    {
                        neighbour.GrowBrutal(AlreadyTried);
                        DepartmentPoint[] neighbourborderpoints = GetBorderPointsFor(neighbour);
                        DepartmentPoint chosenneighbourborderpoint = neighbourborderpoints[rand.Next(neighbourborderpoints.Length)];
                        neighbour.AssignedPoints.Remove(chosenneighbourborderpoint);
                        chosenneighbourborderpoint.Owner = this;
                        AssignedPoints.Add(chosenneighbourborderpoint);
                        if (first)
                            --RemainingPoints;
                        return true;
                    }
                }
                City chosenneighbour = null;
                do
                {
                    if (neighbours.Count == 0)
                        return false;
                    chosenneighbour = neighbours[rand.Next(neighbours.Count)];
                    neighbours.Remove(chosenneighbour);

                } while (!chosenneighbour.GrowBrutal(AlreadyTried));
                DepartmentPoint[] chosenborderpoints = GetBorderPointsFor(chosenneighbour);
                DepartmentPoint chosenborderpoint = chosenborderpoints[rand.Next(chosenborderpoints.Length)];
                chosenneighbour.AssignedPoints.Remove(chosenborderpoint);
                chosenborderpoint.Owner = this;
                AssignedPoints.Add(chosenborderpoint);
                if (first)
                    --RemainingPoints;
                return true;


            }
            else
            {
                //Just Grow
                DepartmentPoint chosenpoint = GrowablePoints[rand.Next(GrowablePoints.Count)];
                int chosencoord = chosenpoint.GrowableCoords[rand.Next(chosenpoint.GrowableCoords.Count)];
                AllPoints[chosencoord].Owner = this;
                AssignedPoints.Add(AllPoints[chosencoord]);
                if (first)
                    --RemainingPoints;
                return true;
            }
        }

        public void AssignStartPoint()
        {
            DepartmentPoint startpoint = null;

            List<DepartmentPoint> possiblestartpoints = new List<DepartmentPoint>(100);
            for (int i = 0; i < DepartmentPoints.Length; ++i)
            {
                if (DepartmentPoints[i].Owner == null)
                    possiblestartpoints.Add(DepartmentPoints[i]);
            }

            startpoint = possiblestartpoints[rand.Next(possiblestartpoints.Count)];

            startpoint.Owner = this;
            AssignedPoints.Add(startpoint);
            --RemainingPoints;
        }

        public void UpdateGrowablePoints()
        {
            GrowablePoints.Clear();
            foreach (DepartmentPoint point in AssignedPoints)
            {
                point.GrowableCoords.Clear();

                int right = point.Coord + 1;
                int left = point.Coord - 1;
                int up = point.Coord - 2814;
                int down = point.Coord + 2814;
                //int rightup = point.Coord + 1 - 2814;
                //int rightdown = point.Coord + 1 + 2814;
                //int leftup = point.Coord -1 - 2814;
                //int leftdown = point.Coord - 1 + 2814;

                bool cangrow = false;

                if (AllPoints[right] != null && AllPoints[right].Department == this.Department && AllPoints[right].Owner == null)
                {
                    point.GrowableCoords.Add(right);
                    cangrow = true;
                }
                if (AllPoints[left] != null && AllPoints[left].Department == this.Department && AllPoints[left].Owner == null)
                {
                    point.GrowableCoords.Add(left);
                    cangrow = true;
                }
                if (AllPoints[up] != null && AllPoints[up].Department == this.Department && AllPoints[up].Owner == null)
                {
                    point.GrowableCoords.Add(up);
                    cangrow = true;
                }
                if (AllPoints[down] != null && AllPoints[down].Department == this.Department && AllPoints[down].Owner == null)
                {
                    point.GrowableCoords.Add(down);
                    cangrow = true;
                }
                //if (AllPoints[rightup] != null && AllPoints[rightup].Department == this.Department && AllPoints[rightup].Owner == null)
                //{
                //    point.GrowableCoords.Add(rightup);
                //    cangrow = true;
                //}
                //if (AllPoints[rightdown] != null && AllPoints[rightdown].Department == this.Department && AllPoints[rightdown].Owner == null)
                //{
                //    point.GrowableCoords.Add(rightdown);
                //    cangrow = true;
                //}
                //if (AllPoints[leftup] != null && AllPoints[leftup].Department == this.Department && AllPoints[leftup].Owner == null)
                //{
                //    point.GrowableCoords.Add(leftup);
                //    cangrow = true;
                //}
                //if (AllPoints[leftdown] != null && AllPoints[leftdown].Department == this.Department && AllPoints[leftdown].Owner == null)
                //{
                //    point.GrowableCoords.Add(leftdown);
                //    cangrow = true;
                //}


                if (cangrow)
                    GrowablePoints.Add(point);
            }
        }

        private DepartmentPoint[] GetBorderPointsFor(City city)
        {
            LinkedList<DepartmentPoint> borderpoints = new LinkedList<DepartmentPoint>();

            foreach (DepartmentPoint point in AssignedPoints)
            {
                int right = point.Coord + 1;
                int left = point.Coord - 1;
                int up = point.Coord - 2814;
                int down = point.Coord + 2814;
                //int rightup = point.Coord + 1 - 2814;
                //int leftup = point.Coord - 1 - 2814;
                //int rightdown = point.Coord + 1 + 2814;
                //int leftdown = point.Coord - 1 + 2814;

                if (AllPoints[right] != null && AllPoints[right].Department == this.Department && AllPoints[right].Owner == city)
                {
                    borderpoints.AddLast(AllPoints[right]);
                }
                if (AllPoints[left] != null && AllPoints[left].Department == this.Department && AllPoints[left].Owner == city)
                {
                    borderpoints.AddLast(AllPoints[left]);
                }
                if (AllPoints[up] != null && AllPoints[up].Department == this.Department && AllPoints[up].Owner == city)
                {
                    borderpoints.AddLast(AllPoints[up]);
                }
                if (AllPoints[down] != null && AllPoints[down].Department == this.Department && AllPoints[down].Owner == city)
                {
                    borderpoints.AddLast(AllPoints[down]);
                }

                //if (AllPoints[rightup] != null && AllPoints[rightup].Department == this.Department && AllPoints[rightup].Owner == city)
                //{
                //    borderpoints.AddLast(AllPoints[rightup]);
                //}
                //if (AllPoints[leftup] != null && AllPoints[leftup].Department == this.Department && AllPoints[leftup].Owner == city)
                //{
                //    borderpoints.AddLast(AllPoints[leftup]);
                //}
                //if (AllPoints[rightdown] != null && AllPoints[rightdown].Department == this.Department && AllPoints[rightdown].Owner == city)
                //{
                //    borderpoints.AddLast(AllPoints[rightdown]);
                //}
                //if (AllPoints[leftdown] != null && AllPoints[leftdown].Department == this.Department && AllPoints[leftdown].Owner == city)
                //{
                //    borderpoints.AddLast(AllPoints[leftdown]);
                //}
            }

            return borderpoints.ToArray();
        }

        private List<City> GetNeighbours(List<City> alreadytried)
        {
            List<City> neighbours = new List<City>(5);

            foreach (DepartmentPoint point in AssignedPoints)
            {
                int right = point.Coord + 1;
                int left = point.Coord - 1;
                int up = point.Coord - 2814;
                int down = point.Coord + 2814;
                //int rightup = point.Coord + 1 - 2814;
                //int leftup = point.Coord - 1 - 2814;
                //int rightdown = point.Coord + 1 + 2814;
                //int leftdown = point.Coord - 1 + 2814;

                if (AllPoints[right] != null && AllPoints[right].Department == this.Department && AllPoints[right].Owner != this && AllPoints[right].Owner != null)
                {
                    if (!neighbours.Contains(AllPoints[right].Owner) && !alreadytried.Contains(AllPoints[right].Owner))
                        neighbours.Add(AllPoints[right].Owner);

                }
                if (AllPoints[left] != null && AllPoints[left].Department == this.Department && AllPoints[left].Owner != this && AllPoints[left].Owner != null)
                {
                    if (!neighbours.Contains(AllPoints[left].Owner) && !alreadytried.Contains(AllPoints[left].Owner))
                        neighbours.Add(AllPoints[left].Owner);
                }
                if (AllPoints[up] != null && AllPoints[up].Department == this.Department && AllPoints[up].Owner != this && AllPoints[up].Owner != null)
                {
                    if (!neighbours.Contains(AllPoints[up].Owner) && !alreadytried.Contains(AllPoints[up].Owner))
                        neighbours.Add(AllPoints[up].Owner);
                }
                if (AllPoints[down] != null && AllPoints[down].Department == this.Department && AllPoints[down].Owner != this && AllPoints[down].Owner != null)
                {
                    if (!neighbours.Contains(AllPoints[down].Owner) && !alreadytried.Contains(AllPoints[down].Owner))
                        neighbours.Add(AllPoints[down].Owner);
                }
                //if (AllPoints[rightup] != null && AllPoints[rightup].Department == this.Department && AllPoints[rightup].Owner != this && AllPoints[rightup].Owner != null)
                //{
                //    if (!neighbours.Contains(AllPoints[rightup].Owner) && !alreadytried.Contains(AllPoints[rightup].Owner))
                //        neighbours.Add(AllPoints[rightup].Owner);

                //}
                //if (AllPoints[leftup] != null && AllPoints[leftup].Department == this.Department && AllPoints[leftup].Owner != this && AllPoints[leftup].Owner != null)
                //{
                //    if (!neighbours.Contains(AllPoints[leftup].Owner) && !alreadytried.Contains(AllPoints[leftup].Owner))
                //        neighbours.Add(AllPoints[leftup].Owner);
                //}
                //if (AllPoints[rightdown] != null && AllPoints[rightdown].Department == this.Department && AllPoints[rightdown].Owner != this && AllPoints[rightdown].Owner != null)
                //{
                //    if (!neighbours.Contains(AllPoints[rightdown].Owner) && !alreadytried.Contains(AllPoints[rightdown].Owner))
                //        neighbours.Add(AllPoints[rightdown].Owner);

                //}
                //if (AllPoints[leftdown] != null && AllPoints[leftdown].Department == this.Department && AllPoints[leftdown].Owner != this && AllPoints[leftdown].Owner != null)
                //{
                //    if (!neighbours.Contains(AllPoints[leftdown].Owner) && !alreadytried.Contains(AllPoints[leftdown].Owner))
                //        neighbours.Add(AllPoints[leftdown].Owner);
                //}

            }

            return neighbours;
        }


        public void AssignRandomPoint()
        {
            List<DepartmentPoint> notassignedpoints = new List<DepartmentPoint>();
            foreach (DepartmentPoint point in DepartmentPoints)
            {
                if (point.Owner == null)
                    notassignedpoints.Add(point);
            }
            if (RemainingPoints > 0 && notassignedpoints.Count == 0)
                throw new Exception();

            DepartmentPoint chosenpoint = notassignedpoints[rand.Next(notassignedpoints.Count)];
            chosenpoint.Owner = this;
            AssignedPoints.Add(chosenpoint);
            --RemainingPoints;

        }
    }
}
