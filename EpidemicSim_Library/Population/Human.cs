using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Population
{
    public struct Human
    {
        private const byte MASK_GENDER      = 0x80;     // 128 = 1000 0000
        private const byte MASK_AGE         = 0x60;     // 96  = 0110 0000
        private const byte MASK_AGE_TICKS   = 0x1F;     // 31  = 0001 1111

        private const byte TICKCOUNT_BABY   = 0x00;     // 0000 0000
        private const byte TICKCOUNT_CHILD  = 0x00;     // 0000 0000
        private const byte TICKCOUNT_ADULT  = 0x00;     // 0000 0000
        private const byte TICKCOUNT_SENIOR = 0x00;     // 0000 0000

        /// <summary>
        /// xxxx xxxx  xxxx xxxx  xxxx xxxx  xxxx xxxx
        ///    4    8    12   16    20   24    28   32
        /// 1. Byte: Gender (1bit) Age (2Bit) YearsTillNextAge (5Bit)
        /// 2. Byte:
        /// 3. Byte:
        /// 4. Byte:
        /// </summary>
        private byte _general, _data1, _data2, _data3;                          //TODO: |f| Find proper names for _dataX according to use

        private Human(byte[] data)
        {
            if (data.Length < 4)
                throw new ArgumentException("Given byte[] must at least contain 4 values!", "data");

            _general = data[0];
            _data1 = data[1];
            _data2 = data[2];
            _data3 = data[3];
        }

        public static Human CreateHuman(Gender gender, Age age)
        {
            byte[] data = new byte[4];

            byte ticks = 0;
            switch (age)
            {
                case Age.Baby:
                    ticks = TICKCOUNT_BABY;
                    break;
                case Age.Child:
                    ticks = TICKCOUNT_CHILD;
                    break;
                case Age.Adult:
                    ticks = TICKCOUNT_ADULT;
                    break;
                case Age.Senior:
                    ticks = TICKCOUNT_SENIOR;
                    break;
                default:
                    throw new Exception("Invalid Age, could not create Human!");
            }

            data[0] = (byte)((byte)gender + (byte)age + ticks);                         //TODO: |f| Fill in proper values and TEST IT!
            data[1] = 0;
            data[2] = 0;
            data[3] = 0;

            return new Human(data);
        }

        public Gender GetGender()
        {
            return (Gender)(_general & MASK_GENDER);
        }

        private void SetAge(Age age)
        {
            _general = (byte)(_general & ~MASK_AGE + (byte)age);
        }

        public Age GetAge()
        {
            return (Age)(_general & MASK_AGE);
        }

        private void SetTickTillNextAge(int ticks)
        {
            if (ticks < 0 || ticks > 31)
                throw new ArgumentOutOfRangeException("Tickcount must be in between 0-31!", "ticks");

            _general = (byte)(_general & ~MASK_AGE_TICKS + ticks);
        }

        public int GetTicksTillNextAge()
        {
            return _general & MASK_AGE_TICKS;
        }

        public void DoAgeTick()
        {
            int afterChange = GetTicksTillNextAge() - 1;
            if (!(afterChange == 0))
                SetTickTillNextAge(afterChange);
            else
            {
                // Tickcount == 0 -> Human ages to next level
                Age newAge = Age.Senior;
                int newTicks = TICKCOUNT_SENIOR;
                switch (GetAge())
                {
                    case Age.Baby:
                        newAge = Age.Child;
                        newTicks = TICKCOUNT_CHILD;
                        break;
                    case Age.Child:
                        newAge = Age.Adult;
                        newTicks = TICKCOUNT_ADULT;
                        break;
                    case Age.Adult:
                        newAge = Age.Senior;
                        newTicks = TICKCOUNT_SENIOR;
                        break;
                    case Age.Senior:
                        //TODO: |f| Define dead Human and kill it here
                        break;
                    default:
                        throw new Exception("There was an error in the aging process!");
                }
                SetAge(newAge);
                SetTickTillNextAge(newTicks);
            }
        }
    }
}