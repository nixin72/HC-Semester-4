<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkTime.aspx.cs" Inherits="Part_D___Time.checkTime" %>

<%@ Register Src="~/Time.ascx" TagPrefix="uc1" TagName="Time" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:Time runat="server" id="Time" />

        <asp:Button runat="server" ID="btnTime" Text="Show Time" OnClick="btnTime_Click" />
        <br /><br />
        <asp:Button runat="server" ID="btnDate" Text="Show Date and time" OnClick="btnDate_Click"/>
    </div>
    </form>
</body>
</html>
