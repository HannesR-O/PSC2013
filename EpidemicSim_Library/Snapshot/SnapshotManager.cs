using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library.Diseases;
using PSC2013.ES.Library.IO.Writers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;


namespace PSC2013.ES.Library.Snapshot
{
    public class SnapshotManager
    {
        private string _target;
        private SimulationInfo _simInfo;
        private Queue<Snapshot> _snapshots;
        private IBinaryWriter _writer;
        private long _tick;

        public SnapshotManager()
        {
            _writer = new AsyncBinaryWriter();
            _snapshots = new Queue<Snapshot>();
        }

        /// <summary>
        /// Initializes a Simulation, everytime this method is called, a new simulation is logged
        /// </summary>
        /// <param name="destination">Where to save the Simulation</param>
        /// <param name="name">The simulations name</param>
        /// <param name="disease">The Disease used in this Simulation</param>
        public void InitalizeSimulation(string destination, Disease disease)
        {
            _snapshots = new Queue<Snapshot>();
            _target = Path.Combine(destination, disease.Name);
            _tick = 1;

            if (!Directory.Exists(_target))
               Directory.CreateDirectory(_target);

            _simInfo = SimulationInfo.InitializeFromRuntime(DateTime.Now, disease.Name, disease);
            _writer.WriteFile(_simInfo, _target + "/header", true);
        }

        /// <summary>
        /// Finishes writing the Snapshot Queue
        /// </summary>
        public void Finish()
        {
            foreach (Snapshot s in _snapshots)
                WriteNextSnapshot();
            ZipFile.CreateFromDirectory(_target, _target + ".sim");
        }

        /// <summary>
        /// Takes a Snapshot
        /// </summary>
        /// <param name="cells">The NOT EMPTY PopulationCells</param>
        /// <param name="deaths"></param>
        public void TakeSnapshot(PopulationCell[] cells, string[] deaths)
        {
            CellSnapshot[] temp = new CellSnapshot[cells.Length];
            for (int i = 0; i < cells.Length - 1; ++i)
            {
                temp[i] = CellSnapshot.InitializeFromRuntime(cells[i], i, null);
            }
            Snapshot snap = Snapshot.IntitializeFromRuntime(_tick, temp);

            _snapshots.Enqueue(snap);
        }

        /// <summary>
        /// Writes the next snapshot in the queue. Returns false, if there is none
        /// </summary>
        /// <returns>True, if a SnapShot is written, false, when there is none to write</returns>
        public bool WriteNextSnapshot()
        {
            if (_snapshots.Count > 0)
            {
                Snapshot temp = _snapshots.Dequeue();
                _writer.WriteFile(temp, _target + temp.Head, true);
                return true;
            }
                
            return false;
        }

        /// <summary>
        /// Return whether there is a Snapshotleft to be written
        /// </summary>
        /// <returns></returns>
        public bool SnapshotLeft()
        {
            return _snapshots.Count > 0;
        }
    }
}