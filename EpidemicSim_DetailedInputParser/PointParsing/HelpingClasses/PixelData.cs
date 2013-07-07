using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemicSim_DetailedInputParser
{
    public struct PixelData
    {
        public byte Blue;
        public byte Green;
        public byte Red;
        public byte Alpha;

        public PixelData(Color color)
        {
            Blue = color.B;
            Green = color.G;
            Red = color.R;
            Alpha = color.A;
        }
        public bool Equals(PixelData p)
        {
            return p.Alpha == this.Alpha && p.Blue == this.Blue && p.Green == this.Green && p.Red == this.Red;
        }
    }
}
