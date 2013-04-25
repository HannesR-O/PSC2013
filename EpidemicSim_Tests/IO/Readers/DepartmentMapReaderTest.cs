using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.IO.Readers;
using Xunit;

namespace PSC2013.ES.Tests.IO.Readers
{
    public class DepartmentMapReaderTest
    {
        private const string DEFAULT_PATH = "../../../EpidemicSim_InputDataParsers/germany.dep";

        private DepartmentMapReader _reader;

        public void StartUp()
        {
            _reader = new DepartmentMapReader(DEFAULT_PATH);
        }

        [Fact]
        public void ReadFileTest()
        {
            StartUp();

            var result = _reader.ReadFile();

            Assert.True(result != null); // sorry but it is not so easy to test this usefully.
        }

        [Fact]
        public void ReadImageTest()
        {
            StartUp();

            //var result = _reader.ReadImage();

            // TODO | dj | test has to be implemented.
        }
    }
}
