using System.Drawing;
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
            Assert.Equal(401, result.Length);
        }

        [Fact]
        public void ReadImageTest()
        {
            StartUp();

            Image result = _reader.ReadImage();
            Image orig = Image.FromFile("../../../EpidemicSim_InputDataParsers/departments_coloured_big.png");

            Assert.Equal(orig.Height, result.Height);
            Assert.Equal(orig.Width, result.Width);
        }
    }
}