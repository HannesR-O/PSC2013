using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.IO.OutputTargets
{
    /// <summary>
    /// Manages OutputTargets and the messages to them.
    /// </summary>
    public class OutputTargetManager
    {
        #region SINGLETON
        private static OutputTargetManager _instance;
        /// <summary>
        /// Returns the current instance of OutputTargetManager.
        /// If there isn't any, a new one will be constructed.
        /// </summary>
        public static OutputTargetManager GetInstance() // TODO | dj | I would like to make a getter out of it...
        {
            if (_instance == null) _instance = new OutputTargetManager();
            return _instance;
        }
        #endregion

        private ISet<IOutputTarget> _targets;

        private OutputTargetManager()
        {
            _targets = new HashSet<IOutputTarget>();
        }

        /// <summary>
        /// Tries to add the target to the manager,
        /// so it gets notifications.
        /// </summary>
        public bool RegisterTarget(IOutputTarget target)
        {
            return _targets.Add(target);
        }

        /// <summary>
        /// Tries to remove the target from the manager,
        /// so it will no longer receive notifications.
        /// </summary>
        public bool UnregisterTarget(IOutputTarget target)
        {
            return _targets.Remove(target);
        }

        /// <summary>
        /// Notifies all targets to write the given
        /// message to their output.
        /// </summary>
        public void WriteMessage(string message)
        {
            foreach (IOutputTarget target in _targets)
                target.WriteToOutput(message);
        }
    }
}
