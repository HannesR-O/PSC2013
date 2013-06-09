using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.GUI.Components
{
    public interface ISettingsComponent
    {
        /// <summary>
        /// The tag of this component.
        /// </summary>
        EComponentTag ComponentTag
        { get; set; }
    }
}
