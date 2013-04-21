using PSC2013.ES.Library.PopulationData;
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
        private SimulationInfo _info;
        private IBinaryWriter _writer;
        private string _target;


        public SnapshotManager()
        {
            _writer = new AsyncBinaryWriter();
            _info = new SimulationInfo("Test Disease 1");

            init();
        }

        /// <summary>
        /// Takes a Snapshot of the current state of arts
        /// </summary>
        public void TakeSnapshot()
        {            
            writeSnapshot(new Snapshot());
        }

        public void End()
        {
            ZipFile.CreateFromDirectory(_target, _target + ".sim");
        }

        /// <summary>
        /// Writes an Snapshot into a file
        /// </summary>
        private void writeSnapshot(Snapshot snap)
        {
            _writer.WriteFile(snap, Path.Combine(_target, snap.Head), true);
        }

        private void init()
        {
            _target = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Simulation");

            if (!Directory.Exists(_target))
            {
                Directory.CreateDirectory(_target);
                _writer.WriteFile(_info, _target + "\\head.siminfo", true);              
            }
            else
                throw new Exception("Folder already exists!");
        }
    }
}