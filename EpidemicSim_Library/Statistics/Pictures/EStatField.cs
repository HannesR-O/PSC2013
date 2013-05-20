﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.Statistics.Pictures
{
    /// <summary>
    /// Enum for classifing which field should be selected
    /// </summary>
    [Flags]
    public enum EStatField : int
    {
        MaleBaby = 0x01, 
        MaleChild = 0x02, 
        MaleAdult = 0x04,
        MaleSenior = 0x08, 
        FemaleBaby = 0x10,
        FemaleChild = 0x20,
        FemaleAdult = 0x40,
        FemaleSenior = 0x80,
        Infected = 0x100,
        Diseased = 0x200,
        AllMale = 0x400,
        AllFemale = 0x800,
        AllHumans = 0x1000
        /* TODO | dj |
         * Shouldn't All~ be accessible by
         * concatinating the fields?
         * e.g. AllMale = MaleBaby | MaleChild | MaleAdult | MaleSenior
         * |t| We are not even halfway done here Anyway...
         */
    }
}
