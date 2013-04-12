using PSC2013.ES.InputDataParsers.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PSC2013.ES.InputDataParsers.Parsers
{
    internal class PopulationParser
    {
        private string[] _lines;
        private List<CityPopulationInfo> _cities;

        /// <summary>
        /// Parses a population file (*.csv) from "Statistesches Bundesamt"
        /// </summary>
        /// <param name="file">The file to parse</param>
        /// <returns>A list of all CityPopulationInfo contained in the file </returns>
        public List<CityPopulationInfo> ParseFile(string file)
        {
            if (!File.Exists(file))
                throw new FileNotFoundException("File could not be found", file);

            string allText = File.ReadAllText(file);

            _lines = allText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            FindCities();

            return _cities;
        }

        private void FindCities()
        {
            _cities = new List<CityPopulationInfo>();

            for (int i = 0; i < _lines.Length; i++)
            {
                string[] lineParts = _lines[i].Split(';');
                if (new Regex(@"^\d{5}$").IsMatch(lineParts[0]) && (lineParts.Length == 6))
                {
                    // Found city..
                    _cities.Add(ParseCity(i));
                    i += 17;
                }
            }
        }

        private CityPopulationInfo ParseCity(int index)
        {
            string[] firstLine = _lines[index].Split(';');
            CityPopulationInfo city = new CityPopulationInfo() { Name = firstLine[1] };

            city[0] = int.Parse(firstLine[4]);
            city[4] = int.Parse(firstLine[5]);

            for (int j = 1; j < 17; j++)
            {
                string[] line = _lines[index + j].Split(';');
                int male = int.Parse(line[4]), female = int.Parse(line[5]);
                if (j == 1)
                {
                    city[0] += male;
                    city[4] += female;
                }
                else if (j < 7)
                {
                    city[1] += male;
                    city[5] += female;
                }
                else if (j < 14)
                {
                    city[2] += male;
                    city[6] += female;
                }
                else
                {
                    city[3] += male;
                    city[7] += female;
                }
            }
            return city;
        }
    }
}