using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.IO.Document;

namespace PSC2013.ES.Library.IO.Writers
{
    public interface IFileWriter
    {
        //TODO: |f| fill in correct types
        /// <summary>
        /// Writes the ES_Document to the specified fileName
        /// </summary>
        /// <param name="fileName">The fileName to write the document in</param>
        /// <param name="file">The ES_Document to write</param>
        void WriteFile(string fileName, IDocument file);

        /// <summary>
        /// Reads an ES_Document from the specified fileName
        /// </summary>
        /// <param name="fileName">The fileName to read from</param>
        /// <returns>The ES_Document that was read</returns>
        object ReadFile(string fileName);
    }
}
