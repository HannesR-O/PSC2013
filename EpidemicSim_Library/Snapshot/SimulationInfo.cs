using System;
using PSC2013.ES.Library.IO;
using PSC2013.ES.Library.DiseaseData;

namespace PSC2013.ES.Library.Snapshot
{
    /// <summary>
    /// Head-Data for Simulation infos, Contains Dates, Refs etc.
    /// </summary>
    public class SimulationInfo : IBinaryObject
    {
        private const byte HEADER = 0x1;

        public Disease Disease { get; private set; }
        public string Name { get; private set; }
        public int MapX { get; private set; }
        public int MapY { get; private set; }
        public int SimulationInvervall { get; private set; }
        public int SnapshotIntervall { get; private set; }
        public long SimulationDuration { get; private set; }

        private SimulationInfo(Disease disease, int mapX, int mapY, int simintervall, int snapintervall, long duration)
        {
            Disease = disease;
            Name = Disease.Name;
            MapX = mapX;
            MapY = mapY;
            SimulationInvervall = simintervall;
            SnapshotIntervall = snapintervall;
            SimulationDuration = duration;
        }

        /// <summary>
        /// Initializes a new SimulationInfo from Runtime
        /// </summary>
        /// <param name="name">The Simulations Name</param>
        /// <param name="disease">The used Disease</param>
        /// <returns></returns>
        public static SimulationInfo InitializeFromRuntime(Disease disease, int x, int y, int simintervall, int snapintervall, long duration)
        {
            return new SimulationInfo(disease, x, y, simintervall, snapintervall, duration);
        }

        /// <summary>
        /// Initializes a new SimulationInfo from a file
        /// </summary>
        /// <param name="bytes">the byte[] from a file</param>
        /// <returns>A new SimulationInfo</returns>
        public static SimulationInfo InitializeFromFile(byte[] bytes)
        {
            if (bytes[0] != HEADER)
                throw new HeaderCorruptException("Header damaged, should be " + HEADER);
            int x = BitConverter.ToInt32(bytes, 1);
            int y = BitConverter.ToInt32(bytes, 5);
            int simintervall = BitConverter.ToInt32(bytes, 9);
            int snapintervall = BitConverter.ToInt32(bytes, 13);
            long duration = BitConverter.ToInt64(bytes, 17);

            int diseaseSize = bytes.Length - 25; // What's left of the array
            byte[] temp = new byte[diseaseSize];
            Array.Copy(bytes, 25, temp, 0, diseaseSize);
            Disease disease = Disease.FromBytes(temp);

            return new SimulationInfo(disease, x, y, simintervall, snapintervall, duration);
        }

        /// <summary>
        /// Returns the Simulations information in an byte[]
        /// </summary>
        /// <returns>Simulations Infos as byte[]</returns>
        public byte[] GetBytes()
        {
            var output = new byte[Disease.ByteSize + 25];
            output[0] = HEADER;
            Array.Copy(BitConverter.GetBytes(MapX), 0, output, 1, 4);
            Array.Copy(BitConverter.GetBytes(MapY), 0, output, 5, 4);
            Array.Copy(BitConverter.GetBytes(SimulationInvervall), 0, output, 9, 4);
            Array.Copy(BitConverter.GetBytes(SnapshotIntervall), 0, output, 13, 4);
            Array.Copy(BitConverter.GetBytes(SimulationDuration), 0, output, 17, 8);
            Array.Copy(Disease.GetBytes(), 0, output, 25, Disease.ByteSize);
            return output;
        }
    }
}