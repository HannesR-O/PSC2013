using System;
using System.Windows.Forms;
using PSC2013.ES.GUI.Miscellaneous;
using PSC2013.ES.Library.IO.Readers;
using PSC2013.ES.Library;
using System.Threading.Tasks;
using PSC2013.ES.Library.Simulation.Components;
using PSC2013.ES.GUI.Components;
using PSC2013.ES.Library.Simulation;

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

        private Task _runningTask;

        public SimulationService(string path)
        {
            _depPath = path;
            _mapReader = new DepartmentMapReader(_depPath);
            _mapReader.IsWritingEnabled = false;
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
            if (_runningTask.Status == TaskStatus.Running)
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

            _secondContainer.StartClick += SecondContainer_StartClick;
            _secondContainer.OuputPanel.TheButton.Click += SecondContainer_AbortClick;
        }

        private void SecondContainer_AbortClick(object sender, EventArgs e)
        {
            _simulator.StopSimulation();
            SetProgressBarToFinished();
        }

        private void SecondContainer_StartClick(object sender, EventArgs e)
        {
            ListBoxOutputTarget lbot = new ListBoxOutputTarget(
                _secondContainer.OuputPanel.GetOutputListBox());

            SettingsContainer sc = _firstContainer.InfoSettings;

            _simulator = EpidemicSimulator.Create(
                _firstContainer.InfoDisease,
                _depPath,
                lbot,
                GetSimComponents(sc.Components));
            _simulator.SetSimulationIntervall(sc.SimulationIntervall);
            _simulator.SetSnapshotIntervall(sc.SnapshotIntervall);

            _simulator.SimulationStarted += OnSimulationStarted;
            _simulator.TickFinished += OnTickFinished;
            _simulator.SimulationEnded += OnSimulationEnded;
            // TODO | dj | more
        }

        private void OnSimulationStarted(object sender, SimulationEventArgs e)
        {
            // if(e.SimulationIntervall == 0)
            //   _secondContainer.OuputPanel.SetProgressBarStyle(ProgressBarStyle.Marquee);
            // else
            //   _secondContainer.OuputPanel.SetProgressBarMax(
            //          e.SimulationIntervall + e.SimulationIntervall / e.SnapshotIntervall + 3); //?
        }

        private void OnTickFinished(object sender, SimulationEventArgs e)
        {
            _secondContainer.OuputPanel.IncreaseProgressBarValue();
        }

        private void OnSimulationEnded(object sender, SimulationEventArgs e)
        {
            // TODO | dj | do we have to react on this? maybe one step forward...
        }

        private void SetProgressBarToFinished()
        {
            _secondContainer.OuputPanel.SetProgressBarStyle(ProgressBarStyle.Continuous);
            _secondContainer.OuputPanel.SetProgressBarToMaxValue();
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
                    case EComponentTag.DiseaseEffectComponent:
                        c = new DiseaseEffectComponent();
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

            // if no component given: debug-infection
            if (comps.Length == 0) comps = new SimulationComponent[1] { new DebugInfectionComponent() };
            return comps;
        }
    }
}