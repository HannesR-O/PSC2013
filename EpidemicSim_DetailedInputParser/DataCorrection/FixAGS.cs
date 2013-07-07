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
        /// Some Cities don't use the AGS(Amtlicher Gemeinde-Schlüssel)
        /// Instead they use a Regional key that can be transformed into
        /// a corresponding AGS
        /// </summary>
        /// <param name="uselessremoved"></param>
        public static string _3BuildAGS(string uselessremoved, bool save)
        {
            String[] datenLines = Regex.Split(uselessremoved, "\r\n");
            StringBuilder builder = new StringBuilder();
            Console.WriteLine("Building AGS's for all Departments/Cities that have a regional key");

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
                if (i != datenLines.Length - 1)
                    builder.Append("\r\n");
            }
            Console.WriteLine("Finnished building AGS's");
            if (save)
            {
                FileStream stream = File.OpenWrite(Program.DESTPATH + "3BuildAGS.txt");
                stream.Write(Encoding.Default.GetBytes(builder.ToString()), 0, Encoding.Default.GetByteCount(builder.ToString()));
                stream.Close();
            }
            return builder.ToString();
        }

    }
}
