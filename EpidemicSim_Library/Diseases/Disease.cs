using System;
using System.Text;
using System.Collections.Generic;
namespace PSC2013.ES.Library.Diseases
{
    /// <summary>
    /// Describes a disease with all its relevant
    /// factors/properties. It is used in the
    /// calculation-process of the simulation.
    /// </summary>
    public class Disease
    {
        public int ByteSize  // Byte-Size of the Disease
        {
            get { return 113 + Encoding.UTF8.GetBytes(Name).Length; }
        } 
        public const byte HEADER = 0x03;

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
        public int IdleTime { get; set; }                                       //TODO: |f| should be short.... //|T| I was not allowed to change it

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
            var output = new byte[this.ByteSize];
            output[0] = HEADER;
            Array.Copy(BitConverter.GetBytes(IncubationPeriod), 0, output, 1, 4);
            Array.Copy(BitConverter.GetBytes(IdleTime), 0, output, 5, 4);
            Array.Copy(BitConverter.GetBytes(SpreadingTime), 0, output, 9, 4);
            Array.Copy(BitConverter.GetBytes(Transferability), 0, output, 13, 4);
            Array.Copy(BitConverter.GetBytes(MortalityRate.Male_Baby), 0, output, 17, 4);
            Array.Copy(BitConverter.GetBytes(MortalityRate.Male_Child), 0, output, 21, 4);
            Array.Copy(BitConverter.GetBytes(MortalityRate.Male_Adult), 0, output, 25, 4);
            Array.Copy(BitConverter.GetBytes(MortalityRate.Male_Senior), 0, output, 29, 4);
            Array.Copy(BitConverter.GetBytes(MortalityRate.Female_Baby), 0, output, 33, 4);
            Array.Copy(BitConverter.GetBytes(MortalityRate.Female_Child), 0, output, 37, 4);
            Array.Copy(BitConverter.GetBytes(MortalityRate.Female_Adult), 0, output, 41, 4);
            Array.Copy(BitConverter.GetBytes(MortalityRate.Female_Senior), 0, output, 45, 4);
            Array.Copy(BitConverter.GetBytes(HealingFactor.Male_Baby), 0, output, 49, 4);
            Array.Copy(BitConverter.GetBytes(HealingFactor.Male_Child), 0, output, 53, 4);
            Array.Copy(BitConverter.GetBytes(HealingFactor.Male_Adult), 0, output, 57, 4);
            Array.Copy(BitConverter.GetBytes(HealingFactor.Male_Senior), 0, output, 61, 4);
            Array.Copy(BitConverter.GetBytes(HealingFactor.Female_Baby), 0, output, 65, 4);
            Array.Copy(BitConverter.GetBytes(HealingFactor.Female_Child), 0, output, 69, 4);
            Array.Copy(BitConverter.GetBytes(HealingFactor.Female_Adult), 0, output, 73, 4);
            Array.Copy(BitConverter.GetBytes(HealingFactor.Female_Senior), 0, output, 77, 4);
            Array.Copy(BitConverter.GetBytes(ResistanceFactor.Male_Baby), 0, output, 81, 4);
            Array.Copy(BitConverter.GetBytes(ResistanceFactor.Male_Child), 0, output, 85, 4);
            Array.Copy(BitConverter.GetBytes(ResistanceFactor.Male_Adult), 0, output, 89, 4);
            Array.Copy(BitConverter.GetBytes(ResistanceFactor.Male_Senior), 0, output, 93, 4);
            Array.Copy(BitConverter.GetBytes(ResistanceFactor.Female_Baby), 0, output, 97, 4);
            Array.Copy(BitConverter.GetBytes(ResistanceFactor.Female_Child), 0, output, 101, 4);
            Array.Copy(BitConverter.GetBytes(ResistanceFactor.Female_Adult), 0, output, 105, 4);
            Array.Copy(BitConverter.GetBytes(ResistanceFactor.Female_Senior), 0, output, 109, 4);
            byte[] nameByte = Encoding.UTF8.GetBytes(Name);
            Array.Copy(nameByte, 0, output, 113, nameByte.Length);
            return output;
        }

        /// <summary>
        /// Returns a new Disease from an Byte[]
        /// </summary>
        /// <param name="bytes">The [] containing the diseases information</param>
        public static Disease FromBytes(byte[] bytes)
        {
            if (bytes[0] != HEADER)
                throw new HeaderCorruptException("Header damaged, should " + HEADER);

            Disease disease = new Disease();

            disease.IncubationPeriod = BitConverter.ToInt32(bytes, 1);
            disease.IdleTime = BitConverter.ToInt32(bytes, 5);
            disease.SpreadingTime = BitConverter.ToInt32(bytes, 9);
            disease.Transferability = BitConverter.ToInt32(bytes, 13);

            int mortMaleBaby = BitConverter.ToInt32(bytes, 17);
            int mortMaleChild = BitConverter.ToInt32(bytes, 21);
            int mortMaleAdult = BitConverter.ToInt32(bytes, 25);
            int mortMaleSenior = BitConverter.ToInt32(bytes, 29);
            int mortFemaleBaby = BitConverter.ToInt32(bytes, 33);
            int mortFemaleChild = BitConverter.ToInt32(bytes, 37);
            int mortFemaleAdult = BitConverter.ToInt32(bytes, 41);
            int mortFemaleSenior = BitConverter.ToInt32(bytes, 45);

            disease.MortalityRate =
                new FactorContainer(new[] {
                mortMaleBaby, mortMaleChild, mortMaleAdult, mortMaleSenior, 
                mortFemaleBaby, mortFemaleChild, mortFemaleAdult, mortFemaleSenior });

            int healMaleBaby = BitConverter.ToInt32(bytes, 49);
            int healMaleChild = BitConverter.ToInt32(bytes, 53);
            int healMaleAdult = BitConverter.ToInt32(bytes, 57);
            int healMaleSenior = BitConverter.ToInt32(bytes, 61);
            int healFemaleBaby = BitConverter.ToInt32(bytes, 65);
            int healFemaleChild = BitConverter.ToInt32(bytes, 69);
            int healFemaleAdult = BitConverter.ToInt32(bytes, 73);
            int healFemaleSenior = BitConverter.ToInt32(bytes, 77);

            disease.HealingFactor =
                new FactorContainer(new[] {
                healMaleBaby, healMaleChild, healMaleAdult, healMaleSenior, 
                healFemaleBaby, healFemaleChild, healFemaleAdult, healFemaleSenior });

            int restMaleBaby = BitConverter.ToInt32(bytes, 81);
            int restMaleChild = BitConverter.ToInt32(bytes, 85);
            int restMaleAdult = BitConverter.ToInt32(bytes, 89);
            int restMaleSenior = BitConverter.ToInt32(bytes, 93);
            int restFemaleBaby = BitConverter.ToInt32(bytes, 97);
            int restFemaleChild = BitConverter.ToInt32(bytes, 101);
            int restFemaleAdult = BitConverter.ToInt32(bytes, 105);
            int restFemaleSenior = BitConverter.ToInt32(bytes, 109);

            disease.ResistanceFactor =
                new FactorContainer(new[] {
                restMaleBaby, restMaleChild, restMaleAdult, restMaleSenior, 
                restFemaleBaby, restFemaleChild, restFemaleAdult, restFemaleSenior });

            string name = Encoding.UTF8.GetString(bytes, 113, bytes.Length - 113);
            disease.Name = name;

            return disease;
        }
    }
}