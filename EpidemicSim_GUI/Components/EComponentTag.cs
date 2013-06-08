using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.GUI.Components
{
    public enum EComponentTag
    {
        MaleBaby        = 0,
        MaleChild       = 1,
        MaleAdult       = 2,
        MaleSenior      = 3,
        FemaleBaby      = 4,
        FemaleChild     = 5,
        FemaleAdult     = 6,
        FemaleSenior    = 7,
        
        SimulationDuration,
        SimulationIntervall,
        SnapshotIntervall,
        
        DiseaseName,
        IncubationPeriod,
        IdleTime,
        SpreadingTime,
        Transferability,
        HealingFactors,
        MortalityFactors,
        ResistanceFactors,

        AgeingComponent,
        InfectionComponent,
        DiseaseEffectComponent,
        MindsetComponent,
        MovementComponent
    }
}
