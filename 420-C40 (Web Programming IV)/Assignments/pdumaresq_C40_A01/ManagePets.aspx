<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagePets.aspx.cs" Inherits="ManagePets" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Pets</title>
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
                <li class="navItm active">
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
    <h2><asp:Label runat="server" ID="lblPageTitle">Add Pet</asp:Label></h2>
    <div id="cont" class="petPage">
        <form id="petForm" runat="server">
            <asp:Panel runat="server" ID="petList">
                <fieldset>
                    <legend>
                        Pets
                    </legend>
                    <asp:RadioButtonList ID="rdbAllPets" runat="server">
                    </asp:RadioButtonList>
                    <br />
                    <asp:LinkButton ID="addPet" runat="server" Text="Add Pet" ></asp:LinkButton>
                </fieldset>
            </asp:Panel>
            
            <br /><br />
            <div class="top">
                <div class="data">
                    <label class="textInput">Pet Name:</label>
                    <asp:TextBox ID="txtName" runat="server" TabIndex="1"></asp:TextBox>
                </div>
                <br />
                <div class="data">
                    <label>Breed: </label>
                    <asp:TextBox ID="txtBreed" runat="server" TabIndex="2"></asp:TextBox>
                </div>
            </div>
                        
            <br /><br />
            <h3>Medical Information: </h3>
            <hr />
            <br />
            <div class="data">
                <label>Birthdate: </label>
                <asp:DropDownList runat="server" ID="ddlYear" TabIndex="3">

                </asp:DropDownList>
                &nbsp;&nbsp;|&nbsp;&nbsp;
                <asp:DropDownList runat="server" ID="ddlMonth" TabIndex="4">

                </asp:DropDownList>
            </div>
            
            <br />
            <div id="lists">
                <div id="sexFixed"">
                    <div id="sex">
                        <label>Sex:&nbsp;</label><br />
                        <asp:RadioButtonList ID="rblSexList" runat="server"  TabIndex="5">
                            <asp:ListItem Value="m">Male</asp:ListItem>
                            <asp:ListItem Value="f">Female</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>

                    <label>Fixed: </label>
                    <asp:CheckBox ID="chbFixed"  runat="server"  TabIndex="6"/>
                </div>
                
                <div id="size">
                    <br />
                    <label>Pet Size: </label>
                    <asp:RadioButtonList ID="rblPetSizeList" runat="server"  TabIndex="7">
                        <asp:ListItem Value="s">Small</asp:ListItem>
                        <asp:ListItem Value="m">Medium</asp:ListItem>
                        <asp:ListItem Value="l">Large</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <br />
            <div id="vaccinations">
                <asp:LinkButton runat="server" ID="btnViewVaccs" Text="Manage Vaccinations" CausesValidation="false" TabIndex="8"/>
            </div>
            <br /> 
            <h3>Pet Personality</h3>
            <hr />
            <!--<br />
            <div id="traits">
                <label>Traits:</label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <div>
                    <asp:CheckBox runat="server" ID="chbBarker" Text="Barker" TabIndex="9"></asp:CheckBox>
                    <br />
                    <asp:CheckBox runat="server" ID="chbClimber" Text="Climber" TabIndex="10"></asp:CheckBox>
                </div>   
            </div>-->
            
            <br />
            <label>Please Tell us a bit about your dog!</label><br />
            <asp:TextBox ID="txtPetNotes" TextMode="multiline" Columns="50" Rows="7" runat="server"  TabIndex="11"></asp:TextBox>
            <br /><br />
            
            <div class="actions"> 
                <asp:Button ID="btnSave" runat="server" Text="Add Pet" OnClick="btnSave_Click"  TabIndex="12"/>   
                <asp:LinkButton runat="server" ID="btnCancel" TabIndex="13"> |&nbsp;&nbsp;&nbsp;Cancel</asp:LinkButton>
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