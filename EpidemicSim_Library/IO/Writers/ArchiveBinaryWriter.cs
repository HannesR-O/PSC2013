using PSC2013.ES.Library.IO.Files;
using System.IO;
using System.IO.Compression;

namespace PSC2013.ES.Library.IO.Writers
{
    public class ArchiveBinaryWriter : IBinaryWriter
    {
        void IBinaryWriter.WriteIntoArchive(IBinaryFile file, string archivePath, string filename, bool overwrite)
        {
            var bytes = file.GetBytes();

            if (!File.Exists(archivePath))
                throw new FileNotFoundException("Archive not found!", archivePath);

            ZipArchiveMode mode = overwrite? ZipArchiveMode.Update : ZipArchiveMode.Create;

            ZipArchive archive = ZipFile.Open(archivePath, mode);

            archive.CreateEntry(filename);
            
            var stream = archive.GetEntry(filename).Open();

            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            archive.Dispose();
        }
    }
}