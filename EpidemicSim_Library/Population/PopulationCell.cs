using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Population
{
    internal struct PopulationCell
    {
        public int MaleBaby { get; set; }
        public int MaleChild { get; set; }
        public int MaleAdult { get; set; }
        public int MaleSenior { get; set; }

        public int FemaleBaby { get; set; }
        public int FemaleChild { get; set; }
        public int FemaleAdult { get; set; }
        public int FemaleSenior { get; set; }

        public long Total
        {
            // |f| There might be an easier solution for this..
            get
            {
                return MaleBaby + MaleChild + MaleAdult + MaleSenior + FemaleBaby + FemaleChild + FemaleAdult + FemaleSenior;
            }
        }
    }
}