using PSC2013.ES.Library.IO.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PSC2013.ES.Library.IO.Writers
{
    public class AsyncBinaryWriter : IDocumentWriter
    {
        async void IDocumentWriter.WriteDocument(IDocument document, string fileName, bool overwrite)
        {
            var bytes = document.GetBytes();

            if(File.Exists(fileName) && !overwrite)
                return;

            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                await fs.WriteAsync(bytes, 0, bytes.Length);
            }
        }

        Document.IDocument IDocumentWriter.ReadFile(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
