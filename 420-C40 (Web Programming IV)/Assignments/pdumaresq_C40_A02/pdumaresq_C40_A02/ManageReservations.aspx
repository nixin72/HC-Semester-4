<%@ Page Title="" Language="C#" MasterPageFile="~/PD_HVK.Master" AutoEventWireup="true" CodeBehind="ManageReservations.aspx.cs" Inherits="pdumaresq_C40_A02.ManageReservations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage Reservation</title>
    <link href="Styles/styles.css" type="text/css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="contPageTitle" ContentPlaceHolderID="pageTitle" runat="server">
    <h2>
        <asp:Label runat="server" ID="lblPageTitle">Add Reservation</asp:Label></h2>
    
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            $(".datepicker").datepicker();
        });
    </script>
</asp:Content>

<asp:Content ID="contPageContent" ContentPlaceHolderID="contPageContent" runat="server">
    <asp:ValidationSummary runat="server" ForeColor="Red"/>
    <div class="top">
                
        <div class="data start" style="width: 30%; margin: auto">
            <label>Start Date:</label>
            <input runat="server" id="txtStart" type="text" class="datepicker" />
        </div>
        <div class="data end" style="width: 30%; margin: auto">
            <label>End Date:</label>
            <input runat="server" id="txtEnd" type="text" class="datepicker" />
        </div>
    </div>

    <asp:LinkButton runat="server" ID="btnAddPet"></asp:LinkButton>
    <div id="pets" runat="server">
        <div class='pet'>
            <div class="petId">
                <h2>
                    <asp:Label runat="server" ID="lblpet1">Sparly</asp:Label></h2>
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
                            <option>--Default--</option>
                        </select>
                    </div>
                    <br />
                    <asp:CheckBox runat="server" ID="chbOwnFood" Text=" I will bring my own food" TabIndex="9" />
                    <br />
                    <asp:CheckBox runat="server" ID="chbFoodTwice" Text=" Fed twice a day" TabIndex="10" />
                    <br />
                    <br />
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
                    <asp:LinkButton runat="server" CausesValidation="false" PostBackUrl="~/ManagePets.aspx" ID="lbtnViewVacc" Text="See Vaccinations to confirm"></asp:LinkButton>
                    <br />
                    <br />
                    <asp:LinkButton runat="server" ID="lblAddMed" TabIndex="12">+ Add a medication</asp:LinkButton>
                    <br />
                    <asp:CheckBoxList runat="server" ID="chlMeds">
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>
    </div>
    <div class="actions services">
        <asp:Button runat="server" TabIndex="15" ID="btnMakeReservation" OnClick="btnMakeReservation_Click" Text="Book Now" />

        <asp:LinkButton runat="server" TabIndex="16" ID="btnCancelRes" Visible="false" Text="Cancel Reservation"></asp:LinkButton>
    </div>

    <%-- Validation control --%>
    <%-- Start date --%>
    <asp:RequiredFieldValidator runat="server" ID="reqStart" ControlToValidate="txtStart" Display="None" Text="*" EnableClientScript="true" ErrorMessage="Please enter a start date."></asp:RequiredFieldValidator>
    <asp:CustomValidator runat="server" ID="cusStart" Display="None" Text="*" ErrorMessage="Please enter a valid start date." ControlToValidate="txtStart" OnServerValidate="cusStart_ServerValidate"></asp:CustomValidator>

    <%-- End date --%>
    <asp:RequiredFieldValidator runat="server" ID="reqEnd" ControlToValidate="txtEnd" Display="None" Text="*" EnableClientScript="true" ErrorMessage="Please enter an end date."></asp:RequiredFieldValidator>
    <asp:CustomValidator runat="server" ID="cusEnd" Display="None" Text="*" ErrorMessage="Please enter a valid start date." ControlToValidate="txtEnd" OnServerValidate="cusEnd_ServerValidate"></asp:CustomValidator>
    <asp:CustomValidator runat="server" ID="cusSEnd" Display="None" Text="*" ErrorMessage="End date must be after start date." ControlToValidate="txtEnd" OnServerValidate="compSEnd_ServerValidate"></asp:CustomValidator>



</asp:Content>
