using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspPageLifecycle
{
    public partial class PostBack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            phFirst.Visible = !(phSecond.Visible = IsPostBack);

            if (IsPostBack)
            {
                int firstNum = int.Parse(firstNumber.Value);
                int secondNum = int.Parse(secondNumber.Value);
                result.InnerText = (firstNum + secondNum).ToString();
            }
        }
    }
}