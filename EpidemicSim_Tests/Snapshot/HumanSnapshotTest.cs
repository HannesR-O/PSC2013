using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.Snapshot;
using PSC2013.ES.Library.PopulationData;
using Xunit;

namespace PSC2013.ES.Tests.Snapshot
{
    public class HumanSnapshotTest
    {
        [Fact]
        public void HumanSnapshotConstructorTest()
        {
            HumanSnapshot human = new HumanSnapshot(EGender.Female, (byte)26, EProfession.Plumber, 1561, 6565, false);
            HumanSnapshot human2 = new HumanSnapshot(EGender.Male, (byte)2, EProfession.Unemployed, 8468, 2135, true);

            Assert.Equal(human.Gender, (byte)EGender.Female);
            Assert.Equal(human2.Gender, (byte)EGender.Male);
            Assert.Equal(human.Age, 26);
            Assert.Equal(human2.Age, 2);
            Assert.Equal(human.Profession, (byte)EProfession.Plumber);
            Assert.Equal(human2.Profession, (byte)EProfession.Unemployed);
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
            HumanSnapshot human = new HumanSnapshot(EGender.Female, (byte)26, EProfession.Housewife, 1561, 6565, false);

            byte[] comp = new byte[12];
            Array.Copy(BitConverter.GetBytes((int)Library.PopulationData.EGender.Female), 0, comp, 0, 1);
            Array.Copy(BitConverter.GetBytes(26), 0, comp, 1, 1);
            Array.Copy(BitConverter.GetBytes((byte)EProfession.Housewife), 0, comp, 2, 1);
            Array.Copy(BitConverter.GetBytes(1561), 0, comp, 3, 4);
            Array.Copy(BitConverter.GetBytes(6565), 0, comp, 7, 4);
            Array.Copy(BitConverter.GetBytes(false), 0, comp, 11, 1);

            byte[] humanb = human.getBytes();
            Assert.Equal(humanb.Length, HumanSnapshot.LENGTH);
            for (int i = 0; i < humanb.Length; ++i)
            {
                Assert.Equal(comp[i], humanb[i]);
            }
        }
    }
}
