using System;
using System.Web;

namespace AspHandler
{
    public class TotalDurationHandlerArgs : EventArgs
    {
        public double TotalTime { get; set; }
        public int Requests { get; set; }
    }
    public class TotalDurationModule : IHttpModule
    {
        private double _totalTime = 0;
        private int _requestCount = 0;

        public void Init(HttpApplication app)
        {
            app.PreRequestHandlerExecute += HandleEvent;
            app.PostRequestHandlerExecute += HandleEvent;
        }

        
        public void HandleEvent(Object src, EventArgs args)
        {
            HttpContext context = ((HttpApplication)src).Context;
            if (!context.IsPostNotification)
            {
                context.Items["total_time"] = _totalTime;
            }
            else if(context.Handler is IRequiresDurationData)
            {
                _totalTime = (double)context.Items["total_time"];
                _requestCount++;
                System.Diagnostics.Debug.WriteLine(string.Format("Total Duration is {0}ms for {1} requests", _totalTime, _requestCount));
            }
        }

        public void Dispose() { }

    }
}
