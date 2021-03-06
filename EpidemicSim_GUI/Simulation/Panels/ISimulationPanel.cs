﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Simulation.Panels
{
    public interface ISimulationPanel<T> : IRawSimulationPanel
    {
        /// <summary>
        /// The information, the panel is holding.
        /// </summary>
        T ContentInformation { get; }
    }
}
