using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspModel
{
    public class ParamsModule: IHttpModule
    {
        //private HttpApplication _app = null;
        //public void Init(HttpApplication app)
        //{
        //    _app = app;
        //    app.LogRequest += new EventHandler(OnLogRequest);
        //}

        //public void OnLogRequest(Object source, EventArgs e)
        //{
        //   // _app can changed to source as HttpApplication
        //
        //    if(_app != null && _app.Request.Url.LocalPath == "/Param.aspx"
        //        && !_app.User.Identity.IsAuthenticated)
        //    {
        //        _app.Context.AddError(new UnauthorizedAccessException());
        //    }
        //}

        public void Init(HttpApplication app)
        {
            app.LogRequest += (src, args) =>
            {
                if (app.Request.Url.LocalPath == "/Param.aspx"
                    && !app.User.Identity.IsAuthenticated)
                {
                    app.Context.AddError(new UnauthorizedAccessException());
                }
            };
        }

        public void Dispose()
        {
        }
    }
}