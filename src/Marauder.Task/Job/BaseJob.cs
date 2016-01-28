using NLog;

namespace Marauder.Task.Job
{
    public class BaseJob
    {
        protected readonly Logger Log;

        public BaseJob()
        {
            this.Log = LogManager.GetLogger(this.GetType().Name);
        }
    }
}
