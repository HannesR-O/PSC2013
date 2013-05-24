namespace PSC2013.ES.Library.PopulationData
{
    public enum EMindset : byte
    {
        //Maximum count of Mindsets = 16
        Working,    // dependent on profession
        Stationary, // -> really sick at hospital
        HomeStaying,// -> ill at home or "Today i don't feel like doing anything" 
        Vacationing,
        DayOff,     //weekend, holiday, took a day off work etc.
    }
}