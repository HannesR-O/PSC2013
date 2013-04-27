using PSC2013.ES.Library.IO.Files;
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

            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                await fs.WriteAsync(bytes, 0, bytes.Length);
                await fs.FlushAsync();
            }
        }
    }
}