using PSC2013.ES.Library.PopulationData;
using PSC2013.ES.Library.Diseases;
using PSC2013.ES.Library.IO.Writers;
using PSC2013.ES.Library.Simulation;
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
        private SimulationInfo _simInfo;
        private static string _target;       
        private static long _tick;
        private static Queue<Snapshot> _snapshots;
        
        private delegate void SenderHandler(object sender, EventArgs e);
        private event SenderHandler _snapToWrite;
        private writer _writer;

        public SnapshotManager()
        {
            _writer = new writer();
            _snapToWrite += new SenderHandler(_writer.Recieve);
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
            //_writer.WriteFile(_simInfo, _target + "/header", true);
        }

        /// <summary>
        /// Finishes writing the Snapshot Queue
        /// </summary>
        public void Finish()
        {
            foreach (Snapshot s in _snapshots)
                _snapToWrite(this, null);
            ZipFile.CreateFromDirectory(_target, _target + ".sim");
        }

        /// <summary>
        /// Takes a Snapshot
        /// </summary>
        /// <param name="cells">The NOT EMPTY PopulationCells</param>
        /// <param name="deaths"></param>
        public void TakeSnapshot(SimulationData sim)
        {
            CellSnapshot[] temp = new CellSnapshot[sim.Population.Length]; //TODO |t|How many do we really need? Only the populated ones...
            int pos = 0;
            foreach (PopulationCell c in sim.Population)
            {
                if (!(c == null))
                    temp[pos] = CellSnapshot.InitializeFromRuntime(c, pos);
            }

            //TODO |t| Creating Humansnapshot[] from sim-

            Snapshot snap = Snapshot.IntitializeFromRuntime(_tick, temp, null); //TODO |t| Sim does NOT hava list of deaths right now? Am i right?
            
            _snapshots.Enqueue(snap);
            _snapToWrite(this, null);
        }   

        // |t| Not necessary anymore me thinks...
        /// <summary>
        /// Return whether there is a Snapshotleft to be written
        /// </summary>
        /// <returns></returns>
        //public bool SnapshotLeft()
        //{
        //    return _snapshots.Count > 0;
        //}

        /// <summary>
        /// Nested class for writing the snapshots
        /// </summary>
        class writer
        {
            private IBinaryWriter _writer;

            /// <summary>
            /// Creates a new Writer
            /// </summary>
            public writer()
            {
                _writer = new AsyncBinaryWriter();
            }

            /// <summary>
            /// Recieves an event, calling to write some shots
            /// </summary>
            /// <param name="sender">Sender of the event</param>
            /// <param name="e">Params fo the event</param>
            public void Recieve(object sender, EventArgs e)
            {
                WriteNextSnapshot();
            }

            /// <summary>
            /// Writes the next snapshots in the queue, until there
            /// are none left. Returns false, if there is none
            /// </summary>
            private void WriteNextSnapshot()
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