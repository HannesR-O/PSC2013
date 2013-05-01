using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.Snapshot;
using Xunit;

namespace PSC2013.ES.Tests.Snapshot
{
    public class HumanSnapshotTest
    {
        [Fact]
        public void HumanSnapshotConstructorTest()
        {
            HumanSnapshot human = new HumanSnapshot(Library.PopulationData.EGender.Female, 26, 1561, 6565, false);
            HumanSnapshot human2 = new HumanSnapshot(Library.PopulationData.EGender.Male, 2, 8468, 2135, true);

            Assert.Equal(human.Gender, Library.PopulationData.EGender.Female);
            Assert.Equal(human2.Gender, Library.PopulationData.EGender.Male);
            Assert.Equal(human.Age, 26);
            Assert.Equal(human2.Age, 2);
            Assert.Equal(human.HomeCell, 1561);
            Assert.Equal(human2.HomeCell, 8468);
            Assert.Equal(human.DeathCell, 6565);
            Assert.Equal(human2.DeathCell, 2135);
            Assert.Equal(human.Cause, false);
            Assert.Equal(human2.Cause, true);
        }

        [Fact]
        public void HumanSnapshotGetBytesTest()
        {
            HumanSnapshot human = new HumanSnapshot(Library.PopulationData.EGender.Female, 26, 1561, 6565, false);

            byte[] comp = new byte[17];
            Array.Copy(BitConverter.GetBytes((int)Library.PopulationData.EGender.Female), 0, comp, 0, 4);
            Array.Copy(BitConverter.GetBytes(26), 0, comp, 4, 4);
            Array.Copy(BitConverter.GetBytes(1561), 0, comp, 8, 4);
            Array.Copy(BitConverter.GetBytes(6565), 0, comp, 12, 4);
            Array.Copy(BitConverter.GetBytes(false), 0, comp, 16, 1);

            byte[] humanb = human.getBytes();
            for (int i = 0; i < humanb.Length; ++i)
            {
                Assert.Equal(comp[i], humanb[i]);
            }
        }
    }
}
