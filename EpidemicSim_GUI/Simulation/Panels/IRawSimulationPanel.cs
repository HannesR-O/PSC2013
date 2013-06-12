using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Simulation.Panels
{
    public interface IRawSimulationPanel
    {
        /// <summary>
        /// The Next-button in the panel.
        /// </summary>
        Button TheButton { get; }

        /// <summary>
        /// Validates the input.
        /// </summary>
        bool ValidateData();
    }
}
