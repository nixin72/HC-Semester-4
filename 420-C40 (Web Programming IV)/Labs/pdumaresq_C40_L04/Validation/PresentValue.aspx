<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PresentValue.aspx.cs" Inherits="PresentValue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Future Value</title>
    <style type="text/css">
        .imageSize   {
            width: 150px;
            height: 65px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>
    
        <img alt="CS Logo" class="imageSize" src="images/CSlogo.png" /> Future Value of Savings <img alt="Heritage" class="imageSize" src="images/heritage.png" /></h1>
        <table>
            <tr>
                <td style="text-align: right">Monthly Investment: </td>
                <td>
                    <asp:DropDownList ID="ddlInvest" runat="server" Width="4em">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="valReqInvest" runat="server" ErrorMessage="Monthly investment is required" ForeColor="red" Display="Dynamic" ControlToValidate="ddlInvest" InitialValue="0">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Annual Interest Rate:</td>
                <td>
                    <asp:TextBox ID="txtInterest" runat="server" Width="4em"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valReqInterest" runat="server" ErrorMessage="Interest Rate is required" ForeColor="red" Display="Dynamic" ControlToValidate="txtInterest">
                    </asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="valRanInterest" MinimumValue="1" MaximumValue="20" runat="server" Type="Integer" ErrorMessage="Value must be between 1 and 20." ForeColor="Red" ControlToValidate="txtInterest" Display="Dynamic">
                    </asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Number of Years:</td>
                <td>
                    <asp:TextBox ID="txtYears" runat="server" Width="4em"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valReqYears" runat="server" ErrorMessage="Year is required" ForeColor="red" Display="Dynamic" ControlToValidate="txtYears">
                    </asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="valComYears" runat="server" ForeColor="Red" ErrorMessage="Years must be greater than 0." ControlToValidate="txtYears" Display="Dynamic" ValueToCompare="0" Type="Integer" Operator="GreaterThan">
                    </asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Future Value:</td>
                <td class="auto-style1">
                    <asp:Label ID="lblFuture" runat="server" Width="12em"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnClear" runat="server" Text="Clear" Width="7em" OnClick="btnClear_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCalc" runat="server" Text="Calculate" Width="7em" OnClick="btnCalc_Click" />
                </td>
            </tr>
        </table>
        </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
