using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC2013.ES.Library.Statistics.Pictures;

namespace PSC2013.ES.GUI.Review.Panels
{
    public partial class ReviewInformationPanel : UserControl, IReviewPanel<EStatField>
    {
        public ReviewInformationPanel()
        {
            InitializeComponent();

            InitEvents();
        }

        private void InitEvents()
        {
            Comp_Category.Changed += OnCategoryChange;
        }

        private void OnCategoryChange(object sender, EventArgs e)
        {
            if (Comp_Category.GetValue())
            {
                Comp_Diseased.LabelText = "Diseased";
                Comp_Infected.LabelText = "Infected";
            }
            else
            {
                // TODO | dj | specify
                Comp_Diseased.LabelText = "IDK";
                Comp_Infected.LabelText = "IDK";
            }
        }

        public EStatField ContentInformation
        {
            get { throw new NotImplementedException(); }
        }

        public Button TheButton
        {
            get { return Btn_Next; }
        }
    }
}
