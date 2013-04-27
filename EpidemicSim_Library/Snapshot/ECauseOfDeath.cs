namespace PSC2013.ES.Library.Snapshot
{
    public enum ECauseOfDeath           //TODO: |f| might wanna move this to PopulationData and implement it to Human?
    {
        Natural = 0,
        Disease = 1                     //TODO: |f| use a bool? (and use 1 bit in Human's free bits?
    }
}