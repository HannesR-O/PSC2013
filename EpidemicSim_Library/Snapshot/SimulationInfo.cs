﻿using PSC2013.ES.Library.IO.Files;
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

        public static SimulationInfo InitializeFromRuntime(string name, Disease disease)
        {
            return new SimulationInfo(name, disease);
        }

        public static SimulationInfo InitializeFromFile(byte[] bytes)
        {
            throw new NotImplementedException();
        }

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
            Array.Copy(BitConverter.GetBytes(Disease.MortalityRate.Female_Senior), 0, output, 47, 4);
            Array.Copy(BitConverter.GetBytes(Disease.HealingFactor.Male_Baby), 0, output, 51, 4);
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
            Array.Copy(BitConverter.GetBytes(Disease.ResistanceFactor.Female_Adult), 0, output,105, 4);
            Array.Copy(BitConverter.GetBytes(Disease.ResistanceFactor.Female_Senior), 0, output, 109, 4);
            Array.Copy(t, 0, output, 113, t.Length);
            return output;
        }
    }
}