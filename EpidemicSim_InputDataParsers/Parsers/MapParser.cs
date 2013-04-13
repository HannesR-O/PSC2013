using System.Drawing;
using System.IO;

namespace PSC2013.ES.InputDataParsers.Parsers
{
    class MapParser
    {
        public static int[,] parseMap(string file)
        {
            if (!File.Exists(file))
                throw new FileNotFoundException("File could not be found", file);

            //Console.WriteLine("Starting...");

            Bitmap image = new Bitmap(file);

            int width = image.Width;
            int height = image.Height;

            int[,] mapArray = new int[width, height];

            for (int i = 0; i < height; ++i)
            {
                //String line = "";
                for (int j = 0; j < width; ++j)
                {
                    Color tempColor = image.GetPixel(j, i);
                    if (tempColor.R == 255 && tempColor.G == 255 && tempColor.B == 255)
                    {
                        // Innen
                        mapArray[j, i] = 0;
                    }
                    else if (tempColor.R == 255 && tempColor.G == 255 && tempColor.B == 0)
                    {
                        // Ausserhalb
                        mapArray[j, i] = -1;
                    }
                    else if (tempColor.R == 00 && tempColor.G == 255 && tempColor.B == 0)
                    {
                        // Städte
                        mapArray[j, i] = 2;
                    }
                    else // Grenzen, Staedte etc                        
                        mapArray[j, i] = 0;
                }
            }

            //Console.WriteLine("Done parsing!");

            // Returns 2-Dimensional int Array, containing the Map. -1 is not in germany, 0 is land, 2 is a city //TODO T Brauchen wir die?
            return mapArray;
        }

        public static int[,] expandArray(int[,] inputArray, int factor)
        {
            int[,] a = inputArray;

            int width = a.GetLength(0);
            int height = a.GetLength(1);

            int[,] b = new int[width * factor, height * factor];

            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    for (int x = (factor * i); x < ((factor * i) + factor); ++x)
                    {
                        for (int y = (factor * j); y < ((factor * j) + factor); ++y)
                        {
                            b[x, y] = a[i, j];
                        }
                    }
                }
            }

            return b;
        }
    }
}
