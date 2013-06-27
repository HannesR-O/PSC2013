using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace EpidemicSim_DetailedInputParser
{
    public class Flood
    {
        public static unsafe void ParsePointfile()
        {
            Bitmap map = (Bitmap)Bitmap.FromFile(Program.SRCPATH + "image.png");
            string[] departmentLines = File.ReadAllLines(Program.SRCPATH + "newlandcirclecoords.txt", Encoding.Default);
            Random rand = new Random();
            int x = 0;
            int y = 0;
            Console.WriteLine("Starting to parse Pointfile.txt");


            //Create 500 unique colors (for each boundary in the image)
            LinkedList<PixelData> ColorsToUse = new LinkedList<PixelData>();
            for (int i = 0; i < 500; ++i)
            {
                PixelData color = new PixelData();
                do
                {
                    color = new PixelData(Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256)));

                } while (ColorsToUse.Contains(color));
                ColorsToUse.AddLast(color);
            }

            //Floodfill
            for (int i = 0; i < departmentLines.Length; ++i)
            {
                BitmapData bbData = map.LockBits(new Rectangle(0, 0, map.Width, map.Height), ImageLockMode.ReadWrite, map.PixelFormat);
                PixelData* origin = (PixelData*)bbData.Scan0.ToPointer();

                x = int.Parse(departmentLines[i].Split('|')[0]);
                y = int.Parse(departmentLines[i].Split('|')[1]);

                PixelData currentcolor = *(origin + x + y * map.Width);

                PixelData desiredcolor = ColorsToUse.First.Value;
                ColorsToUse.RemoveFirst();

                FloodStack stack = new FloodStack();
                stack.ToCall = new Stack<Point>(map.Width * map.Height);
                stack.DesiredColor = desiredcolor;
                stack.CurrentColor = currentcolor;

                stack.ToCall.Push(new Point(x, y));
                while (stack.ToCall.Count != 0)
                {
                    Point p = stack.ToCall.Pop();
                    Floodfill(stack, p, origin + p.X + p.Y * map.Width, stack.CurrentColor, stack.DesiredColor);
                }

                map.UnlockBits(bbData);
            }

            map.Save(Program.DESTPATH + "Flood.png", ImageFormat.Png);

            Console.WriteLine("Finnished Floodfill");

            ///////////////////////////////////////////////////////////////////////////////////
            //Check Uniqueness of Department colors
            LinkedList<Color> usedcolors = new LinkedList<Color>();
            LinkedList<string> usednames = new LinkedList<string>();
            string lastname = "CHEWBACCA";

            for (int k = 0; k < departmentLines.Length; ++k)
            {
                string[] splittedline = departmentLines[k].Split('|');

                x = int.Parse(splittedline[0]);
                y = int.Parse(splittedline[1]);

                Color color = map.GetPixel(x, y);

                if (!lastname.Equals(splittedline[2]))
                {
                    for (int l = 0; l < usedcolors.Count; ++l)
                    {
                        Color c = usedcolors.ElementAt(l);
                        if (c.R == color.R && c.G == color.G && c.B == color.B && c.A == color.A)
                        {
                            throw new Exception("Two Areas in Image with the same Color!:\n" + splittedline[2] + "\t" + usednames.ElementAt(l));
                        }
                    }

                    usedcolors.AddLast(color);
                    usednames.AddLast(splittedline[2]);
                }
                lastname = splittedline[2];
            }

            Console.WriteLine("Checked, that every department has a unique color");
            //////////////////////////////////////////////////////////////////////////////////

            FileStream stream = File.OpenWrite(Program.SRCPATH + "Points.txt");
            LinkedList<DepInfo> AllDeps = new LinkedList<DepInfo>();

            for (int k = 0; k < departmentLines.Length; ++k)
            {
                DepInfo CurrentDep = new DepInfo(0);
                string[] splittedline = departmentLines[k].Split('|');
                x = int.Parse(splittedline[0]);
                y = int.Parse(splittedline[1]);
                Color usedcolor = map.GetPixel(x, y);
                CurrentDep.Name = splittedline[2];

                BitmapData bData = map.LockBits(new Rectangle(0, 0, map.Width, map.Height), ImageLockMode.ReadWrite, map.PixelFormat);
                PixelData* start = (PixelData*)bData.Scan0.ToPointer();
                PixelData* ptr = start;

                int x1 = x - 1000;
                if (x1 < 0)
                    x1 = 0;


                int x2 = x + 1000;
                if (x2 > map.Width)
                    x2 = map.Width;


                int y1 = y - 1000;
                if (y1 < 0)
                    y1 = 0;


                int y2 = y + 1000;
                if (y2 > map.Height)
                    y2 = map.Height;


                for (int i = x1; i < x2; ++i)
                {
                    for (int j = y1; j < y2; j++)
                    {
                        ptr = start + i + (j * map.Width);
                        if (ptr->Red == usedcolor.R && ptr->Green == usedcolor.G && ptr->Blue == usedcolor.B && ptr->Alpha == usedcolor.A)
                        {
                            CurrentDep.Points.AddLast(j * map.Width + i);
                        }
                    }
                }

                AllDeps.AddLast(CurrentDep);
                Console.WriteLine("Finished collecting Points For " + CurrentDep.Name);

                map.UnlockBits(bData);

            }

            Console.WriteLine("Collected all Points");

            bool foundDoppelganger = false;

            int startcount = AllDeps.Count;
            for (int i = 0; i < startcount; ++i)
            {
                foundDoppelganger = false;
                DepInfo current = AllDeps.First.Value;
                AllDeps.RemoveFirst();

                for (int j = 0; j < AllDeps.Count; ++j)
                {
                    if (current.Name.Equals(AllDeps.ElementAt(j).Name))
                    {
                        foundDoppelganger = true;

                        foreach (int point in current.Points)
                        {
                            AllDeps.ElementAt(j).Points.AddLast(point);
                        }
                        break;
                    }
                }
                if (!foundDoppelganger)
                    AllDeps.AddLast(current);
            }

            Console.WriteLine("Merged Points belonging to one Department");


            DepInfo[] AllPointsArr = AllDeps.ToArray();

            for (int i = 0; i < AllPointsArr.Length; ++i)
            {
                AllPointsArr[i].PointsArr = AllPointsArr[i].Points.ToArray();
            }

            Console.WriteLine("Transformed Lists into Arrays");

            StringBuilder towrite = new StringBuilder();
            towrite.Append("");


            for (int i = 0; i < AllPointsArr.Length; ++i)
            {

                towrite.Append(AllPointsArr[i].Name + ";" + AllPointsArr[i].PointsArr.Length);
                for (int j = 0; j < AllPointsArr[i].PointsArr.Length; ++j)
                {
                    towrite.Append(";" + AllPointsArr[i].PointsArr[j] % 2814 + ":" + AllPointsArr[i].PointsArr[j] / 2814 + ":" + AllPointsArr[i].PointsArr[j]);
                }

                towrite.Append("\r\n");
                Console.WriteLine("Finnished " + AllPointsArr[i].Name);
            }
            stream.Write(Encoding.Default.GetBytes(towrite.ToString()), 0, Encoding.Default.GetBytes(towrite.ToString()).Length);
            stream.Close();

            Console.WriteLine("Finnished Everything");
            Console.ReadLine();
        }

        struct PixelData
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
            public bool Equals(PixelData d)
            {
                return d.Alpha == this.Alpha && d.Blue == this.Blue && d.Green == this.Green && d.Red == this.Red;
            }
        }

        struct DepInfo
        {
            public LinkedList<int> Points;
            public int[] PointsArr;
            public string Name;

            public DepInfo(int notneeded)
            {
                Points = new LinkedList<int>();
                PointsArr = null;
                Name = null;
            }
        }


        unsafe class FloodStack
        {
            public PixelData DesiredColor;
            public PixelData CurrentColor;
            public Stack<Point> ToCall;

        }


        private static unsafe void Floodfill(FloodStack stack, Point p, PixelData* floodptr, PixelData currentcolor, PixelData desiredcolor)
        {
            if ((floodptr + 1)->Equals(currentcolor))
            {
                stack.ToCall.Push(new Point(p.X + 1, p.Y));
            }
            if ((floodptr - 1)->Equals(currentcolor))
            {
                stack.ToCall.Push(new Point(p.X - 1, p.Y));
            }
            if ((floodptr + 2814)->Equals(currentcolor))
            {
                stack.ToCall.Push(new Point(p.X, p.Y + 1));
            }
            if ((floodptr - 2814)->Equals(currentcolor))
            {
                stack.ToCall.Push(new Point(p.X, p.Y - 1));
            }
            //new
            if ((floodptr + 2815)->Equals(currentcolor))
            {
                stack.ToCall.Push(new Point(p.X + 1, p.Y + 1));
            }
            if ((floodptr - 2813)->Equals(currentcolor))
            {
                stack.ToCall.Push(new Point(p.X + 1, p.Y - 1));
            }
            if ((floodptr + 2813)->Equals(currentcolor))
            {
                stack.ToCall.Push(new Point(p.X - 1, p.Y + 1));
            }
            if ((floodptr - 2815)->Equals(currentcolor))
            {
                stack.ToCall.Push(new Point(p.X - 1, p.Y - 1));
            }

            //

            floodptr->Alpha = desiredcolor.Alpha;
            floodptr->Blue = desiredcolor.Blue;
            floodptr->Green = desiredcolor.Green;
            floodptr->Red = desiredcolor.Red;
        }



        public static void TestPointResults()
        {
            Random rand = new Random();
            //Bitmap map = (Bitmap)Bitmap.FromFile(Program.SRCPATH + "emptymap.png");
            Bitmap map = new Bitmap(2814, 3841);

            string[] CoordLines = File.ReadAllLines(Program.SRCPATH + "Points.txt");

            for (int i = 0; i < CoordLines.Length; ++i)
            {
                string[] splittedLine = CoordLines[i].Split(';');

                Color color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                for (int j = 2; j < splittedLine.Length; ++j)
                {
                    string[] coord = splittedLine[j].Split(':');
                    map.SetPixel(int.Parse(coord[0]), int.Parse(coord[1]), color);
                }
            }

            map.Save(Program.DESTPATH + "notemptymap.png", ImageFormat.Png);

            Console.WriteLine("Finished");
        }
    }
}
