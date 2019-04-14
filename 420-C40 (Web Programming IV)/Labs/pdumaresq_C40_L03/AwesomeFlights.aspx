

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Account</title>
    <link href="styles/styles.css" rel="stylesheet" />
</head>
<body>
    <div class="topHeader">
        <p>Awesome Flights</p>
        <form id="loginForm">
            <ul class="navList" style="display: inline; float: right;">
                    <li><a href="#">Check in</a></li>
                    <li><a href="#">Book Flight</a></li>
                    <li><a href="#">Flight status</a></li>
                    <li>Log Out</li>
                </ul>
            
        </form>

    </div>
    <div class="wrapper">


        <div class="divContent">
            <!--Div for the form content -->
            <span class="userName">Book A Flight</span>
            <div class="divForm">
                <form id="accountForm" runat="server">
                    <!-- Preparation for user's profile pictures -->
                    <div>
                        <div class="formFields">
                        <asp:Label ID="lblProfilePicPlaceholder" CssClass="Section" runat="server" Text="Flight:"></asp:Label>
                        <hr />
                            <br />
                            &nbsp;&nbsp;
                            <asp:CheckBox runat="server" ID="round" Text="round trip" CssClass="round"/>
                            <br />
                             <p class="flight">
                            <asp:Label ID="Label1" runat="server" Text="Departure:"></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </p>
                        <p class="flight">
                            <asp:Label ID="Label2" runat="server" Text="Destination: "></asp:Label>
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </p>
                        </div>
                        <div class="formFields">
                        <div>
                            
                        </div>
                            
                            <p class="flight">
                                <asp:Label ID="lblDepartureDate" runat="server" Text="Departure date:"></asp:Label>
                                <asp:TextBox TextMode="Date" ID="txtFirstName" runat="server"></asp:TextBox>
                            </p>
                            <p class="flight">
                                <asp:Label ID="lblReturnDate" runat="server" Text="Return Date: "></asp:Label>
                                <asp:TextBox TextMode="Date" ID="txtReturnDate" runat="server"></asp:TextBox>
                            </p>
                    </div>
                    </div>
                            
                    
                    
                    <div id="passengers">
                        <asp:Label ID="lblPassengers" runat="server" Text="Passengers:" CssClass="Section"></asp:Label>
                        <hr />
                        <br />
                        <div style="display: flex; width: 80%;">
                        <div class="data">
                        <asp:Label CssClass="label" ID="Adults" runat="server" Text="Adults"></asp:Label>
                            <asp:DropDownList ID="ddlAdults" runat="server">
                                <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                        </asp:DropDownList>
                        </div>
                        <div class="data">
                        <asp:Label CssClass="label" ID="Label3" runat="server" Text="Children"></asp:Label>
                        <asp:DropDownList ID="ddlChildren" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                        </asp:DropDownList>
                        </div>
                        </div>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton runat="server" ID="btnMoreThan9" Text="More Than 9 travellers?"><br />

                        </asp:LinkButton>
                        <br />
                        <div class="data">
                            <asp:Label ID="llbCountry" runat="server" Text="Country of residence: "></asp:Label>
                            <asp:TextBox ID="txtCoutry" runat="server"></asp:TextBox>
                        </div>
                        <br />
                        <div class="data">
                            <asp:Label ID="lblPromo" runat="server" Text="Promotional Code: "></asp:Label>
                            <asp:TextBox ID="txtPromo" runat="server"></asp:TextBox>
                        </div>
                        <br />
                        <asp:Button runat="server" Text="search" CssClass="btnSearch"/>

                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
