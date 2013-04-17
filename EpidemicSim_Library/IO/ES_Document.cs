using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.IO
{
    public class ES_Document
    {
        private List<string> _lines;

        public DocumentType DocType { get; set; }

        public ES_Document(IEnumerable<string> lines)
        {
            _lines = new List<string>();
        }

        public void AddLine(string line)
        {
            _lines.Add(line);
        }

        public void AddLines(IEnumerable<string> lines)
        {
            _lines.AddRange(lines);
        }
    }
}
