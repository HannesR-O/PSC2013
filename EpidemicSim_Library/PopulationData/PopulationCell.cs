using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.PopulationData
{
    public struct PopulationCell
    {
        public Human[] Humans;
        public int RefDepartment;
        public int HumanCount;

        public void Init()
        {
            Humans = new Human[10];
        }
    }
}
