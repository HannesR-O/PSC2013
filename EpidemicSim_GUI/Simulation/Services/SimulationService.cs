using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC2013.ES.GUI.Components;
using PSC2013.ES.GUI.Miscellaneous;
using PSC2013.ES.Library;
using PSC2013.ES.Library.AreaData;
using PSC2013.ES.Library.IO.Readers;
using PSC2013.ES.Library.Simulation;
using PSC2013.ES.Library.Simulation.Components;

namespace PSC2013.ES.GUI.Simulation.Services
{
    public class SimulationService : IService
    {
        public event EventHandler<ServiceEventArgs> ChangeWorkingArea;

        private SimulationFirstContainer _firstContainer;
        private SimulationSecondContainer _secondContainer;

        private string _depPath;
        private DepartmentMapReader _mapReader;
        private EpidemicSimulator _simulator;
        private bool _firstDepartment;

        private Task _runningTask;
        private CancellationTokenSource _cancellationTokenSource;

        public SimulationService(string path)
        {
            _depPath = path;
            _mapReader = new DepartmentMapReader(_depPath);
            _mapReader.IsWritingEnabled = false;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void StartService()
        {
            ChangeWorkingArea.Raise(this,
                new ServiceEventArgs {
                    RequestedContainer = EContainer.SimulationFirstContainer
                });

            _firstContainer.StartlocationPanel.SetProgressBarStyle(ProgressBarStyle.Marquee);
            _runningTask = Task.Run(() => LoadMap());

            _firstContainer.FinalClick += FirstContainer_FinalClick;
        }

        public void ReactToAnswer(IContainer container)
        {
            switch (container.ContainerType)
            {
                case EContainer.SimulationFirstContainer:
                    _firstContainer = (SimulationFirstContainer)container;
                    break;
                case EContainer.SimulationSecondContainer:
                    _secondContainer = (SimulationSecondContainer)container;
                    break;
                default:
                    break;
            }
        }

        public bool CanClose
        {
            get { return _runningTask == null || _runningTask.Status != TaskStatus.Running; }
        }

        private void FirstContainer_FinalClick(object sender, EventArgs e)
        {
            // Map-Task still running.
            if (!CanClose)
            {
                MessageBox.Show("Waiting for a background-task to finish.", "Task still running...");
                return;
            }

            // everything's fine.
            NextContainer();
        }

        private void NextContainer()
        {
            ChangeWorkingArea.Raise(this,
                new ServiceEventArgs {
                    RequestedContainer = EContainer.SimulationSecondContainer
                });

            _secondContainer.Focus();
            _secondContainer.StartClick += SecondContainer_StartClick;
            _secondContainer.OuputPanel.TheButton.Click += SecondContainer_AbortClick;
        }

        private void SecondContainer_AbortClick(object sender, EventArgs e)
        {
            if (_simulator != null && _simulator.IsSimulating)
                _simulator.StopSimulation();
            else
                _cancellationTokenSource.Cancel(); // TODO | dj | does not work
            SetProgressBarToFinished();
        }

        private void SecondContainer_StartClick(object sender, EventArgs e)
        {
            _secondContainer.OuputPanel.SetProgressBarStyle(ProgressBarStyle.Marquee);
            // start the simulation-construction in an extra task.
            _runningTask = Task.Run(() => StartSim(), _cancellationTokenSource.Token);
        }

        private void StartSim()
        {
            _firstDepartment = true;

            ListBoxOutputTarget lbot = new ListBoxOutputTarget(
                _secondContainer.OuputPanel.GetOutputListBox());

            SimulationSettingsContainer sc = _firstContainer.InfoSettings;

            _simulator = EpidemicSimulator.Create(
                _firstContainer.InfoDisease,
                _depPath,
                lbot,
                OnReaderIterationPassed,
                OnDepartmentCalculated,
                _secondContainer.InfoStartTime,
                GetSimComponents(sc.Components));

            _simulator.SetSimulationIntervall(sc.SimulationIntervall);
            _simulator.SetSnapshotIntervall(sc.SnapshotIntervall);

            _simulator.SimulationStarted += OnSimulationStarted;
            _simulator.TickFinished += OnTickFinished;
            _simulator.SimulationEnded += OnSimulationEnded;
            _simulator.ProcessFinished += OnProcessFinished;
            _simulator.SnapshotWritten += OnSnapshotWritten;

            _simulator.StartSimulation(_secondContainer.InfoDestination,
                _firstContainer.InfoStartlocations, sc.SimulationDuration);
        }

        #region OnEventMethods
        private void OnSimulationStarted(object sender, SimulationEventArgs e)
        {
            _secondContainer.OuputPanel.Invoke(new Action(() =>
            {
                if (_simulator.SimulationDuration == 0)
                    _secondContainer.OuputPanel.SetProgressBarStyle(ProgressBarStyle.Marquee);
                else
                {
                    _secondContainer.OuputPanel.SetProgressBarValue(0);
                    _secondContainer.OuputPanel.SetProgressBarMax((int)
                           (_simulator.SimulationDuration +
                           ((float)_simulator.SimulationDuration / _simulator.SimulationIntervall /
                            _simulator.SnapshotIntervall) +
                           3)); /* Start: 1
                                  * Ended: 1
                                  * Finished: 1
                                  */
                }
            }));
            IncreaseProgressBar();
        }

        private void OnTickFinished(object sender, SimulationEventArgs e)
        {
            IncreaseProgressBar();
        }

        private void OnDepartmentCalculated(object sender, GeneratorEventArgs e)
        {
            if (_firstDepartment)
            {
                _secondContainer.OuputPanel.Invoke(new Action(() =>
                    {
                        _secondContainer.OuputPanel.SetProgressBarMax(e.Total);
                    }));
                _firstDepartment = false;
            }
            IncreaseProgressBar();
        }

        private void OnReaderIterationPassed(object sender, ContinuationEventArgs e)
        {
            _secondContainer.OuputPanel.Invoke(new Action(() =>
                {
                    if (e.Continuing)
                        _secondContainer.OuputPanel.SetProgressBarStyle(ProgressBarStyle.Marquee);
                    else if (e.Finished)
                        _secondContainer.OuputPanel.SetProgressBarStyle(ProgressBarStyle.Continuous);
                }));
        }

        private void OnSnapshotWritten(object sender, EventArgs e)
        {
            IncreaseProgressBar();
        }

        private void OnSimulationEnded(object sender, SimulationEventArgs e)
        {
            IncreaseProgressBar();
        }

        private void OnProcessFinished(object sender, EventArgs e)
        {
            SetProgressBarToFinished();
        }
        #endregion

        private void IncreaseProgressBar()
        {
            _secondContainer.OuputPanel.Invoke(new Action(() => 
                {
                    _secondContainer.OuputPanel.IncreaseProgressBarValue();
                }));
        }

        private void SetProgressBarToFinished()
        {
            _secondContainer.OuputPanel.Invoke(new Action(() =>
                {
                    _secondContainer.OuputPanel.SetProgressBarStyle(ProgressBarStyle.Continuous);
                    _secondContainer.OuputPanel.SetProgressBarToMaxValue();
                }));
        }

        private void LoadMap()
        {
            var info = _mapReader.ReadFile();
            ListBox lb = _firstContainer.StartlocationPanel.TheListBox;
            lb.Invoke(new Action(() => lb.Items.AddRange(info)));

            var img = _mapReader.ReadImage();
            var cont = _firstContainer.StartlocationPanel;
            cont.Invoke(new Action(() => cont.SetImage(img)));

            cont.Invoke(new Action(() => cont.SetProgressBarStyle(ProgressBarStyle.Continuous)));
        }

        private SimulationComponent[] GetSimComponents(EComponentTag[] tags)
        {
            SimulationComponent[] comps = new SimulationComponent[tags.Length];

            for (int i = 0; i < tags.Length; ++i)
            {
                SimulationComponent c = null; // | dj | not the most secure way but it should work.
                switch (tags[i])
                {
                    case EComponentTag.AgeingComponent:
                        c = new AgeingComponent(110);
                        break;
                    case EComponentTag.InfectionComponent:
                        c = new InfectionComponent();
                        break;
                    case EComponentTag.DiseaseTickComponent:
                        c = new DiseaseTickComponent();
                        break;
                    case EComponentTag.DiseaseDeathComponent:
                        c = new DiseaseDeathComponent();
                        break;
                    case EComponentTag.DiseaseHealingComponent:
                        c = new DiseaseHealingComponent();
                        break;
                    case EComponentTag.MindsetComponent:
                        c = new MindsetComponent();
                        break;
                    case EComponentTag.MovementComponent:
                        c = new MovementComponent();
                        break;
                }
                comps[i] = c;
            }

            // if no (diseasetick-)component given: debug-infection
            //if (comps.Length == 0) comps = new SimulationComponent[1] { new DebugInfectionComponent() };
            if (!comps.Any(x => x is InfectionComponent))
            {
                SimulationComponent[] temp = new SimulationComponent[comps.Length + 1];
                comps.CopyToOtherArray(temp);
                temp[comps.Length] = new DebugInfectionComponent();
                comps = temp;
                temp = null;
            }
            return comps;
        }
    }
}