using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using PSC2013.ES.Library.AreaData;
using PSC2013.ES.Library.IO.OutputTargets;

namespace PSC2013.ES.Library.IO.Readers
{
    public class DepartmentMapReader : OutputTargetWriter
    {
        /// <summary>
        /// The path to the file used by this reader.
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// Called when the ReadFile-method analyzed a new line
        /// or is finished.
        /// </summary>
        public event EventHandler<ContinuationEventArgs> IterationPassed;

        /// <summary>
        /// Instanciates a new reader with the
        /// path of the file, used for following
        /// methods/operations.
        /// </summary>
        /// <param name="path">The (valid) filepath.</param>
        public DepartmentMapReader(string path) : base("DMR")
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
            WriteMessage("Reading file...");

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
                    IterationPassed.Raise(this, new ContinuationEventArgs() { Continuing = true });
                }
            }
            stream.Close();
            archive.Dispose();
            IterationPassed.Raise(this, new ContinuationEventArgs() { Finished = true });

            return depInfList.ToArray();
        }

        /// <summary>
        /// Reads the map-image of the .dep-file.
        /// </summary>
        /// <returns></returns>
        public Image ReadImage()
        {
            WriteMessage("Reading image...");
            ZipArchive archive = ZipFile.OpenRead(Path);
            Image img;
            using (var stream = archive.GetEntry("image").Open())
            {
                img = Image.FromStream(stream);
            }
            archive.Dispose();
            return img;
        }
    }

    public class ContinuationEventArgs : EventArgs
    {
        public bool Continuing { get; set; }
        public bool Finished { get; set; }
    }
}