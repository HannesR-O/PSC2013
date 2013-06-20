using System;
using System.Windows.Forms;

namespace PSC2013.ES.GUI.Review.Panels
{
    public partial class ReviewSnapshotSelectPanel : UserControl, IReviewPanel<string[]>
    {
        public ReviewSnapshotSelectPanel()
        {
            InitializeComponent();
        }

        public bool ValidateData()
        {
            // always true, because it is possible to just generate charts...
            return true;
        }

        public void SetProgressBarStyle(ProgressBarStyle style)
        {
            this.ProgressBar_Main.Style = style;
        }

        public ListBox TheListBox
        {
            get { return ListBox_Snapshots; }
        }

        public string[] ContentInformation
        {
            get { return GatherInformation(); }
        }

        public Button TheButton
        {
            get { return Btn_Next; }
        }

        private string[] GatherInformation()
        {
            var items = ListBox_Snapshots.SelectedItems;
            string[] strings = new string[items.Count];
            
            int i = 0;
            foreach (var item in items)
                strings[i++] = (string)item;

            return strings;
        }
    }
}