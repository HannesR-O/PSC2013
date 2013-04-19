using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.PopulationData
{
    public class PopulationCell
    {
        private const int STANDARD_ARRAY_LENGTH = 8;

        public Human[] Humans { get; private set; }

        public int RefDepartment { get; set; }
        public int HumanCount { get; set; }
        public int SpreadingCount { get; set; }

        public PopulationCell()
        {
            Humans = new Human[0];
        }

        public void AddHuman(Human human)
        {
            for (int i = 0; i < Humans.Length; i++)
            {
                if (Humans[i].IsDead())
                {
                    Humans[i] = human;
                    return;
                }
            }

            int length = (Humans.Length <= 1) ? STANDARD_ARRAY_LENGTH : (int)(Humans.Length * 1.5f);
            Human[] newArray = new Human[length];

            int n = 0;
            foreach (Human toCopy in Humans)
            {
                newArray[n++] = toCopy;
            }

            newArray[++n] = human;
        }
    }
}