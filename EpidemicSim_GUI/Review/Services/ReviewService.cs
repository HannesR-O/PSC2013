using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSC2013.ES.GUI.Miscellaneous;
using PSC2013.ES.Library;
using PSC2013.ES.Library.IO.OutputTargets;
using PSC2013.ES.Library.Statistics;
using PSC2013.ES.Library.Statistics.Pictures;

namespace PSC2013.ES.GUI.Review.Services
{
    public class ReviewService : IService
    {
        public event EventHandler<ServiceEventArgs> ChangeWorkingArea;

        private ReviewFirstContainer _firstContainer;
        private ReviewSecondContainer _secondContainer;

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

            CreateGraphics();
            // TODO | dj | continue...
        }

        private void CreateGraphics()
        {
            var settings = _firstContainer.InfoSettings;
            
            string destination = settings.DestinationPath;
            string prefix = settings.Prefix;
            EColorPalette colorPalette = settings.ColorPalette;
            bool[] diagrams = settings.SelectedDiagrams;
            EStatField fields = _firstContainer.InfoInformation;
            string[] entries = _firstContainer.InfoSnapshots;
            int entryCount = _statsManager.ReviewManager.Entries.Count;

            _secondContainer.OutputPanel.SetProgressBarMax(
                (diagrams.Contains(true)? entryCount + 2 : 0) + entries.Length + 1);
            _secondContainer.OutputPanel.SetProgressBarValue(0);
            _secondContainer.OutputPanel.SetProgressBarStyle(ProgressBarStyle.Continuous);

            OutputTargetManager.GetInstance().RegisterTarget(
                new ListBoxOutputTarget(_secondContainer.OutputPanel.TheListBox));

            _runningTask = Task.Run(() => GenerateGraphics(
                prefix, destination, colorPalette, diagrams, fields, entries));
        }

        private void GenerateGraphics(string prefix, string destination,
            EColorPalette colorPalette, bool[] diagrams, EStatField fields, string[] entries)
        {   // parallel run
            IncreaseProgressBar();

            _statsManager.SnapshotAnalized += (_, __) => IncreaseProgressBar();
            _statsManager.AnalyzingFinished += (_, __) => IncreaseProgressBar();
            _statsManager.ReviewManager.GraphicDone += (_, __) => IncreaseProgressBar();

            if (diagrams.Contains(true))
                _statsManager.AnalyzeSimulation();

            _statsManager.ReviewManager.SetNewDestination(destination);

            if (fields.HasFlag((EStatField)0x400))
                _statsManager.ReviewManager.CreateMultipleDeathGraphics(
                    new List<string>(entries), fields, colorPalette, prefix);
            else
                _statsManager.ReviewManager.CreateMultipleGraphics(
                    new List<string>(entries), fields, colorPalette, prefix);
            
            FinishProgressBar();
            OutputTargetManager.GetInstance().WriteMessage("Done");
        }

        private void IncreaseProgressBar()
        {
            var pan = _secondContainer.OutputPanel;
            pan.Invoke(new Action(() => pan.IncreaseProgressBarValue()));
        }

        private void FinishProgressBar()
        {
            var pan = _secondContainer.OutputPanel;
            pan.Invoke(new Action(() => pan.SetProgressBarToMaxValue()));
        }

        public void ReactToAnswer(IContainer container)
        {
            switch (container.ContainerType)
            {
                case EContainer.ReviewFirstContainer:
                    _firstContainer = (ReviewFirstContainer)container;
                    _firstContainer.Focus();
                    break;
                case EContainer.ReviewSecondContainer:
                    _secondContainer = (ReviewSecondContainer)container;
                    _secondContainer.Focus();
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
