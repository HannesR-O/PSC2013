using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemicSim_DetailedInputParser
{
    public class DepInfo
    {
        public List<int> Points;
        public string Name;
        public DepInfo(string name)
        {
            Name = name;
            Points = new List<int>(100000);
        }
    }
}
