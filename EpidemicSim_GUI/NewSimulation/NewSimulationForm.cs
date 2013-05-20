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

        private delegate void ProgressBarDelegate(ProgressBar pb);
        private delegate void ListBoxDelegate(ListBox lb);
        private delegate void PanelUpdateDelegate(DiseaseLocationPanel panel);
        private delegate void PictureBoxDelegate(PictureBox picturebox);
        private delegate void LastOpportunityControlDelegate(Control ctrl);

        private int _snapshotInterval;
        private long _simDuration;
        private int _realtimeTick;

        private Disease _disease;
        private string _depFilePath;
        private DepartmentMapReader _departmentReader;

        private Image _originalImage;

        private NewSimulationForm()
        {
            InitializeComponent();
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
                    DepartmentInfo[] info = _departmentReader.ReadFile();
                    dlp.ListBoxDepartments.Invoke(new PanelUpdateDelegate(
                        (panel) =>
                        {
                            ListBox lb = panel.ListBoxDepartments;                      // viewing results.
                            var lst = info.Select(x => x.Name).ToList();
                            lst.Sort();                                                 // sorting the output
                            lb.Items.AddRange(lst.ToArray());                           // for better usage.
                            lst = null;

                            panel.ProgressBar.Visible = false;                          // building up the...

                            Size progBarSize = panel.ProgressBar.Size;

                            Button btn_back = new Button();                             // ...back-button.
                            btn_back.Text = "< Back";
                            btn_back.Size = new Size(progBarSize.Width / 2 - 5,
                                progBarSize.Height);
                            btn_back.Location = panel.ProgressBar.Location;
                            btn_back.Parent = panel.ProgressBar.Parent;
                            btn_back.Visible = true;
                            btn_back.Enabled = true;
                            btn_back.Click += (orig, args) =>
                                {
                                    this.Invoke(new LastOpportunityControlDelegate((obj) =>
                                        {
                                            this.Controls.Remove(panel);
                                            this.MainSidePanel.Visible = true;
                                        }), this);
                                };

                            Button btn = new Button();                                  // ...start-button.
                            btn.Text = "Start";
                            btn.Size = new Size(progBarSize.Width / 2 - 5,
                                progBarSize.Height);
                            btn.Location = new Point(panel.ProgressBar.Location.X +
                                progBarSize.Width / 2 + 5,
                                panel.ProgressBar.Location.Y);
                            btn.Parent = panel.ProgressBar.Parent;
                            btn.Visible = true;
                            btn.Enabled = false;
                            btn.Click += (orig, args) => StartSimulation();

                            lb.SelectedIndexChanged += (_, __) =>                       // changes on selection.
                                {
                                    if (lb.SelectedIndices.Count > 0)
                                    {
                                        List<string> items = new List<string>();
                                        foreach (string item in lb.SelectedItems)
                                            items.Add(item);

                                        Task.Run(() =>
                                            {
                                                // Wait-Cursor
                                                this.Invoke(new LastOpportunityControlDelegate(
                                                    (ctrl) => ctrl.Cursor = Cursors.WaitCursor), this);

                                                // Modify image
                                                Bitmap img = (Bitmap)_originalImage.Clone();
                                                foreach (string item in items)
                                                {
                                                    DepartmentInfo dep = info.First(x => x.Name.Equals(item));
                                                    foreach (Point p in dep.Coordinates)
                                                        img.SetPixel(p.X, p.Y, Color.Cyan);
                                                }

                                                // Show new image
                                                MainPanel_pictureBox.Invoke(
                                                    new PictureBoxDelegate((box) =>
                                                        {
                                                            box.Image = img;
                                                            box.Refresh();
                                                        }),
                                                    MainPanel_pictureBox);

                                                // Default-Cursor
                                                this.Invoke(new LastOpportunityControlDelegate(
                                                    (ctrl) => ctrl.Cursor = Cursors.Default), this);
                                            });
                                        btn.Enabled = true;
                                    }
                                    else
                                    {
                                        MainPanel_pictureBox.Image = _originalImage;
                                        btn.Enabled = false;
                                    }
                                };
                        }), dlp);
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
