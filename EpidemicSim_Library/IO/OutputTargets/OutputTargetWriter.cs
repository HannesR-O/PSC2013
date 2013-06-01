using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// sended toward the IOutputTargets.
        /// </summary>
        protected bool IsSymbolEnabled { get; set; }

        private ISet<IOutputTarget> _targets;

        private OutputTargetWriter()
        {
            _targets = new HashSet<IOutputTarget>();
            IsSymbolEnabled = true;
        }

        protected OutputTargetWriter(string symbol) : this()
        {
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
        protected virtual void WriteMessage(string message)
        {
            if (IsSymbolEnabled)
                message = Symbol + ": " + message;

            foreach (IOutputTarget target in _targets)
                target.WriteToOutput(message);
        }
    }
}
