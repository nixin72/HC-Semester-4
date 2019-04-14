<%@ Page Title="" Language="C#" MasterPageFile="~/HVK.Master" AutoEventWireup="true" CodeBehind="ManageReservation.aspx.cs" Inherits="HVKA03.ManageReservation" %>

<%@ Register Src="~/DatePicker.ascx" TagPrefix="hvk" TagName="DatePicker" %>
<%@ Register Src="~/PetServiceTable.ascx" TagPrefix="hvk" TagName="PetServiceTable" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage Reservation</title>
    <link href="Styles/styles.css" type="text/css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="contPageTitle" ContentPlaceHolderID="pageTitle" runat="server">
    <h2>
        <asp:Label runat="server" ID="lblPageTitle">Add Reservation</asp:Label></h2>

</asp:Content>

<asp:Content ID="contPageContent" ContentPlaceHolderID="contPageContent" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div id="homeOwnerContainer">
        <div runat="server" id="pickOwner">
            <asp:DropDownList runat="server" ID="ddlPickOwner" CausesValidation="false" AutoPostBack="true" OnSelectedIndexChanged="ddlPickOwner_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div id="errors">
            <asp:ValidationSummary runat="server" ID="valMsgs" ForeColor="Red" />
            <asp:Label runat="server" ID="errMsgs"></asp:Label>
        </div>
        
        <div class="top" id="startEndInfo" runat="server">
        
            <div class="data start" style="width: 30%; margin: auto">
                <label>Start Date:</label>
                <hvk:DatePicker runat="server" id="txtStartDate" />
            </div>
            <div class="data end" style="width: 30%; margin: auto">
                <label>End Date:</label>
                <hvk:DatePicker runat="server" id="txtEndDate" />
            </div>
            <label>
            </label>
        </div>
    
        <div id="pets" runat="server">
            <asp:Panel ID="allPets" CssClass="pet" runat="server">
                <div class="flex-container">
                    <hvk:PetServiceTable runat="server" id="pet1" Visible="false" />
                </div>
                <div class="flex-container">
                    <hvk:PetServiceTable runat="server" id="pet2" Visible="false" />
                </div>
                <div class="flex-container">
                    <hvk:PetServiceTable runat="server" id="pet3" Visible="false" />
                </div>
                <div class="flex-container">
                    <hvk:PetServiceTable runat="server" id="pet4" Visible="false" />
                </div>
                
            </asp:Panel>
        </div>
        <div class="actions services">
        
            <asp:Button runat="server" TabIndex="15" ID="btnMakeReservation" Text="Book Now" OnClick="btnMakeReservation_Click" />
            <asp:Button runat="server" TabIndex="15" ID="btnUpdateReservation" Text="Save Changes" OnClick="btnUpdateReservation_Click" />
            <br />
            <asp:LinkButton runat="server" TabIndex="16" ID="btnCancelRes" Visible="false" Text="Cancel Reservation" OnClick="btnDeleteReservation_Click"></asp:LinkButton>
            <asp:LinkButton runat="server" TabIndex="16" ID="btnStartReservation" Visible="false" Text="Start Reservation"></asp:LinkButton>
        </div>
    </div>
    

    <%-- Validation control --%>    

    <%-- Start date --%>    
    
    <%--<asp:CustomValidator runat="server" ID="cusStart" Display="None" Text="*" ErrorMessage="Please enter a valid start date." ControlToValidate="txtStart" OnServerValidate="cusStart_ServerValidate"></asp:CustomValidator>--%>
    
    <%-- End date --%>    
    
    <%--<asp:CustomValidator runat="server" ID="cusEnd" Display="None" Text="*" ErrorMessage="Please enter a valid start date." ControlToValidate="txtEnd" OnServerValidate="cusEnd_ServerValidate"></asp:CustomValidator>--%>
    <%--<asp:CustomValidator runat="server" ID="cusSEnd" Display="None" Text="*" ErrorMessage="End date must be after start date." ControlToValidate="txtEnd" OnServerValidate="compSEnd_ServerValidate"></asp:CustomValidator>--%>

    <%-- At lest one pet --%>
    <%--<asp:CustomValidator runat="server" ID="cusOnePet" Display="None" Text="*" ErrorMessage="Please include at least one pet in the reservation." OnServerValidate="cusOnePet_ServerValidate"></asp:CustomValidator>--%>
</asp:Content>

