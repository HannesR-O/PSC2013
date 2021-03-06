﻿using System;
using System.Linq;
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
    public class ReviewManager : OutputTargetWriter
    {
        public List<string> Entries { get; private set; }
        public int EntryCount { get { return Entries.Count; } }
        public SimulationInfo SimInfo { get; private set; }
        public TickSnapshot LoadedSnapshot { get; private set; }

        private ZipArchive _currentArchive;
        private MapCreator _creator;

        public event EventHandler<EventArgs> GraphicDone;

        public ReviewManager() : base ("RM")
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
                if (!entry.Name.Equals("header")) // All except header...
                    Entries.Add(entry.Name);

            long minEntry = Entries.Min(x => long.Parse(x.Split('_')[0]));
            first = _currentArchive.Entries.Where(
                    x => !x.Name.Equals("header") &&
                    int.Parse(x.Name.Split('_')[0]) == minEntry
                    ).First();
            

            try // If there's no header, the file is corrupt // yeah, with two r's 
            {
                byte[] file = _currentArchive.GetEntry("header").ToByteArray(); // Reading Header                
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
            
            byte[] temp = first.ToByteArray();// Reading first Snap to initialize Maxima
            TickSnapshot tick = TickSnapshot.InitializeFromFile(temp);
            _creator.InitializeMaxima(tick);
            WriteMessage(first.Name + " is first. Initializing...");
            LoadedSnapshot = tick; // First Snaphsot stays loaded
            Entries.Sort();
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
            {
                Directory.CreateDirectory(destination);
                _creator.setTarget(destination);
            }
        }

        /// <summary>
        /// Loads a Ticksnapshot to Runtime, when loaded, it can be used to create graphics
        /// </summary>
        /// <param name="name">The Entries name</param>
        public void LoadTickSnapshot(String name)
        {
            string[] nameSplit = name.Split('_');
            long tick;
            long.TryParse(nameSplit[0], out tick);
            if (tick != LoadedSnapshot.Tick)
            {
                byte[] temp = _currentArchive.GetEntry(name).ToByteArray();

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
        public string CreateGraphics(EStatField field, EColorPalette colors, string namePrefix)
        {
            if (_currentArchive != null)
            {
                if (LoadedSnapshot != null)
                {
                    return _creator.GetMap(LoadedSnapshot, field, colors, namePrefix);
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
        public string[] CreateMultipleGraphics(List<string> entries, EStatField field, EColorPalette colors, string namePrefix)
        {
            int i = 1;
            int size = entries.Count;
            int sizeLength = size.ToString().Length;
            string[] paths = new string[size];
            
            foreach (string entry in entries)
            {
                if(Entries.Contains(entry))
                {
                    WriteMessage("Loading " + entry + "...");
                    LoadTickSnapshot(entry);
                    paths[i-1] = CreateGraphics(field, colors, namePrefix);
                    WriteMessage(String.Format("{0," + sizeLength + "} of {1} graphics finished.", i, size));
                }
                else
                {
                    WriteMessage(entry + " could not be created");
                }
                ++i;
                GraphicDone.Raise(this, null);
            }
            return paths;
        }

        /// <summary>
        /// Creates a Graphic of the dead Humans
        /// </summary>
        /// <param name="field">The desired Field</param>
        /// <param name="colors">The desired ColorPalette</param>
        /// <param name="namePrefix">The desired Prefix</param>
        public string CreateDeathGraphics(EStatField field, EColorPalette colors, string namePrefix)
        {
            if (_currentArchive != null)
            {
                if (LoadedSnapshot != null)
                {
                    return _creator.GetDeathMap(LoadedSnapshot, field, colors, namePrefix);
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
        public string[] CreateMultipleDeathGraphics(List<string> entries, EStatField field, EColorPalette colors, string namePrefix)
        {
            int i = 1;
            int size = entries.Count;
            int sizeLength = size.ToString().Length;
            string[] paths = new string[size];

            foreach (string entry in entries)
            {
                if (Entries.Contains(entry))
                {
                    WriteMessage("Loading " + entry + "...");
                    LoadTickSnapshot(entry);
                    paths[i-1] = CreateDeathGraphics(field, colors, namePrefix);
                    WriteMessage(String.Format("{0," + sizeLength + "} of {1} graphics finished.", i, size));
                }
                else
                {
                    WriteMessage(entry + " could not be created");
                }
                ++i;
                GraphicDone.Raise(this, null);
            }
            return paths;
        }
    }
}