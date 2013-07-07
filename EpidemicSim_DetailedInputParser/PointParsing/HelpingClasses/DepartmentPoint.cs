using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemicSim_DetailedInputParser
{
    public class DepartmentPoint
    {
        public City Owner;
        public int Coord;
        public Department Department;
        public List<int> GrowableCoords;

        public DepartmentPoint(int coord, Department dep)
        {
            Coord = coord;
            Owner = null;
            GrowableCoords = new List<int>(4);
            Department = dep;
        }
    }

    public class Department
    {
        
    }
    
}
