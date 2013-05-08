using PSC2013.ES.Library.Snapshot;
using System.Drawing;
using System.Linq;
using System;


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
        public void GetMap(TickSnapshot snapshot, EStatField field, Color[] palette)
        {
            Bitmap map = new Bitmap(X, Y);
            int max = snapshot.Cells.Max(x => x.Values[(int)field]);
            Console.WriteLine(max);
            int min = snapshot.Cells.Min(x => x.Values[(int)field]);
            Console.WriteLine(min);

            int[] steps = new int[10];
            steps[0] = max;
            steps[1] = (int)(max * 0.9f);
            steps[2] = (int)(max * 0.8f);
            steps[3] = (int)(max * 0.7f);
            steps[4] = (int)(max * 0.6f);
            steps[5] = (int)(max * 0.5f);
            steps[6] = (int)(max * 0.4f);
            steps[7] = (int)(max * 0.3f);
            steps[8] = (int)(max * 0.2f);
            steps[9] = (int)(max * 0.1f);

            foreach (CellSnapshot cell in snapshot.Cells)
            {
                int count = cell.Values[(int)field];
                Point p = ExtensionMethods.DeFlatten(cell.Position, X);

                if (count == 0)
                    map.SetPixel(p.X, p.Y, Color.Black);

                for (int i = 9; i >= 0; --i)
                {
                    map.SetPixel(p.X, p.Y, palette[i]);
                }

            }
            map.Save(_target + "/map" + snapshot.Tick + ".png", System.Drawing.Imaging.ImageFormat.Png);
        }

        public void GetDeathMap(TickSnapshot snapshot, Color[] palette)
        {
            Bitmap map = new Bitmap(X, Y);

            foreach (CellSnapshot cell in snapshot.Cells)
            {
                Point p = ExtensionMethods.DeFlatten(cell.Position, X);
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