using System.Collections.Generic;

namespace PSC2013.ES.Library.IO.OutputTargets
{
    /// <summary>
    /// OutputTargetWriter provides the implementation
    /// to manage several IOutputTargets and to send a
    /// message to them.
    /// </summary>
    public abstract class OutputTargetWriter
    {
        /// <summary>
        /// Representing the current writer as a short
        /// (unique) string.
        /// </summary>
        protected string Symbol { get; set; }
        /// <summary>
        /// Gets or sets, whether the Symbol will be
        /// forwarded towards the IOutputTargets.
        /// </summary>
        public bool IsSymbolEnabled { get; set; }
        /// <summary>
        /// Gets or sets, whether the message will
        /// be forwarded to the IOutputTargets.
        /// </summary>
        public bool IsWritingEnabled { get; set; }

        protected OutputTargetWriter(string symbol)
        {
            IsSymbolEnabled = true;
            IsWritingEnabled = true;

            Symbol = symbol;
        }

        /// <summary>
        /// Calls the OutputTargetManager to write the
        /// given message to alla targets.
        /// If IsSymbolEnabled is true, the symbol will
        /// be added to the string.
        /// Nothing will be written, if IsWritingEnabled
        /// is false.
        /// </summary>
        protected void WriteMessage(string message)
        {
            if (!IsWritingEnabled)
                return;

            if (IsSymbolEnabled)
                message = Symbol + ": " + message;

            OutputTargetManager.GetInstance().WriteMessage(message);
        }
    }
}