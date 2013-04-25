using System.Linq;

namespace PSC2013.ES.Library.PopulationData
{
    public class PopulationCell
    {
        private const int DEFAULT_ARRAY_LENGTH = 8;

        public Human[] Humans { get; private set; }

        public int RefDepartment { get; set; }

        public int HumanCount { get { return Humans.Count(human => !human.IsDead()); } }
        public int SpreadingCount { get { return Humans.Count(human => human.IsSpreading()); } }

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

           	int length = (Humans.Length <= 1) ? DEFAULT_ARRAY_LENGTH : (int)(Humans.Length * 1.5f);
            Human[] newArray = new Human[length];

            int n = 0;
            foreach (Human toCopy in Humans)
            {
                newArray[n++] = toCopy;
            }

            newArray[++n] = human;
            Humans = newArray;
        }

        public override string ToString()
        {
            return Humans.Count(human => !human.IsDead()).ToString();
        }
    }
}