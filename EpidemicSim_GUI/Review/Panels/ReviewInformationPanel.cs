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
using PSC2013.ES.GUI.Components;

namespace PSC2013.ES.GUI.Review.Panels
{
    public partial class ReviewInformationPanel : UserControl, IReviewPanel<EStatField>
    {
        public static readonly string[] DISEASED = new string[] { "Diseased:", "Death through disease:",
            "Selects all humans being diseased.", "Selects all humans died as a result of the disease."};
        public static readonly string[] INFECTED = new string[] { "Infected:", "Death through age:",
            "Selects all humans being infected.", "Selects all humans died as a result of high age."};

        public ReviewInformationPanel()
        {
            InitializeComponent();

            InitEvents();
        }

        public bool ValidateData()
        {
            return ContentInformation != 0;
        }

        #region events
        private void InitEvents()
        {
            Comp_Category.Changed += OnCategoryChange;
            Comp_All.Clicked += OnAllClick;
            Comp_Male.Clicked += OnAllMaleClick;
            Comp_Female.Clicked += OnAllFemaleClick;
        }

        private void OnCategoryChange(object sender, EventArgs e)
        {
            int i = Comp_Category.GetValue() ? 0 : 1;

            Comp_Diseased.LabelText = DISEASED[i];
            Comp_Diseased.ToolTip = DISEASED[i + 2];

            Comp_Infected.LabelText = INFECTED[i];
            Comp_Infected.ToolTip = INFECTED[i + 2];
        }

        private void OnAllClick(object sender, EventArgs e)
        {
            bool b = Comp_All.GetValue();
            CheckMale(b);
            CheckFemale(b);
        }

        private void OnAllMaleClick(object sender, EventArgs e)
        {
            CheckMale(Comp_Male.GetValue());
        }

        private void OnAllFemaleClick(object sender, EventArgs e)
        {
            CheckFemale(Comp_Female.GetValue());
        }

        private void CheckMale(bool check)
        {
            CheckEmAll(check, Panel_Male.Controls);
        }

        private void CheckFemale(bool check)
        {
            CheckEmAll(check, Panel_Female.Controls);
        }

        private void CheckEmAll(bool check, ControlCollection controls)
        {
            foreach (var item in controls)
            {
                var comp = item as BoolComponent;
                if (comp != null)
                {
                    comp.SetValue(check);
                    if (comp.ComponentTag == EComponentTag.None)
                        comp.Changed += (_, e) => OnMajorChanged(comp, e);
                    else
                        comp.Changed += (_, e) => OnMinorChanged(comp, e);
                }
            }
        }

        private void OnMajorChanged(object sender, EventArgs e)
        {
            var comp = sender as SettingsComponent<bool>;
            if (comp == null || comp.GetValue())
                return;

            Comp_All.SetValue(false);
        }

        private void OnMinorChanged(object sender, EventArgs e)
        {
            var comp = sender as SettingsComponent<bool>;
            if (comp == null || comp.GetValue())
                return;

            if ((int)comp.ComponentTag <= 4)    // male
                Comp_Male.SetValue(false);
            else                                // female
                Comp_Female.SetValue(false);

        }
        #endregion

        public EStatField ContentInformation
        {
            get { return GatherInformation(); }
        }

        public Button TheButton
        {
            get { return Btn_Next; }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            int width = GrpBox_Main.Width / 2 - 9;

            Panel_Male.Width = width;
            Panel_Female.Width = width;
            Panel_Female.Left = Panel_Male.Left + width + 6;
        }

        private EStatField GatherInformation()
        {
            EStatField field = 0;

            field = CombineFields(field, Panel_Male.Controls);
            field = CombineFields(field, Panel_Female.Controls);

            if (Comp_Infected.GetValue())
                field |= (EStatField)0x100;
            if (Comp_Diseased.GetValue())
                field |= (EStatField)0x200;

            if (!Comp_Category.GetValue())      // if dead, the 11th bit is set.
                field |= (EStatField)0x400;

            return field;
        }

        private EStatField CombineFields(EStatField field, ControlCollection controls)
        {
            foreach (var item in controls)
            {
                var comp = item as SettingsComponent<bool>;
                if (comp != null && comp.ComponentTag != EComponentTag.None && comp.GetValue())
                {
                    int tag = (int)comp.ComponentTag - 1;
                    field |= (EStatField)(int)Math.Pow(2, tag);
                }
            }
            return field;
        }
    }
}
