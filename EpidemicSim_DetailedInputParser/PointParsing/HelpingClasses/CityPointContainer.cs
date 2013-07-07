using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemicSim_DetailedInputParser
{
    public class CityPointContainer
    {
        public int PointCount;
        public string NameOfCity;

        public CityPointContainer(string name, int pointsforcity)
        {
            NameOfCity = name;
            PointCount = pointsforcity;
        }
    }
}
