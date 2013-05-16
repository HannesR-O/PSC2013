using System;
using System.Drawing;
using System.Collections.Generic;
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
        public List<string> Entrys { get; private set; }

        private SimulationInfo _simInfo;
        private ZipArchive _currentArchive;
        private TickSnapshot _currentSnapshot;

        private MapCreator _creator;

        /// <summary>
        /// Opens a new .sim File and restores the contents to Runtime;
        /// Only one can be opened at a time
        /// </summary>
        /// <param name="path">The path where the file is located</param>
        /// <param name="mapDestination">Where the Pictures should be saved</param>
        public void OpenSimFile(string path, string mapDestination)
        {
            if (_currentArchive != null)
                _currentArchive.Dispose();

            _currentArchive = ZipFile.Open(path, ZipArchiveMode.Read);

            Entrys = new List<string>();
            foreach (ZipArchiveEntry entry in _currentArchive.Entries)
            {
                if (entry.Name != "header") // Very dirty, but won't need to open every file to look it up;
                    Entrys.Add(entry.Name);
            }

            byte[] file = ArchiveReader.ToByteArray(_currentArchive.GetEntry("header"));
            _simInfo = SimulationInfo.InitializeFromFile(file);

            _creator = new MapCreator(mapDestination, _simInfo.MapX, _simInfo.MapY);
            _currentSnapshot = null;
        }

        public void LoadTickSnapshot(String name)
        {
            byte[] temp = ArchiveReader.ToByteArray(_currentArchive.GetEntry(name));

            _currentSnapshot = TickSnapshot.InitializeFromFile(temp);
        }

        public void CreateGraphics(EStatField field, Color[] colors, string namePrefix)
        {
            if (_currentArchive != null)
            {
                if (_currentSnapshot != null)
                {
                    _creator.GetMap(_currentSnapshot, field, colors, namePrefix);
                }
                else
                {
                    throw new ApplicationException("No Snapshot is opened!");
                }
            }
            else
            {
                throw new ApplicationException("No File loaded");
            }
        }

        public void CreateDeathGraphics(Color[] colors)
        {
            if (_currentArchive != null)
            {
                if (_currentSnapshot != null)
                {
                    _creator.GetDeathMap(_currentSnapshot, colors);
                }
                else
                {
                    throw new ApplicationException("No Snapshot is opened!");
                }
            }
            else
            {
                throw new ApplicationException("No File loaded");
            }
        }
    }
}
