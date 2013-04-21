using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.Simulation;
using PSC2013.ES.Library.Snapshot;

namespace PSC2013.ES.Library
{
    public class EpidemicSimulator
    {
        // Data
        private SimulationData _data;

        // Managers
        private SnapshotManager _snapshotMgr;

        private EpidemicSimulator()
        {

        }

        public EpidemicSimulator Create()
        {
            var sim = new EpidemicSimulator();

            return sim;
        }
    }
}