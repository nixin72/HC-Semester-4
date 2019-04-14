<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="undo2.aspx.cs" Inherits="pdumaresq_B42_L07.undo2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Name: <asp:TextBox runat="server" ID="txtName" ></asp:TextBox><br />
        Phone: <asp:TextBox runat="server" ID="txtPhone" ></asp:TextBox><br />
        City: <asp:TextBox runat="server" ID="txtCity" ></asp:TextBox>
        <br />
        <asp:Button     runat="server" ID="btnSend" Text="Send" OnClick="btnSend_Click" />
        <asp:LinkButton runat="server" ID="btnUndo" Text="Undo" Onclick="btnUndo_Click"/>

    </div>
    </form>
</body>
</html>
