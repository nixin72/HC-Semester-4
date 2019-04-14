<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Events.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #result {
            border: thin solid black;
            display: none;
        }

        .display tr td {
            border: thin solid black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label1" runat="server" Text="Label">
                        Name of Event: 
                    </asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtEvent" runat="server">

                    </asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Label">
                        Number of Guests: 
                    </asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtGuests" runat="server">
                    </asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label3" runat="server" Text="Label">
                        Type of food
                    </asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="ddlFood" runat="server">
                        <asp:ListItem>
                            $20 (Cold Buffet)
                        </asp:ListItem>
                        <asp:ListItem>
                            $30 (Hot Buffet)
                        </asp:ListItem>
                        <asp:ListItem>
                            $40 (One course meal)
                        </asp:ListItem>
                        <asp:ListItem>
                            $60 (Three course meal)
                        </asp:ListItem>
                        <asp:ListItem>
                            $100 (six course meal)
                        </asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label4" runat="server" Text="Label">
                        Entertainment: 
                    </asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox ID="chbDJ" runat="server" />
                    <asp:Label ID="Label6" runat="server" Text="Label">
                        DJ
                    </asp:Label>
                    <br />
                    <asp:CheckBox ID="chbLive" runat="server" />
                    <asp:Label ID="Label7" runat="server" Text="Label">
                        Live
                    </asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label5" runat="server" Text="Label">
                        Open Bar: 
                    </asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox ID="chbOpenBar" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnCalc" runat="server" Text="Calculate" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        
    </div>
    </form>
    <asp:Table runat="server" ID="result" CssClass="display">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <h1 runat="server" id="heading"></h1>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                Item
            </asp:TableCell>
            <asp:TableCell>
                Cost
            </asp:TableCell>
            <asp:TableCell>
                Totals
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                Number of Guests
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label runat="server" ID="lblCostGuests">
                </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                Cost pet Guest (1, Course Meal, With service)
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblCostFood" runat="server" Text="">
                </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                Total Cost for Guests
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblTotalsFood" runat="server" Text="">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                Music
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblCostMusic" runat="server" Text="">
                </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblTotalMusic" runat="server" Text="">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                Open Bar (Cost pet guest = $30)
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblCostBar" runat="server" Text="">
                </asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblTotalBar" runat="server" Text="">
                </asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                Total Cost
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblTotalCost" runat="server" Text=""></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</body>
</html>