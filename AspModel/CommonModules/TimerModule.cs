using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CommonModules
{
    public class TimerEventArgs : EventArgs
    {
        public double Duration { get; set; }
    }
    public class TimerModule: IHttpModule
    {
        private DateTime _startTime;
        public event EventHandler<TimerEventArgs> RequestTimed;

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += HandleEvent;
            context.EndRequest += HandleEvent;
        }

        private void HandleEvent(object sender, EventArgs e)
        {
            HttpApplication app = sender as HttpApplication;
            switch (app.Context.CurrentNotification)
            {
                case RequestNotification.BeginRequest:
                    _startTime = app.Context.Timestamp;
                    break;
                case RequestNotification.EndRequest:
                    double elapsed = DateTime.Now.Subtract(_startTime).Milliseconds;
                    System.Diagnostics.Debug.WriteLine(string.Format("Timer Module: Duration: {0} {1}ms",
                        app.Request.RawUrl, elapsed));
                    if (RequestTimed != null)
                    {
                        RequestTimed(this, new TimerEventArgs { Duration = elapsed });
                    }
                    break;
            }
           
        }
    }
}
