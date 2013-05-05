using System;
using PSC2013.ES.Library.Snapshot;
using PSC2013.ES.Library.Statistics.Pictures;
using System.IO;
using System.IO.Compression;

namespace PSC2013.ES.Library.Statistics
{
    /// <summary>
    /// Manages taken SimulationSnapshots and creates Statistics out of its contents
    /// </summary>
    public class StatisticsManager
    {
        private SimulationInfo _simInfo;
        private TickSnapshot[] _snapshots;

        private MapCreator _creator;

        /// <summary>
        /// Opens a new .sim File and restores the contents to Runtime;
        /// Only one can be opened at a time
        /// </summary>
        /// <param name="path">The path where the file is located</param>
        public void OpenSimFile(string path)
        {
            ZipArchive archive = ZipFile.Open(path, ZipArchiveMode.Read);

            ZipArchiveEntry head = archive.GetEntry("header");
            var stream = head.Open(); // |t| Please kill it with fire!!
            var mem = new MemoryStream();
            stream.CopyTo(mem);
            byte[] a = mem.ToArray();

            _simInfo = SimulationInfo.InitializeFromFile(a);
            Console.WriteLine(_simInfo.Disease.Name);

            ZipArchiveEntry snap = archive.GetEntry("2_[21-18-49]");
            var stream2 = snap.Open(); // |t| Please kill it with fire!!
            var mem2 = new MemoryStream();
            stream2.CopyTo(mem2);
            byte[] b = mem2.ToArray();

            TickSnapshot t = TickSnapshot.InitializeFromFile(b);
            Console.ReadKey();
        }

        public void CreateGraphics(TickSnapshot snapshot)
        {
            _creator.GetMaleMap(snapshot, ColorPalette.RED);
        }
    }
}
