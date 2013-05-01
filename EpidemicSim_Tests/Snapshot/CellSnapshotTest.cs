using System;
using PSC2013.ES.Library.Snapshot;
using PSC2013.ES.Library.PopulationData;
using Xunit;

namespace PSC2013.ES.Tests.Snapshot
{
    public class CellSnapshotTest
    {
        private PopulationCell _infosRuntime;

        public void Start()
        {
            _infosRuntime = new PopulationCell();
            for (int i = 0; i < 12; ++i)
            {
                _infosRuntime.AddHuman(Human.Create(EGender.Male, 2, 15651));
                _infosRuntime.AddHuman(Human.Create(EGender.Male, 7, 18516));
                _infosRuntime.AddHuman(Human.Create(EGender.Male, 26, 3541));
                _infosRuntime.AddHuman(Human.Create(EGender.Male, 84, 8479));
                _infosRuntime.AddHuman(Human.Create(EGender.Female, 6, 15651));
                _infosRuntime.AddHuman(Human.Create(EGender.Female, 14, 18516));
                _infosRuntime.AddHuman(Human.Create(EGender.Female, 34, 3541));
                _infosRuntime.AddHuman(Human.Create(EGender.Female, 96, 8479));
            }
        }

        [Fact]
        public void CellSnapInitializeFromRuntimeTest()
        {
            Start();
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
        }

        [Fact]
        public void CellSnapInitializeFromFileTest()
        {
            byte[] bytes = new byte[36];
            Array.Copy(BitConverter.GetBytes(12), 0, bytes, 0, 4);
            Array.Copy(BitConverter.GetBytes(12), 0, bytes, 4, 4);
            Array.Copy(BitConverter.GetBytes(12), 0, bytes, 8, 4);
            Array.Copy(BitConverter.GetBytes(12), 0, bytes, 12, 4);
            Array.Copy(BitConverter.GetBytes(12), 0, bytes, 16, 4);
            Array.Copy(BitConverter.GetBytes(12), 0, bytes, 20, 4);
            Array.Copy(BitConverter.GetBytes(12), 0, bytes, 24, 4);
            Array.Copy(BitConverter.GetBytes(12), 0, bytes, 28, 4);
            Array.Copy(BitConverter.GetBytes(15654), 0, bytes, 32, 4);
            CellSnapshot cell = CellSnapshot.InitializeFromFile(bytes);
            Assert.Equal(cell.CountMaleBaby, 12);
            Assert.Equal(cell.CountMaleChild, 12);
            Assert.Equal(cell.CountMaleAdult, 12);
            Assert.Equal(cell.CountMaleSenior, 12);
            Assert.Equal(cell.CountFemaleBaby, 12);
            Assert.Equal(cell.CountFemaleChild, 12);
            Assert.Equal(cell.CountFemaleAdult, 12);
            Assert.Equal(cell.CountFemaleSenior, 12);
            Assert.Equal(cell.Position, 15654);
        }

        [Fact]
        public void CellSnapGetBytesTest()
        {
            Start();
            CellSnapshot cell = CellSnapshot.InitializeFromRuntime(_infosRuntime, 15654);

            byte[] bytes = cell.GetBytes();
            byte[] control = new byte[36];
            Array.Copy(BitConverter.GetBytes(12), 0, control, 0, 4);
            Array.Copy(BitConverter.GetBytes(12), 0, control, 4, 4);
            Array.Copy(BitConverter.GetBytes(12), 0, control, 8, 4);
            Array.Copy(BitConverter.GetBytes(12), 0, control, 12, 4);
            Array.Copy(BitConverter.GetBytes(12), 0, control, 16, 4);
            Array.Copy(BitConverter.GetBytes(12), 0, control, 20, 4);
            Array.Copy(BitConverter.GetBytes(12), 0, control, 24, 4);
            Array.Copy(BitConverter.GetBytes(12), 0, control, 28, 4);
            Array.Copy(BitConverter.GetBytes(15654), 0, control, 32, 4);

            Assert.Equal(bytes, control);
        }
    }
}