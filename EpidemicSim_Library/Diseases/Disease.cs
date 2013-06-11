namespace PSC2013.ES.Library.Diseases
{
    /// <summary>
    /// Describes a disease with all its relevant
    /// factors/properties. It is used in the
    /// calculation-process of the simulation.
    /// </summary>
    public class Disease
    {
        // TODO | dj | types might be changed...
        public const int SIZE = 2; // minimal Byte-Size of the Disease, not 

        /// <summary>
        /// Name of the Disease
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Incubation period until a subject
        /// is showing symptoms.
        /// </summary>
        public int IncubationPeriod { get; set; }

        /// <summary>
        /// Time until a subject spreads the
        /// disease after getting infected.
        /// </summary>
        public int IdleTime { get; set; }                                       //TODO: |f| should be short.... 

        /// <summary>
        /// Time, the subject spreads the disease.
        /// </summary>
        public int SpreadingTime { get; set; }                                  //TODO: |f| should be short.... ASWELL!

        /// <summary>
        /// Mortality rate of diseased subjects.
        /// </summary>
        public FactorContainer MortalityRate { get; set; }

        /// <summary>
        /// Possibility of a subject being
        /// healed of the disease.
        /// </summary>
        public FactorContainer HealingFactor { get; set; }

        /// <summary>
        /// The possibility to transfer the
        /// disease from one subject to another.
        /// 100 = 100% ...
        /// </summary>
        public int Transferability { get; set; }

        /// <summary>
        /// Factor of resistance. Possibility for
        /// a subject of not being infected/diseased.
        /// May be increased by successful healings.
        /// </summary>
        public FactorContainer ResistanceFactor { get; set; }

        // Disease "IO"-Methods

        /// <summary>
        /// Returns a Byte[] Representation of the Disease
        /// </summary>
        /// <returns>A Byte[] Representation of the Disease</returns>
        public byte[] GetBytes()
        {
            return null;
        }

        /// <summary>
        /// Returns a new Disease from an Byte[]
        /// </summary>
        /// <param name="bytes">The [] containing the diseases information</param>
        public static Disease FromBytes(byte[] bytes)
        {
            return new Disease();
        }
    }
}