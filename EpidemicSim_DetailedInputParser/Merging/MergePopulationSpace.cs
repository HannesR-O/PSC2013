using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpidemicSim_DetailedInputParser
{
    public static partial class Parsing
    {
        /// <summary>
        /// Merges the Populationdatafile with the file
        /// containing the spaces of each City
        /// </summary>
        /// <returns></returns>
        public static string _1MergePopulationAndSpaceData(bool save)
        {
            String[] einwohnerLines = File.ReadAllLines(Program.SRCPATH + "einwohnerzahl.txt", Encoding.Default);
            String[] flaechenLines = File.ReadAllLines(Program.SRCPATH + "fläche.txt", Encoding.Default);
            StringBuilder builder = new StringBuilder();

            Console.WriteLine("Merging Population- and Space-Data");
            for (int i = 0; i < einwohnerLines.Length; ++i)
            {
                string[] splittedEinwohner = einwohnerLines[i].Split(';');
                string[] splittedFlaeche = flaechenLines[i].Split(';');
                if (!(splittedEinwohner[2].Equals(splittedFlaeche[1]) && splittedEinwohner[1].Equals(splittedFlaeche[0])))
                {
                    throw new Exception("The lines from the two files do not match although they should be Equal...");
                }
                else
                {
                    for (int j = 1; j < splittedEinwohner.Length; ++j)
                    {
                        builder.Append(splittedEinwohner[j] + ";");
                    }

                    for (int j = 2; j < splittedFlaeche.Length; ++j)
                    {
                        builder.Append(splittedFlaeche[j]);
                        if (!(j == splittedFlaeche.Length - 1))
                            builder.Append(";");
                    }
                    if (i != einwohnerLines.Length - 1)
                        builder.Append("\r\n");
                }
            }
            Console.WriteLine("Finnished Merging.");
            if (save)
            {
                FileStream stream = File.OpenWrite(Program.DESTPATH + "1MergePopulationAndSpaceData.txt");
                stream.Write(Encoding.Default.GetBytes(builder.ToString()), 0, Encoding.Default.GetByteCount(builder.ToString()));
                stream.Close();
            }
            return builder.ToString();
        }
    }
}
