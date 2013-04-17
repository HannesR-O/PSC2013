using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.IO
{
    public interface IDocumentWriter
    {
        /// <summary>
        /// Writes the ES_Document to the specified fileName
        /// </summary>
        /// <param name="fileName">The fileName to write the document in</param>
        /// <param name="document">The ES_Document to write</param>
        void WriteDocument(string fileName, ES_Document document);

        /// <summary>
        /// Reads an ES_Document from the specified fileName
        /// </summary>
        /// <param name="fileName">The fileName to read from</param>
        /// <returns>The ES_Document that was read</returns>
        ES_Document ReadDocument(string fileName);
    }
}
