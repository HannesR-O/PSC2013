using System;
using PSC2013.ES.Library.Statistics.Pictures;

namespace PSC2013.ES.GUI.Miscellaneous
{
    public class ReviewSettingsContainer
    {
        public EColorPalette ColorPalette { get; set; }

        public string DestinationPath { get; set; }

        public string Prefix { get; set; }

        public bool[] SelectedDiagrams { get; set; }
    }
}