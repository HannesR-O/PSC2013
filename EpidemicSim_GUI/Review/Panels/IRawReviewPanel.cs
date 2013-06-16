using System;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Review.Panels
{
    public interface IRawReviewPanel
    {
        /// <summary>
        /// The final-button in the panel.
        /// </summary>
        Button TheButton { get; }
    }
}