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
            _infosRuntime.MaleBabies = 0;
            _infosRuntime.MaleChildren = ushort.MaxValue;
            _infosRuntime.MaleAdults = ushort.MinValue;
            _infosRuntime.MaleSeniors = 1351;
            _infosRuntime.FemaleBabies = 12;
            _infosRuntime.FemaleChildren = 24;
            _infosRuntime.FemaleAdults = 135;
            _infosRuntime.FemaleSeniors = 12;

            _infosRuntime.Infecting = 46;
            _infosRuntime.Diseased = 35;
        }

        private void InitBytes()
        {
            _infosBytes = new byte[24];
            Array.Copy(BitConverter.GetBytes(0), 0, _infosBytes, 0, 2);
            Array.Copy(BitConverter.GetBytes(ushort.MaxValue), 0, _infosBytes, 2, 2);
            Array.Copy(BitConverter.GetBytes(ushort.MinValue), 0, _infosBytes, 4, 2);
            Array.Copy(BitConverter.GetBytes(1351), 0, _infosBytes, 6, 2);
            Array.Copy(BitConverter.GetBytes(12), 0, _infosBytes, 8, 2);
            Array.Copy(BitConverter.GetBytes(24), 0, _infosBytes, 10, 2);
            Array.Copy(BitConverter.GetBytes(135), 0, _infosBytes, 12, 2);
            Array.Copy(BitConverter.GetBytes(12), 0, _infosBytes, 14, 2);            
            Array.Copy(BitConverter.GetBytes(46), 0, _infosBytes, 16, 2);
            Array.Copy(BitConverter.GetBytes(35), 0, _infosBytes, 18, 2);
            Array.Copy(BitConverter.GetBytes(15654), 0, _infosBytes, 20, 2);

        }

        [Fact]
        public void CellSnapInitializeFromRuntimeTest()
        {
            InitCell();
            CellSnapshot cell = CellSnapshot.InitializeFromRuntime(_infosRuntime, 15654);
            Assert.Equal(cell.Values[0], 0);
            Assert.Equal(cell.Values[1], ushort.MaxValue);
            Assert.Equal(cell.Values[2], ushort.MinValue);
            Assert.Equal(cell.Values[3], 1351);
            Assert.Equal(cell.Values[4], 12);
            Assert.Equal(cell.Values[5], 24);
            Assert.Equal(cell.Values[6], 135);
            Assert.Equal(cell.Values[7], 12);
            Assert.Equal(cell.Position, 15654);
            Assert.Equal(cell.Values[8], 46);
            Assert.Equal(cell.Values[9], 35);
        }

        [Fact]
        public void CellSnapInitializeFromFileTest()
        {
            InitBytes();
            CellSnapshot cell = CellSnapshot.InitializeFromFile(_infosBytes);
            Assert.Equal(cell.Values[0], 0);
            Assert.Equal(cell.Values[1], ushort.MaxValue);
            Assert.Equal(cell.Values[2], ushort.MinValue);
            Assert.Equal(cell.Values[3], 1351);
            Assert.Equal(cell.Values[4], 12);
            Assert.Equal(cell.Values[5], 24);
            Assert.Equal(cell.Values[6], 135);
            Assert.Equal(cell.Values[7], 12);
            Assert.Equal(cell.Values[8], 46);
            Assert.Equal(cell.Values[9], 35);
            Assert.Equal(cell.Position, 15654);
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