using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspPageLifecycle
{
    public partial class Default : System.Web.UI.Page
    {
        public IEnumerable<EventDescription> GetEvents()
        {
            return EventCollection.Events;
        }
        
        protected void Page_PreInit(object src, EventArgs args)
        {
            EventCollection.Add(EventSource.Page, "PreInit");
        }

        protected void Page_Init(object src, EventArgs args)
        {
            EventCollection.Add(EventSource.Page, "Init");
        }

        protected void Page_InitComplete(object src, EventArgs args)
        {
            EventCollection.Add(EventSource.Page, "InitComplete");
            //ucCounter.Count += (csrc, cargs) =>
            //{
            //    EventCollection.Add(EventSource.Page, string.Format("Control - Counter: {0}", cargs.Counter));
            //};
        }

        protected void Page_PreLoad(object src, EventArgs args)
        {
            EventCollection.Add(EventSource.Page, "PreLoad");
        }

        protected void Page_Load(object src, EventArgs args)
        {
            EventCollection.Add(EventSource.Page, "Load");
        }

        protected void Page_LoadComplete(object src, EventArgs args)
        {
            EventCollection.Add(EventSource.Page, "LoadComplete");
        }

        protected void Page_PreRender(object src, EventArgs args)
        {
            EventCollection.Add(EventSource.Page, "PreRender");
        }

        protected void Page_PreRenderComplete(object src, EventArgs args)
        {
            EventCollection.Add(EventSource.Page, "PreRenderComplete");
        }

        protected void Page_SaveStateComplete(object src, EventArgs args)
        {
            EventCollection.Add(EventSource.Page, "SaveStateComplete");
        }

        protected override void Render(HtmlTextWriter writer)
        {
            EventCollection.Add(EventSource.Page, "Render");
            base.Render(writer);
        }

        protected override void SavePageStateToPersistenceMedium(object state)
        {
            EventCollection.Add(EventSource.Page, "SavePageStateToPersistenceMedium");
            base.SavePageStateToPersistenceMedium(state);
        }

        protected void Page_Unload(object src, EventArgs args)
        {
            EventCollection.Add(EventSource.Page, "Unload");
        }

        protected void HandleCounterEvent(object src, ViewCounterEventArgs args)
        {
            //Called in the "OnCount" menthod in the user control markup 
            EventCollection.Add(EventSource.Page, string.Format("Control - Counter: {0}", args.Counter));
        }
    }
}