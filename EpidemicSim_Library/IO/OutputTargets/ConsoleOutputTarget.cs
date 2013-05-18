using System;

namespace PSC2013.ES.Library.IO.OutputTargets
{
    public class ConsoleOutputTarget : IOutputTarget
    {
        /// <summary>
        /// Writes a given message to the ISimulationOutputTarget
        /// </summary>
        /// <param name="message">The message to write</param>
        public void WriteToOutput(string message)
        {
            if (message == null)
                throw new ArgumentNullException("message", "Given message to write cannot be null!");

            Console.WriteLine(message);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(IOutputTarget other)
        {
            return (other != null) && (other is ConsoleOutputTarget);
        }
    }
}