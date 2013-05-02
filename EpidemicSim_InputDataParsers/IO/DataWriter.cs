using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Text;
using PSC2013.ES.InputDataParsers.Data;

namespace PSC2013.ES.InputDataParsers.IO
{
    public class DataWriter
    {
        private const string DEFAULT_STORAGE_PATH = @"../../germany.dep";

        private readonly string _path;

        /// <summary>
        /// Initializes a new writer with the given
        /// destination file.
        /// </summary>
        /// <param name="path">The target-file.</param>
        public DataWriter (string path)
	    {
            _path = path;
            if (path == null)
                _path = DEFAULT_STORAGE_PATH;
	    }

        /// <summary>
        /// Stores the given data in the given file.
        /// If no path is set (path == null) the default
        /// path is used. This is NOT recommended.
        /// 
        /// This data can be read by the
        /// Library.IO.Readers.DepartmentMapReader...
        /// </summary>
        /// <param name="data">The data.</param>
        public void StoreMatchedData(List<RegionPopulationInfo> data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            CheckFile();
            var tpl = OpenStream("map");

#if DEBUG
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int n = 0;
#endif
            using (StreamWriter writer = new StreamWriter(tpl.Item1))
            {
                foreach (RegionPopulationInfo rpi in data)
                {
#if DEBUG
                    Console.WriteLine("#" + n++ + " : Writing at " + rpi.Name);
#endif
                    byte[] bytes = Encoding.UTF8.GetBytes(rpi.Name);    // Name
                    writer.BaseStream.Write(bytes, 0, bytes.Length);
                    for (int i = 0; i < 8; i++)                         // Population(s)
                        writer.Write("|" + rpi[i]);
                    foreach (Point p in rpi.AssociatedCoordinates)      // Coordinates
                        writer.Write("|" + p.X + ":" + p.Y);
                    writer.WriteLine();
                    writer.Flush();
                }
                writer.Flush();
            }

            tpl.Item1.Close();
            tpl.Item2.Dispose();

#if DEBUG
            sw.Stop();
            Console.WriteLine("Time elapsed: " + sw.Elapsed);
#endif
        }

        /// <summary>
        /// Stores the image in the given file.
        /// Choose for this the same as used for
        /// the corresponding RegionPopulationInfo(s).
        /// 
        /// This data can be read by the
        /// Library.IO.Readers.DepartmentMapReader...
        /// </summary>
        /// <param name="imagePath">Path to the existing image
        /// (it will NOT be modified/deleted).</param>
        public void StoreMapImage(string imagePath)
        {
            if (imagePath == null)
                throw new ArgumentNullException("imagePath");

            CheckFile();

            ZipArchive archive = ZipFile.Open(_path, ZipArchiveMode.Update);
            archive.CreateEntryFromFile(imagePath, "image", CompressionLevel.Optimal);
            archive.Dispose();
        }

        private void CheckFile()
        {
            if (!File.Exists(_path))
            {
                string tmp = _path.Replace(".dep", "");
                Directory.CreateDirectory(tmp);
                ZipFile.CreateFromDirectory(tmp, _path, CompressionLevel.Optimal, false);
                Directory.Delete(tmp, true);
            }
        }

        private Tuple<Stream, ZipArchive> OpenStream(string name)
        {
            ZipArchive archive = ZipFile.Open(_path, ZipArchiveMode.Update);
            archive.CreateEntry(name);
            return new Tuple<Stream, ZipArchive>(archive.GetEntry(name).Open(), archive);
        }
    }
}