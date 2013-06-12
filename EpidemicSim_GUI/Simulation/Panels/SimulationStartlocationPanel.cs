using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC2013.ES.Library;
using PSC2013.ES.Library.AreaData;

namespace PSC2013.ES.GUI.Simulation.Panels
{
    public partial class SimulationStartlocationPanel : UserControl, ISimulationPanel<InfectionInitState>
    {
        private Image _origImg;

        public SimulationStartlocationPanel()
        {
            InitializeComponent();
        }

        public bool ValidateData()
        {
            throw new NotImplementedException();
        }

        public void SetProgressBarStyle(ProgressBarStyle style)
        {
            ProgressBar_Main.Style = style;
        }

        public void SetImage(Image img)
        {
            PictBox_SelectedDepartments.Image = img;
            _origImg = img;
        }

        public ListBox TheListBox
        {
            get { return ListBox_Departments; }
        }

        public Button TheButton
        {
            get { return this.Btn_Next; }
        }

        public InfectionInitState ContentInformation
        {
            get { return new InfectionInitState { DesiredInfection = GatherInformation() }; }
        }

        private Dictionary<int, int> GatherInformation()
        {
            var dict = new Dictionary<int, int>();
            int totalToInfect = Comp_InfectedCount.GetValue();

            DepartmentInfo[] deps = null;
            if (ListBox_Departments.InvokeRequired)
                ListBox_Departments.Invoke(new Action(() => deps = GetSelectedDepartments()));
            else
                deps = GetSelectedDepartments();

            int totalPeople = deps.Sum(x => x.GetTotal());
            double factor = (double)totalToInfect / totalPeople;

            foreach (var item in deps)
            {
                int coords = item.Coordinates.Length;
                foreach (var p in item.Coordinates)
                {
                    int index = p.Flatten(_origImg.Width);
                    dict.Add(index, (int)(item.GetTotal() * factor / coords--));
                }
            }

            // TODO | dj | test!

            return dict;
        }

        private DepartmentInfo[] GetSelectedDepartments()
        {
            var sel = ListBox_Departments.SelectedItems;

            DepartmentInfo[] deps = new DepartmentInfo[sel.Count];

            int i = 0;
            foreach (var item in sel)
                deps[i++] = (DepartmentInfo)item;

            return deps;
        }

        private void ListBox_Departments_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Task t = Task.Run(() => SetPictureBoxImage());
            t.ContinueWith((_) => Cursor.Current = Cursors.Default);
        }

        private void SetPictureBoxImage()
        {
            PictBox_SelectedDepartments.Invoke(new Action(() =>
                {
                    PictBox_SelectedDepartments.Image = MarkSelections();
                }));
        }

        private Bitmap MarkSelections()
        {
            DepartmentInfo[] deps = GetSelectedDepartments();

            Bitmap bmp = (Bitmap)_origImg.Clone();

            foreach (var dep in deps)
            {
                foreach (var p in dep.Coordinates)
                {
                    bmp.SetPixel(p.X, p.Y, Color.Cyan);
                }
            }

            return bmp;
        }
    }
}
