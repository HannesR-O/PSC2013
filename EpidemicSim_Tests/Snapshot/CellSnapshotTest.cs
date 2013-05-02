using System;
using PSC2013.ES.Library.Snapshot;
using PSC2013.ES.Library.PopulationData;
using Xunit;

namespace PSC2013.ES.Tests.Snapshot
{
    public class CellSnapshotTest
    {
        private PopulationCell _infosRuntime;
        private byte[] _infosBytes;

        private void InitCell()
        {
            _infosRuntime = new PopulationCell();
            for (int i = 0; i < 12; ++i)
            {
                Human human = Human.Create(EGender.Female, 6, 15651);
                human.SetDiseased(true);
                Human human2 = Human.Create(EGender.Male, 2, 15651);
                human.SetInfected(true);
                _infosRuntime.AddHuman(human);
                _infosRuntime.AddHuman(human2);
                _infosRuntime.AddHuman(Human.Create(EGender.Male, 7, 18516));
                _infosRuntime.AddHuman(Human.Create(EGender.Male, 26, 3541));
                _infosRuntime.AddHuman(Human.Create(EGender.Male, 84, 8479));
                
                _infosRuntime.AddHuman(Human.Create(EGender.Female, 14, 18516));
                _infosRuntime.AddHuman(Human.Create(EGender.Female, 34, 3541));
                _infosRuntime.AddHuman(Human.Create(EGender.Female, 96, 8479));
            }
        }

        private void InitBytes()
        {
            _infosBytes = new byte[24];
            Array.Copy(BitConverter.GetBytes(12), 0, _infosBytes, 0, 2);
            Array.Copy(BitConverter.GetBytes(12), 0, _infosBytes, 2, 2);
            Array.Copy(BitConverter.GetBytes(12), 0, _infosBytes, 4, 2);
            Array.Copy(BitConverter.GetBytes(12), 0, _infosBytes, 6, 2);
            Array.Copy(BitConverter.GetBytes(12), 0, _infosBytes, 8, 2);
            Array.Copy(BitConverter.GetBytes(12), 0, _infosBytes, 10, 2);
            Array.Copy(BitConverter.GetBytes(12), 0, _infosBytes, 12, 2);
            Array.Copy(BitConverter.GetBytes(12), 0, _infosBytes, 14, 2);
            Array.Copy(BitConverter.GetBytes(15654), 0, _infosBytes, 16, 2);
            Array.Copy(BitConverter.GetBytes(12), 0, _infosBytes, 20, 2);
            Array.Copy(BitConverter.GetBytes(12), 0, _infosBytes, 22, 2);

        }

        [Fact]
        public void CellSnapInitializeFromRuntimeTest()
        {
            InitCell();
            CellSnapshot cell = CellSnapshot.InitializeFromRuntime(_infosRuntime, 15654);
            Assert.Equal(cell.CountMaleBaby, 12);
            Assert.Equal(cell.CountMaleChild, 12);
            Assert.Equal(cell.CountMaleAdult, 12);
            Assert.Equal(cell.CountMaleSenior, 12);
            Assert.Equal(cell.CountFemaleBaby, 12);
            Assert.Equal(cell.CountFemaleChild, 12);
            Assert.Equal(cell.CountFemaleAdult, 12);
            Assert.Equal(cell.CountFemaleSenior, 12);
            Assert.Equal(cell.Position, 15654);
            Assert.Equal(cell.Diseased, 12);
            Assert.Equal(cell.Infected, 12);
        }

        [Fact]
        public void CellSnapInitializeFromFileTest()
        {
            InitBytes();
            CellSnapshot cell = CellSnapshot.InitializeFromFile(_infosBytes);
            Assert.Equal(cell.CountMaleBaby, 12);
            Assert.Equal(cell.CountMaleChild, 12);
            Assert.Equal(cell.CountMaleAdult, 12);
            Assert.Equal(cell.CountMaleSenior, 12);
            Assert.Equal(cell.CountFemaleBaby, 12);
            Assert.Equal(cell.CountFemaleChild, 12);
            Assert.Equal(cell.CountFemaleAdult, 12);
            Assert.Equal(cell.CountFemaleSenior, 12);
            Assert.Equal(cell.Position, 15654);
            Assert.Equal(cell.Diseased, 12);
            Assert.Equal(cell.Infected, 12);
        }

        [Fact]
        public void CellSnapGetBytesTest()
        {
            InitCell();
            InitBytes();
            CellSnapshot cell = CellSnapshot.InitializeFromRuntime(_infosRuntime, 15654);

            byte[] test = cell.GetBytes();

            Assert.Equal(test.Length, CellSnapshot.LENGTH);
            for (int i = 0; i < test.Length; ++i)
            {
                Assert.Equal(test[i], _infosBytes[i]);
            }
        }

        
    }
}