<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sayHello.aspx.cs" Inherits="Part_C___Say_Hello.sayHello" %>

<%@ Register Src="~/myName.ascx" TagPrefix="uc1" TagName="myName" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Hello</h2>

        <uc1:myName runat="server" id="myName" />
        <br />
        <asp:Label runat="server" ID="lblGreeting"></asp:Label>
    </div>
    </form>
</body>
</html>
