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
        /// Some Federal States that are actually Cities do not have departments/cities belonging to them.
        /// As a consequence we need to artificially create those or change the Federal State to a Department.
        /// </summary>
        /// <param name="allhaveags"></param>
        /// <param name="save"></param>
        /// <returns></returns>
        public static string _5FixCityStates(string fixedislands, bool save)
        {
            string[] datenLines = Regex.Split(fixedislands, "\r\n");
            StringBuilder builder = new StringBuilder();

            Console.WriteLine("Starting to Fix FederalStates that are Cities");
            //Berlin is separated into districts in the file...
            int berlincounter = 0;

            for (int i = 0; i < datenLines.Length; ++i)
            {
                string[] splittedDaten = datenLines[i].Split(';');

                if (splittedDaten[1].Equals("  Berlin"))
                {
                    //Create a new Department called Berlin with the values of berlin
                    builder.Append(datenLines[i] + "\r\n" + "11999");

                    for (int j = 1; j < splittedDaten.Length; ++j)
                    {
                        builder.Append(";" + splittedDaten[j]);
                    }
                }
                else if (splittedDaten[1].StartsWith("        Berlin-"))
                {
                    //make Berlins Districts to actual Cities
                    builder.Append("" + (11990000 + berlincounter));
                    for (int j = 1; j < splittedDaten.Length; ++j)
                    {
                        builder.Append(";" + splittedDaten[j]);
                    }
                    ++berlincounter;
                }
                else if (splittedDaten[1].Equals("  Hamburg"))
                {
                    //Create a new Deparment called Hamburg
                    builder.Append(datenLines[i] + "\r\n" + "02999");
                    for (int j = 1; j < splittedDaten.Length; ++j)
                    {
                        builder.Append(";" + splittedDaten[j]);
                    }
                }
                else
                {
                    builder.Append(datenLines[i]);
                }
                //Bremen is a Fed State with two Departments Bremen and Bremerhaven is 
                //treated like a kreisfreie Stadt. No changes needed


                if (i != datenLines.Length - 1)
                    builder.Append("\r\n");
            }
            Console.WriteLine("Finnished fixing City-Federal States");
            if (save)
            {
                FileStream stream = File.OpenWrite(Program.DESTPATH + "5FixCityStates.txt");
                stream.Write(Encoding.Default.GetBytes(builder.ToString()), 0, Encoding.Default.GetByteCount(builder.ToString()));
                stream.Close();
            }
            return builder.ToString();
        }
    }
}
