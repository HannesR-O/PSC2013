using System.IO;
using System.IO.Compression;

namespace PSC2013.ES.Library.IO.Readers
{
    public class ArchiveReader
    {
        public static byte[] ToByteArray(ZipArchiveEntry entry)
        {
            var stream = entry.Open(); // |t| Could be better...
            var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
