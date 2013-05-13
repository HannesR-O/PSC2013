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
        private int X = 2814; //TODO Read From SimInfoFile
        private int Y = 3841;
        private string _target;

        /// <summary>
        /// Initializes a new Mapcreator
        /// </summary>
        /// <param name="path">Where the Maps shall be saved</param>
        public MapCreator(string path)
        {
            _target = path;
        }

        /// <summary>
        /// Creates a map with the given circumstances
        /// </summary>
        /// <param name="snapshot">The Snapshot to be mapped</param>
        /// <param name="field">The Field to be visualised</param>
        /// <param name="palette">The Color Palette to be used</param>
        public void GetMap(TickSnapshot snapshot, EStatField field, Color[] palette, string namePrefix)
        {
            if ((int)field < 10)
                StandardMap(snapshot, field, palette, namePrefix);
            else
                ExtendendMap(snapshot, field, palette, namePrefix);
        }

        private void StandardMap(TickSnapshot snapshot, EStatField field, Color[] palette, string namePrefix)
        {
            Bitmap map = new Bitmap(X, Y);
            int max = snapshot.Cells.Max(x => x.Values[(int)field]);
            int min = snapshot.Cells.Min(x => x.Values[(int)field]);

            int[] steps = new int[20];
            steps[0] = max;
            steps[1] = (int)(max * 0.95f);
            steps[2] = (int)(max * 0.90f);
            steps[3] = (int)(max * 0.85f);
            steps[4] = (int)(max * 0.8f);
            steps[5] = (int)(max * 0.75f);
            steps[6] = (int)(max * 0.7f);
            steps[7] = (int)(max * 0.65f);
            steps[8] = (int)(max * 0.6f);
            steps[9] = (int)(max * 0.55f);
            steps[10] = (int)(max * 0.5f);
            steps[11] = (int)(max * 0.45f);
            steps[12] = (int)(max * 0.4f);
            steps[13] = (int)(max * 0.35f);
            steps[14] = (int)(max * 0.3f);
            steps[15] = (int)(max * 0.25f);
            steps[16] = (int)(max * 0.2f);
            steps[17] = (int)(max * 0.15f);
            steps[18] = (int)(max * 0.1f);
            steps[19] = (int)(max * 0.05f);

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
        }

        private void ExtendendMap(TickSnapshot snapshot, EStatField field, Color[] palette, string namePrefix)
        {
            Bitmap map = new Bitmap(X, Y);
            Dictionary<int, long> Values = new Dictionary<int,long>();

            int s, i, j;
            switch (field)
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

            foreach (CellSnapshot cell in snapshot.Cells)
            {
                long temp = 0;
                
                for (; i < j; ++i)
                {
                      temp += cell.Values[i];                  
                }
                Values.Add(cell.Position, temp);
                i = s;
            }

            long max = Values.Values.Max();
            long min = Values.Values.Min();

            long[] steps = new long[20];
            steps[0] = max;
            steps[1] = (long)(max * 0.95f);
            steps[2] = (long)(max * 0.90f);
            steps[3] = (long)(max * 0.85f);
            steps[4] = (long)(max * 0.8f);
            steps[5] = (long)(max * 0.75f);
            steps[6] = (long)(max * 0.7f);
            steps[7] = (long)(max * 0.65f);
            steps[8] = (long)(max * 0.6f);
            steps[9] = (long)(max * 0.55f);
            steps[10] = (long)(max * 0.5f);
            steps[11] = (long)(max * 0.45f);
            steps[12] = (long)(max * 0.4f);
            steps[13] = (long)(max * 0.35f);
            steps[14] = (long)(max * 0.3f);
            steps[15] = (long)(max * 0.25f);
            steps[16] = (long)(max * 0.2f);
            steps[17] = (long)(max * 0.15f);
            steps[18] = (long)(max * 0.1f);
            steps[19] = (long)(max * 0.05f);

            foreach (int pos in Values.Keys)
            {
                long count = Values[pos];
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

    }
}