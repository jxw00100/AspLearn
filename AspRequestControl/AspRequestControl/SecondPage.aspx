<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecondPage.aspx.cs" Inherits="AspRequestControl.SecondPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                This is the SecondPage.aspx
                <p>Handler: <%: Context.Handler %></p>
                <p>Current Handler: <%: Context.CurrentHandler %></p>
                <p>Previous Handler: <%: Context.PreviousHandler %></p>
            </div>
        </form>
    </body>
</html>
