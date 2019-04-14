<%@ Page Title="" Language="C#" MasterPageFile="~/PD_HVK.Master" AutoEventWireup="true" CodeBehind="ManageReservations.aspx.cs" Inherits="HulkHvkA03.ManageReservations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage Reservation</title>
    <link href="Styles/styles.css" type="text/css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="contPageTitle" ContentPlaceHolderID="pageTitle" runat="server">
    <h2>
        <asp:Label runat="server" ID="lblPageTitle">Add Reservation</asp:Label></h2>

</asp:Content>

<asp:Content ID="contPageContent" ContentPlaceHolderID="contPageContent" runat="server">
    <asp:ValidationSummary runat="server" ForeColor="Red"/>
    <div class="top">
                
        <div class="data start" style="width: 30%; margin: auto">
            <label>Start Date:</label>
            <hvk:DatePicker runat="server"></hvk:DatePicker>
        </div>
        <div class="data end" style="width: 30%; margin: auto">
            <label>End Date:</label>
            <input runat="server" id="txtEnd" type="text" class="datepicker" />
        </div>
    </div>

    <div id="pets" runat="server">
        <div class='pet'>
            <div class="petId">
                <h2>
                    <asp:Label runat="server" ID="lblpet1">Sparly</asp:Label></h2>
            </div>
            <div>
                <div class="services">
                    <label>Services: </label>
                    <asp:CheckBoxList runat="server" ID="chlServices" TabIndex="11">
                        <asp:ListItem>Walk</asp:ListItem>
                        <asp:ListItem>Playtime</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
                <br />
                <asp:LinkButton runat="server" ID="viewMore" TabIndex="14">
                            View pricing information
                </asp:LinkButton>
            </div>
        </div>
    </div>
    <div class="actions services">
        <asp:Button runat="server" TabIndex="15" ID="btnMakeReservation"  Text="Book Now" />    <%--OnClick="btnMakeReservation_Click"--%>

        <asp:LinkButton runat="server" TabIndex="16" ID="btnCancelRes" Visible="false" Text="Cancel Reservation"></asp:LinkButton>
    </div>

    <%-- Validation control --%>
    <%-- Start date --%>
    <%--<asp:RequiredFieldValidator runat="server" ID="reqStart" ControlToValidate="txtStart" Display="None" Text="*" EnableClientScript="true" ErrorMessage="Please enter a start date."></asp:RequiredFieldValidator>--%>
    <%--<asp:CustomValidator runat="server" ID="cusStart" Display="None" Text="*" ErrorMessage="Please enter a valid start date." ControlToValidate="txtStart" OnServerValidate="cusStart_ServerValidate"></asp:CustomValidator>--%>

    <%-- End date --%>
    <%--<asp:RequiredFieldValidator runat="server" ID="reqEnd" ControlToValidate="txtEnd" Display="None" Text="*" EnableClientScript="true" ErrorMessage="Please enter an end date."></asp:RequiredFieldValidator>--%>
    <%--<asp:CustomValidator runat="server" ID="cusEnd" Display="None" Text="*" ErrorMessage="Please enter a valid start date." ControlToValidate="txtEnd" OnServerValidate="cusEnd_ServerValidate"></asp:CustomValidator>--%>
    <%--<asp:CustomValidator runat="server" ID="cusSEnd" Display="None" Text="*" ErrorMessage="End date must be after start date." ControlToValidate="txtEnd" OnServerValidate="compSEnd_ServerValidate"></asp:CustomValidator>--%>
</asp:Content>
