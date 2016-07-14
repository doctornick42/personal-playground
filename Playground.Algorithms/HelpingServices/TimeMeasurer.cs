using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Algorithms.HelpingServices
{
    public class TimeMeasurer
    {
        //public delegate void LogTime();

        //public event LogTime onTimeStop;

        public event Action<string> onWatchStop;

        public void RunAndLogOutTime<T>(T service, Action<T> actionToRun)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            actionToRun(service);
            stopWatch.Stop();

            onWatchStop.Invoke(String.Format("Execution time: {0} ms", stopWatch.ElapsedMilliseconds));
        }
    }
}
