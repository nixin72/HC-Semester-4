<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PresentValue.aspx.cs" Inherits="images_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Future Value</title>
    <style type="text/css">
        .imgSize {
            width: 150px;
            height: 65px;
        }

        .input {
            width: 12em;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1 style="width: 877px">
            <img alt="CS logo" class="imgSize" src="images/CSlogo.png" />
            Future Value of Savings
            <img alt="Heritage Log" class="imgSize" src="images/heritage.png" />
        </h1>
        <p style="width: 877px">
            <asp:Table ID="Table1" runat="server">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Right">
                        Monthly Investment: 
                    </asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:DropDownList CssClass="input" ID="ddlInvest" runat="server">

                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Right">
                        Annual interest rate: 
                    </asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="txtInterest" CssClass="input" runat="server">

                        </asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Right">
                        Number of years: 
                    </asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="txtYears" CssClass="input" runat="server">

                        </asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Right">
                        Future Value: 
                    </asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:Label runat="server" CssClass="input" ID="lblFuture" Text="Label">

                        </asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">
                        <asp:Button ID="btnClear" CssClass="input" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    </asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:Button ID="btnCalc" CssClass="input" runat="server" Text="Calculate" OnClick="btnCalc_Click"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </p>
    </div>
    </form>
</body>
</html>