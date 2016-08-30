using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspRequestControl
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                switch (Request.Form["choice"])
                {
                    case "redirect302":
                        Response.Redirect("/SecondPage.aspx", false);
                        break;
                    case "redirect301":
                        //Response.RedirectPermanent("/CurrentTimeHandler.ashx");
                        Response.RedirectLocation = "/CurrentTimeHandler.ashx";
                        Response.StatusCode = 301;
                        Context.ApplicationInstance.CompleteRequest();
                        break;
                    case "transferpage":
                        //Context.RemapHandler(new SecondPage()); //Exception: 'HttpContext.RemapHandler' can only be invoked before 'HttpApplication.MapRequestHandler' event is raised.
                        Server.Transfer("/SecondPage.aspx");
                        break;
                    

                }
            }
        }
    }
}