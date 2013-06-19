using System;
using System.Windows.Forms;
using PSC2013.ES.GUI.Miscellaneous;
using PSC2013.ES.Library.Statistics.Pictures;

namespace PSC2013.ES.GUI.Review.Panels
{
    public partial class ReviewSettingsPanel : UserControl, IReviewPanel<ReviewSettingsContainer>
    {
        public ReviewSettingsPanel()
        {
            InitializeComponent();
            var vals = Enum.GetNames(typeof(EColorPalette));
            this.Comp_Palette.AddRange(vals);
            this.Comp_Palette.SetValue(vals[0]);
        }

        public Button TheButton
        {
            get { return this.Btn_Next; }
        }

        public ReviewSettingsContainer ContentInformation
        {
            get { return GatherInformation(); }
        }

        private ReviewSettingsContainer GatherInformation()
        {
            var rsc = new ReviewSettingsContainer();

            EColorPalette pal;
            Enum.TryParse<EColorPalette>((string)Comp_Palette.GetValue(), out pal);
            rsc.ColorPalette = pal;

            rsc.DestinationPath = this.Comp_Destination.GetValue();

            rsc.Prefix = this.Comp_Prefix.GetValue();

            rsc.SelectedDiagrams = new bool[] {
                this.Comp_AgeDiagram.GetValue(),
                this.Comp_AllDiagram.GetValue()
            };

            return rsc;
        }
    }
}