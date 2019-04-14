<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nag.aspx.cs" Inherits="pdumaresq_B42_L07.nag" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" ID="txtName"></asp:TextBox><br />
        <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox><br />
        <asp:Button runat="server" ID="btnResiter" Text="Register now" OnClick="btnResiter_Click"/>
        <br /><br />
        <asp:Label runat="server" ID="lblNag" ></asp:Label>
    </div>
    </form>
</body>
</html>
