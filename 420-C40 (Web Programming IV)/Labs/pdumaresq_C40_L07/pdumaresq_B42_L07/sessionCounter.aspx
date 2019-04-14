<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sessionCounter.aspx.cs" Inherits="pdumaresq_B42_L07.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" ID="lblLabel" ></asp:Label>
        <br />
        <asp:Button runat="server" ID="btnClickCounter" Text="Click counter" OnClick="btnClickCounter_Click"/>
        <asp:Button runat="server" ID="btnDateTimeLast" Text="DateTime Last" OnClick="btnDateTimeLast_Click"/>
    </div>
    </form>
</body>
</html>
