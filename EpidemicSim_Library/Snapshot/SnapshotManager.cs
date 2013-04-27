using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library.Diseases;
using PSC2013.ES.Library.IO.Writers;
using PSC2013.ES.Library.Simulation;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;


namespace PSC2013.ES.Library.Snapshot
{
    public class SnapshotManager
    {
        private string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // ...

        private static SimulationInfo _simInfo;
        private static string _target;       
        private static long _tick;
        private static Queue<Snapshot> _snapshots;

        private event EventHandler TookSnapshot;
        private SnapshotWriter _writer;

        public SnapshotManager()
        {

        }

        public void Initialize(string destination, Disease disease)
        {
            _simInfo = SimulationInfo.InitializeFromRuntime(DateTime.Now, disease.Name, disease);
            _target = Path.Combine(destination, disease.Name);
            _snapshots = new Queue<Snapshot>();
            _tick = 1;
            _writer = new SnapshotWriter();
            TookSnapshot += _writer.Recieve;
        }

        /// <summary>
        /// Takes a Snapshot of the current state
        /// </summary>
        /// <param name="simData">Current SimulationData to take a Snapshot of</param>
        public void TakeSnapshot(SimulationData simData)
        {
            CellSnapshot[] cells = new CellSnapshot[simData.Population.Length]; //TODO |t|How many do we really need? Only the populated ones...
            int pos = 0;
            foreach (PopulationCell cell in simData.Population)
            {
                if (!(cell == null))
                {
                    cells[pos] = CellSnapshot.InitializeFromRuntime(cell, pos);
                    ++pos;
                }
            }
            HumanSnapshot[] deadPeople = new HumanSnapshot[simData.Deaths.Length];
            foreach (HumanSnapshot ha in simData.Deaths)
            {

            }

            Snapshot snap = Snapshot.IntitializeFromRuntime(_tick, cells, deadPeople);

            _snapshots.Enqueue(snap);
            TookSnapshot(this, null);
        }

        /// <summary>
        /// Finishes writing the Snapshot Queue
        /// </summary>
        public void Finish()
        {
            foreach (Snapshot s in _snapshots)
                TookSnapshot(this, null);
            ZipFile.CreateFromDirectory(_target, _target + ".sim");
            Directory.Delete(_target, true);
        }

        /// <summary>
        /// Nested class for writing the snapshots
        /// </summary>
        class SnapshotWriter
        {
            private IBinaryWriter _writer;

            /// <summary>
            /// Creates a new Writer
            /// </summary>
            public SnapshotWriter()
            {
                _writer = new AsyncBinaryWriter();

                if (!Directory.Exists(_target))
                    Directory.CreateDirectory(_target);

                _writer.WriteFile(_simInfo, _target + "/header", true);
            }

            /// <summary>
            /// Recieves an event, calling to write some shots
            /// </summary>
            /// <param name="sender">Sender of the event</param>
            /// <param name="e">Params fo the event</param>
            public void Recieve(object sender, EventArgs e)
            {
                WriteAllSnapshots();
            }

            /// <summary>
            /// Writes the next snapshots in the queue, until there
            /// are none left. Returns false, if there is none
            /// </summary>
            private void WriteAllSnapshots()
            {
                while (_snapshots.Count > 0)
                {
                    Snapshot temp = _snapshots.Dequeue();
                    _writer.WriteFile(temp, _target + temp.Head, true);
                }
            }
        }
    }
}