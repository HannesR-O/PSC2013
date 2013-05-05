using System;

namespace PSC2013.ES.Library.IO
{
    public interface IOutputTarget : IEquatable<IOutputTarget>
    {
        /// <summary>
        /// Writes a given message to the ISimulationOutputTarget
        /// </summary>
        /// <param name="message">The message to write</param>
        void WriteToOutput(string message);
        /* TODO: |f| Several things:
         * - Consider adding methods and/or enums to determine MessageLevels
         * - Move OutputTargets into own folder/namespace? 
         * - Where to implement GUI variants of this Interface? Library or GUI project?
         */
    }
}