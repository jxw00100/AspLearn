<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspPageLifecycle.Default" %>

<%@ Register TagPrefix="Events" TagName="Counter" Src="~/ViewCounter.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <Events:Counter ID="ucCounter" runat="server" OnCount="HandleCounterEvent" />
    <br />
    <form id="form1" runat="server">
    <div>
        <table>
            <asp:Repeater ID="rptEvents" SelectMethod="GetEvents" ItemType="AspPageLifecycle.EventDescription" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td>Event Srouce</td>
                        <td>Event Type</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Item.Source %></td>
                        <td><%# Item.Type %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    </form>
</body>
</html>
