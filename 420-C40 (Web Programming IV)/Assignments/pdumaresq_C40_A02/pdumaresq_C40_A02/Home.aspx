<%@ Page Title="" Language="C#" MasterPageFile="~/PD_HVK.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="pdumaresq_C40_A02.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage Customer</title>
    <link href="Styles/styles.css" type="text/css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="pageTitle" runat="server">
    <h2>
        <asp:Label runat="server" ID="lblPageTitle">Home</asp:Label></h2>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contPageContent" runat="server">

    <asp:Panel runat="server" ID="pnlCustomer" CssClass="pnlCustomer">
        <div id="homeOwnerContainer" class="flex-container" style="display: flex; margin: auto; width: 80%;">
            <div runat="server" id="homeLeftPanel" style="border: thin solid black; width: 40%">
                <%-- Customer info --%>
                <div id="customerInfo" class="flex-container" style="display: flex;">
                    <div class="homeProfilePic">
                        <asp:Image runat="server" ImageUrl="~/images/defaultProfile.png" ID="profilePic" Width="50" Height="50" />
                    </div>
                    <div class="info">
                        <asp:Label runat="server" ID="lblCusFname" Text="First name: Philip"></asp:Label>
                        <br />
                        <asp:Label runat="server" ID="lblCusLname" Text="Last name: Dumaresq"></asp:Label>
                        <br />
                        Edit
                    </div>
                </div>

                <%-- Pets --%>
                <div id="pets">
                    <h2>Pets:</h2>
                    <hr />
                    <asp:Panel runat="server" ID="pnlPets">
                    </asp:Panel>
                </div>
            </div>

            <%-- Reservations --%>
            <asp:Panel runat="server" ID="reservationsAndClerk" CssClass="resClerk">
                <asp:Panel runat="server" ID="pnlClerk" Visible="false">
                    <asp:TextBox runat="server" TextMode="Search" ID="txtCustomerSearch"></asp:TextBox>
                    <asp:LinkButton runat="server" Text="Search" ID="btnCustomerSearch" />
                    
                    <br /><br />
                </asp:Panel>

                <div class="customerReservations">
                    <h2>Reservations:</h2>
                    <hr />
                    <asp:Table runat="server" ID="tblReservations" CssClass="tblReservations">
                        <asp:TableHeaderRow runat="server" CssClass="resCell">
                            <asp:TableHeaderCell runat="server" CssClass="resCell" ID="thcCustomer" Visible="false">Customer name</asp:TableHeaderCell>
                            <asp:TableHeaderCell runat="server" CssClass="resCell">Start Date</asp:TableHeaderCell>
                            <asp:TableHeaderCell runat="server" CssClass="resCell"></asp:TableHeaderCell>
                            <asp:TableHeaderCell runat="server" CssClass="resCell">End Date</asp:TableHeaderCell>
                            <asp:TableHeaderCell runat="server" CssClass="resCell">Pets</asp:TableHeaderCell>
                            <asp:TableHeaderCell runat="server" CssClass="resCell"></asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>
            </asp:Panel>
        </div>
    </asp:Panel>
</asp:Content>
