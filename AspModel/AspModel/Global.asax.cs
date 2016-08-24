using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace AspModel
{
    public class Global : System.Web.HttpApplication
    {
        private DateTime _startTime;
        protected void Application_Start(object sender, EventArgs e)
        {
            EventCollection.Add(EventSource.Application, "Start");
            Application["message"] = "Application Events";
        }

        protected void Application_End(object sender, EventArgs e)
        {
            EventCollection.Add(EventSource.Application, "End");
        }

        //public override void Init()
        //{
        //    IHttpModule mod = Modules["AverageTime"];
        //    if (mod is AverageTimeModule)
        //    {
        //        (mod as AverageTimeModule).NewAverage += (src, args) =>
        //        {
        //            Response.Write(string.Format("<h3>Ave Time: {0:F2}ms</h3>", args.AverageTime));
        //        };
        //    }
        //}

        public void AverageTime_NewAverage(Object sender, AverageTimeEventArgs args)
        {
            Response.Write(string.Format("<h3>Globle Event Method - Ave Time: {0:F2}ms</h3>", args.AverageTime));
        }

        //protected void Application_BeginRequest(Object sender, EventArgs e)
        //{
        //    _startTime = Context.Timestamp;
        //}

        //protected void Application_EndRequest(Object sender, EventArgs e)
        //{
        //    double elapsed = DateTime.Now.Subtract(_startTime).TotalMilliseconds;
        //    System.Diagnostics.Debug.WriteLine("Duration: {0} {1}ms", Request.RawUrl, elapsed);
        //}

        //protected void Application_PostAuthentication(Object sender, EventArgs e)
        //{
        //    if(Request.Url.LocalPath == "/Params.aspx" &&
        //        !User.Identity.IsAuthenticated)
        //    {
        //        Context.AddError(new UnauthorizedAccessException());
        //    }
        //}

        //protected void Application_LogRequest(Object sender, EventArgs e)
        //{
        //    System.Diagnostics.Debug.WriteLine(
        //        string.Format("Request for {0} = Code {1}",
        //            Request.RawUrl, Response.StatusCode));
        //}
    }
}