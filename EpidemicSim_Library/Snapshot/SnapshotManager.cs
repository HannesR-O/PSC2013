using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library.Diseases;
using PSC2013.ES.Library.IO.Writers;
using PSC2013.ES.Library.Simulation;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Linq;


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

        public event EventHandler<EventArgs> WriterQueueEmpty;

        /// <summary>
        /// Initializes the logging of a new Simulation
        /// </summary>
        /// <param name="destination">Where to save the data</param>
        /// <param name="disease">The Disease used in the Simulation</param>
        public void Initialize(string destination, Disease disease, int mapX, int mapY)
        {
            _simInfo = SimulationInfo.InitializeFromRuntime(disease, mapX, mapY);

            _target = Path.Combine(destination, disease.Name);
            _snapshots = new Queue<TickSnapshot>();

            _tick = 0;

            _writer = new SnapshotWriter();
            _writer.QueueEmptied += WriterQueueEmpty.Raise;
            TookSnapshot += _writer.Recieve;
        }

        /// <summary>
        /// Takes a Snapshot of the current state and starts to write all Snapshots that are left
        /// </summary>
        /// <param name="simData">Current SimulationData to take a Snapshot of</param>
        public void TakeSnapshot(SimulationData simData)
        {
            _tick++;
            int cellCount = simData.Cells.Count(x => x != null);
            CellSnapshot[] cells = new CellSnapshot[cellCount];

            int pos = 0;
            int i = 0;
            foreach (PopulationCell cell in simData.Cells)
            {
                if (cell != null)
                    cells[i++] = CellSnapshot.InitializeFromRuntime(cell, pos);
                ++pos;
            }

            TickSnapshot snap = TickSnapshot.IntitializeFromRuntime(_tick, cells, simData.Deaths);

            _snapshots.Enqueue(snap);
            TookSnapshot(this, null);            
        }
        
        /// <summary>
        /// Nested class for writing the snapshots
        /// </summary>
        class SnapshotWriter
        {
            private IBinaryWriter _writer;
            private Task _task;

            public event EventHandler<EventArgs> QueueEmptied;

            /// <summary>
            /// Creates a new Writer and creates an archive at the above given destination
            /// </summary>
            public SnapshotWriter()
            {
                _writer = new ArchiveBinaryWriter();

                if (!File.Exists(_target + ".sim") && !Directory.Exists(_target))
                {
                    Directory.CreateDirectory(_target);
                    ZipFile.CreateFromDirectory(_target, _target + ".sim", CompressionLevel.Optimal, false);
                    Directory.Delete(_target, true);
                    _target = _target + ".sim";
                }
                else
                    throw new ArgumentException("Path or .sim File at Path exists!"); //TODO Please Catch me...

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
                    // TODO | dj | maybe we should copy the queue?
                    // because IF the IO is a/the bottleneck then locking
                    // the queue would cause the manager itself being blocked
                    // and not being able to enqueue a new snapshot until
                    // the IO is finished.
                    /* other possibility for this:
                     * TickSnapshot tmp;
                     * lock(_snapshots) { tmp = _snapshots.Dequeue(); }
                     * if (tmp != null)
                     * {
                     *      // ...the writing stuff here.
                     * }
                     */
                    lock (_snapshots)
                    {
                        TickSnapshot temp = _snapshots.Dequeue();
                        _writer.WriteIntoArchive(temp, _target, temp.Head, false);
                        Console.WriteLine("Finished writing \"" + temp.Head + "\" @ " + DateTime.Now.ToString());
                    }
                }
                _task = null;
                QueueEmptied.Raise(this, null);
            }
        }
    }
}