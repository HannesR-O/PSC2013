using PSC2013.ES.Library.IO.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Snapshot
{
    /// <summary>
    /// Head-Data for Simulation infos, Contains Dates, Refs etc.
    /// </summary>
    public class SimulationInfo : IBinaryFile
    {
        private string _diseaseInfo;

        public SimulationInfo(string info)
        {
            _diseaseInfo = info;
        }

        public byte[] GetBytes()
        {
            System.Text.ASCIIEncoding conv = new ASCIIEncoding();
            return conv.GetBytes(_diseaseInfo);
        }

        public void InitializeFromFile(byte[] bytes)
        { 
        }
    }
}