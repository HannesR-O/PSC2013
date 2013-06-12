using System;
using PSC2013.ES.Library.Snapshot;
using PSC2013.ES.Library.DiseaseData;
using Xunit;

namespace PSC2013.ES.Tests.Snapshot
{
    public class SimulationInfoTest
    {
        Disease _disease;
        string _name = "Disease";

        public void Start()
        {
            _disease = new Disease
            {
                Name = "Disease",
                IncubationPeriod = 238475,
                IdleTime = 123415,
                SpreadingTime = 123123,
                Transferability = 901237,
                MortalityRate = new FactorContainer(new[] { 1, 2, 14, 151, 11515, 123, 123, 120 }),
                HealingFactor = new FactorContainer(new[] { 1, 2, 14, 151, 11515, 123, 123, 120 }),
                ResistanceFactor = new FactorContainer(new[] { 1, 2, 14, 151, 11515, 123, 123, 120 })
            };
        }

        [Fact]
        public void SimInfoInitializeFromRuntimeTest()
        {
            Start();
            SimulationInfo sim = SimulationInfo.InitializeFromRuntime(_disease, 0, 0);

            Assert.Equal(sim.Disease, _disease);
            Assert.Equal(sim.Name, _name);
        }

        [Fact]
        public void SimInfoInitializeFromFileTest()
        {
            Start();
            SimulationInfo sim = SimulationInfo.InitializeFromRuntime(_disease, 0, 0);
            byte[] name = System.Text.Encoding.UTF8.GetBytes(_name);
            byte[] comp = new byte[121 + name.Length];
            Array.Copy(BitConverter.GetBytes(238475), 0, comp, 1, 4);
            Array.Copy(BitConverter.GetBytes(123415), 0, comp, 5, 4);
            Array.Copy(BitConverter.GetBytes(123123), 0, comp, 9, 4);
            Array.Copy(BitConverter.GetBytes(901237), 0, comp, 13, 4);
            Array.Copy(BitConverter.GetBytes(1), 0, comp, 17, 4);
            Array.Copy(BitConverter.GetBytes(2), 0, comp, 21, 4);
            Array.Copy(BitConverter.GetBytes(14), 0, comp, 25, 4);
            Array.Copy(BitConverter.GetBytes(151), 0, comp, 29, 4);
            Array.Copy(BitConverter.GetBytes(11515), 0, comp, 33, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 37, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 41, 4);
            Array.Copy(BitConverter.GetBytes(120), 0, comp, 45, 4);
            Array.Copy(BitConverter.GetBytes(1), 0, comp, 49, 4);
            Array.Copy(BitConverter.GetBytes(2), 0, comp, 53, 4);
            Array.Copy(BitConverter.GetBytes(14), 0, comp, 57, 4);
            Array.Copy(BitConverter.GetBytes(151), 0, comp, 61, 4);
            Array.Copy(BitConverter.GetBytes(11515), 0, comp, 65, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 69, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 73, 4);
            Array.Copy(BitConverter.GetBytes(120), 0, comp, 77, 4);
            Array.Copy(BitConverter.GetBytes(1), 0, comp, 81, 4);
            Array.Copy(BitConverter.GetBytes(2), 0, comp, 85, 4);
            Array.Copy(BitConverter.GetBytes(14), 0, comp, 89, 4);
            Array.Copy(BitConverter.GetBytes(151), 0, comp, 93, 4);
            Array.Copy(BitConverter.GetBytes(11515), 0, comp, 97, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 101, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 105, 4);
            Array.Copy(BitConverter.GetBytes(120), 0, comp, 109, 4);
            Array.Copy(BitConverter.GetBytes(2814), 0, comp, 113, 4);
            Array.Copy(BitConverter.GetBytes(3841), 0, comp, 117, 4);
            Array.Copy(name, 0, comp, 121, name.Length);

            SimulationInfo test = SimulationInfo.InitializeFromFile(comp);

            Assert.Equal(sim.Disease.IdleTime, test.Disease.IdleTime);
            Assert.Equal(sim.Disease.IncubationPeriod, test.Disease.IncubationPeriod);
            Assert.Equal(sim.Disease.SpreadingTime, test.Disease.SpreadingTime);
            Assert.Equal(sim.Disease.Transferability, test.Disease.Transferability);

            Assert.Equal(sim.Name, test.Name);
        }

        [Fact]
        public void SimInfoGetBytesTest()
        {
            Start();
            SimulationInfo sim = SimulationInfo.InitializeFromRuntime(_disease, 0, 0);

            byte[] testing = sim.GetBytes();
            byte[] name = System.Text.Encoding.UTF8.GetBytes(_disease.Name);
            byte[] comp = new byte[121 + name.Length];
            comp[0] = 0x1;
            Array.Copy(BitConverter.GetBytes(238475), 0, comp, 1, 4);
            Array.Copy(BitConverter.GetBytes(123415), 0, comp, 5, 4);
            Array.Copy(BitConverter.GetBytes(123123), 0, comp, 9, 4);
            Array.Copy(BitConverter.GetBytes(901237), 0, comp, 13, 4);
            Array.Copy(BitConverter.GetBytes(1), 0, comp, 17, 4);
            Array.Copy(BitConverter.GetBytes(2), 0, comp, 21, 4);
            Array.Copy(BitConverter.GetBytes(14), 0, comp, 25, 4);
            Array.Copy(BitConverter.GetBytes(151), 0, comp, 29, 4);
            Array.Copy(BitConverter.GetBytes(11515), 0, comp, 33, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 37, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 41, 4);
            Array.Copy(BitConverter.GetBytes(120), 0, comp, 45, 4);
            Array.Copy(BitConverter.GetBytes(1), 0, comp, 49, 4);
            Array.Copy(BitConverter.GetBytes(2), 0, comp, 53, 4);
            Array.Copy(BitConverter.GetBytes(14), 0, comp, 57, 4);
            Array.Copy(BitConverter.GetBytes(151), 0, comp, 61, 4);
            Array.Copy(BitConverter.GetBytes(11515), 0, comp, 65, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 69, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 73, 4);
            Array.Copy(BitConverter.GetBytes(120), 0, comp, 77, 4);
            Array.Copy(BitConverter.GetBytes(1), 0, comp, 81, 4);
            Array.Copy(BitConverter.GetBytes(2), 0, comp, 85, 4);
            Array.Copy(BitConverter.GetBytes(14), 0, comp, 89, 4);
            Array.Copy(BitConverter.GetBytes(151), 0, comp, 93, 4);
            Array.Copy(BitConverter.GetBytes(11515), 0, comp, 97, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 101, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 105, 4);
            Array.Copy(BitConverter.GetBytes(120), 0, comp, 109, 4);
            Array.Copy(BitConverter.GetBytes(2814), 0, comp, 113, 4);
            Array.Copy(BitConverter.GetBytes(3841), 0, comp, 117, 4);
            Array.Copy(name, 0, comp, 121, name.Length);

            for (int i = 0; i < comp.Length; ++i)
            {
                Assert.Equal(comp[i], testing[i]); 
            }
            
        }
    }
}