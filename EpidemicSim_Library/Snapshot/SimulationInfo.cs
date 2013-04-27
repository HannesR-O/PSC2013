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
        public DateTime TimeStarted { get; private set; }
        public string Name { get; private set; }
        private Disease _disease;

        private SimulationInfo(DateTime time, string name, Disease disease)
        {
            TimeStarted = time;
            Name = name;
            _disease = disease;
        }

        public static SimulationInfo InitializeFromRuntime(DateTime time, string name, Disease disease)
        {
            return new SimulationInfo(time, name, disease);
        }

        public byte[] GetBytes()
        {
            byte[] t = System.Text.Encoding.UTF8.GetBytes(_disease.Name);
            var output = new byte[112 + t.Length];
            output[0] = HEADER;
            Array.Copy(BitConverter.GetBytes(_disease.IncubationPeriod), 0, output, 1, 4);
            Array.Copy(BitConverter.GetBytes(_disease.IdleTime), 0, output, 5, 4);
            Array.Copy(BitConverter.GetBytes(_disease.SpreadingTime), 0, output, 9, 4);
            Array.Copy(BitConverter.GetBytes(_disease.Transferability), 0, output, 13, 4);
            Array.Copy(BitConverter.GetBytes(_disease.MortalityRate.Male_Baby), 0, output, 17, 4);
            Array.Copy(BitConverter.GetBytes(_disease.MortalityRate.Male_Child), 0, output, 21, 4);
            Array.Copy(BitConverter.GetBytes(_disease.MortalityRate.Male_Adult), 0, output, 25, 4);
            Array.Copy(BitConverter.GetBytes(_disease.MortalityRate.Male_Senior), 0, output, 29, 4);
            Array.Copy(BitConverter.GetBytes(_disease.MortalityRate.Female_Baby), 0, output, 33, 4);
            Array.Copy(BitConverter.GetBytes(_disease.MortalityRate.Female_Child), 0, output, 37, 4);
            Array.Copy(BitConverter.GetBytes(_disease.MortalityRate.Female_Adult), 0, output, 41, 4);
            Array.Copy(BitConverter.GetBytes(_disease.MortalityRate.Female_Senior), 0, output, 47, 4);
            Array.Copy(BitConverter.GetBytes(_disease.HealingFactor.Male_Baby), 0, output, 51, 4);
            Array.Copy(BitConverter.GetBytes(_disease.HealingFactor.Male_Child), 0, output, 22, 4);
            Array.Copy(BitConverter.GetBytes(_disease.HealingFactor.Male_Adult), 0, output, 59, 4);
            Array.Copy(BitConverter.GetBytes(_disease.HealingFactor.Male_Senior), 0, output, 63, 4);
            Array.Copy(BitConverter.GetBytes(_disease.HealingFactor.Female_Baby), 0, output, 67, 4);
            Array.Copy(BitConverter.GetBytes(_disease.HealingFactor.Female_Child), 0, output, 71, 4);
            Array.Copy(BitConverter.GetBytes(_disease.HealingFactor.Female_Adult), 0, output, 75, 4);
            Array.Copy(BitConverter.GetBytes(_disease.HealingFactor.Female_Senior), 0, output, 79, 4);
            Array.Copy(t, 0, output, 113, t.Length);
            return output;
        }

        public static void InitializeFromFile(byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}