using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PSC2013.ES.Library.IO.Readers;
using PSC2013.ES.Library.Diseases;
using System.Threading.Tasks;
using PSC2013.ES.Library.AreaData;
using PSC2013.ES.Library;
using PSC2013.ES.Library.Simulation.Components;
using PSC2013.ES.Library.IO;

namespace PSC2013.ES.GUI.NewSimulation
{
    public partial class NewSimulationForm : Form
    {
        private const string NUMFIELD_NOT_IN_RANGE_EXCEPTION = "The given value is invalid. It must be in range of {0} and {1}.";

        private delegate void ProgressBarDelegate(ProgressBar pb);
        private delegate void ListBoxDelegate(ListBox lb, DepartmentInfo[] info);
        private delegate void PanelUpdate(DiseaseLocationPanel panel);

        private Form _owner;

        private int _snapshotInterval;
        private long _simDuration;
        private int _realtimeTick;

        private Disease _disease;
        private string _depFilePath;
        private DepartmentMapReader _departmentReader;

        private NewSimulationForm()
        {
            InitializeComponent();
        }

        public NewSimulationForm(Form owner, string filepath) : this()
        {
            _owner = owner;

            _depFilePath = filepath;
            
            var facCont = new FactorContainer(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 });
            _disease = new Disease()
            {
                HealingFactor = facCont,
                ResistanceFactor = facCont,
                MortalityRate = facCont
            };

            _departmentReader = new DepartmentMapReader(_depFilePath);

            OpenDepMap();
        }

        private void OpenDepMap()
        {
            Image img = _departmentReader.ReadImage();
            MainPanel_pictureBox.Image = img;
        }

        private void StartSimulation()
        {
            // TODO | dj | adjust and take actual data...
            TestSimulation();
        }

        private void TestSimulation()
        {
            EpidemicSimulator _epidemicSim = EpidemicSimulator.Create(
                _disease, _depFilePath,
                new DebugSimulationComponent(),
                new AgeingSimulationComponent(110),
                new MovementSimulationComponent());
            _epidemicSim.SetSimulationIntervall(_realtimeTick);
            _epidemicSim.SetSnapshotIntervall(_snapshotInterval);
            _epidemicSim.AddOutputTarget(new ConsoleOutputTarget());
            _epidemicSim.SimulationStarted += (sender, args) => Console.WriteLine("Simulation started!");
            _epidemicSim.TickFinished += (sender, args) => Console.WriteLine("Tick finished!");
            _epidemicSim.SimulationEnded += (sender, args) => Console.WriteLine("Simulation finished!");


            _epidemicSim.StartSimulation(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), _simDuration);
        }

        // == EVENTS ====== \\

        protected override void OnClosing(CancelEventArgs e)
        {
            _owner.Show();
            base.OnClosing(e);
        }

        private void btn_mortality_Click(object sender, EventArgs e)
        {
            var dialog = new FactorContainerForm("Mortality");
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
                _disease.MortalityRate = dialog.FactorContainer;
        }

        private void btn_healing_Click(object sender, EventArgs e)
        {
            var dialog = new FactorContainerForm("Healing");
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
                _disease.HealingFactor = dialog.FactorContainer;
        }

        private void btn_resistance_Click(object sender, EventArgs e)
        {
            var dialog = new FactorContainerForm("Resistance");
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
                _disease.ResistanceFactor = dialog.FactorContainer;
        }

        private void numField_Int_ValueChanged(object sender, EventArgs e)
        {
            var numUpDown = sender as NumericUpDown;
            if (numUpDown != null)
            {
                decimal value = numUpDown.Value;
                if (value < 0 || value > int.MaxValue)
                    throw new ArgumentOutOfRangeException("Value",
                        string.Format(NUMFIELD_NOT_IN_RANGE_EXCEPTION, 0, int.MaxValue));
                int intValue = (int)value;
                if (numUpDown == numField_incubationperiod)
                    _disease.IncubationPeriod = intValue;
                else if (numUpDown == numField_idle)
                    _disease.IdleTime = intValue;
                else if (numUpDown == numField_spreading)
                    _disease.SpreadingTime = intValue;
                else if (numUpDown == numField_transferability)
                    _disease.Transferability = intValue;
                else if (numUpDown == numField_realtimetick)
                    _realtimeTick = intValue;
                else if (numUpDown == numField_snapshotInterval)
                    _snapshotInterval = intValue;
            }
        }

        private void numField_long_ValueChanged(object sender, EventArgs e)
        {
            var numUpDown = sender as NumericUpDown;
            if (numUpDown != null)
            {
                decimal value = numUpDown.Value;
                if (value < 0 || value > long.MaxValue)
                    throw new ArgumentOutOfRangeException("Value",
                        string.Format(NUMFIELD_NOT_IN_RANGE_EXCEPTION, 0, long.MaxValue));
                long longValue = (long)value;
                if (numUpDown == numField_simduration)
                    _simDuration = longValue;
            }
        }

        private void txBox_name_TextChanged(object sender, EventArgs e)
        {
            _disease.Name = txBox_name.Text;
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            this.MainSidePanel.Visible = false;
            var dlp = new DiseaseLocationPanel();
            dlp.Dock = DockStyle.Right;
            this.Controls.Add(dlp);
            _departmentReader.IterationPassed += (s, arg) =>
            {
                if (arg != null && arg.Finished)
                    dlp.ProgressBar.Invoke(new ProgressBarDelegate((pb) =>
                        { pb.Style = ProgressBarStyle.Continuous; pb.Value = 100; }),
                        dlp.ProgressBar);
            };

            Task.Factory.StartNew(() =>
                {
                    return _departmentReader.ReadFile();                                // reading file.
                }).ContinueWith((information) =>
                    dlp.ListBoxDepartments.Invoke(                                      // continuing with
                        new ListBoxDelegate((lb, info) =>                               // adding result to list.
                            lb.Items.AddRange(info.Select(x => x.Name).ToArray())),
                            dlp.ListBoxDepartments, information.Result)
                ).ContinueWith((_) => // TODO | dj | THIS IS NOT THE ACTUAL NEXT STEP!!!
                    dlp.Invoke(new PanelUpdate((panel) =>                               // now hiding progressbar
                    {                                                                   // and adding button.
                        panel.ProgressBar.Visible = false;
                        Button btn = new Button();
                        btn.Text = "Start";
                        btn.Size = panel.ProgressBar.Size;
                        btn.Location = panel.ProgressBar.Location;
                        btn.Parent = panel.ProgressBar.Parent;
                        btn.Visible = true;
                        btn.Click += (orig, args) => StartSimulation();
                    }),
                    dlp));

            // TODO | dj | continue.
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
