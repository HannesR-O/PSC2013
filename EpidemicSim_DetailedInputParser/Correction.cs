using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EpidemicSim_DetailedInputParser
{
    public class Correction
    {
        public static string _2RemoveuselessData(string mergedpopspace)
        {
            String[] datenLines = Regex.Split(mergedpopspace, "\r\n");
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < datenLines.Length; ++i)
            {
                string[] splittedDaten = datenLines[i].Split(';');

                //empty                             //regional                  //Gemeinde                              //Samtgemeinden...
                if (splittedDaten[19].Equals("-") || splittedDaten[0].Length == 3 || splittedDaten[0].Length == 7 || splittedDaten[1].ToLower().Contains("samtgemeinde"))
                    continue;

                builder.Append(datenLines[i]);

                if(i != datenLines.Length - 1)
                     builder.Append("\r\n");
            }

            return builder.ToString();
        }

        /// <summary>
        /// Some Cities don't use the AGS(Amtlicher gemeindeschlüssel)
        /// Instead they use a Regional key that can be transformed into
        /// a corresponding AGS
        /// </summary>
        /// <param name="uselessremoved"></param>
        public static string _3BuildAGS(string uselessremoved)
        {
            String[] datenLines = Regex.Split(uselessremoved, "\r\n");
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < datenLines.Length; ++i)
            {
                string[] splittedline = datenLines[i].Split(';');

                if (splittedline[0].Length == 11)
                {
                    splittedline[0] = splittedline[0][0] + "" + splittedline[0][1] +
                                      splittedline[0][2] + splittedline[0][3] +
                                      splittedline[0][4] + splittedline[0][8] +
                                      splittedline[0][9] + splittedline[0][10];

                    for (int j = 0; j < splittedline.Length; ++j)
                    {
                        builder.Append(splittedline[j]);
                        if (!(j == splittedline.Length - 1))
                        {
                            builder.Append(";");
                        }
                    }
                }
                else if (splittedline[0].Length == 10)
                {
                    splittedline[0] = splittedline[0][0] + "" + splittedline[0][1] + "" +
                                      splittedline[0][2] + "" + splittedline[0][3] + "" +
                                      splittedline[0][4] + "" + splittedline[0][7] + "" +
                                      splittedline[0][8] + "" + splittedline[0][9];

                    for (int j = 0; j < splittedline.Length; ++j)
                    {
                        builder.Append(splittedline[j]);
                        if (!(j == splittedline.Length - 1))
                        {
                            builder.Append(";");
                        }
                    }
                }
                else
                {
                    builder.Append(datenLines[i]);
                }
                if(i != datenLines.Length - 1)
                    builder.Append("\r\n");
            }

            return builder.ToString();
        }


        public static string _4FixCityStates(string allhaveags)
        {
            string[] datenLines = Regex.Split(allhaveags, "\r\n");
            StringBuilder builder = new StringBuilder();

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

                    //splittedDaten[splittedDaten.Length - 1] = "11999";
                }
                else if (splittedDaten[1].StartsWith("        Berlin-"))
                {
                    //make Berlins Districts to actual Cities
                    builder.Append("" + (1199000 + berlincounter));
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


                if(i != datenLines.Length - 1)
                    builder.Append("\r\n");
            }

            return builder.ToString();
        }
    }
}
