using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CommonModules
{
    public class LogModule: IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.LogRequest += HandleEvent;
        }

        private void HandleEvent(object sender, EventArgs e)
            
        {
            HttpApplication app = sender as HttpApplication;
            System.Diagnostics.Debug.WriteLine(
                string.Format("Log Modules: Request for {0} - code {1}",
                    app.Request.RawUrl, app.Response.StatusCode));
        }
    }
}
