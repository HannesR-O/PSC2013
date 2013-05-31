using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PSC2013.ES.Library.IO.OutputTargets;
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

        private int _snapshotInterval;
        private long _simDuration;
        private int _realtimeTick;

        private Disease _disease;
        private string _depFilePath;
        private DepartmentMapReader _departmentReader;

        private Image _originalImage;
        private List<int> _startInfectionPoints;

        private NewSimulationForm()
        {
            InitializeComponent();
            _startInfectionPoints = new List<int>();
        }

        public NewSimulationForm(string filepath) : this()
        {
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
            _originalImage = _departmentReader.ReadImage();
            MainPanel_pictureBox.Image = _originalImage;
        }

        private void StartSimulation()
        {
            /* TODO |f| now gets the correct values even if valueChanged was not raised.. 
             * still need to remove unecessary eventmethods since they are no longer needed */
            ParseInputs();

            TestSimulation();
        }

        private void ParseInputs()
        {
            _disease.IncubationPeriod = (int)numField_incubationperiod.Value;
            _disease.IdleTime = (int)numField_idle.Value;
            _disease.SpreadingTime = (int)numField_spreading.Value;
            _disease.Transferability = (int)numField_transferability.Value;
            _realtimeTick = (int)numField_realtimetick.Value;
            _snapshotInterval = (int)numField_snapshotInterval.Value;
            _simDuration = (long)numField_simduration.Value;
        }

        private void TestSimulation()
        {
            EpidemicSimulator _epidemicSim = EpidemicSimulator.Create(
                _disease, _depFilePath,
                new DebugSimulationComponent(),
                new AgeingSimulationComponent(110),
                new MovementSimulationComponent(),
                new InfectionCalculatorComponent());
            _epidemicSim.SetSimulationIntervall(_realtimeTick);
            _epidemicSim.SetSnapshotIntervall(_snapshotInterval);
            _epidemicSim.AddOutputTarget(new ConsoleOutputTarget());
            _epidemicSim.SimulationStarted += (sender, args) => Console.WriteLine("Simulation started!");
            _epidemicSim.TickFinished += (sender, args) => Console.WriteLine("Tick finished!");
            _epidemicSim.SimulationEnded += (sender, args) => Console.WriteLine("Simulation finished!");

            Dictionary<int, int> dict = new Dictionary<int, int>();
            Random r = new Random();
            foreach (int item in _startInfectionPoints)
                dict[item] = r.Next(15) + 3;

            _epidemicSim.StartSimulation(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                new InfectionInitState { DesiredInfection = dict },
                _simDuration);
        }

        // == EVENTS ====== \\

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
            var dlp = new DiseaseLocationPanel {Dock = DockStyle.Right};
            this.Controls.Add(dlp);
            _departmentReader.IterationPassed += (s, arg) =>
            {
                if (arg != null && arg.Finished)
                    dlp.ProgressBar.Invoke(() =>
                    {
                        dlp.ProgressBar.Style = ProgressBarStyle.Continuous;
                        dlp.ProgressBar.Value = 100;
                    });
            };

            Task.Factory.StartNew(() =>
                {
                    DepartmentInfo[] info = _departmentReader.ReadFile();
                    dlp.ListBoxDepartments.Invoke(() =>
                        {
                            ListBox lb = dlp.ListBoxDepartments;                // viewing results.
                            var lst = info.Select(x => x.Name).ToList();
                            lst.Sort();                                         // sorting the output
                            lb.Items.AddRange(lst.ToArray());                   // for better usage.
                            lst = null;

                            dlp.ProgressBar.Visible = false;                    // building up the...

                            Size progBarSize = dlp.ProgressBar.Size;

                            Button btn_back = new Button
                            {
                                    Text = "< Back",
                                    Size = new Size(progBarSize.Width / 2 - 5, progBarSize.Height),
                                    Location = dlp.ProgressBar.Location,
                                    Parent = dlp.ProgressBar.Parent,
                                    Visible = true,
                                    Enabled = true
                            }; // ...back-button.
                            btn_back.Click += (orig, args) => this.Invoke(() =>
                                {
                                    this.Controls.Remove(dlp);
                                    this.MainSidePanel.Visible = true;
                                });

                            Button btn = new Button
                            {
                                    Text = "Start",
                                    Size = new Size(progBarSize.Width / 2 - 5, progBarSize.Height),
                                    Location = new Point(dlp.ProgressBar.Location.X + progBarSize.Width / 2 + 5,
                                                         dlp.ProgressBar.Location.Y),
                                    Parent = dlp.ProgressBar.Parent,
                                    Visible = true,
                                    Enabled = false
                            }; // ...start-button.
                            btn.Click += (orig, args) => StartSimulation();

                            lb.SelectedIndexChanged += (_, __) => // changes on selection.
                                {
                                    if (lb.SelectedIndices.Count > 0)
                                    {
                                        List<string> items = lb.SelectedItems.Cast<string>().ToList();

                                        Task.Run(() =>
                                            {
                                                // Wait-Cursor
                                                this.Invoke(() => this.Cursor = Cursors.WaitCursor);

                                                // Modify image
                                                Bitmap img = (Bitmap)_originalImage.Clone();
                                                _startInfectionPoints.Clear();
                                                foreach (string item in items)
                                                {
                                                    DepartmentInfo dep = info.First(x => x.Name.Equals(item));
                                                    foreach (Point p in dep.Coordinates)
                                                    {
                                                        _startInfectionPoints.Add(p.Flatten(img.Width));
                                                        img.SetPixel(p.X, p.Y, Color.Cyan);
                                                    }
                                                }

                                                // Show new image
                                                MainPanel_pictureBox.Invoke(() =>
                                                    {
                                                        MainPanel_pictureBox.Image = img;
                                                        MainPanel_pictureBox.Refresh();
                                                    });

                                                // Default-Cursor
                                                this.Invoke(() => this.Cursor = Cursors.Default);
                                            });
                                        btn.Enabled = true;
                                    }
                                    else
                                    {
                                        MainPanel_pictureBox.Image = _originalImage;
                                        btn.Enabled = false;
                                    }
                                };
                        });
                });
            //Task.Factory.StartNew(() =>
            //    {
            //        return _departmentReader.ReadFile();                                // reading file.
            //    }).ContinueWith((information) =>
            //        dlp.ListBoxDepartments.Invoke(                                      // continuing with
            //            new ListBoxDelegate((lb, info) =>                               // adding result to list.
            //                lb.Items.AddRange(info.Select(x => x.Name).ToArray())),
            //                dlp.ListBoxDepartments, information.Result)
            //    ).ContinueWith((_) => // TODO | dj | THIS IS NOT THE ACTUAL NEXT STEP!!!
            //        dlp.Invoke(new PanelUpdate((panel) =>                               // now hiding progressbar
            //        {                                                                   // and adding button.
            //            panel.ProgressBar.Visible = false;
            //            Button btn = new Button();
            //            btn.Text = "Start";
            //            btn.Size = panel.ProgressBar.Size;
            //            btn.Location = panel.ProgressBar.Location;
            //            btn.Parent = panel.ProgressBar.Parent;
            //            btn.Visible = true;
            //            btn.Click += (orig, args) => StartSimulation();
            //        }),
            //        dlp));

            // TODO | dj | continue.
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
