<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="styles/default.css" type="text/css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        <img src="images/heritageLogo.jpeg" style="height: 79px; width: 177px" />
        <h1>My First ASP Page</h1>
        <p>
            Principal (P):&nbsp;
            <asp:TextBox ID="txtPrinciple" runat="server" Width="4em"></asp:TextBox>
        </p>
        <p>
            Rate (R):&nbsp;
            <asp:TextBox ID="txtRate" runat="server" Width="3em"></asp:TextBox>
        </p>
        <p>
            Time (R):&nbsp;
            <asp:TextBox ID="txtTime" runat="server" Width="3em"></asp:TextBox>
        </p>
        <p>
            Total:
            <asp:Label ID="lblTotal" runat="server" Text="Calculation goes here"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnCalc" runat="server" OnClick="btnCalc_Click" Text="Calculate" />
        </p>   
    </form>
</body>
</html>