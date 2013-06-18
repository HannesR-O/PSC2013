using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC2013.ES.GUI.Miscellaneous;
using PSC2013.ES.Library;
using PSC2013.ES.Library.Statistics;

namespace PSC2013.ES.GUI.Review.Services
{
    public class ReviewService : IService
    {
        public event EventHandler<ServiceEventArgs> ChangeWorkingArea;

        private ReviewFirstContainer _firstContainer;

        private string _simPath;
        private StatisticsManager _statsManager;

        private Task _runningTask;

        public ReviewService(string simFilePath)
        {
            _simPath = simFilePath;
        }

        public void StartService()
        {
            ChangeWorkingArea.Raise(this,
                new ServiceEventArgs {
                    RequestedContainer = EContainer.ReviewFirstContainer
                });


            _runningTask = Task.Run(() => LoadEntries());
            
            _firstContainer.FinalClick += FirstContainer_FinalClick;
        }

        private void LoadEntries()
        {
            _statsManager = new StatisticsManager(_simPath);

            var cont = _firstContainer.SnapshotsSelectPanel;

            cont.Invoke(new Action(() => cont.TheListBox.Items.AddRange(_statsManager.ReviewManager.Entries.ToArray())));
            cont.Invoke(new Action(() => cont.SetProgressBarStyle(ProgressBarStyle.Continuous)));
        }

        private void FirstContainer_FinalClick(object sender, EventArgs e)
        {
            if (!CanClose)
            {
                MessageBox.Show("Waiting for a background-task to finish.", "Task still running...");
                return;
            }

            NextContainer();
        }

        private void NextContainer()
        {
            ChangeWorkingArea.Raise(this,
                new ServiceEventArgs {
                    RequestedContainer = EContainer.ReviewSecondContainer
                });

            // TODO | dj | continue...
        }

        public void ReactToAnswer(IContainer container)
        {
            switch (container.ContainerType)
            {
                case EContainer.ReviewFirstContainer:
                    _firstContainer = (ReviewFirstContainer)container;
                    break;
                case EContainer.ReviewSecondContainer:
                    // TODO | dj | continue.
                    break;
                default:
                    break;
            }
        }

        public bool CanClose
        {
            get { return _runningTask == null || _runningTask.Status != TaskStatus.Running; }
        }
    }
}
