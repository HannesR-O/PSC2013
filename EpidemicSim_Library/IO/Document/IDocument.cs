using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.IO.Document
{
    /// <summary>
    /// Interface for documents, that need to be written
    /// </summary>
    public interface IDocument
    {
        byte[] GetBytes();
    }
}
