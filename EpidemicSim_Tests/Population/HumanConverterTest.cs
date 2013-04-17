using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using PSC2013.ES.Library.Converter;

namespace PSC2013.ES.Tests.Population
{
    public class HumanConverterTest
    {
        [Fact]
        public void testGender()
        {
            ulong male = 0x0; 
            ulong male2 = 0x3A;
            ulong female = 0x1;            
            ulong female2 = 0x3B;

            Assert.False(HumanConverter.getGender(male));
            Assert.False(HumanConverter.getGender(male2));
            Assert.True(HumanConverter.getGender(female));
            Assert.True(HumanConverter.getGender(female2));
        }

        [Fact]
        public void testAge()
        {
            ulong one = 0xfe; // 127 Wer wird den bitte so alt?;
            ulong two = 0x2; // 0
            ulong three = 0x1;
            Assert.Equal<ulong>(HumanConverter.getAge(one), 127);            
            Assert.Equal<ulong>(HumanConverter.getAge(two), 1);
            Assert.Equal<ulong>(HumanConverter.getAge(three), 0);
        }

        [Fact]
        public void testDefaultResistance()
        {
            ulong one = 0xF00; // Resistance = 1111 = 15
            ulong two = 0x1B6; // Resistance = 1 = 1

            Assert.Equal<ulong>(HumanConverter.getDefaultResistance(one), 15);
            Assert.Equal<ulong>(HumanConverter.getDefaultResistance(two), 1);
        }

        [Fact]
        public void testInfluence()
        {
            ulong one = 0x1FFFF;    // 31 / +15
            ulong two = 0x1EFFF;    // 30 / -15
            ulong three = 0xFFF;    // 0/ - 0
            ulong four = 0x1FFF;      // 1 /+ 0

            Assert.Equal<ulong>(HumanConverter.getInfluence(one), 31);
            Assert.Equal<ulong>(HumanConverter.getInfluence(two), 30);
            Assert.Equal<ulong>(HumanConverter.getInfluence(three), 0);
            Assert.Equal<ulong>(HumanConverter.getInfluence(four), 1);
        }
    }
}
