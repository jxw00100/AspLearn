<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspRequestControl.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <input type="radio" name="choice" value="redirect302" checked="checked" />Redirect
            </div>
            <div>
                <input type="radio" name="choice" value="redirect301" />Redirect Permanent
            </div>
            <div>
                <input type="radio" name="choice" value="remaphandler" />Remap Handler
            </div>
            <div>
                <input type="radio" name="choice" value="transferpage" />Tansfer Page
            </div>
            <div>
                <input type="radio" name="choice" value="execute" />Execute Handler
            </div>
            <p><button type="submit">Submit</button></p>
        </form>
    </body>
</html>