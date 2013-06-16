using System;

namespace PSC2013.ES.GUI.Review.Panels
{
    public interface IReviewPanel<T> : IRawReviewPanel
    {
        /// <summary>
        /// The information, the panel is holding.
        /// </summary>
        T ContentInformation { get; }
    }
}