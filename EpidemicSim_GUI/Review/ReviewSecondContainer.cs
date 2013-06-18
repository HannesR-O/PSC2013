using System;
using System.Windows.Forms;
using PSC2013.ES.GUI.Miscellaneous;

namespace PSC2013.ES.GUI.Review
{
    public partial class ReviewSecondContainer : UserControl, IContainer
    {
        public ReviewSecondContainer()
        {
            InitializeComponent();
        }

        public EContainer ContainerType
        {
            get { return EContainer.ReviewSecondContainer; }
        }
    }
}