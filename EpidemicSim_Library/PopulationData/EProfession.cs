using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.Library.PopulationData
{
  
    public enum EProfession : byte
    {
        //Maximum count for Professions = 16
        Pupil, //At Home from 18-7; At School from 7-(10-14); Chance to visit friends from 14-18; Weekend : ???; Holidays : ?
        Student, 
        DeskJobber, 
        Plumber, 
        Housewife, 
        Commuter, 
        TravellingSalesman, 
        Unemployed 
    }
}
