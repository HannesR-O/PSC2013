using System;

namespace PSC2013.ES.Library.Population
{
    public struct PopulationCell
    {
        public int MaleBaby { get; set; }
        public int MaleChild { get; set; }
        public int MaleAdult { get; set; }
        public int MaleSenior { get; set; }

        public int FemaleBaby { get; set; }
        public int FemaleChild { get; set; }
        public int FemaleAdult { get; set; }
        public int FemaleSenior { get; set; }

        public long Total       // |f| long just to be safe from overflows
        {
            // |f| There might be an easier solution for this..
            get
            {
                return (long)MaleBaby + MaleChild + MaleAdult + MaleSenior + FemaleBaby + FemaleChild + FemaleAdult + FemaleSenior;
            }
        }
    }
}