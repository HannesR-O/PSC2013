using PSC2013.ES.Library.IO.Files;
using System;
using PSC2013.ES.Library.Diseases;

namespace PSC2013.ES.Library.Snapshot
{
    /// <summary>
    /// Head-Data for Simulation infos, Contains Dates, Refs etc.
    /// </summary>
    public class SimulationInfo : IBinaryFile
    {
        private const byte HEADER = 0x1;
        public Disease Disease { get; private set; }
        public string Name { get; private set; }

        private SimulationInfo(string name, Disease disease)
        {
            Name = name;
            Disease = disease;
        }

        /// <summary>
        /// Initializes a new SimulationInfo from Runtime
        /// </summary>
        /// <param name="name">The Simulations Name</param>
        /// <param name="disease">The used Disease</param>
        /// <returns></returns>
        public static SimulationInfo InitializeFromRuntime(string name, Disease disease)
        {
            return new SimulationInfo(name, disease);
        }

        /// <summary>
        /// Initializes a new SimulationInfo from a file
        /// </summary>
        /// <param name="bytes">the byte[] from a file</param>
        /// <returns>A new SimulationInfo</returns>
        public static SimulationInfo InitializeFromFile(byte[] bytes)
        {
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
                new FactorContainer ( new[] {
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

            string name = BitConverter.ToString(bytes, 113);
            disease.Name = name;
            return new SimulationInfo(name, disease);
        }

        /// <summary>
        /// Returns the Simulations information in an byte[]
        /// </summary>
        /// <returns>Simulations Infos as byte[]</returns>
        public byte[] GetBytes()
        {
            byte[] t = System.Text.Encoding.UTF8.GetBytes(Disease.Name);
            var output = new byte[113 + t.Length];
            output[0] = HEADER;
            Array.Copy(BitConverter.GetBytes(Disease.IncubationPeriod), 0, output, 1, 4);
            Array.Copy(BitConverter.GetBytes(Disease.IdleTime), 0, output, 5, 4);
            Array.Copy(BitConverter.GetBytes(Disease.SpreadingTime), 0, output, 9, 4);
            Array.Copy(BitConverter.GetBytes(Disease.Transferability), 0, output, 13, 4);
            Array.Copy(BitConverter.GetBytes(Disease.MortalityRate.Male_Baby), 0, output, 17, 4);
            Array.Copy(BitConverter.GetBytes(Disease.MortalityRate.Male_Child), 0, output, 21, 4);
            Array.Copy(BitConverter.GetBytes(Disease.MortalityRate.Male_Adult), 0, output, 25, 4);
            Array.Copy(BitConverter.GetBytes(Disease.MortalityRate.Male_Senior), 0, output, 29, 4);
            Array.Copy(BitConverter.GetBytes(Disease.MortalityRate.Female_Baby), 0, output, 33, 4);
            Array.Copy(BitConverter.GetBytes(Disease.MortalityRate.Female_Child), 0, output, 37, 4);
            Array.Copy(BitConverter.GetBytes(Disease.MortalityRate.Female_Adult), 0, output, 41, 4);
            Array.Copy(BitConverter.GetBytes(Disease.MortalityRate.Female_Senior), 0, output, 45, 4);
            Array.Copy(BitConverter.GetBytes(Disease.HealingFactor.Male_Baby), 0, output, 49, 4);
            Array.Copy(BitConverter.GetBytes(Disease.HealingFactor.Male_Child), 0, output, 53, 4);
            Array.Copy(BitConverter.GetBytes(Disease.HealingFactor.Male_Adult), 0, output, 57, 4);
            Array.Copy(BitConverter.GetBytes(Disease.HealingFactor.Male_Senior), 0, output, 61, 4);
            Array.Copy(BitConverter.GetBytes(Disease.HealingFactor.Female_Baby), 0, output, 65, 4);
            Array.Copy(BitConverter.GetBytes(Disease.HealingFactor.Female_Child), 0, output, 69, 4);
            Array.Copy(BitConverter.GetBytes(Disease.HealingFactor.Female_Adult), 0, output, 73, 4);
            Array.Copy(BitConverter.GetBytes(Disease.HealingFactor.Female_Senior), 0, output, 77, 4);
            Array.Copy(BitConverter.GetBytes(Disease.ResistanceFactor.Male_Baby), 0, output, 81, 4);
            Array.Copy(BitConverter.GetBytes(Disease.ResistanceFactor.Male_Child), 0, output, 85, 4);
            Array.Copy(BitConverter.GetBytes(Disease.ResistanceFactor.Male_Adult), 0, output, 89, 4);
            Array.Copy(BitConverter.GetBytes(Disease.ResistanceFactor.Male_Senior), 0, output, 93, 4);
            Array.Copy(BitConverter.GetBytes(Disease.ResistanceFactor.Female_Baby), 0, output, 97, 4);
            Array.Copy(BitConverter.GetBytes(Disease.ResistanceFactor.Female_Child), 0, output, 101, 4);
            Array.Copy(BitConverter.GetBytes(Disease.ResistanceFactor.Female_Adult), 0, output, 105, 4);
            Array.Copy(BitConverter.GetBytes(Disease.ResistanceFactor.Female_Senior), 0, output, 109, 4);
            Array.Copy(t, 0, output, 113, t.Length);
            return output;
        }
    }
}