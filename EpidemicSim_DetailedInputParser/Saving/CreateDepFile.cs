using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EpidemicSim_DetailedInputParser
{
    public static partial class Parsing
    {
        public static void _9CreateDepFile(string ready)
        {
            string[] datalines = Regex.Split(ready, "\r\n");
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < datalines.Length; ++i)
            {
                string[] splittedLine = datalines[i].Split(';');
                if (splittedLine[0].Length == 5 && i + 1 < datalines.Length && datalines[i + 1].Split(';')[0].Length != 8)
                {
                    builder.Append(splittedLine[1].Trim());

                    int mb = int.Parse(splittedLine[20]) + int.Parse(splittedLine[21]);

                    int mc = int.Parse(splittedLine[22]) + int.Parse(splittedLine[23]) +
                             int.Parse(splittedLine[24]) + int.Parse(splittedLine[25]);

                    int ma = int.Parse(splittedLine[26]) + int.Parse(splittedLine[27]) +
                             int.Parse(splittedLine[28]) + int.Parse(splittedLine[29]) +
                             int.Parse(splittedLine[30]) + int.Parse(splittedLine[31]) +
                             int.Parse(splittedLine[32]) + int.Parse(splittedLine[33]);

                    int ms = int.Parse(splittedLine[34]) + int.Parse(splittedLine[35]) +
                             int.Parse(splittedLine[36]);

                    int fb = int.Parse(splittedLine[38]) + int.Parse(splittedLine[39]);

                    int fc = int.Parse(splittedLine[40]) + int.Parse(splittedLine[41]) +
                             int.Parse(splittedLine[42]) + int.Parse(splittedLine[43]);

                    int fa = int.Parse(splittedLine[44]) + int.Parse(splittedLine[45]) +
                             int.Parse(splittedLine[46]) + int.Parse(splittedLine[47]) +
                             int.Parse(splittedLine[48]) + int.Parse(splittedLine[49]) +
                             int.Parse(splittedLine[50]) + int.Parse(splittedLine[51]);

                    int fs = int.Parse(splittedLine[52]) + int.Parse(splittedLine[53]) +
                             int.Parse(splittedLine[54]);

                    builder.Append("|" + mb + "|" + mc + "|" + ma + "|" + ms +
                                   "|" + fb + "|" + fc + "|" + fa + "|" + fs);

                    int pointcount = int.Parse(splittedLine[75]);
                    for (int j = 0; j < pointcount; ++j)
                    {
                        string[] coord = splittedLine[76 + j].Split(':');
                        builder.Append("|" + coord[0] + ":" + coord[1]);
                    }
                    builder.Append("\n");
                }
                else if (splittedLine[0].Length == 8)
                {
                    builder.Append(splittedLine[1].Trim());
                    int mb = int.Parse(splittedLine[20]) + int.Parse(splittedLine[21]);

                    int mc = int.Parse(splittedLine[22]) + int.Parse(splittedLine[23]) +
                             int.Parse(splittedLine[24]) + int.Parse(splittedLine[25]);

                    int ma = int.Parse(splittedLine[26]) + int.Parse(splittedLine[27]) +
                             int.Parse(splittedLine[28]) + int.Parse(splittedLine[29]) +
                             int.Parse(splittedLine[30]) + int.Parse(splittedLine[31]) +
                             int.Parse(splittedLine[32]) + int.Parse(splittedLine[33]);

                    int ms = int.Parse(splittedLine[34]) + int.Parse(splittedLine[35]) +
                             int.Parse(splittedLine[36]);

                    int fb = int.Parse(splittedLine[38]) + int.Parse(splittedLine[39]);

                    int fc = int.Parse(splittedLine[40]) + int.Parse(splittedLine[41]) +
                             int.Parse(splittedLine[42]) + int.Parse(splittedLine[43]);

                    int fa = int.Parse(splittedLine[44]) + int.Parse(splittedLine[45]) +
                             int.Parse(splittedLine[46]) + int.Parse(splittedLine[47]) +
                             int.Parse(splittedLine[48]) + int.Parse(splittedLine[49]) +
                             int.Parse(splittedLine[50]) + int.Parse(splittedLine[51]);

                    int fs = int.Parse(splittedLine[52]) + int.Parse(splittedLine[53]) +
                             int.Parse(splittedLine[54]);

                    builder.Append("|" + mb + "|" + mc + "|" + ma + "|" + ms +
                                   "|" + fb + "|" + fc + "|" + fa + "|" + fs);

                    int pointcount = int.Parse(splittedLine[75]);
                    for (int j = 0; j < pointcount; ++j)
                    {
                        string[] coord = splittedLine[76 + j].Split(':');
                        builder.Append("|" + coord[0] + ":" + coord[1]);
                    }
                    builder.Append("\n");
                }
            }

            string folderpath = Program.DESTPATH + "CityMap";
            string deppath = folderpath + ".dep";
            Directory.CreateDirectory(folderpath);
            ZipFile.CreateFromDirectory(folderpath, deppath, CompressionLevel.Optimal, false);
            ZipArchive archive = ZipFile.Open(deppath, ZipArchiveMode.Update, Encoding.UTF8);
            Directory.Delete(folderpath);

            archive.CreateEntryFromFile(Program.SRCPATH + "newimage.png", "image", CompressionLevel.Optimal);

            ZipArchiveEntry mapentry = archive.CreateEntry("map");
            Stream stream = mapentry.Open();

            stream.Write(Encoding.UTF8.GetBytes(builder.ToString()), 0, Encoding.UTF8.GetByteCount(builder.ToString()));
            mapentry.Archive.Dispose();
            stream.Close();
        }
    }
}
