using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using PSC2013.ES.Library.IO.OutputTargets;
using PSC2013.ES.Library.Snapshot;
using PSC2013.ES.Library.Statistics.Pictures;
using PSC2013.ES.Library.IO.Readers;

namespace PSC2013.ES.Library.Statistics
{
    /// <summary>
    /// Manages taken SimulationSnapshots and creates Statistics out of its contents
    /// Steps:
    /// 1. Open a Simfile (Opens Siminfo and loads first entry)
    /// 2. Open another a Ticksnapshot or go straight to 3.
    /// 3. Work with it (Map or Deathmap)
    /// </summary>
    public class StatisticsManager : OutputTargetWriter
    {
        public List<string> Entries { get; private set; }
        public SimulationInfo SimInfo { get; private set; }
        public TickSnapshot LoadedSnapshot { get; private set; }

        private ZipArchive _currentArchive;
        private MapCreator _creator;

        public StatisticsManager() : base ("SM")
        { }

        /// <summary>
        /// Opens a new .sim File and restores the contents to Runtime;
        /// Only one can be opened at a time
        /// </summary>
        /// <param name="path">The path where the file is located</param>
        public void OpenSimFile(string path)
        {
            if (_currentArchive != null)
                _currentArchive.Dispose();

            if (File.Exists(path))
                _currentArchive = ZipFile.Open(path, ZipArchiveMode.Read);
            else 
                throw new FileNotFoundException("File not found!");

            ZipArchiveEntry first = null;
            Entries = new List<string>();
            foreach (ZipArchiveEntry entry in _currentArchive.Entries) // Reading all entries
            {
                if (!entry.Name.Equals("header")) // All except header...
                {
                    Entries.Add(entry.Name);
                    if (entry.Name.StartsWith("1_")) // The first entry
                    {
                        first = entry;
                    }
                }
            }

            try // If there's no header, the file is corrupt // yeah, with two r's 
            {
                byte[] file = ArchiveReader.ToByteArray(_currentArchive.GetEntry("header")); // Reading Header                
                SimInfo = SimulationInfo.InitializeFromFile(file);
            }
            catch (Exception e)
            {
                throw new SimFileCorruptException("The Header was not found!", e);
            }
           
            _creator = new MapCreator(SimInfo.MapX, SimInfo.MapY);
            _creator.setTarget(Path.GetDirectoryName(path)); // Setting Default Destination

            LoadedSnapshot = null;

            if (first == null) // If there's no first Snapshot, the file corrupt, no sense in empty logs
                throw new SimFileCorruptException("No first Snapshot found!");
            
            byte[] temp = ArchiveReader.ToByteArray(first);// Reading first Snap to initialize Maxima
            TickSnapshot tick = TickSnapshot.InitializeFromFile(temp);
            _creator.InitializeMaxima(tick);
            WriteMessage(first.Name + " is first. Initializing...");
            LoadedSnapshot = tick; // First Snaphsot stays loaded
        }

        /// <summary>
        /// Changes the Directory where Pictures are stored
        /// </summary>
        /// <param name="destination">The new Destination</param>
        public void SetNewDestination(string destination)
        {
            if (Directory.Exists(destination))
                _creator.setTarget(destination);
            else 
                throw new FileNotFoundException("Destination at " + destination + " could not be found");
        }

        /// <summary>
        /// Loads a Ticksnapshot to Runtime, when loaded, i can be used to create graphics
        /// </summary>
        /// <param name="name">The Entries name</param>
        public void LoadTickSnapshot(String name)
        {
            if (!name.StartsWith(LoadedSnapshot.Tick + "_"))
            {
                byte[] temp = ArchiveReader.ToByteArray(_currentArchive.GetEntry(name));

                LoadedSnapshot = TickSnapshot.InitializeFromFile(temp);
            }
        }

        /// <summary>
        /// Returns the Caption of the last created Picture
        /// </summary>
        /// <returns>The Caption, null, if no Pic was created so far</returns>
        public Dictionary<string, Color> GetCaption()
        {            
            return _creator.GetCaption();
        }

        /// <summary>
        /// Creates a Graphic of the loaded Snapshot with the given parameters
        /// </summary>
        /// <param name="field">A concatenation of EStatfields to be used</param>
        /// <param name="colors">The Colorpalette to be used</param>
        /// <param name="namePrefix">The Prefix the data shall be named with</param>
        /// <returns></returns>
        public void CreateGraphics(EStatField field, EColorPalette colors, string namePrefix)
        {
            if (_currentArchive != null)
            {
                if (LoadedSnapshot != null)
                {
                    _creator.GetMap(LoadedSnapshot, field, colors, namePrefix);
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

        /// <summary>
        /// Creates Graphics with the same Parameters for multiple Snapshots
        /// </summary>
        /// <param name="entries">The List of Snapshots</param>
        /// <param name="field">The desired Field</param>
        /// <param name="colors">The desired ColorPalette</param>
        /// <param name="namePrefix">The desired Prefix</param>
        public void CreateMulipleGraphics(List<string> entries, EStatField field, EColorPalette colors, string namePrefix)
        {
            int i = 1;
            int size = entries.Count;
            foreach (string entry in entries)
            {
                if(Entries.Contains(entry))
                {
                    WriteMessage("Loading " + entry + "...");
                    LoadTickSnapshot(entry);
                    CreateGraphics(field, colors, namePrefix);
                    WriteMessage(String.Format("{0,3} of {1} graphics finished.", i, size));
                    ++i;
                }
                else
                {
                    WriteMessage(entry + " could not be created");
                    ++i;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="colors"></param>
        /// <param name="field"></param>
        /// <param name="namePrefix"></param>
        public void CreateDeathGraphics(EStatField field, EColorPalette colors, string namePrefix)
        {
            if (_currentArchive != null)
            {
                if (LoadedSnapshot != null)
                {
                    _creator.GetDeathMap(LoadedSnapshot, field, colors, namePrefix);
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

        /// <summary>
        /// Creates DeathGraphics with the same Parameters for multiple Snapshots
        /// </summary>
        /// <param name="entries">The List of Snapshots</param>
        /// <param name="field">The desired Field</param>
        /// <param name="colors">The desired ColorPalette</param>
        /// <param name="namePrefix">The desired Prefix</param>
        public void CreateMultipleDeathGraphics(List<string> entries, EStatField field, EColorPalette colors, string namePrefix)
        {
            int i = 1;
            int size = entries.Count;
            foreach (string entry in entries)
            {
                if (Entries.Contains(entry))
                {
                    WriteMessage("Loading " + entry + "...");
                    LoadTickSnapshot(entry);
                    CreateDeathGraphics(field, colors, namePrefix);
                    WriteMessage(String.Format("{0,3} of {1} graphics finished.", i, size));
                    ++i;
                }
                else
                {
                    WriteMessage(entry + " could not be created");
                    ++i;
                }
            }
        }

        /// <summary>
        /// SimFile is Corrupted, if something is missing inside a .Sim. Doesn't consider
        /// whether archive itself is corrupt
        /// </summary>
        public sealed class SimFileCorruptException : Exception
        {
            public SimFileCorruptException() { }
            public SimFileCorruptException(string Massage) { }
            public SimFileCorruptException(string message, System.Exception innerException) { }
        }
    }
}