using PSC2013.ES.Library.IO;

namespace PSC2013.ES.Library.IO.Writers
{
    public interface IBinaryWriter
    {
        /// <summary>
        /// Writes a given IBinaryObject to the given path
        /// </summary>
        /// <param name="obj">The IBinaryObject to write</param>
        /// <param name="filename">The file to write into</param>
        /// <param name="overwrite">Flag to decide whether an existing file should be overwritten</param>        
        void WriteToFile(IBinaryObject obj, string filePath, bool overwrite);
    }
}