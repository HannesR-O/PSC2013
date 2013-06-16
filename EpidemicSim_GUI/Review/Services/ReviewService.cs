using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC2013.ES.GUI.Miscellaneous;
using PSC2013.ES.Library;

namespace PSC2013.ES.GUI.Review.Services
{
    public class ReviewService : IService
    {
        public event EventHandler<ServiceEventArgs> ChangeWorkingArea;

        private ReviewFirstContainer _firstContainer;

        private string _simPath;

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

            // TODO | dj | continue.

            throw new NotImplementedException();
        }

        public void ReactToAnswer(IContainer container)
        {
            // TODO | dj | continue.
            switch (container.ContainerType)
            {
                case EContainer.ReviewFirstContainer:
                    _firstContainer = (ReviewFirstContainer)container;
                    break;
                case EContainer.ReviewSecondContainer:
                    break;
                default:
                    break;
            }
            throw new NotImplementedException();
        }

        public bool CanClose
        {
            get { return _runningTask == null || _runningTask.Status != TaskStatus.Running; }
        }
    }
}
