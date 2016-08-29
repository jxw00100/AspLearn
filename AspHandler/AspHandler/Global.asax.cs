using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace AspHandler
{
    public class Global : System.Web.HttpApplication
    {
        public Global()
        {
            MapRequestHandler += HandleEvent;
            PostMapRequestHandler += HandleEvent;
            PreRequestHandlerExecute += HandleEvent;
            PostRequestHandlerExecute += HandleEvent;
        }

        private void HandleEvent(Object sender, EventArgs e)
        {
            string eventType = Context.CurrentNotification.ToString();
            if (Context.IsPostNotification)
            {
                eventType = "Post" + eventType;
            }

            System.Diagnostics.Debug.WriteLine("Request Event: {0}", new[] { eventType });
        }
    }
}