using System;
using System.Web;

namespace AspRequestControl
{
    public class HandlerSelectionModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication app)
        {
            app.PostResolveRequestCache += (src, args) =>
            {
                switch (app.Request.Form["choice"])
                {
                    case "remaphandler":
                        app.Context.RemapHandler(new CurrentTimeHandler());
                        break;
                    case "execute":
                        string[] paths = { "Default.aspx", "SecondPage.aspx" };
                        foreach (string path in paths)
                        {
                            app.Response.Write(string.Format("<div>This is the {0} responses</div>", path));
                            app.Server.Execute(path);
                        }
                        app.CompleteRequest();
                        break;
                }
            };
        }
    }
}
