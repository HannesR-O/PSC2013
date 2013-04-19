using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.IO.Document;

namespace PSC2013.ES.Library.IO.Writers
{
    public interface IDocumentWriter
    {
        /// <summary>
        /// Writes the IDocument to the specified fileName
        /// </summary>
        /// <param name="document">The IDocument to write</param>
        /// <param name="fileName">The fileName to write the document in</param>
        /// <param name="overwrite">Flag to decide whether an existing file should be overwritten</param>        
        void WriteDocument(IDocument document, string fileName, bool overwrite);

        /// <summary>
        /// Reads an ES_Document from the specified fileName
        /// </summary>
        /// <param name="fileName">The fileName to read from</param>
        /// <returns>The IDocument that was read</returns>
        IDocument ReadFile(string fileName);
    }
}
