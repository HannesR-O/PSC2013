using System.Drawing;

namespace PSC2013.ES.Library.Statistics.Pictures
{
    public static class ColorPalette
    {
        public const int RANGE = 50;

        private static Color[] _red;
        private static Color[] _blue;
        private static Color[] _redgreen;

        public static Color[] RED
        {
            get
            {
                if (_red == null)
                {
                    _red = new Color[RANGE];
                    for (int i = 0; i < RANGE; i++)
                        _red[i] = Color.FromArgb(255, (int)(255f / RANGE * i), 0);
                }
                return _red;
            }
        }

        public static Color[] BLUE
        {
            get
            {
                if (_blue == null)
                {
                    _blue = new Color[RANGE];
                    for (int i = 0; i < RANGE; i++)
                        _blue[i] = Color.FromArgb(0, (int)(255f / RANGE * i), 255);
                }
                return _blue;
            }
        }

        public static Color[] REDGREEN
        {
            get
            {
                if (_redgreen == null)
                {
                    _redgreen = new Color[RANGE];
                    int smallerPart = RANGE / 8;
                    int greaterPart = RANGE - smallerPart;

                    for (int i = 0; i < greaterPart; i++)
                        _redgreen[i] = Color.FromArgb(255, (int)(255f / greaterPart * i), 0);
                    for (int i = 0; i < smallerPart; i++)
                        _redgreen[i + greaterPart] = Color.FromArgb(255-(int)(255f / smallerPart * i), 255, 0);
                }
                return _redgreen;
            }
        }
    }
}
