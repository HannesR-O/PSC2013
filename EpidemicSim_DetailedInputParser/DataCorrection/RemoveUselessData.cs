using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EpidemicSim_DetailedInputParser
{
    public static partial class Parsing
    {
        /// <summary>
        /// Removes all lines in the previously merged file,
        /// that don't contain Values or are doppelgangers
        /// </summary>
        /// <param name="mergedpopspace"></param>
        /// <param name="save"></param>
        /// <returns></returns>
        public static string _2RemoveuselessData(string mergedpopspace, bool save)
        {
            String[] datenLines = Regex.Split(mergedpopspace, "\r\n");
            StringBuilder builder = new StringBuilder();

            Console.WriteLine("Removing Lines from the previously merged File that can't be used");
            for (int i = 0; i < datenLines.Length; ++i)
            {
                string[] splittedDaten = datenLines[i].Split(';');

                //empty                             //regional                           //Gemeinde(doppelganger)                              //Samtgemeinden...
                if (splittedDaten[19].Equals("-") || splittedDaten[0].Length == 3 || splittedDaten[0].Length == 7 || splittedDaten[1].ToLower().Contains("samtgemeinde"))
                    continue;

                builder.Append(datenLines[i]);

                if (i != datenLines.Length - 1)
                    builder.Append("\r\n");
            }
            Console.WriteLine("Finnished Removing unusable Lines");
            if (save)
            {
                FileStream stream = File.OpenWrite(Program.DESTPATH + "2RemoveuselessData.txt");
                stream.Write(Encoding.Default.GetBytes(builder.ToString()), 0, Encoding.Default.GetByteCount(builder.ToString()));
                stream.Close();
            }
            return builder.ToString();
        }
    }
}
