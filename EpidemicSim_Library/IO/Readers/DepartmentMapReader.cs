using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using PSC2013.ES.Library.AreaData;

namespace PSC2013.ES.Library.IO.Readers
{
    public class DepartmentMapReader
    {
        /// <summary>
        /// The path to the file used by this reader.
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// Instanciates a new reader with the
        /// path of the file, used for following
        /// methods/operations.
        /// </summary>
        /// <param name="path">The (valid) filepath.</param>
        public DepartmentMapReader(string path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            Path = path;
        }

        /// <summary>
        /// Reads the previously given file and
        /// tries to interpret its content file
        /// as an array of DepartmenInfos.
        /// </summary>
        /// <returns>The DepartmentInfo-Array.</returns>
        public DepartmentInfo[] ReadFile()
        {
            var depInfList = new List<DepartmentInfo>();

            ZipArchive archive = ZipFile.OpenRead(Path);
            Stream stream = archive.GetEntry("map").Open();

            using (StreamReader sr = new StreamReader(stream))
            {
                while (!sr.EndOfStream)
                {
                    DepartmentInfo depInf = new DepartmentInfo();
                    string[] s = sr.ReadLine().Split('|');
                    depInf.Name = s[0];                                 // Name
                    for (int i = 1; i < 9; i++)                         // Population(s)
                        depInf.Population[i - 1] = int.Parse(s[i]);
                    depInf.Coordinates = new Point[s.Length - 9];
                    for (int i = 9; i < s.Length; i++)                  // Coordinates
                    {
                        string[] pArr = s[i].Split(':');
                        depInf.Coordinates[i - 9] = new Point(
                            int.Parse(pArr[0]), int.Parse(pArr[1]));
                    }

                    depInfList.Add(depInf);
                }
            }
            return depInfList.ToArray();
        }

        /// <summary>
        /// Reads the map-image of the .dep-file.
        /// </summary>
        /// <returns></returns>
        public Image ReadImage()
        {
            ZipArchive archive = ZipFile.OpenRead(Path);
            using (var stream = archive.GetEntry("image").Open())
            {
                return Image.FromStream(stream);
            }
        }
    }
}