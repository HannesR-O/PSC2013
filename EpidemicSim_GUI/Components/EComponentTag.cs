using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC2013.ES.GUI.Components
{
    public enum EComponentTag
    {
        None,

        MaleBaby        = 1,
        MaleChild       = 2,
        MaleAdult       = 3,
        MaleSenior      = 4,
        FemaleBaby      = 5,
        FemaleChild     = 6,
        FemaleAdult     = 7,
        FemaleSenior    = 8,
        
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
