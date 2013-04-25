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
    public static class DataWriter
    {
        private const string DEFAULT_STORAGE_PATH = @"../../germany";

        /// <summary>
        /// Stores the given data in the given file.
        /// If no path is set (path == null) the default
        /// path is used. This is NOT recommended.
        /// 
        /// This data can be read by the
        /// Library.IO.Readers.DepartmentMapReader...
        /// </summary>
        /// <param name="path">The filepath.</param>
        /// <param name="data">The data.</param>
        public static void StoreMatchedData(string path, List<RegionPopulationInfo> data)
        {
            if (data == null)
                throw new ArgumentNullException("data");

            if (path == null)
                path = DEFAULT_STORAGE_PATH;

            Directory.CreateDirectory(path);
            string filePath = Path.Combine(path, "map");

#if DEBUG
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int n = 0;
#endif
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (RegionPopulationInfo rpi in data)
                {
#if DEBUG
                    Console.WriteLine("#" + n++ + "Writing at " + rpi.Name);
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

            ZipFile.CreateFromDirectory(path, path + ".dep", CompressionLevel.Optimal, false, Encoding.UTF8);
            Directory.Delete(path, true);

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
        /// <param name="storagePath">Path where to store the file.</param>
        /// <param name="imagePath">Path to the existing image
        /// (it will NOT be modified/deleted).</param>
        public static void StoreMapImage(string storagePath, string imagePath)
        {
            if (imagePath == null)
                throw new ArgumentNullException("imagePath");

            if (storagePath == null)
                storagePath = DEFAULT_STORAGE_PATH;

            if (!storagePath.EndsWith(".dep"))
                storagePath += ".dep";

            if (!File.Exists(storagePath)) // if the file does not exist.
            {
                string tmpPath = storagePath.Replace(".dep", "");
                Directory.CreateDirectory(tmpPath);
                ZipFile.CreateFromDirectory(tmpPath, storagePath, CompressionLevel.Optimal, false);
                Directory.Delete(tmpPath, true);
            }

            ZipArchive archive = ZipFile.Open(storagePath, ZipArchiveMode.Update);
            archive.CreateEntryFromFile(imagePath, "image", CompressionLevel.Optimal);
            archive.Dispose();
        }
    }
}