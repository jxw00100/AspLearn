using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommonModules;

namespace AspModel
{
    public class AverageTimeEventArgs : EventArgs{
        public double AverageTime {get;set;}
    }
    public class AverageTimeModule: IHttpModule
    {
        private static double totalTime;
        private static int requestCount;
        private static object lockObject = new object();

        public event EventHandler<AverageTimeEventArgs> NewAverage;
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            for (int i = 0; i < context.Modules.Count; i++)
            {
                if (context.Modules[i] is TimerModule)
                {
                    (context.Modules[i] as TimerModule).RequestTimed += (src, args) =>
                    {
                        AddNewDataPoint(args.Duration);
                    };
                    break;
                }

            }
        }

        private void AddNewDataPoint(double duration)
        {
            lock (lockObject)
            {
                double ave = (totalTime += duration) / (++requestCount);
                System.Diagnostics.Debug.WriteLine(string.Format("Average request duration: {0:F2}ms", ave));
                if (NewAverage != null)
                {
                    NewAverage(this, new AverageTimeEventArgs { AverageTime = ave });
                }
            }
        }
    }
}