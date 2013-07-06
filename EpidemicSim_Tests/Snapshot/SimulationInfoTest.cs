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
            SimulationInfo sim = SimulationInfo.InitializeFromRuntime(_disease, 0, 0, 0, 0, 0);

            Assert.Equal(sim.Disease, _disease);
            Assert.Equal(sim.Name, _name);
        }

        [Fact]
        public void SimInfoInitializeFromFileTest()
        {
            Start();
            SimulationInfo sim = SimulationInfo.InitializeFromRuntime(_disease, int.MaxValue, int.MinValue, 250, 1, 0);
            byte[] name = System.Text.Encoding.UTF8.GetBytes(_name);
            byte[] comp = new byte[138 + name.Length];
            comp[0] = 0x01;
            Array.Copy(BitConverter.GetBytes(int.MaxValue), 0, comp, 1, 4);
            Array.Copy(BitConverter.GetBytes(int.MinValue), 0, comp, 5, 4);
            Array.Copy(BitConverter.GetBytes(250), 0, comp, 9, 4);
            Array.Copy(BitConverter.GetBytes(1), 0, comp, 13, 4);
            Array.Copy(BitConverter.GetBytes(0L), 0, comp, 17, 8);
            comp[25] = 3; // Header for Disease (HeaderCorruption else)
            Array.Copy(BitConverter.GetBytes(238475), 0, comp, 26, 4);
            Array.Copy(BitConverter.GetBytes(123415), 0, comp, 30, 4);
            Array.Copy(BitConverter.GetBytes(123123), 0, comp, 34, 4);
            Array.Copy(BitConverter.GetBytes(901237), 0, comp, 38, 4);
            Array.Copy(BitConverter.GetBytes(1), 0, comp, 42, 4);
            Array.Copy(BitConverter.GetBytes(2), 0, comp, 46, 4);
            Array.Copy(BitConverter.GetBytes(14), 0, comp, 50, 4);
            Array.Copy(BitConverter.GetBytes(151), 0, comp, 54, 4);
            Array.Copy(BitConverter.GetBytes(11515), 0, comp, 58, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 62, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 66, 4);
            Array.Copy(BitConverter.GetBytes(120), 0, comp, 70, 4);
            Array.Copy(BitConverter.GetBytes(1), 0, comp, 74, 4);
            Array.Copy(BitConverter.GetBytes(2), 0, comp, 78, 4);
            Array.Copy(BitConverter.GetBytes(14), 0, comp, 82, 4);
            Array.Copy(BitConverter.GetBytes(151), 0, comp, 86, 4);
            Array.Copy(BitConverter.GetBytes(11515), 0, comp, 90, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 94, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 99, 4);
            Array.Copy(BitConverter.GetBytes(120), 0, comp, 102, 4);
            Array.Copy(BitConverter.GetBytes(1), 0, comp, 106, 4);
            Array.Copy(BitConverter.GetBytes(2), 0, comp, 110, 4);
            Array.Copy(BitConverter.GetBytes(14), 0, comp, 114, 4);
            Array.Copy(BitConverter.GetBytes(151), 0, comp, 118, 4);
            Array.Copy(BitConverter.GetBytes(11515), 0, comp, 122, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 126, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 130, 4);
            Array.Copy(BitConverter.GetBytes(120), 0, comp, 134, 4);
            Array.Copy(name, 0, comp, 138, name.Length);

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
            SimulationInfo sim = SimulationInfo.InitializeFromRuntime(_disease, int.MaxValue, int.MinValue, 250, 1, 0);

            byte[] testing = sim.GetBytes();
            byte[] name = System.Text.Encoding.UTF8.GetBytes(_disease.Name);
            byte[] comp = new byte[138 + name.Length];
            comp[0] = 0x01;
            Array.Copy(BitConverter.GetBytes(int.MaxValue), 0, comp, 1, 4);
            Array.Copy(BitConverter.GetBytes(int.MinValue), 0, comp, 5, 4);
            Array.Copy(BitConverter.GetBytes(250), 0, comp, 9, 4);
            Array.Copy(BitConverter.GetBytes(1), 0, comp, 13, 4);
            Array.Copy(BitConverter.GetBytes(0L), 0, comp, 17, 8);
            comp[25] = 0x03; // Header for Disease (HeaderCorruption else)
            Array.Copy(BitConverter.GetBytes(238475), 0, comp, 26, 4);
            Array.Copy(BitConverter.GetBytes(123415), 0, comp, 30, 4);
            Array.Copy(BitConverter.GetBytes(123123), 0, comp, 34, 4);
            Array.Copy(BitConverter.GetBytes(901237), 0, comp, 38, 4);
            Array.Copy(BitConverter.GetBytes(1), 0, comp, 42, 4);
            Array.Copy(BitConverter.GetBytes(2), 0, comp, 46, 4);
            Array.Copy(BitConverter.GetBytes(14), 0, comp, 50, 4);
            Array.Copy(BitConverter.GetBytes(151), 0, comp, 54, 4);
            Array.Copy(BitConverter.GetBytes(11515), 0, comp, 58, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 62, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 66, 4);
            Array.Copy(BitConverter.GetBytes(120), 0, comp, 70, 4);
            Array.Copy(BitConverter.GetBytes(1), 0, comp, 74, 4);
            Array.Copy(BitConverter.GetBytes(2), 0, comp, 78, 4);
            Array.Copy(BitConverter.GetBytes(14), 0, comp, 82, 4);
            Array.Copy(BitConverter.GetBytes(151), 0, comp, 86, 4);
            Array.Copy(BitConverter.GetBytes(11515), 0, comp, 90, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 94, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 98, 4);
            Array.Copy(BitConverter.GetBytes(120), 0, comp, 102, 4);
            Array.Copy(BitConverter.GetBytes(1), 0, comp, 106, 4);
            Array.Copy(BitConverter.GetBytes(2), 0, comp, 110, 4);
            Array.Copy(BitConverter.GetBytes(14), 0, comp, 114, 4);
            Array.Copy(BitConverter.GetBytes(151), 0, comp, 118, 4);
            Array.Copy(BitConverter.GetBytes(11515), 0, comp, 122, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 126, 4);
            Array.Copy(BitConverter.GetBytes(123), 0, comp, 130, 4);
            Array.Copy(BitConverter.GetBytes(120), 0, comp, 134, 4);
            Array.Copy(name, 0, comp, 138, name.Length);

            for (int i = 0; i < comp.Length; ++i)
            {
                Assert.Equal(comp[i], testing[i]); 
            }
            
        }
    }
}