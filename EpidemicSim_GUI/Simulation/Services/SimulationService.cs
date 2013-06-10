using System;
using System.Windows.Forms;
using PSC2013.ES.GUI.Miscellaneous;
using PSC2013.ES.Library.IO.Readers;
using PSC2013.ES.Library;
using System.Threading.Tasks;

namespace PSC2013.ES.GUI.Simulation.Services
{
    public class SimulationService : IService
    {
        public event EventHandler<ServiceEventArgs> ChangeWorkingArea;

        private DepartmentMapReader _mapReader;
        private SimulationFirstContainer _firstContainer;
        private SimulationSecondContainer _secondContainer;

        private Task _runningTask;

        public SimulationService(string path)
        {
            _mapReader = new DepartmentMapReader(path);
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
    }
}