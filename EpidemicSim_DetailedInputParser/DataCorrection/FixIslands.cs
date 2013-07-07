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
        /// Islands are represented as cities in previos Files,
        /// this method changes them to Departments, so that
        /// the Citypointparsing can work correctly.
        /// In addition the space of departments containing Islands
        /// is reduced by the space of those islands
        /// </summary>
        /// <param name="bla"></param>
        /// <param name="save"></param>
        /// <returns></returns>
        public static string _4FixIslands(string fixedags, bool save)
        {
            string[] datenLines = Regex.Split(fixedags, "\r\n");
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < datenLines.Length; ++i)
            {
                string[] splittedLine = datenLines[i].Split(';');
                if (splittedLine[1].Equals("      Nordfriesland, Landkreis"))
                {
                    //add Nordfriesland (Dirty change of departmentspace...)
                    splittedLine[56] = "177211"; //Islands added space : 31071
                    builder.Append(splittedLine[0]);
                    for (int j = 1; j < splittedLine.Length; ++j)
                        builder.Append(";" + splittedLine[j]);

                    builder.Append("\r\n");

                    LinkedList<string> syltlines = new LinkedList<string>();
                    LinkedList<string> foehrlines = new LinkedList<string>();
                    LinkedList<string> amrumlines = new LinkedList<string>();
                    LinkedList<string> nordstrandlines = new LinkedList<string>();
                    string pellwormline = null;
                    string langenessline = null;
                    int syltcounter = 0;
                    int foehrcounter = 0;
                    int amrumcounter = 0;
                    int nordstrandcounter = 0;

                    int[] syltvalues = new int[73];
                    int[] foehrvalues = new int[73];
                    int[] amrumvalues = new int[73];
                    int[] nordstrandvalues = new int[73];

                    ++i;
                    while (datenLines[i].Split(';')[0].Length == 8)
                    {
                        string[] splittedtmp = datenLines[i].Split(';');

                        if (splittedtmp[1].ToLower().Contains("sylt") ||
                            splittedtmp[1].Equals("        List"))
                        {
                            StringBuilder line = new StringBuilder();
                            line.Append("0" + (1077000 + syltcounter));
                            for (int k = 1; k < splittedtmp.Length; ++k)
                            {
                                line.Append(";" + splittedtmp[k]);
                                if (k > 1)
                                    syltvalues[k - 2] += int.Parse(splittedtmp[k]);

                            }
                            line.Append("\r\n");
                            syltlines.AddLast(line.ToString());
                            ++syltcounter;
                        }
                        else if (splittedtmp[1].Equals("        Alkersum") ||
                            splittedtmp[1].Equals("        Borgsum") ||
                            splittedtmp[1].Equals("        Dunsum") ||
                            splittedtmp[1].Equals("        Midlum") ||
                            splittedtmp[1].Equals("        Nieblum") ||
                            splittedtmp[1].Equals("        Oevenum") ||
                            splittedtmp[1].Equals("        Oldsum") ||
                            splittedtmp[1].Equals("        Süderende") ||
                            splittedtmp[1].Equals("        Utersum") ||
                            splittedtmp[1].Equals("        Witsum") ||
                            splittedtmp[1].Equals("        Wrixum") ||
                            splittedtmp[1].Equals("        Wyk auf Föhr"))
                        {
                            StringBuilder line = new StringBuilder();
                            line.Append("0" + (1078000 + foehrcounter));
                            for (int k = 1; k < splittedtmp.Length; ++k)
                            {
                                line.Append(";" + splittedtmp[k]);
                                if (k > 1)
                                    foehrvalues[k - 2] += int.Parse(splittedtmp[k]);
                            }
                            line.Append("\r\n");
                            foehrlines.AddLast(line.ToString());
                            ++foehrcounter;
                        }
                        else if (splittedtmp[1].Equals("        Wittdün auf Amrum") ||
                            splittedtmp[1].Equals("        Norddorf auf Amrum") ||
                            splittedtmp[1].Equals("        Nebel"))
                        {
                            StringBuilder line = new StringBuilder();
                            line.Append("0" + (1079000 + amrumcounter));
                            for (int k = 1; k < splittedtmp.Length; ++k)
                            {
                                line.Append(";" + splittedtmp[k]);
                                if (k > 1)
                                    amrumvalues[k - 2] += int.Parse(splittedtmp[k]);
                            }
                            line.Append("\r\n");
                            amrumlines.AddLast(line.ToString());
                            ++amrumcounter;
                        }
                        else if (splittedtmp[1].Equals("        Nordstrand") ||
                            splittedtmp[1].Equals("        Elisabeth-Sophien-Koog"))
                        {
                            StringBuilder line = new StringBuilder();
                            line.Append("0" + (1080000 + nordstrandcounter));
                            for (int k = 1; k < splittedtmp.Length; ++k)
                            {
                                line.Append(";" + splittedtmp[k]);
                                if (k > 1)
                                    nordstrandvalues[k - 2] += int.Parse(splittedtmp[k]);
                            }
                            line.Append("\r\n");
                            nordstrandlines.AddLast(line.ToString());
                            ++nordstrandcounter;
                        }
                        else if (splittedtmp[1].Equals("        Pellworm"))
                        {
                            StringBuilder line = new StringBuilder();
                            line.Append("01090");
                            for (int k = 1; k < splittedtmp.Length; ++k)
                            {
                                line.Append(";" + splittedtmp[k]);
                            }
                            line.Append("\r\n");
                            pellwormline = line.ToString();
                        }
                        else if (splittedtmp[1].Equals("        Langeneß"))
                        {
                            StringBuilder line = new StringBuilder();
                            line.Append("01091");
                            for (int k = 1; k < splittedtmp.Length; ++k)
                            {
                                line.Append(";" + splittedtmp[k]);
                            }
                            line.Append("\r\n");
                            langenessline = line.ToString();
                        }
                        else
                        {
                            builder.Append(datenLines[i] + "\r\n");
                        }
                        ++i;

                    }
                    --i;

                    StringBuilder tmp = new StringBuilder();
                    tmp.Append("01077;Sylt");
                    for (int l = 0; l < syltvalues.Length; ++l)
                        tmp.Append(";" + syltvalues[l]);
                    tmp.Append("\r\n");
                    syltlines.AddFirst(tmp.ToString());
                    tmp.Clear();


                    tmp.Append("01078;Föhr");
                    for (int l = 0; l < foehrvalues.Length; ++l)
                        tmp.Append(";" + foehrvalues[l]);
                    tmp.Append("\r\n");
                    foehrlines.AddFirst(tmp.ToString());
                    tmp.Clear();


                    tmp.Append("01079;Amrum");
                    for (int l = 0; l < amrumvalues.Length; ++l)
                        tmp.Append(";" + amrumvalues[l]);
                    tmp.Append("\r\n");
                    amrumlines.AddFirst(tmp.ToString());
                    tmp.Clear();

                    tmp.Append("01080;Nordstrand");
                    for (int l = 0; l < nordstrandvalues.Length; ++l)
                        tmp.Append(";" + nordstrandvalues[l]);
                    tmp.Append("\r\n");
                    nordstrandlines.AddFirst(tmp.ToString());
                    tmp.Clear();


                    foreach (string s in syltlines)
                        builder.Append(s);

                    foreach (string s in foehrlines)
                        builder.Append(s);

                    foreach (string s in amrumlines)
                        builder.Append(s);

                    foreach (string s in nordstrandlines)
                        builder.Append(s);

                    builder.Append(pellwormline);
                    builder.Append(langenessline);
                }
                else if (splittedLine[1].Equals("      Ostholstein, Landkreis"))
                {
                    string fehmarnline = null;

                    splittedLine[56] = "120711"; //Islands added space : 18548
                    builder.Append(splittedLine[0]);
                    for (int j = 1; j < splittedLine.Length; ++j)
                        builder.Append(";" + splittedLine[j]);

                    builder.Append("\r\n");

                    ++i;
                    while (datenLines[i].Split(';')[0].Length == 8)
                    {
                        string[] splittedtmp = datenLines[i].Split(';');

                        if (splittedtmp[1].Equals("        Fehmarn"))
                        {
                            StringBuilder line = new StringBuilder();
                            line.Append("01092");
                            for (int k = 1; k < splittedtmp.Length; ++k)
                            {
                                line.Append(";" + splittedtmp[k]);
                            }
                            line.Append("\r\n");
                            fehmarnline = line.ToString();
                        }
                        else
                        {
                            builder.Append(datenLines[i] + "\r\n");
                        }
                        ++i;
                    }
                    --i;
                    builder.Append(fehmarnline);
                }
                else if (splittedLine[1].Equals("      Friesland, Landkreis")) //TODO aurich etc not niedersachsen
                {
                    //Wangerooge
                    string wangeroogeline = null;

                    splittedLine[56] = "60293"; //Islands added space : 497
                    builder.Append(splittedLine[0]);
                    for (int j = 1; j < splittedLine.Length; ++j)
                        builder.Append(";" + splittedLine[j]);

                    builder.Append("\r\n");


                    ++i;
                    for (; datenLines[i].Split(';')[0].Length == 8; ++i)
                    {
                        if (datenLines[i].Split(';')[1].Equals("        Wangerooge"))
                        {
                            wangeroogeline = "99999" + datenLines[i].Substring(datenLines[i].IndexOf(';')) + "\r\n";
                        }
                        else
                        {
                            builder.Append(datenLines[i] + "\r\n");
                        }
                    }
                    --i;

                    builder.Append(wangeroogeline);
                }
                else if (splittedLine[1].Equals("      Wittmund, Landkreis"))
                {
                    string spiekeroogline = null;
                    string langeoogline = null;

                    splittedLine[56] = "61874"; //Islands added space : 3792
                    builder.Append(splittedLine[0]);
                    for (int j = 1; j < splittedLine.Length; ++j)
                        builder.Append(";" + splittedLine[j]);

                    builder.Append("\r\n");

                    ++i;
                    for (; datenLines[i].Split(';')[0].Length == 8; ++i)
                    {
                        if (datenLines[i].Split(';')[1].Equals("        Spiekeroog"))
                        {
                            spiekeroogline = "99999" + datenLines[i].Substring(datenLines[i].IndexOf(';')) + "\r\n";
                        }
                        else if (datenLines[i].Split(';')[1].Equals("        Langeoog"))
                        {
                            langeoogline = "99999" + datenLines[i].Substring(datenLines[i].IndexOf(';')) + "\r\n";
                        }
                        else
                        {
                            builder.Append(datenLines[i] + "\r\n");
                        }
                    }
                    --i;
                    builder.Append(spiekeroogline);
                    builder.Append(langeoogline);
                }
                else if (splittedLine[1].Equals("      Aurich, Landkreis"))
                {
                    string baltrumline = null;
                    string norderneyline = null;
                    string juistline = null;
                    string memmertline = null;

                    splittedLine[56] = "123292"; //Islands added space : 5439
                    builder.Append(splittedLine[0]);
                    for (int j = 1; j < splittedLine.Length; ++j)
                        builder.Append(";" + splittedLine[j]);

                    builder.Append("\r\n");

                    ++i;
                    for (; datenLines[i].Split(';')[0].Length == 8; ++i)
                    {
                        if (datenLines[i].Split(';')[1].Equals("        Baltrum"))
                        {
                            baltrumline = "99999" + datenLines[i].Substring(datenLines[i].IndexOf(';')) + "\r\n";
                        }
                        else if (datenLines[i].Split(';')[1].Equals("        Norderney"))
                        {
                            norderneyline = "99999" + datenLines[i].Substring(datenLines[i].IndexOf(';')) + "\r\n";
                        }
                        else if (datenLines[i].Split(';')[1].Equals("        Juist"))
                        {
                            juistline = "99999" + datenLines[i].Substring(datenLines[i].IndexOf(';')) + "\r\n";
                        }
                        else if (datenLines[i].Split(';')[1].Equals("        Nordseeinsel Memmert, gem.fr. Geb."))
                        {
                            memmertline = "99999" + datenLines[i].Substring(datenLines[i].IndexOf(';')) + "\r\n";
                        }

                        else
                        {
                            builder.Append(datenLines[i] + "\r\n");
                        }
                    }
                    --i;
                    builder.Append(baltrumline);
                    builder.Append(norderneyline);
                    builder.Append(juistline);
                    builder.Append(memmertline);
                }
                else if (splittedLine[1].Equals("      Leer, Landkreis"))
                {
                    //Wangerooge
                    string borkumline = null;

                    splittedLine[56] = "105504"; //Islands added space : 3097
                    builder.Append(splittedLine[0]);
                    for (int j = 1; j < splittedLine.Length; ++j)
                        builder.Append(";" + splittedLine[j]);

                    builder.Append("\r\n");

                    ++i;
                    for (; datenLines[i].Split(';')[0].Length == 8; ++i)
                    {
                        if (datenLines[i].Split(';')[1].Equals("        Borkum"))
                        {
                            borkumline = "99999" + datenLines[i].Substring(datenLines[i].IndexOf(';')) + "\r\n";
                        }
                        else
                        {
                            builder.Append(datenLines[i] + "\r\n");
                        }
                    }
                    --i;

                    builder.Append(borkumline);
                }

                else if (splittedLine[1].Equals("      Landkreis Vorpommern-Rügen"))
                {
                    LinkedList<string> ruegen1lines = new LinkedList<string>();
                    int ruegen1counter = 0;
                    int[] ruegen1values = new int[73];

                    LinkedList<string> ruegen2lines = new LinkedList<string>();
                    int ruegen2counter = 0;
                    int[] ruegen2values = new int[73];


                    string hiddenseeline = null;

                    splittedLine[56] = "227752"; //Islands added space : 91417
                    builder.Append(splittedLine[0]);
                    for (int j = 1; j < splittedLine.Length; ++j)
                        builder.Append(";" + splittedLine[j]);

                    builder.Append("\r\n");

                    ++i;
                    for (; datenLines[i].Split(';')[0].Length == 8; ++i)
                    {
                        string[] splittedtmp = datenLines[i].Split(';');

                        if (datenLines[i].Split(';')[1].Equals("        Insel Hiddensee"))
                        {
                            hiddenseeline = "99999" + datenLines[i].Substring(datenLines[i].IndexOf(';')) + "\r\n";
                        }
                        else if (datenLines[i].Split(';')[1].Equals("        Dranske") ||
                            datenLines[i].Split(';')[1].Equals("        Wiek") ||
                            datenLines[i].Split(';')[1].Equals("        Breege") ||
                            datenLines[i].Split(';')[1].Equals("        Altenkirchen") ||
                            datenLines[i].Split(';')[1].Equals("        Putgarten"))
                        {
                            StringBuilder line = new StringBuilder();
                            line.Append("0" + (111111 + ruegen1counter));
                            for (int k = 1; k < splittedtmp.Length; ++k)
                            {
                                line.Append(";" + splittedtmp[k]);
                                if (k > 1)
                                    ruegen1values[k - 2] += int.Parse(splittedtmp[k]);
                            }
                            line.Append("\r\n");
                            ruegen1lines.AddLast(line.ToString());
                            ++ruegen1counter;
                        } 
                        else if (datenLines[i].Split(';')[1].Equals("        Ummanz") ||
                            datenLines[i].Split(';')[1].Equals("        Trent") ||
                            datenLines[i].Split(';')[1].Equals("        Schaprode") ||
                            datenLines[i].Split(';')[1].Equals("        Samtens") ||
                            datenLines[i].Split(';')[1].Equals("        Rambin") ||
                            datenLines[i].Split(';')[1].Equals("        Neuenkirchen") ||
                            datenLines[i].Split(';')[1].Equals("        Kluis") ||
                            datenLines[i].Split(';')[1].Equals("        Gingst") ||
                            datenLines[i].Split(';')[1].Equals("        Dreschvitz") ||
                            datenLines[i].Split(';')[1].Equals("        Altefähr") ||
                            datenLines[i].Split(';')[1].Equals("        Zirkow") ||
                            datenLines[i].Split(';')[1].Equals("        Thiessow") ||
                            datenLines[i].Split(';')[1].Equals("        Sellin") ||
                            datenLines[i].Split(';')[1].Equals("        Middelhagen") ||
                            datenLines[i].Split(';')[1].Equals("        Lancken-Granitz") ||
                            datenLines[i].Split(';')[1].Equals("        Göhren") ||
                            datenLines[i].Split(';')[1].Equals("        Gager") ||
                            datenLines[i].Split(';')[1].Equals("        Baabe") ||
                            datenLines[i].Split(';')[1].Equals("        Sehlen") ||
                            datenLines[i].Split(';')[1].Equals("        Rappin") ||
                            datenLines[i].Split(';')[1].Equals("        Ralswiek") ||
                            datenLines[i].Split(';')[1].Equals("        Poseritz") ||
                            datenLines[i].Split(';')[1].Equals("        Patzig") ||
                            datenLines[i].Split(';')[1].Equals("        Parchtitz") ||
                            datenLines[i].Split(';')[1].Equals("        Lietzow") ||
                            datenLines[i].Split(';')[1].Equals("        Gustow") ||
                            datenLines[i].Split(';')[1].Equals("        Garz/Rügen, Stadt") ||
                            datenLines[i].Split(';')[1].Equals("        Buschvitz") ||
                            datenLines[i].Split(';')[1].Equals("        Bergen auf Rügen, Stadt") ||
                            datenLines[i].Split(';')[1].Equals("        Sassnitz, Stadt") ||
                            datenLines[i].Split(';')[1].Equals("        Binz") ||
                            datenLines[i].Split(';')[1].Equals("        Putbus, Stadt"))
                        {
                            StringBuilder line = new StringBuilder();
                            line.Append("0" + (111111 + ruegen2counter));
                            for (int k = 1; k < splittedtmp.Length; ++k)
                            {
                                line.Append(";" + splittedtmp[k]);
                                if (k > 1)
                                    ruegen2values[k - 2] += int.Parse(splittedtmp[k]);
                            }
                            line.Append("\r\n");
                            ruegen2lines.AddLast(line.ToString());
                            ++ruegen2counter;
                        }
                        else
                        {
                            builder.Append(datenLines[i] + "\r\n");
                        }
                    }
                    --i;
                    builder.Append(hiddenseeline);

                    StringBuilder tmp = new StringBuilder();
                    tmp.Append("11111;Rügen1");
                    for (int l = 0; l < ruegen1values.Length; ++l)
                        tmp.Append(";" + ruegen1values[l]);
                    tmp.Append("\r\n");
                    ruegen1lines.AddFirst(tmp.ToString());
                    tmp.Clear();

                    tmp.Append("11111;Rügen2");
                    for (int l = 0; l < ruegen2values.Length; ++l)
                        tmp.Append(";" + ruegen2values[l]);
                    tmp.Append("\r\n");
                    ruegen2lines.AddFirst(tmp.ToString());
                    tmp.Clear();

                    foreach (string s in ruegen1lines)
                        builder.Append(s);

                    foreach (string s in ruegen2lines)
                        builder.Append(s);

                }
                else
                {
                    builder.Append(datenLines[i]);
                    if (i != datenLines.Length - 1)
                        builder.Append("\r\n");
                }

            }

            if (save)
            {
                FileStream stream = File.OpenWrite(Program.DESTPATH + "4FixIslands.txt");
                stream.Write(Encoding.Default.GetBytes(builder.ToString()), 0, Encoding.Default.GetByteCount(builder.ToString()));
                stream.Close();
            }
            return builder.ToString();
        }
    }
}
