using System;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Miscellaneous
{
    /// <summary>
    /// Interface for major services.
    /// Known implementations: SimulationService, ReviewService
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Called if the service requests another
        /// container in the WorkingArea.
        /// </summary>
        event EventHandler<ServiceEventArgs> ChangeWorkingArea;

        /// <summary>
        /// Starts the service itself.
        /// </summary>
        void StartService();

        /// <summary>
        /// Let the service react to the given "answer".
        /// </summary>
        void ReactToAnswer(IContainer container);

        /// <summary>
        /// Returns whether the service can be shut
        /// down or not.
        /// </summary>
        bool CanClose { get; }
    }

    public class ServiceEventArgs : EventArgs
    {
        public EContainer RequestedContainer { get; set; }
    }
}