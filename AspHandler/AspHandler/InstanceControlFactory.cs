using System;
using System.Web;

namespace AspHandler
{
    public class InstanceControlFactory : IHttpHandlerFactory
    {
        private int _factoryCounter = 0;

        public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            return new InstanceControlHandler(++_factoryCounter);
        }

        public void ReleaseHandler(IHttpHandler handler)
        {
        }
    }

    public class InstanceControlHandler: IHttpHandler{
        private int _handlerCounter;
        public InstanceControlHandler(int count){
            _handlerCounter = count;
        }

        public bool IsReusable
        {
	        get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
 	        context.Response.ContentType = "text/plain";
            context.Response.Write(string.Format("The counter value is {0}", _handlerCounter));
        }

    }
}
