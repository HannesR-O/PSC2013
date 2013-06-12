using PSC2013.ES.Library.IO.Files;
using System;
using System.IO;
using System.IO.Compression;

namespace PSC2013.ES.Library.IO.Writers
{
    public class ArchiveBinaryWriter : IBinaryWriter
    {
        void IBinaryWriter.WriteIntoArchive(IBinaryObject file, string archivePath, string fileName, bool overwrite)
        {
            if (archivePath.LastIndexOf('.') != archivePath.Length - 4)
                throw new ArgumentException("Archive file's extension's length must be 3 for now!", archivePath);

            if (File.Exists(archivePath))
            {
                if (!overwrite)
                    throw new ArgumentException("Archive already existing and overwrite flag not set!", archivePath);

                ZipFile.Open(archivePath, ZipArchiveMode.Update).ClearArchive();
            }
            else
            {
                var di = new DirectoryInfo("" + RANDOM.Next());

                if (di.Exists)
                    throw new Exception("This should not happen... Randomfoldername already existed..");        //TODO: |f| find a prettier solution

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
    }
}