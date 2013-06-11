using PSC2013.ES.Library.IO.Files;

namespace PSC2013.ES.Library.IO.Writers
{
    public interface IBinaryWriter
    {
        /// <summary>
        /// Writes a given IBinaryFile to the given path
        /// </summary>
        /// <param name="file">The IBinaryFile to write</param>
        /// <param name="archivePath">The archive to write the IBinaryFile into</param>
        /// <param name="filename">The File name to be added</param>
        /// <param name="overwrite">Flag to decide whether an existing file should be overwritten</param>        
        void WriteIntoArchive(IBinaryObject file, string archivePath, string filename, bool overwrite);
        /* TODO: |f| This SUCKS!! IBinaryWriter should not specify the targettype namely Archive..
         * But refactoring isn't that simple, since the archive needs an archive name AND a file name.
         * Otherwise there could only be one IBinaryObject per file which is also bad! */
    }
}