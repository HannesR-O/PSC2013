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
            if (y > 0 && y > 0)
            {
                X = x;
                Y = y;
            }
        }

        /// <summary>
        /// Creates a map with the given circumstances
        /// </summary>
        /// <param name="snapshot">The Snapshot to be mapped</param>
        /// <param name="field">The Field to be visualised</param>
        /// <param name="palette">The Color Palette to be used</param>
        public Dictionary<String, Color> GetMap(TickSnapshot snapshot, EStatField field, EColorPalette palette, string namePrefix)
        {
            Color[] pal = GetPalette(palette);

            if ((int)field < 10)
                return StandardMap(snapshot, field, pal, namePrefix);
            else
                return ExtendendMap(snapshot, field, pal, namePrefix);
        }

        private Dictionary<String, Color> StandardMap(TickSnapshot snapshot, EStatField field, Color[] palette, string namePrefix)
        {
            Bitmap map = new Bitmap(X, Y);
            int max = snapshot.Cells.Max(x => x.Values[(int)field]);

            int[] steps = GenerateSteps(max, CalculateSteps(max));

            foreach (CellSnapshot cell in snapshot.Cells)
            {
                int count = cell.Values[(int)field];
                Point p = cell.Position.DeFlatten(X);

                if (count == 0)
                    map.SetPixel(p.X, p.Y, Color.Black);
                else
                {
                    for (int i = 19; i >= 0; --i)
                    {
                        if (steps[i] >= count)
                        {
                            map.SetPixel(p.X, p.Y, palette[i]);
                            break;
                        }
                    }
                }

            }
            map.Save(_target + "/" + namePrefix + "_" + snapshot.Tick + "_" + (int)field + ".png", ImageFormat.Png);

            return GenerateLegend(steps, palette);
        }


        private Dictionary<String, Color> ExtendendMap(TickSnapshot snapshot, EStatField field, Color[] palette, string namePrefix)
        {
            Bitmap map = new Bitmap(X, Y);
            Dictionary<int, int> Values = new Dictionary<int,int>();

            int s, i, j; // Index for each cell to count
            switch (field) // Switch over which category we want to paint
            {
                case EStatField.AllMale:
                    s =i = 0;
                    j = 4;
                    break;
                case EStatField.AllFemale:
                    s = i = 4;
                    j = 8;
                    break;
                case EStatField.AllHumans:
                    s = i = 0;
                    j = 8;
                    break;
                default:
                    s = i = j = 0;
                    break;
            }

            foreach (CellSnapshot cell in snapshot.Cells) // Counting for each Cell
            {
                int temp = 0;
                
                for (; i < j; ++i)
                {
                      temp += cell.Values[i];                  
                }
                Values.Add(cell.Position, temp);
                i = s;
            }

            int max = Values.Values.Max();

            int[] steps = GenerateSteps(max, CalculateSteps(max));

            foreach (int pos in Values.Keys)
            {
                int count = Values[pos];
                Point p = pos.DeFlatten(X);

                if (count == 0)
                    map.SetPixel(p.X, p.Y, Color.Black);
                else
                {
                    for (int index = 19; index >= 0; --index)
                    {
                        if (steps[index] >= count)
                        {
                            map.SetPixel(p.X, p.Y, palette[index]);
                            break;
                        }
                    }
                }
            }
            map.Save(_target + "/" + namePrefix + "_" + snapshot.Tick + "_" + (int)field + ".png", ImageFormat.Png);

            return GenerateLegend(steps, palette);
        }

        private static float CalculateSteps(int maximum)
        {
            if (maximum >= 20)
                return 0.05f;
            else
                return 1f / maximum; 
        }

        /// <summary>
        /// Creates an Map, showing where People died in this Tick.
        /// </summary>
        /// <param name="snapshot"></param>
        /// <param name="palette"></param>
        public void GetDeathMap(TickSnapshot snapshot, Color[] palette)
        {
            Bitmap map = new Bitmap(X, Y);

            foreach (CellSnapshot cell in snapshot.Cells)
            {
                Point p = cell.Position.DeFlatten(X);
                map.SetPixel(p.X, p.Y, Color.Black);
            }
            foreach (HumanSnapshot snap in snapshot.Deaths)
            {
                Point p = ExtensionMethods.DeFlatten(snap.DeathCell, X);
                map.SetPixel(p.X, p.Y, palette[0]);
            }

            map.Save(_target + "/deathmap" + snapshot.Tick + ".png", System.Drawing.Imaging.ImageFormat.Png);
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

            legend.Add(steps[0] + " - " + steps[1], palette[0]); // This one has always to be there

            for (int i = 1; i < steps.Length - 2; ++i)
            {
                string range = steps[i] + " - " + steps[i + 1];
                if (!legend.ContainsKey(range))
                    legend.Add(range, palette[i]);
            }

            legend.Add(steps[steps.Length - 1] + " - 1", palette[palette.Length - 1]); // Always the last one

            return legend;
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