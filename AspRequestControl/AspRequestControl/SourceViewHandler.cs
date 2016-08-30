using System;
using System.IO;
using System.Web;

namespace AspRequestControl
{
    public class SourceViewHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string reqFilePath = context.Request.FilePath;
            //context.Request.CurrentExecutionFilePath
            //context.Request.CurrentExecutionFilePathExtension
            reqFilePath = reqFilePath.Substring(0, reqFilePath.LastIndexOf('.'));
            

            if (reqFilePath.ToLower().EndsWith(".ashx"))
            {
                context.Response.Redirect(reqFilePath);
            }
 
            StreamReader sr = new StreamReader(context.Request.MapPath(reqFilePath));

            context.Response.ContentType = "text/plain";
            context.Response.Write("<pre>");
            context.Response.Write(context.Server.HtmlDecode(sr.ReadToEnd()));
            context.Response.Write("</pre>");
        }
    }
}
