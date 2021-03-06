﻿using PSC2013.ES.Library.IO.OutputTargets;
using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library.DiseaseData;
using PSC2013.ES.Library.IO.Writers;
using PSC2013.ES.Library.Simulation;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;


namespace PSC2013.ES.Library.Snapshot
{
    /// <summary>
    /// Used to persist Simulation-Snapshots
    /// </summary>
    public class SnapshotManager : OutputTargetWriter
    {
        private string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // ...

        private static SimulationInfo _simInfo;
        private static string _target;
        private static Queue<TickSnapshot> _snapshots;

        private event EventHandler TookSnapshot;
        private SnapshotWriter _writer;

        public event EventHandler<EventArgs> WriterQueueEmpty;
        public event EventHandler<EventArgs> SnapshotWritten;
        public int UnfinnishedSnapshots { get {lock(_snapshots) return _snapshots.Count + ((_writer._task == null)? 0 : 1); } }

        public SnapshotManager() : base("SNM")
        { }

        /// <summary>
        /// Initializes the logging of a new Simulation
        /// </summary>
        /// <param name="destination">Where to save the data</param>
        /// <param name="disease">The Disease used in the Simulation</param>
        public void Initialize(string destination, Disease disease, int mapX, int mapY, int simintervall, int snapintervall, long duration)
        {
            _simInfo = SimulationInfo.InitializeFromRuntime(disease, mapX, mapY, simintervall, snapintervall, duration);

            _target = destination;
            _snapshots = new Queue<TickSnapshot>();

            _writer = new SnapshotWriter();
            _writer.QueueEmptied += (s, e) => WriterQueueEmpty.Raise(s, e);
            _writer.SnapshotWritten += (s, e) => SnapshotWritten.Raise(s, e);
            TookSnapshot += _writer.Recieve;
        }

        /// <summary>
        /// Takes a Snapshot of the current state and starts to write all Snapshots that are left
        /// </summary>
        /// <param name="simData">Current SimulationData to take a Snapshot of</param>
        public void TakeSnapshot(SimulationData simData, long tick)
        {
            int cellCount = simData.Cells.Count(x => x != null);
            CellSnapshot[] cells = new CellSnapshot[cellCount];

            int pos = 0;
            int i = 0;
            foreach (PopulationCell cell in simData.Cells) // Not parallel...
            {
                if (cell != null)
                    cells[i++] = CellSnapshot.InitializeFromRuntime(cell, pos);
                ++pos;
            }

            TickSnapshot snap = TickSnapshot.IntitializeFromRuntime(tick, cells, simData.Deaths.NotNullIterator().ToArray());
            simData.ClearDeaths();

            _snapshots.Enqueue(snap);
            TookSnapshot(this, null);            
        }
        
        /// <summary>
        /// Nested class for writing the snapshots
        /// </summary>
        class SnapshotWriter : OutputTargetWriter
        {
            private ArchiveBinaryWriter _writer;
            public Task _task;

            public event EventHandler<EventArgs> QueueEmptied;
            public event EventHandler<EventArgs> SnapshotWritten;

            /// <summary>
            /// Creates a new Writer and creates an archive at the above given destination
            /// </summary>
            public SnapshotWriter() : base("SW")
            {
                _writer = new ArchiveBinaryWriter();

                if (!_target.EndsWith(".sim"))
                    _target += ".sim";
                if (File.Exists(_target))
                    throw new ArgumentException("Specified .sim file already exists!"); //TODO Please Catch me...

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
                    TickSnapshot temp;
                    lock (_snapshots) { temp = _snapshots.Dequeue(); }
                    if (temp != null)
                    {
                        _writer.WriteIntoArchive(temp, _target, temp.Name, false);
                        SnapshotWritten.Raise(this, null);
                        WriteMessage("Finished writing \"" + temp.Name + "\" @ " + DateTime.Now.ToString());
                    }
                }
                _task = null;
                QueueEmptied.Raise(this, null);
            }
        }
    }
}