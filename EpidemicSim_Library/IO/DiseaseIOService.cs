using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PSC2013.ES.Library.DiseaseData;
using PSC2013.ES.Library.IO.Writers;
using System.IO.Compression;

namespace PSC2013.ES.Library.IO
{
    public static class DiseaseIOService
    {
        public const string FILEEXTENSION = ".dis";

        /// <summary>
        /// Saves a Disease to the given Location if it exists and the file not exists
        /// </summary>
        /// <param name="disease">The Disease to be saved</param>
        /// <param name="fileName">The Destination for the File</param>
        /// <param name="overwrite">Should existing files get overriden?</param>
        public static void Save(Disease disease, string fileName, bool overwrite)
        {
            if (File.Exists(fileName) && !overwrite)
                throw new ArgumentException("File already exists (" + fileName + ")!", "fileName");
            if (!fileName.EndsWith(FILEEXTENSION))
                throw new ArgumentException("File must have extension " + FILEEXTENSION, "fileName");

            new ArchiveBinaryWriter().WriteToFile(disease, fileName, overwrite);
        }

        /// <summary>
        /// Loads a Disease form the given FileLocation if it exists
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Disease Load(string fileName)
        {
            if (!File.Exists(fileName))
                throw new ArgumentException("File does not exists at " + fileName, "fileName");
            if (!fileName.EndsWith(FILEEXTENSION))
                throw new ArgumentException("File is not a Disease File. Should be \"" + FILEEXTENSION + "\"!", "fileName");

            using (var archive = ZipFile.Open(fileName, ZipArchiveMode.Read))
            {
                return Disease.FromBytes(archive.Entries[0].ToByteArray());
            }
        }
    }
}