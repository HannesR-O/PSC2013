using PSC2013.ES.Library.IO.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PSC2013.ES.Library.IO.Writers
{
    public class AsyncBinaryWriter : IBinaryWriter
    {
        async void IBinaryWriter.WriteFile(IBinaryFile file, string fileName, bool overwrite)
        {
            var bytes = file.GetBytes();

            if (File.Exists(fileName) && !overwrite)
                return;

            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                await fs.WriteAsync(bytes, 0, bytes.Length);
                await fs.FlushAsync();
            }
        }

        T IBinaryWriter.ReadFile<T>(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                var header = fs.ReadByte();
                byte[] bytes = new byte[fs.Length - 1];
                fs.Read(bytes, 0, (int)(fs.Length - 1));        //TODO: |f| allows a max filesize of 2047 MB, might need to use a loop
                //TODO: |f| not the best way to do this, because classes need to set their header correct
                IBinaryFile file = null;
                switch (header)
                {
                    case 0x1:
                        break;
                    default:
                        throw new Exception("Unknown file header while reading " + fileName);
                }
                return (T)file;
            }
        }
    }
}