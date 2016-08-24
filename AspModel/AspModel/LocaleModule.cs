using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace AspModel
{
    public class LocaleModule: IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += HandleEvent;
        }

        private void HandleEvent(object sender, EventArgs e)
        {
            string[] langs = (sender as HttpApplication).Request.UserLanguages;

            if (langs != null && langs.Length > 0 && langs[0] != null)
            {
                try
                {
                    //Thread.CurrentThread.CurrentCulture = new CultureInfo(langs[0]);
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                }
                catch { }
            }
        }
    }
}