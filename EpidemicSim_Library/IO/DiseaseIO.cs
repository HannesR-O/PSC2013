using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PSC2013.ES.Library.Diseases;

namespace PSC2013.ES.Library.IO
{
    public static class DiseaseIO
    {
        public const string FILEEXTENSION = "dis";

        /// <summary>
        /// Saves a Disease to the given Location if it exists and the file not exists
        /// </summary>
        /// <param name="disease">The Disease to be saved</param>
        /// <param name="destination">The Destination for the File</param>
        public static void Save(Disease disease, string destination)
        {
            string filePath = Path.Combine(destination, disease.Name + "." + FILEEXTENSION);
            if (!Directory.Exists(destination))
                throw new ArgumentException("Directory doesn't exist (" + destination + ")");
            if (File.Exists(filePath))
                throw new ArgumentException("File already exists at " + filePath);

            using (var stream = new FileStream(filePath, FileMode.CreateNew))
            {
                stream.Write(disease.GetBytes(), 0, disease.ByteSize);
                stream.Flush();
                stream.Close();
            }
        }

        /// <summary>
        /// Loads a Disease form the given FileLocation if it exists
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Disease Load(string path)
        {
            if (File.Exists(path))
                throw new ArgumentException("File already exists at " + path);
            if (!path.EndsWith("." + FILEEXTENSION))
                throw new ArgumentException("File is not a Disease File. Should be \"." + FILEEXTENSION + "\"");

            Disease disease = new Disease();

            using (var stream = new FileStream(path, FileMode.Open))
            {
                byte[] temp = new byte[stream.Length];
                stream.Read(temp, 0, (int)stream.Length);
                disease = Disease.FromBytes(temp);

                stream.Flush();
                stream.Close();
            }

            return disease;
        }
    }
}
