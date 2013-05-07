using System.Linq;

namespace PSC2013.ES.Library.PopulationData
{
    public struct PopulationCell
    {
        public int RefDepartment { get; set; }

        public ushort Infected;
        public ushort Diseased;
        public ushort Spreading;

        public ushort MaleBabies;
        public ushort MaleChildren;
        public ushort MaleAdults;
        public ushort MaleSeniors;

        public ushort FemaleBabies;
        public ushort FemaleChildren;
        public ushort FemaleAdults;
        public ushort FemaleSeniors;

        public int Probability;

        internal void CalculateProbability()
        {
            throw new System.NotImplementedException();
        }
    }
}