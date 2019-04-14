<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageCustomer.aspx.cs" Inherits="ManageCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Customer</title>
    <link href="Styles/styles.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <div id="banner">
        <div id="promo">
            <h2>Happy Valley Kennels</h2>
        </div>
        <div id="nav">
            <ul>
                <li class="navItm">
                    <a href="ManageReservation.aspx">Reservations</a>
                </li>
                <li class="navItm">
                    <a href="ManagePets.aspx">Pets</a>
                </li>
                <li class="navItm active">
                    <a href="ManageCustomer.aspx">My Account</a>
                </li>
                <li class="profile">
                    <img src="images/defaultProfile.png" alt="profile picture" width="30" height="30" />
                </li>
            </ul>
        </div>
    </div>
    <h2><asp:Label runat="server" ID="lblPageTitle">Create user</asp:Label></h2>
    <div id="cont">
        <form id="form" runat="server">
            <div class="top">
                <div id="owner_photo" class="left">
                    <img src="images/defaultProfile.png" alt="user photo" width="200" height="200" />
                </div>
                <br /><br />
                <div id="contInfo" class="right">
                    <div class="data">
                        <label>First Name: </label>
                        <asp:TextBox ID="txtfname" runat="server" TabIndex="1"></asp:TextBox>
                    </div>
                    <br />
                    <div class="data">
                        <label>Last Name: </label>
                        <asp:TextBox ID="txtlname" runat="server" TabIndex="2"></asp:TextBox>
                    </div>
                    <br />
                    <div class="data">
                        <label>Email Address: </label>
                        <asp:TextBox ID="txtemail" runat="server" TabIndex="3"></asp:TextBox>
                    </div>
                    <br />
                    <div class="data">
                        <label>Phone number: </label>
                        <asp:TextBox ID="txtphone" runat="server" TabIndex="4"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="bottom">
                <div id="addressInfo" class="left">
                    <div class="data">
                        <label>Street: </label>
                        <asp:TextBox ID="txtStreet" runat="server" TabIndex="5"></asp:TextBox>
                    </div>
                    <br />
                    <div class="data">
                        <label>City: </label>
                        <asp:TextBox ID="txtCity" runat="server" TabIndex="6"></asp:TextBox>
                    </div>
                    <br />
                    <div class="data">
                        <label>Province: </label>
                        <asp:DropDownList runat="server" ID="ddlProvince" TabIndex="7">
                            <asp:ListItem>QC</asp:ListItem>
                            <asp:ListItem>ON</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <br />
                    <div class="data">
                        <label>Postal Code: </label>
                        <asp:TextBox ID="txtPostal" runat="server" TabIndex="8"></asp:TextBox>
                    </div>
                    <br />
                    <asp:Panel id="password" runat="server">
                        <h3><asp:Label runat="server" ID="lblChgPswrd">Set Password</asp:Label></h3>
                        <div class="data">
                            <asp:Label runat="server" ID="lblOldPswrd">Password: </asp:Label>
                            <asp:TextBox TextMode="Password" ID="txtOldPswd" runat="server" TabIndex="12"></asp:TextBox>
                        </div><br />
                        <div class="data">
                            <asp:Label runat="server" ID="lblNewPswrd">Confirm Password: </asp:Label>
                            <asp:TextBox TextMode="Password" ID="txtNewPswd" runat="server" TabIndex="13"></asp:TextBox>
                        </div>
                    </asp:Panel>

                    <br /><br />
                    <asp:Button ID="btnSave" runat="server" Text="Create Account" TabIndex="14" OnClick="btnSave_click"/>
                    <asp:LinkButton runat="server" ID="btnCancel" Text="Cancel" > |&nbsp;&nbsp;&nbsp;Cancel</asp:LinkButton>
                    <asp:Panel runat="server" ID="deleteCustomer">
                        <hr />
                        <asp:LinkButton runat="server" ID="btnDeleteCustomer" Text="Delete customer"></asp:LinkButton>
                    </asp:Panel>
                </div>

                <div id="emgCont" class="right">
                    <h3>Emergency Contact Information</h3>
                    <br />
                    <div class="data">
                        <label>First Name: </label><br />
                        <asp:TextBox ID="txtEmgF" runat="server" TabIndex="9"></asp:TextBox>
                    </div>
                    <br />
                    <div class="data">
                        <label>Last Name: </label><br />
                        <asp:TextBox ID="txtEmgL" runat="server" TabIndex="10"></asp:TextBox>
                    </div>
                    <br />
                    <div class="data">
                        <label>Phone Number: </label><br />
                        <asp:TextBox ID="txtEmgP" runat="server" TabIndex="11"></asp:TextBox>
                    </div>
                </div>
            </div>
        </form>
    </div>
    <div id="footer">
        <p>Happy Valley Kennels</p>
        <hr style=" border-color:black "/>
        <p>Philip Dumaresq</p>
    </div>
</body>
</html>