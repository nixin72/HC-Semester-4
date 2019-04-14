<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageReservation.aspx.cs" Inherits="ManageReservation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Reservation</title>
    <link href="Styles/styles.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <div id="banner">
        <div id="promo">
            <h2>Happy Valley Kennels</h2>
        </div>
        <div id="nav">
            <ul>
               <li class="navItm active">
                    <a href="ManageReservation.aspx">Reservations</a>
                </li>
                <li class="navItm">
                    <a href="ManagePets.aspx">Pets</a>
                </li>
                <li class="navItm">
                    <a href="ManageCustomer.aspx">My Account</a>
                </li>
                <li class="profile">
                    <img src="images/defaultProfile.png" alt="profile picture" width="30" height="30" />
                </li>
            </ul>
        </div>
    </div>
    
    <h2><asp:Label runat="server" ID="lblPageTitle">Make reservation</asp:Label></h2>
    <div id="cont">
        <form id="form" runat="server">
            <div class="top" >
                <div class="data start" style="width: 30%; margin: auto">
                    <label>Start Date:</label> 
                    <asp:DropDownList runat="server" ID="ddlStartMonth" TabIndex="1">

                    </asp:DropDownList>
                    <asp:DropDownList runat="server" ID="ddlStartDay" TabIndex="2">

                    </asp:DropDownList>
                    <asp:DropDownList runat="server" ID="ddlStartYear" TabIndex="3">

                    </asp:DropDownList>
                </div>
                <div class="data end" style="width: 30%; margin: auto">
                    <label>End Date:</label>
                    <asp:DropDownList runat="server" ID="ddlEndMonth" TabIndex="4">

                    </asp:DropDownList>
                    <asp:DropDownList runat="server" ID="ddlEndDay" TabIndex="5">

                    </asp:DropDownList>
                    <asp:DropDownList runat="server" ID="ddlEndYear" TabIndex="6">

                    </asp:DropDownList>
                </div>
            </div>
            <asp:LinkButton runat="server" ID="btnAddPet"></asp:LinkButton>
            <div id="pets" runat="server">
                <div class='pet'>
                    <div class="petId">
                        <h2><asp:Label runat="server" ID="lblpet1">Sparly</asp:Label></h2>
                        <asp:Panel runat="server" ID="pnlSharing">
                            <label>Share with:</label>
                            <asp:DropDownList runat="server" ID="ddlSharing" TabIndex="7">
                                <asp:ListItem>Other Pet</asp:ListItem>
                            </asp:DropDownList>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlClerkRun">
                            <label>Selected run:</label><br />
                            <asp:DropDownList runat="server" ID="ddlRun" TabIndex="7">
                            </asp:DropDownList>
                        </asp:Panel>
                    </div>
                    
                    <div class="top">
                        <div class='left res' style='text-align: left'>
                            <div class="data">
                                <label>Prefered Food:</label>
                                <select id='ddlFood' runat='server' tabindex="8">

                                </select>
                            </div>
                            <br />
                            <asp:CheckBox runat="server" ID="chbOwnFood" Text=" I will bring my own food" TabIndex="9"/>
                            <br />
                            <asp:CheckBox runat="server" ID="chbFoodTwice" Text=" Fed twice a day" TabIndex="10" />
                            <br /><br />
                            <div class="services">
                                <label>Services: </label>
                                <asp:CheckBoxList runat="server" ID="chlServices" TabIndex="11">
                                    <asp:ListItem>Walk</asp:ListItem>
                                    <asp:ListItem>Grooming</asp:ListItem>
                                    <asp:ListItem>Playtime</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                            
                            <br />
                            <asp:LinkButton runat="server" ID="viewMore" TabIndex="14">
                                View pricing information
                            </asp:LinkButton>
                            
                        </div>
                        <div class='right res'>
                            <h4>Medical information:</h4>
                            <asp:Label runat="server" ID="lblVaccs">Vaccinations are up to date</asp:Label><br />
                            <asp:LinkButton runat="server" ID="lbtnViewVacc" Text="See Vaccinations to confirm"></asp:LinkButton>
                            <br /><br />
                            <asp:LinkButton runat="server" ID="lblAddMed" TabIndex="12">+ Add a medication</asp:LinkButton>
                            <br />
                            <asp:CheckBoxList runat="server" ID="chlMeds">

                            </asp:CheckBoxList>

                            <br />
                            notes:<br />
                            <asp:TextBox ID="txtPet1Notes" TabIndex="13" TextMode="multiline" Columns="40" Rows="5" runat="server"></asp:TextBox> 
                        </div>
                    </div>
                </div>
            </div>
            <div class="actions services">
                <asp:Button runat="server" TabIndex="15" ID="btnMakeReservation" OnClick="btnMakeReservation_Click" Text="Book Now" />
                
                <asp:LinkButton runat="server" TabIndex="16" ID="btnCancelRes" Visible="false" Text="Cancel Reservation"></asp:LinkButton>
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