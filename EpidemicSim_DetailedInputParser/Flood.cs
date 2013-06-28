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
            StringBuilder builder = new StringBuilder();
            List<DepInfo> Departments = new List<DepInfo>(402);
            bool[] AlreadyChecked = new bool[map.Width * map.Height];
            Random rand = new Random();
            int x = 0;
            int y = 0;
            Console.WriteLine("Starting to parse Departmentpoints");

            //Determin Colors that are used in the Image
            List<PixelData> UsedColors = new List<PixelData>(500);
            for (int i = 0; i < departmentLines.Length; ++i)
            {
                BitmapData bbData = map.LockBits(new Rectangle(0, 0, map.Width, map.Height), ImageLockMode.ReadWrite, map.PixelFormat);
                PixelData* origin = (PixelData*)bbData.Scan0.ToPointer();

                x = int.Parse(departmentLines[i].Split('|')[0]);
                y = int.Parse(departmentLines[i].Split('|')[1]);

                UsedColors.Add(*(origin + x + y * map.Width));
                map.UnlockBits(bbData);
            }

            Console.WriteLine("Creating unique Colors to fill departments");
            //Create 500 colors that are not already used and differ
            LinkedList<PixelData> ColorsToUse = new LinkedList<PixelData>();
            for (int i = 0; i < 500; ++i)
            {
                PixelData color = new PixelData();
                do
                {
                    color = new PixelData(Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256)));

                } while (ColorsToUse.Contains(color) || UsedColors.Contains(color));
                ColorsToUse.AddLast(color);
            }

            //Start Floodfill
            Console.WriteLine("Starting actual Parsing");
            for (int i = 0; i < departmentLines.Length; ++i)
            {
                DepInfo currentDep = null;
                bool doppelganger = false;
                
                for (int j = 0; j < Departments.Count; ++j)
                {
                    if(Departments[j] != null && Departments[j].Name.Equals(departmentLines[i].Split('|')[2]))
                    {
                        doppelganger = true;
                        currentDep = Departments[j];
                    }
                }
                if (!doppelganger)
                {
                    currentDep = new DepInfo(departmentLines[i].Split('|')[2]);
                }

                BitmapData bbData = map.LockBits(new Rectangle(0, 0, map.Width, map.Height), ImageLockMode.ReadWrite, map.PixelFormat);
                PixelData* origin = (PixelData*)bbData.Scan0.ToPointer();
                PixelData* floodptr = null;

                x = int.Parse(departmentLines[i].Split('|')[0]);
                y = int.Parse(departmentLines[i].Split('|')[1]);

                PixelData currentcolor = *(origin + x + y * map.Width);
                PixelData desiredcolor = ColorsToUse.First.Value;
                ColorsToUse.RemoveFirst();

                Stack<int> FloodStack = new Stack<int>(map.Width * map.Height);
                FloodStack.Push(x + (y * map.Width));
                currentDep.Points.Add(x + (y * map.Width));
                AlreadyChecked[(x + (y * map.Width))] = true;

                while (FloodStack.Count != 0)
                {
                    int coord = FloodStack.Pop();
                    floodptr = origin + coord;

                    if (!AlreadyChecked[coord + 1] && (floodptr + 1)->Equals(currentcolor))
                    {
                        FloodStack.Push(coord + 1);
                        currentDep.Points.Add(coord + 1);
                        AlreadyChecked[coord + 1] = true;
                    }
                    if (!AlreadyChecked[coord - 1] && (floodptr - 1)->Equals(currentcolor))
                    {
                        FloodStack.Push(coord - 1);
                        currentDep.Points.Add(coord - 1);
                        AlreadyChecked[coord - 1] = true;
                    }
                    if (!AlreadyChecked[coord + 2814] && (floodptr + 2814)->Equals(currentcolor))
                    {
                        FloodStack.Push(coord + 2814);
                        currentDep.Points.Add(coord + 2814);
                        AlreadyChecked[coord + 2814] = true;
                    }
                    if (!AlreadyChecked[coord - 2814] && (floodptr - 2814)->Equals(currentcolor))
                    {
                        FloodStack.Push(coord - 2814);
                        currentDep.Points.Add(coord - 2814);
                        AlreadyChecked[coord - 2814] = true;
                    }
                    if (!AlreadyChecked[coord + 2815] && (floodptr + 2815)->Equals(currentcolor))
                    {
                        FloodStack.Push(coord + 2815);
                        currentDep.Points.Add(coord + 2815);
                        AlreadyChecked[coord + 2815] = true;
                    }
                    if (!AlreadyChecked[coord - 2813] && (floodptr - 2813)->Equals(currentcolor))
                    {
                        FloodStack.Push(coord - 2813);
                        currentDep.Points.Add(coord - 2813);
                        AlreadyChecked[coord - 2813] = true;
                    }
                    if (!AlreadyChecked[coord + 2813] && (floodptr + 2813)->Equals(currentcolor))
                    {
                        FloodStack.Push(coord + 2813);
                        currentDep.Points.Add(coord + 2813);
                        AlreadyChecked[coord + 2813] = true;
                    }
                    if (!AlreadyChecked[coord - 2815] && (floodptr - 2815)->Equals(currentcolor))
                    {
                        FloodStack.Push(coord - 2815);
                        currentDep.Points.Add(coord - 2815);
                        AlreadyChecked[coord - 2815] = true;
                    }

                    floodptr->Alpha = desiredcolor.Alpha;
                    floodptr->Blue = desiredcolor.Blue;
                    floodptr->Green = desiredcolor.Green;
                    floodptr->Red = desiredcolor.Red;
                }
                map.UnlockBits(bbData);
                if(!doppelganger)
                    Departments.Add(currentDep);
                Console.WriteLine("Collected Points for:\t" + currentDep.Name);
            }

            
            FileStream stream = File.OpenWrite(Program.SRCPATH + "Points.txt");
            for (int l = 0; l < Departments.Count; ++l)
            {
                    builder.Append(Departments[l].Name + ";" + Departments[l].Points.Count);
                    foreach (int point in Departments[l].Points)
                    {
                        builder.Append(";" + point % map.Width + ":" + point / map.Width + ":" + point);
                    }
                    builder.Append("\r\n");
                    stream.Write(Encoding.Default.GetBytes(builder.ToString()), 0, Encoding.Default.GetByteCount(builder.ToString()));
                    builder.Clear();
            }
            stream.Close();
            Console.WriteLine("Finnished Collecting Points");
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
            public bool Equals(PixelData p)
            {
                return p.Alpha == this.Alpha && p.Blue == this.Blue && p.Green == this.Green && p.Red == this.Red;
            }
        }

        class DepInfo
        {
            public List<int> Points;
            public string Name;
            public DepInfo(string name)
            {
                Name = name;
                Points = new List<int>(100000);
            }
        }

        public static unsafe void TestPointResults()
        {
            Random rand = new Random();
            Bitmap map = new Bitmap(2814, 3841);
            string[] CoordLines = File.ReadAllLines(Program.SRCPATH + "Points.txt");
            BitmapData bbData = map.LockBits(new Rectangle(0, 0, map.Width, map.Height), ImageLockMode.ReadWrite, map.PixelFormat);
            PixelData* origin = (PixelData*)bbData.Scan0.ToPointer();

            Console.WriteLine("Testing Pointresults");
            for (int i = 0; i < CoordLines.Length; ++i)
            {
                string[] splittedLine = CoordLines[i].Split(';');
                PixelData color = new PixelData(Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256)));

                for (int j = 2; j < splittedLine.Length; ++j)
                {
                    string[] coords = splittedLine[j].Split(':');
                    int coordinate = int.Parse(coords[0]) + (int.Parse(coords[1]) * map.Width);
                    PixelData* pixelptr = origin + coordinate;
                    (*pixelptr) = color;
                }
                Console.WriteLine("Drew:\t" + splittedLine[0]);
            }

            map.Save(Program.DESTPATH + "DepartmentsWithUniqueColor.png", ImageFormat.Png);
            Console.WriteLine("Created TestresultImage");
        }
    }
}
