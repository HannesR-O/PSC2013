using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.IO.Writers;
using System.IO;
using System.IO.Compression;

namespace PSC2013.ES.Library.Snapshot
{
    public class SnapshotManager
    {
        private Snapshot _last;
        private SimulationInfo _info;
        private IBinaryWriter _writer;


        public SnapshotManager()
        {
            // Write Simulation Info
            _writer = new AsyncBinaryWriter();
            _info = new SimulationInfo("Test Disease 1");
            init();
        }

        /// <summary>
        /// Takes a Snapshot of the current state of arts
        /// </summary>
        public void TakeSnapshot()
        {
 
        }

        /// <summary>
        /// Creates various statistics // TBD
        /// </summary>
        /// <param name="shot"></param>
        public void CreateStatistics(Snapshot shot)
        {
 
        }

        /// <summary>
        /// Writes an Snapshot into a file
        /// </summary>
        /// <returns>Bool, succsessfully written or not</returns>
        private void writeSnapshot()
        {
            _writer.WriteFile(_last, _last.Head, false);
        }

        private void init()
        {
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Sim");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                _writer.WriteFile(_info, dir + "/head.siminfo", true);
                ZipFile.CreateFromDirectory(dir, dir+ "ulation.zip");
            }
            else
                throw new ArgumentException("Folder already exists!");
        }
    }
}
