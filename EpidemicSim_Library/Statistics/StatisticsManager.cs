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

            if (File.Exists(path))
            _currentArchive = ZipFile.Open(path, ZipArchiveMode.Read);
            else 
                throw new FileNotFoundException("File not found!");

            ZipArchiveEntry first = null;
            Entrys = new List<string>();
            foreach (ZipArchiveEntry entry in _currentArchive.Entries)
            {
                if (!entry.Name.Equals("header"))
                {
                    Entrys.Add(entry.Name);
                    if (entry.Name.StartsWith("1"))
                    {
                        first = entry;
                        Console.WriteLine(entry.Name + " is first. Initializing...");
                    }
                }
            }

            try
            {
                byte[] file = ArchiveReader.ToByteArray(_currentArchive.GetEntry("header")); // Reading Header                
                _simInfo = SimulationInfo.InitializeFromFile(file);
            }
            catch (Exception e)
            {
                throw new SimFileCoruptException("The Header was not found!", e);
            }
           
            if (Directory.Exists(mapDestination))
                _creator = new MapCreator(mapDestination, _simInfo.MapX, _simInfo.MapY);
            else
                throw new DirectoryNotFoundException("Destination does not Exists");
            _currentSnapshot = null;

            if (first == null)
                throw new SimFileCoruptException("No first Snapshot found!");
            
                byte[] temp = ArchiveReader.ToByteArray(first);// Reading first Snap to initialize Maxima
                TickSnapshot tick = TickSnapshot.InitializeFromFile(temp);
                _creator.InitializeMaxima(tick);
                _currentSnapshot = tick;            
        }

        public void LoadTickSnapshot(String name)
        {
            if (!name.StartsWith(_currentSnapshot.Tick.ToString()))
            {
                byte[] temp = ArchiveReader.ToByteArray(_currentArchive.GetEntry(name));

                _currentSnapshot = TickSnapshot.InitializeFromFile(temp);
            }
        }

        public Dictionary<String, Color> CreateGraphics(EStatField field, EColorPalette colors, string namePrefix)
        {
            if (_currentArchive != null)
            {
                if (_currentSnapshot != null)
                {
                    return _creator.GetMap(_currentSnapshot, field, colors, namePrefix);
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

        public void CreateDeathGraphics(EColorPalette colors, EDeathField field, string namePrefix)
        {
            if (_currentArchive != null)
            {
                if (_currentSnapshot != null)
                {
                    _creator.GetDeathMap(_currentSnapshot, field, colors, namePrefix);
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

        public class SimFileCoruptException : Exception
        {
            public SimFileCoruptException() { }
            public SimFileCoruptException(string Massage) { }
            public SimFileCoruptException(string message, System.Exception innerException) { }
        }
    }
}