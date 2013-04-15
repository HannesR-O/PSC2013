using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Population
{
    public class Human
    {
        private static byte FLAG_AGE = 0x03;    // 0000 0011

        /// <summary>
        /// xxxx xxxx  xxxx xxxx  xxxx xxxx  xxxx xxxx
        ///    4    8    12   16    20   24    28   32
        /// 1. Byte: Gender (1bit) Age (2Bit) YearsTillNextAge (5Bit)
        /// 2. Byte:
        /// 3. Byte:
        /// 4. Byte:
        /// </summary>
        private byte[] _data;

        public Human()
        {
            _data = new byte[4];
            new Random().NextBytes(_data);
        }

        public Gender GetGender()
        {
            return (Gender)(_data[0] >> 7);
        }

        public Age GetAge()
        {
            return (Age)(_data[0] >> 5 & FLAG_AGE);
        }

        public int GetTicksTillNextAge()
        {
            return _data[0] & 31;
        }
    }
}
