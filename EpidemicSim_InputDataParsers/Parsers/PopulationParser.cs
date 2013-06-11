using PSC2013.ES.InputDataParsers.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public Tuple<List<RegionPopulationInfo>, List<string>> ParseCompleteSimulationInputData(string populationFile, string coordinateFile, string imageFile)
        {
            List<RegionPopulationInfo> populationInfos = ParsePopulationFile(populationFile);
            List<RegionPopulationInfo> coordinateInfos = ParseCoordinateFile(coordinateFile, imageFile);

            return MatchRegionInfos(populationInfos, coordinateInfos);
        }

        /// <summary>
        /// Parses a population file (*.csv) from "Statistisches Bundesamt"
        /// </summary>
        /// <param name="populationFile">The file to parse</param>
        /// <returns>A list of all RegionPopulationInfo with population numbers only </returns>
        public List<RegionPopulationInfo> ParsePopulationFile(string populationFile)
        {
            if (!File.Exists(populationFile))
                throw new FileNotFoundException("File could not be found", populationFile);

            _lines = File.ReadAllText(populationFile, Encoding.UTF8).Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            return FindCities();
        }

        private List<RegionPopulationInfo> FindCities()
        {
            var _cities = new List<RegionPopulationInfo>();

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
            return _cities;
        }

        private RegionPopulationInfo ParseCity(int index)
        {
            string[] firstLine = _lines[index].Split(';');
            string[] nameParts = firstLine[1].Split(',');
            string name = nameParts[0].Trim();

            if (nameParts.Length == 2)                                                  //TODO: |f| dirty fix
                if (nameParts[1].Contains("Stadt") || nameParts[1].Contains("stadt"))
                    name += " (Stadt)";

            RegionPopulationInfo city = new RegionPopulationInfo() { Name = name };

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

        /// <summary>
        /// Parses a coordinate file 
        /// </summary>
        /// <param name="coordinateFile">Coordinate file to parse</param>
        /// <param name="imageFile">Image file to use</param>
        /// <returns>A list of mapped RegionPopulationInfo with coordinates only</returns>
        public List<RegionPopulationInfo> ParseCoordinateFile(string coordinateFile, string imageFile)
        {
            if (!File.Exists(coordinateFile))
                throw new FileNotFoundException("File could not be found", coordinateFile);

            if (!File.Exists(imageFile))
                throw new FileNotFoundException("File could not be found", imageFile);

            List<Tuple<string, Point>> sampleCoordinates = LandCircleParser.ParseCircles(coordinateFile);

            Dictionary<string, List<Point>> matchedCoordinates = DepartmentParser.Parse(imageFile, sampleCoordinates);

            var result = new List<RegionPopulationInfo>();

            foreach (var item in matchedCoordinates)
            {
                result.Add(new RegionPopulationInfo() { Name = item.Key, AssociatedCoordinates = item.Value });
            }

            return result;
        }

        private Tuple<List<RegionPopulationInfo>, List<string>> MatchRegionInfos(List<RegionPopulationInfo> populationInfos, List<RegionPopulationInfo> coordinateInfos)
        {
            var result = new Tuple<List<RegionPopulationInfo>, List<string>>(new List<RegionPopulationInfo>(), new List<string>());

            for (int i = 0; i < populationInfos.Count; i++)
            {
                var match = coordinateInfos.FirstOrDefault(x => x.Name == populationInfos[i].Name);

                if (match != null)
                {
                    populationInfos[i].AssociatedCoordinates = match.AssociatedCoordinates;
                    result.Item1.Add(populationInfos[i]);
                    coordinateInfos.Remove(match);
                }
                else
                    result.Item2.Add(populationInfos[i].Name + "(csv)");
            }
            foreach (var item in coordinateInfos)
            {
                result.Item2.Add(item.Name + "(txt)");
            }


            return result;
        }
    }
}