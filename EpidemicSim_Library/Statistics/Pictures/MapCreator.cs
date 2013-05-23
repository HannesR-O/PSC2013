using System.Drawing.Imaging;
using PSC2013.ES.Library.Snapshot;
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

        private int X = 2814; // Now default
        private int Y = 3841; // Here as well...

        private string _target;

        /// <summary>
        /// Initializes a new Mapcreator
        /// </summary>
        /// <param name="path">Where the Maps shall be saved</param>
        /// <param name="x">Map Size X</param>
        /// <param name="y">Map Size Y</param>
        public MapCreator(string path, int x, int y)
        {
            _target = path;
            if (x > 0 && y > 0)
            {
                X = x;
                Y = y;
            }
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
        public Dictionary<String, Color> GetMap(TickSnapshot snapshot, EStatField field, EColorPalette palette, string namePrefix)
        {
            Color[] pal = GetPalette(palette);

            Bitmap map = new Bitmap(X, Y);
                    
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

                if (count == 0)
                    map.SetPixel(p.X, p.Y, Color.Black);
                else
                {
                    for (int i = 19; i >= 0; --i)
                    {
                        if (_steps[i] >= count)
                        {
                            map.SetPixel(p.X, p.Y, pal[i]);
                            break;
                        }
                    }
                }

            }
            map.Save(_target + "/" + namePrefix + "_" + snapshot.Tick + "_" + (int)field + ".png", ImageFormat.Png);

            return GenerateLegend(_steps, pal);            
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

            // inefficient, needs fields as well
            foreach (CellSnapshot cell in snapshot.Cells)
            {
                Point p = cell.Position.DeFlatten(X);
                map.SetPixel(p.X, p.Y, Color.Black);
            }
            foreach (HumanSnapshot snap in (HumanSnapshotWrapper.GetMatchingHumans(snapshot.Deaths, field)))
            {
                Point p = ExtensionMethods.DeFlatten(snap.DeathCell, X);
                map.SetPixel(p.X, p.Y, pal[0]);
            }

            map.Save(_target + "/" + namePrefix + "_" + snapshot.Tick + ".png", System.Drawing.Imaging.ImageFormat.Png);
        }

        /// <summary>
        /// Creates an Dictionary consisting of the Ranges and the used Colors.
        /// </summary>
        /// <param name="steps">The Steps</param>
        /// <param name="palette">The Color Palette</param>
        /// <returns>Dictionary of Range and Color</returns>
        private static Dictionary<string, Color> GenerateLegend(int[] steps, Color[] palette)
        {
            if (steps.Length != palette.Length)
                throw new ArgumentException("Both Arrays have to be same Length");

            if (!(steps.Length > 1 && palette.Length > 1))
                throw new ArgumentException("Steps or Palette need to have at least 2 Values each");
            
            Dictionary<string, Color> legend = new Dictionary<string, Color>();

            if (steps[0] > 0)
            {
                legend.Add(steps[0] + " - " + (steps[1] + 1), palette[0]); // This one has always to be there

                int i = 1;
                for (; i < steps.Length - 1; ++i)
                {
                    string range = steps[i] + " - " + (steps[i + 1] + 1);
                    if (!legend.ContainsKey(range) && !(steps[i] > 1) && !(steps[i + 1] > 0))
                        break;
                    legend.Add(range, palette[i]);
                }

                legend.Add(steps[i] + " - 1", palette[i]); // Always the last one
            }
            legend.Add("0", Color.Black);

            return legend;
        }

        /// <summary>
        /// Calculates a Range of Values from a given int up to 20 Steps
        /// </summary>
        /// <param name="maximum">The Maxrange</param>
        /// <returns>A List of max 20 equals steps</returns>
        private static float CalculateSteps(int maximum)
        {
            if (maximum >= 20)
                return 0.05f;
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
            int[] steps = new int[20];
            steps[0] = max;

            float temp = 1.0f;

            for (int i = 1; i < 20; ++i)
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
                default:
                    return ColorPalette.RED;
            }
        }
    }
}