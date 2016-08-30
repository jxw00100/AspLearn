using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspPageLifecycle
{
    public class ViewCounterEventArgs : EventArgs
    {
        public int Counter { get; set; }
    }

    public partial class ViewCounter : System.Web.UI.UserControl
    {
        public event EventHandler<ViewCounterEventArgs> Count;

        protected void Page_Init(object sender, EventArgs e)
        {
            EventCollection.Add(EventSource.Control, "Init");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            EventCollection.Add(EventSource.Control, "Load");
            int count;
            Session["counter"] = count = ((int)(Session["counter"] ?? 0)) + 1;
            if (Count != null)
            {
                Count(this, new ViewCounterEventArgs { Counter = count });
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            EventCollection.Add(EventSource.Control, "PreRender");
        }

        protected override void Render(HtmlTextWriter writer)
        {
            EventCollection.Add(EventSource.Control, "Render");
            base.Render(writer);
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            EventCollection.Add(EventSource.Control, "Unload");
        }

        protected int? GetCounter()
        {
            return Session["counter"] as int? ?? 0;
        }
    }
}