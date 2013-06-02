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

        private ISet<IOutputTarget> _targets;

        protected OutputTargetWriter(string symbol)
        {
            _targets = new HashSet<IOutputTarget>();
            IsSymbolEnabled = true;
            IsWritingEnabled = true;

            Symbol = symbol;
        }

        /// <summary>
        /// Tries to add the target to the writer-list.
        /// </summary>
        protected bool RegisterTarget(IOutputTarget target)
        {
            return _targets.Add(target);
        }

        /// <summary>
        /// Tries to remove the target from the writer-list.
        /// </summary>
        protected bool UnregisterTarget(IOutputTarget target)
        {
            return _targets.Remove(target);
        }

        /// <summary>
        /// Calls all targets to write the given message.
        /// If IsSymbolEnabled is true, the symbol will
        /// be added to the string.
        /// </summary>
        protected void WriteMessage(string message)
        {
            if (!IsWritingEnabled)
                return;

            if (IsSymbolEnabled)
                message = Symbol + ": " + message;

            foreach (IOutputTarget target in _targets)
                target.WriteToOutput(message);
        }
    }
}
