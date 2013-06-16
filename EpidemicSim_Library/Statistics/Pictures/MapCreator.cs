using System.Drawing.Imaging;
using PSC2013.ES.Library.Snapshot;
using PSC2013.ES.Library;
using System.Drawing;
using System.Linq;
using System;
using System.Collections.Generic;

namespace PSC2013.ES.Library.Statistics.Pictures
{
    public class MapCreator
    {
        private int _max = 0;
        private int[] _steps;
        private Dictionary<string, Color> _caption;

        private int X = 2814; // Now default
        private int Y = 3841; // Here as well...

        public string Target { get; private set; }

        /// <summary>
        /// Initializes a new Mapcreator
        /// </summary>
        /// <param name="path">Where the Maps shall be saved</param>
        /// <param name="x">Map Size X</param>
        /// <param name="y">Map Size Y</param>
        public MapCreator(int x, int y)
        {
            if (x > 0 && y > 0)
            {
                X = x;
                Y = y;
            }
        }

        public void setTarget(string newtarget)
        {
            Target = newtarget;
        }

        public void InitializeMaxima(TickSnapshot firstSnapshot)
        {
            foreach (CellSnapshot c in firstSnapshot.Cells)
            {
                int max = 0;
                for (int i = 0; i < 8; ++i)
                {
                    max += c.Values[i];
                }
                if (max > _max)
                    _max = max;
            }
            _steps = GenerateSteps(_max, CalculateSteps(_max));
        }

        /// <summary>
        /// Creates a map with the given parameters
        /// </summary>
        /// <param name="snapshot">The Snapshot to be mapped</param>
        /// <param name="field">The Field to be visualised</param>
        /// <param name="palette">The Color Palette to be used</param>
        public unsafe void GetMap(TickSnapshot snapshot, EStatField field, EColorPalette palette, string namePrefix)
        {
            Color[] pal = GetPalette(palette);

            Bitmap map = new Bitmap(X, Y);
            BitmapData bData = map.LockBits(new Rectangle(0, 0, map.Width, map.Height), ImageLockMode.ReadWrite, map.PixelFormat);
            PixelData* start = (PixelData*)bData.Scan0.ToPointer();
            PixelData* pixelptr = null;
                    
            List<int> fields = new List<int>();
            foreach (EStatField f in Enum.GetValues(typeof(EStatField)))
            {
                if ((f & field) == f)
                    fields.Add((int)Math.Log((double)f, 2d));
            }
            
            foreach (CellSnapshot cell in snapshot.Cells)
            {
                int count = 0;
                                
                foreach (int i in fields)
                    count += cell.Values[i];

                Point p = cell.Position.DeFlatten(X);
                pixelptr = start + p.X + (p.Y * map.Width);

                if (count == 0)
                {
                    pixelptr->Alpha = 255;
                    pixelptr->Blue = 0;
                    pixelptr->Green = 0;
                    pixelptr->Red = 0;
                }
                else
                {
                    for (int i = ColorPalette.RANGE - 1; i >= 0; --i)
                    {
                        if (_steps[i] >= count)
                        {
                            pixelptr->Alpha = pal[i].A;
                            pixelptr->Blue = pal[i].B;
                            pixelptr->Green = pal[i].G;
                            pixelptr->Red = pal[i].R;
                            break;
                        }
                    }
                }

            }
            map.UnlockBits(bData);
            map.Save(Target + "/" + namePrefix + "_" + snapshot.Tick + "_S-" + field + ".png", ImageFormat.Png);
            GenerateCaption(_steps, pal);
        }

