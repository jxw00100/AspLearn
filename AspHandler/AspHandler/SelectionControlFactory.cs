using System;
using System.Web;

namespace AspHandler
{
    public class SelectionControlFactory : IHttpHandlerFactory
    {

        public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            if (url.ToLower().Replace(".select", string.Empty) == "/time")
            {
                return new CurrentTimeHandler();
            }
            else if (url.ToLower().Replace(".select", string.Empty) == "/day")
            {
                return new CurrentDayHandler();
            }
            else
            {
                return new NotFoundHandler();
            }
        }

        public void ReleaseHandler(IHttpHandler handler)
        {
        }
    }

    public class CurrentTimeHandler: IHttpHandler
    {

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(string.Format("The time is: {0}", DateTime.Now.ToShortTimeString()));
        }
    }

    public class CurrentDayHandler : IHttpHandler
    {

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(string.Format("Today is: {0}", DateTime.Now.DayOfWeek.ToString()));
        }
    }

    public class NotFoundHandler : IHttpHandler
    {

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new HttpException(404, "Not Found");
        }
    }
}
