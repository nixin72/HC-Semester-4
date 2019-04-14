<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstControl.aspx.cs" Inherits="pdumaresq_C40_L081.partA" %>

<%@ Register Src="ListPicker.ascx" TagName="ListPicker" TagPrefix="uc1" %> 
<%@ Register src="~/ListPicker2.ascx" TagName="ListPicker" TagPrefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ValidationSummary runat="server" />


        <uc1:ListPicker id="ListPicker1" Runat="server" />

        <br /><br /><br />

        <uc2:ListPicker id="ListPicker2" Runat="server" />
    </div>
    </form>
</body>
</html>
