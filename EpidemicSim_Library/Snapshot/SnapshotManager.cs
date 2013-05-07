using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library.Diseases;
using PSC2013.ES.Library.IO.Writers;
using PSC2013.ES.Library.Simulation;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;


namespace PSC2013.ES.Library.Snapshot
{
    /// <summary>
    /// Used to persist Simulation-Snapshots
    /// </summary>
    public class SnapshotManager
    {
        private string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // ...

        private static SimulationInfo _simInfo;
        private static string _target;
        private static long _tick;
        private static Queue<TickSnapshot> _snapshots;

        private event EventHandler TookSnapshot;
        private SnapshotWriter _writer;

        /// <summary>
        /// Initializes the logging of a new Simulation
        /// </summary>
        /// <param name="destination">Where to save the data</param>
        /// <param name="disease">The Disease used in the Simulation</param>
        public void Initialize(string destination, Disease disease)
        {
            _simInfo = SimulationInfo.InitializeFromRuntime(disease);
            _target = Path.Combine(destination, disease.Name);
            _snapshots = new Queue<TickSnapshot>();
            _tick = 1;
            _writer = new SnapshotWriter();
            TookSnapshot += _writer.Recieve;
        }

        /// <summary>
        /// Takes a Snapshot of the current state and starts to write all Snapshots that are left
        /// </summary>
        /// <param name="simData">Current SimulationData to take a Snapshot of</param>
        public void TakeSnapshot(SimulationData simData)
        {
            CellSnapshot[] cells = new CellSnapshot[simData.Cells.Length]; //TODO |t|How many do we really need? Only the populated ones...
            int pos = 0;
            int i = 0;
            foreach (PopulationCell cell in simData.Cells)
            {
                //TODO |h| maybe another "== null" - check than checking if probability > 0
                if (cell.Probability > 0)
                {
                    cells[i++] = CellSnapshot.InitializeFromRuntime(cell, pos);
                }
                ++pos;
            }
            TickSnapshot snap = TickSnapshot.IntitializeFromRuntime(_tick, cells, simData.Deaths);
            _snapshots.Enqueue(snap);
            TookSnapshot(this, null);
            _tick++;
        }

        /// <summary>
        /// Finishes writing the Snapshot Queue und compresses the folder
        /// DEPRECATED
        /// </summary>
        public void Finish()
        {
            foreach (TickSnapshot s in _snapshots)
                TookSnapshot(this, null);            
            Console.WriteLine("Finished logging of Simulation @ " + DateTime.Now.ToString());
        }

        /// <summary>
        /// Nested class for writing the snapshots
        /// </summary>
        class SnapshotWriter
        {
            private IBinaryWriter _writer;

            private Task _task;

            /// <summary>
            /// Creates a new Writer abd creates an archive at the above given destination
            /// </summary>
            public SnapshotWriter()
            {
                _writer = new ArchiveBinaryWriter();

                if (!File.Exists(_target + ".sim"))
                {                    
                    Directory.CreateDirectory(_target);
                    ZipFile.CreateFromDirectory(_target, _target + ".sim", CompressionLevel.Optimal, false);
                    Directory.Delete(_target, true);
                    _target = _target + ".sim";
                }                    

                _writer.WriteIntoArchive(_simInfo, _target, "header", true);
            }

            /// <summary>
            /// Recieves an event, calling to write some shots
            /// </summary>
            /// <param name="sender">Sender of the event</param>
            /// <param name="e">Params fo the event</param>
            public void Recieve(object sender, EventArgs e)
            {
                if (_task == null)
                    _task = Task.Run(() => WriteAllSnapshots());
            }

            /// <summary>
            /// Writes the next snapshots in the queue, until there
            /// are none left.
            /// </summary>
            private void WriteAllSnapshots()
            {
                while (_snapshots.Count > 0)
                {
                    lock (_snapshots)
                    {
                        TickSnapshot temp = _snapshots.Dequeue();
                        _writer.WriteIntoArchive(temp, _target, temp.Head, true);
                        Console.WriteLine("Finished writing \"" + temp.Head + "\" @ " + DateTime.Now.ToString());
                    }
                }
                _task = null;
            }
        }
    }
}