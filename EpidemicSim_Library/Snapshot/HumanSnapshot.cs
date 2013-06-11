using System;
using System.Linq;
using PSC2013.ES.Library.PopulationData;

namespace PSC2013.ES.Library.Snapshot
{
    /// <summary>
    /// A snapshot of a Human, containing only important data. Can only be created from given values and is immutable.
    /// </summary>
    public class HumanSnapshot
    {
        public const byte LENGTH = 12;
        
        public byte Gender { get; private set; }
        public byte Age { get; private set; }
        public byte Profession { get; private set; }
        public int HomeCell { get; private set; }
        public int DeathCell { get; private set; }
        public bool Cause { get; private set; } // false = Natural, true = Disease

        /// <summary>
        /// A Snapshot of a dead Human
        /// </summary>
        /// <param name="gender">The gender</param>
        /// <param name="age">The age</param>
        /// <param name="profession">The profession</param>
        /// <param name="homeCell">The HomeCell</param>
        /// <param name="deathCell">The DeathCell</param>
        /// <param name="cause">The CauseOfDeath. false = Natural, true = Disease</param>
        private HumanSnapshot(byte gender, byte age,
            byte profession, int homeCell, int deathCell, bool cause)
        {
            Gender = gender;
            Age = age;
            Profession = profession;
            HomeCell = homeCell;
            DeathCell = deathCell;
            Cause = cause;
        }

        /// <summary>
        /// Initializes a new Humansnapshot from runtime
        /// </summary>
        /// <param name="gender">The dead humans gender</param>
        /// <param name="age">The dead humans age</param>
        /// <param name="profession">The dead humans profession</param>
        /// <param name="homeCell">The dead humans homecell</param>
        /// <param name="deathCell">The dead humans deathcell</param>
        /// <param name="cause">The dead humans deathcause. false = Natural, true = Disease</param>
        /// <returns></returns>
        public static HumanSnapshot InitializeFromRuntime(byte gender, byte age,
            byte profession, int homeCell, int deathCell, bool cause)
        {
            return new HumanSnapshot(gender, age, profession, homeCell, deathCell, cause);
        }
        
        /// <summary>
        /// Initializes a new HumanSnapshot form a byte()
        /// </summary>
        /// <param name="bytes">The Informations from a file</param>
        /// <returns>A new HumanSnapshot from the information</returns>
        public static HumanSnapshot InitializeFromFile(byte[] bytes)
        {
            byte gender = bytes[0];
            byte age = bytes[1];
            byte profession = bytes[2];
            int homeCell = BitConverter.ToInt32(bytes, 3);
            int deathCell = BitConverter.ToInt32(bytes, 7);
            bool cause = BitConverter.ToBoolean(bytes, 11);

            return new HumanSnapshot(gender, age, profession, homeCell, deathCell, cause);
        }
     
        /// <summary>
        /// Returns the Dead Humans informations in an byte[]
        /// </summary>
        /// <returns>Dead Humans Infos as byte[]</returns>
        public byte[] getBytes()
        {
            byte[] output = new byte[LENGTH];

            Array.Copy(BitConverter.GetBytes(Gender), 0, output, 0, 1);
            Array.Copy(BitConverter.GetBytes(Age), 0, output, 1, 1);
            Array.Copy(BitConverter.GetBytes(Profession), 0, output, 2, 1);
            Array.Copy(BitConverter.GetBytes(HomeCell), 0, output, 3, 4);
            Array.Copy(BitConverter.GetBytes(DeathCell), 0, output, 7, 4);
            Array.Copy(BitConverter.GetBytes(Cause), 0, output, 11, 1);
            return output;
        }
    }
}