using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Statistics.Pictures
{
    /// <summary>
    /// Enmum for classifing which field should be selected
    /// </summary>
    public enum EStatField : int
    {
        MaleBaby = 0, 
        MaleChild = 1, 
        MaleAdult = 2,
        MaleSenior = 3, 
        FemaleBaby = 4,
        FemaleChild = 5,
        FemaleAdult = 6,
        FemaleSenior = 7,
        Infected = 8,
        Diseased = 9,
        AllMale = 10,
        AllFemale = 11,
        AllHumans = 12
    }
}