        /// <summary>
        /// Creates an Map, showing where People died in this Tick.
        /// </summary>
        /// <param name="snapshot"></param>
        /// <param name="palette"></param>
        public void GetDeathMap(TickSnapshot snapshot, EStatField field, EColorPalette palette, string namePrefix)
        {
            Color[] pal = GetPalette(palette);

            Bitmap map = new Bitmap(X, Y);

            foreach (CellSnapshot cell in snapshot.Cells)
            {
                Point p = cell.Position.DeFlatten(X);
                map.SetPixel(p.X, p.Y, Color.Black);
            }
            foreach (HumanSnapshot snap in (HumanSnapshotCreteriaMatcher.GetMatchingHumans(snapshot.Deaths, field)))
            {
                Point p = ExtensionMethods.DeFlatten(snap.DeathCell, X);
                map.SetPixel(p.X, p.Y, pal[0]);
            }

            map.Save(Target + "/" + namePrefix + "_" + snapshot.Tick + "_D-" + field + ".png", System.Drawing.Imaging.ImageFormat.Png);
            GenerateCaption(_steps, pal);
        }

        /// <summary>
        /// Returns the last used Dict of Color Ranges (String) and a Color
        /// </summary>
        /// <returns>The Last used Caption</returns>
        public Dictionary<string, Color> GetCaption()
        {
            return _caption;
        }

        /// <summary>
        /// Creates an Dictionary consisting of the Ranges and the used Colors.
        /// </summary>
        /// <param name="steps">The Steps</param>
        /// <param name="palette">The Color Palette</param>
        /// <returns>Dictionary of Range and Color</returns>
        private void GenerateCaption(int[] steps, Color[] palette)
        {
            if (steps.Length != palette.Length)
                throw new ArgumentException("Both Arrays have to be same Length");

            if (!(steps.Length > 1 && palette.Length > 1))
                throw new ArgumentException("Steps or Palette need to have at least 2 Values each");
            
            Dictionary<string, Color> caption = new Dictionary<string, Color>();

            if (steps[0] > 0)
            {
                caption.Add(steps[0] + " - " + (steps[1] + 1), palette[0]); // This one has always to be there

                int i = 1;
                for (; i < steps.Length - 1; ++i)
                {
                    string range = steps[i] + " - " + (steps[i + 1] + 1);
                    if (!caption.ContainsKey(range) && !(steps[i] > 1) && !(steps[i + 1] > 0))
                        break;
                    caption.Add(range, palette[i]);
                }

                caption.Add(steps[i] + " - 1", palette[i]); // Always the last one
            }
            caption.Add("0", Color.Black);

            _caption = caption;
        }
        
        /// <summary>
        /// Calculates a Range of Values from a given int up to ColorPalette.RANGE Steps
        /// </summary>
        /// <param name="maximum">The Maxrange</param>
        /// <returns>not the correct comment</returns>
        private static float CalculateSteps(int maximum)
        {
            if (maximum >= ColorPalette.RANGE)
                return 1f / ColorPalette.RANGE;
            else
                return 1f / maximum;
        }

        /// <summary>
        /// Generates an Array of Steps from an given Value down to somewhere near 0
        /// </summary>
        /// <param name="max">The Max Value</param>
        /// <returns></returns>
        private static int[] GenerateSteps(int max, float step)
        {
            int[] steps = new int[ColorPalette.RANGE];
            steps[0] = max;

            float temp = 1.0f;

            for (int i = 1; i < ColorPalette.RANGE; ++i)
            {
                temp -= step;
                int thisStep = (int)(max * temp);
                if (thisStep <= 0)
                    break;
                steps[i] = thisStep;
            }

            return steps;
        }

        private static Color[] GetPalette(EColorPalette palette)
        {
            switch (palette)
            {
                case EColorPalette.Red:
                    return ColorPalette.RED;
                case EColorPalette.Blue:
                    return ColorPalette.BLUE;
                case EColorPalette.RedGreen:
                    return ColorPalette.REDGREEN;
                default:
                    return ColorPalette.RED;
            }
        }
    }

    struct PixelData
    {
        public byte Blue;
        public byte Green;
        public byte Red;
        public byte Alpha;
    }
}