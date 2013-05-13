namespace PSC2013.ES.Library.PopulationData
{
    public class PopulationCell
    {
        public int RefDepartment { get; set; }

        public ushort Infected
        {
            get { return _data[8]; }
            set { _data[8] = value; }
        }
        public ushort Diseased 
        {
            get { return _data[9]; }
            set { _data[9] = value; }
        }
        public ushort Spreading
        {
            get { return _data[10]; }
            set { _data[10] = value; }
        }

        public ushort MaleBabies
        {
            get { return _data[0]; }
            set { _data[0] = value; }
        }
        public ushort MaleChildren
        {
            get { return _data[1]; }
            set { _data[1] = value; }
        }
        public ushort MaleAdults
        {
            get { return _data[2]; }
            set { _data[2] = value; }
        }
        public ushort MaleSeniors
        {
            get { return _data[3]; }
            set { _data[3] = value; }
        }

        public ushort FemaleBabies
        {
            get { return _data[4]; }
            set { _data[4] = value; }
        }
        public ushort FemaleChildren
        {
            get { return _data[5]; }
            set { _data[5] = value; }
        }
        public ushort FemaleAdults
        {
            get { return _data[6]; }
            set { _data[6] = value; }
        }
        public ushort FemaleSeniors
        {
            get { return _data[7]; }
            set { _data[7] = value; }
        }

        public ushort[] Data
        {
            get
            {
                ushort[] returnArray = new ushort[8];
                _data.CopyToOtherArray(returnArray);
                return returnArray;
            }
        }

        /// <summary>
        /// Probability to of a human meeting an infected human.
        /// </summary>
        public float Probability { get; set; }

        private ushort[] _data;

        public PopulationCell()
        {
            _data = new ushort[11];
        }
    }
}