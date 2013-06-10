using System;

namespace PSC2013.ES.GUI.Miscellaneous
{
    public interface IContainer
    {
        /// <summary>
        /// The containers type.
        /// </summary>
        EContainer ContainerType { get; }
    }

    public enum EContainer
    {
        NONE,

        SimulationFirstContainer,
        SimulationSecondContainer,

        ReviewFirstContainer,
        ReviewSecondContainer
    }
}