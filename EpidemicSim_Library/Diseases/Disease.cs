namespace PSC2013.ES.Library.Diseases
{
    /// <summary>
    /// Describes a disease with all relevant
    /// factors/properties. This is used in the
    /// calculation-process of the simulation.
    /// </summary>
    public class Disease
    {
        // TODO | dj | types might be changed...

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
        public int IdleTime { get; set; }

        /// <summary>
        /// Time, the subject spreads the disease.
        /// </summary>
        public int SpreadingTime { get; set; }

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
        /// disease from one subject to another
        /// </summary>
        public int Transferability { get; set; }

        /// <summary>
        /// Factor of resistance. Possibility for
        /// a subject of not being infected/diseased.
        /// May be increased by successful healings.
        /// </summary>
        public FactorContainer ResistanceFactor { get; set; }
    }
}