using System;
using System.IO;
using System.IO.Compression;

namespace PSC2013.ES.Library.IO.Writers
{
    public class ArchiveBinaryWriter : IBinaryWriter
    {
        public void WriteIntoArchive(IBinaryObject file, string archivePath, string fileName, bool overwrite)
        {
            if (archivePath.LastIndexOf('.') != archivePath.Length - 4)
                throw new ArgumentException("Archive file's extension's length must be 3 for now!", archivePath);

            if (File.Exists(archivePath))
            {
                if (overwrite)
                {
                    var tmpArch = ZipFile.Open(archivePath, ZipArchiveMode.Update);
                    tmpArch.ClearArchive();
                    tmpArch.Dispose();
                }
            }
            else
            {
                DirectoryInfo di;

                do
                {
                    //To secure no directory gets overriden
                    di = new DirectoryInfo("" + RANDOM.Next());
                } while (di.Exists);

                di.Create();
                ZipFile.CreateFromDirectory(di.FullName, archivePath, CompressionLevel.Optimal, false);
                di.Delete();
            }
                
            var bytes = file.GetBytes();

            var archive = ZipFile.Open(archivePath, ZipArchiveMode.Update);

            archive.CreateEntry(fileName);

            using (Stream stream = archive.GetEntry(fileName).Open())
            {
                stream.Write(bytes, 0, bytes.Length);
            }
            archive.Dispose();
        }

        public void WriteToFile(IBinaryObject obj, string filePath, bool overwrite)
        {
            //TODO: decide which filename (in the archive) to use
            WriteIntoArchive(obj, filePath, Path.GetFileNameWithoutExtension(filePath), overwrite);
        }
    }
}