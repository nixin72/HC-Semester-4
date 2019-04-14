<%@ Page Language="C#" AutoEventWireup="true" Culture="en-GB" CodeFile="StumbleInn.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Reservations</title>
    <link href="styles/Main.css" rel="stylesheet" type="text/css" />
    <link href="styles/Request.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnSubmit" defaultfocus="txtArrivalDate">
    <div id="page">
    
        <h1>Stumble Inn and Suites</h1>
        <h2>Where you&rsquo;re always treated like royalty</h2>
        <p id="arrival_date">
            <asp:RequiredFieldValidator ID="valReqArrival" runat="server" Type="Date" ErrorMessage="Arrival date is required" ControlToValidate="txtArrivalDate" CssClass="validator" Display="Dynamic" Text="*">
            </asp:RequiredFieldValidator>
            <asp:CompareValidator ID="valComArrival" runat="server" Type="Date" ErrorMessage="Please enter a valid date" ControlToValidate="txtArrivalDate" ValueToCompare="mm/dd/yyyy" Operator="DataTypeCheck" CssClass="validator" Display="Dynamic" Text="*">
            </asp:CompareValidator>
            <asp:RangeValidator runat="server" ID="valRanArrival" Type="Date" ErrorMessage="Date must be within the next 6 months" ControlToValidate="txtArrivalDate" CssClass="validator" Display="Dynamic" Text="*">
            </asp:RangeValidator>
            Arrival date:&nbsp;
            <asp:TextBox ID="txtArrivalDate" Text="mm/dd/yyyy" runat="server" Width="75px"></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ibtnCalendar" runat="server" CausesValidation="false"
                ImageUrl="~/Validation/images/Calendar.bmp" ImageAlign="Top" 
                onclick="ibtnCalendar_Click" />
        </p>
        <p>
            <asp:Calendar ID="calArrival" runat="server" Visible="False" OnSelectionChanged="calArrival_SelectionChanged"></asp:Calendar>
        </p>
        <p class="clear">
            <asp:RequiredFieldValidator ID="valReqNights" runat="server" ErrorMessage="Number of nights is required" ControlToValidate="txtNights" CssClass="validator" Display="Dynamic" Text="*">
            </asp:RequiredFieldValidator>
            <asp:CompareValidator ID="valComNights" ControlToValidate="txtNights" runat="server" ErrorMessage="Nights must be 1 or more." CssClass="validator" Display="Dynamic" Text="*" Operator="GreaterThan" Type="Integer" ValueToCompare="0">
            </asp:CompareValidator>
            Number of nights:&nbsp; 
            <asp:TextBox ID="txtNights" runat="server" Width="45px"></asp:TextBox>
        </p>
        <p>
            Number of adults:&nbsp;
            <asp:DropDownList ID="ddlAdults" runat="server" Width="50px">
            </asp:DropDownList>&nbsp;&nbsp;
            Children:&nbsp;
            <asp:DropDownList ID="ddlChildren" runat="server" Width="50px">
            </asp:DropDownList>
        </p>
        <h3>Preferences</h3>
        <p>
            Room type:&nbsp;
            <asp:RadioButton ID="rdoBusiness" runat="server" Text="Business" 
                GroupName="Room" />&nbsp;
            <asp:RadioButton ID="rdoSuite" runat="server" Text="Suite" GroupName="Room" />&nbsp;
            <asp:RadioButton ID="rdoStandard" runat="server" Text="Standard" 
                GroupName="Room" />
        </p>
        <p>
            Bed type:&nbsp;
            <asp:RadioButton ID="rdoKing" runat="server" Text="King" 
                GroupName="Bed" />&nbsp;
            <asp:RadioButton ID="rdoDouble" runat="server" Text="Double Double" 
                GroupName="Bed" />
        </p>
        <p>
            <asp:CheckBox ID="chkSmoking" runat="server" Text="Smoking" />
        </p>
        <p id="requests">Special requests:</p>
        <p>
            <asp:TextBox ID="txtSpecialRequests" runat="server" Rows="4" TextMode="MultiLine" 
                Width="250px"></asp:TextBox>
        </p>
        <h3 class="clear">Contact information</h3>
        <p class="contact">Name:</p>
        <p>
            <asp:RequiredFieldValidator ID="valReqName" runat="server" ErrorMessage="Name is required" ControlToValidate="txtName" CssClass="validator" Display="Dynamic" Text="*">
            </asp:RequiredFieldValidator>
            <asp:TextBox ID="txtName" runat="server" Width="320px"></asp:TextBox>
        </p>
        <p class="contact">Email:</p>
        <p> 
            <asp:RequiredFieldValidator ID="valReqEmail" runat="server" ErrorMessage="Email is required" ControlToValidate="txtEmail" Display="Dynamic" CssClass="validator" Text="*">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="valRegEmail" runat="server" ErrorMessage="Please enter a valid email" CssClass="validator" ControlToValidate="txtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Text="*">
            </asp:RegularExpressionValidator>
            <asp:TextBox ID="txtEmail" runat="server" Width="320px"></asp:TextBox>
        </p>
        <p id="buttons">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="80px" 
                onclick="btnSubmit_Click" />&nbsp;
            <asp:Button ID="btnClear" runat="server" Text="Clear" Width="80px" 
                onclick="btnClear_Click" CausesValidation="false" />
        </p>
        <p id="message">
            <asp:Label ID="lblMessage" runat="server">
                <asp:ValidationSummary ID="valSummary" CssClass="validator" HeaderText="Errors" runat="server" />
            </asp:Label>
        </p>
    </div>
    </form>
</body>
</html>
