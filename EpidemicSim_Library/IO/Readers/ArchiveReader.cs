using System.IO;
using System.IO.Compression;

namespace PSC2013.ES.Library.IO.Readers
{
    public class ArchiveReader
    {
        /// <summary>
        /// Converts a Zipentry to a Stream
        /// </summary>
        /// <param name="entry">The ArchiveEntry</param>
        /// <returns>A byte[] with its contents</returns>
        public static byte[] ToByteArray(ZipArchiveEntry entry)
        {
            var stream = entry.Open(); // |t| Could be better...
            var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
