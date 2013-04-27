using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.PopulationData
{
    public enum EMindset : byte
    {
        //Maximum count of Mindsets = 16
        Stationary, // -> really sick at hospital
        HomeStaying,// -> ill at home or "Today i don't feel like doing anything" 
        Working,    // dependent on profession
        Vacationing,
        DayOff,     //weekend, holiday, took a day off work etc.
        Shopping
    }
}
