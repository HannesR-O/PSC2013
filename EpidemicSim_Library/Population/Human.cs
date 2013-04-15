using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Population
{
    public class Human
    {
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
            return (Gender)(_data[0] & 128 >> 7);
        }
    }
}
