using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using PSC2013.ES.Library.Snapshot;
using PSC2013.ES.Library.Statistics.Pictures;
using PSC2013.ES.Library.IO.Readers;

namespace PSC2013.ES.Library.Statistics
{
    /// <summary>
    /// Manages taken SimulationSnapshots and creates Statistics out of its contents
    /// </summary>
    public class StatisticsManager
    {
        private SimulationInfo _simInfo;
        private TickSnapshot _current;

        private MapCreator _creator;

        /// <summary>
        /// Opens a new .sim File and restores the contents to Runtime;
        /// Only one can be opened at a time
        /// </summary>
        /// <param name="path">The path where the file is located</param>
        public void OpenSimFile(string path)
        {
            _creator = new MapCreator("C:\\Users\\Tobi\\Desktop");
            ZipArchive archive = ZipFile.Open(path, ZipArchiveMode.Read);

            byte[] file = ArchiveReader.ToByteArray(archive.GetEntry("head"));

            _simInfo = SimulationInfo.InitializeFromFile(file);
        }

        public void LoadTickSnapshot(ZipArchiveEntry entry)
        {
            byte[] temp = ArchiveReader.ToByteArray(entry);

            TickSnapshot t = TickSnapshot.InitializeFromFile(temp);
        }

        public void CreateGraphics(StatField field, Color[] colors)
        {
            _creator.GetMap(_current, field,  colors);
        }
    }
}
