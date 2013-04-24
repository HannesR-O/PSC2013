using PSC2013.ES.Library.IO.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.Library.Diseases;

namespace PSC2013.ES.Library.Snapshot
{
    /// <summary>
    /// Head-Data for Simulation infos, Contains Dates, Refs etc.
    /// </summary>
    public class SimulationInfo : IBinaryFile
    {
        public DateTime TimeStarted { get; private set; }
        public string Name { get; private set; }
        private Disease _disease;
        private string _info;


        public SimulationInfo(DateTime time, string name, Disease disease)
        {
            TimeStarted = time;
            Name = name;
            _disease = disease;
            _info = "Simulation \"" + Name + "\" was started at " + TimeStarted;
        }

        public byte[] GetBytes()
        {
            //return System.Text.Encoding.UTF8.GetBytes(0x1 + "|" +  _info + "|");
            return BitConverter.GetBytes(_disease.IdleTime);
        }

        public void InitializeFromFile(byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}