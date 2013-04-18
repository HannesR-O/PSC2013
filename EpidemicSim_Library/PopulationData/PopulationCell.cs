using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.PopulationData
{
    public struct PopulationCell
    {
        private const int STANDARD_ARRAY_LENGTH = 8;

        public Human[] Humans;
        public int RefDepartment;
        public int HumanCount;

        public void Init() // TODO | dj | should be called normally
        {
            Humans = new Human[0];
        }

        public void AddHuman(Human h)
        {
            for (int i = 0; i < Humans.Length; i++)
            {
                if (Humans[i].IsDead())
                {
                    Humans[i] = h;
                    return;
                }
            }

            int l = (Humans.Length <= 1) ? STANDARD_ARRAY_LENGTH : (int)(Humans.Length * 1.5f);
            Human[] arr = new Human[l];

            int n = 0;
            foreach (Human human in Humans)
            {
                arr[n] = human;
                n++;
            }
        }
    }
}
