using PSC2013.ES.Library.IO.Files;

namespace PSC2013.ES.Library.IO.Writers
{
    public interface IBinaryWriter
    {
        /// <summary>
        /// Writes a given IBinaryFile to the given path
        /// </summary>
        /// <param name="file">The IBinaryFile to write</param>
        /// <param name="filePath">The path to write the IBinaryFile to</param>
        /// <param name="overwrite">Flag to decide whether an existing file should be overwritten</param>        
        void WriteFile(IBinaryFile file, string filePath, bool overwrite);
    }
}