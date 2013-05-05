using PSC2013.ES.Library.Snapshot;
using System.Drawing;


namespace PSC2013.ES.Library.Statistics.Pictures
{
    public class MapCreator
    {
        private int X = 2814;
        private int Y = 3841;
        private string _target;

        public MapCreator(string path)
        {
            _target = path;
        }

        public void GetMaleMap(TickSnapshot snapshot, Color[] palette)
        {
            Bitmap map = new Bitmap(X, Y);

            foreach (CellSnapshot cell in snapshot.Cells)
            {
                Point p = ExtensionMethods.DeFlatten(cell.Position, X);
                map.SetPixel(p.X, p.Y, palette[0]);
            }

            map.Save(_target + "/malemap.bmp", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}