using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.IO.Files;

namespace PSC2013.ES.Library.IO.Writers
{
    public interface IBinaryWriter
    {
        /// <summary>
        /// Writes the IDocument to the specified fileName
        /// </summary>
        /// <param name="file">The IDocument to write</param>
        /// <param name="fileName">The fileName to write the document in</param>
        /// <param name="overwrite">Flag to decide whether an existing file should be overwritten</param>        
        void WriteFile(IBinaryFile file, string fileName, bool overwrite);

        /// <summary>
        /// Reads an IDocument from a given fileName
        /// </summary>
        /// <typeparam name="T">The Document to read</typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        T ReadFile<T>(string fileName) where T : IBinaryFile;
    }
}
