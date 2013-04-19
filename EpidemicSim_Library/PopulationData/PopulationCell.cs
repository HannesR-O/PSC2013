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

        public Human[] Humans { get { if (_humans == null) Initialize(); return _humans; } private set { _humans = value;  } }
        private Human[] _humans;

        public int RefDepartment { get; set; }
        public int HumanCount { get; set; }

        private void Initialize()
        {
            _humans = new Human[16];
        }

        public void AddHuman(Human human)
        {
            if (_humans == null)                    // safety first :P
                Initialize();

            for (int i = 0; i < Humans.Length; i++)
            {
                if (_humans[i].IsDead())
                {
                    _humans[i] = human;
                    return;
                }
            }

            int l = (_humans.Length <= 1) ? STANDARD_ARRAY_LENGTH : (int)(_humans.Length * 1.5f);
            Human[] arr = new Human[l];

            int n = 0;
            foreach (Human oldHuman in _humans)
            {
                arr[n++] = oldHuman;
            }

            arr[++n] = human;
        }
    }
}