<%@ Page Title="" Language="C#" MasterPageFile="~/HVK.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HVKA03.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage Customer</title>
    <link href="Styles/styles.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageTitle" runat="server">
        <asp:SqlDataSource ID="dbOwner" runat="server" 
        ConnectionString="<%$ ConnectionStrings:dsHulk %>" 
        ProviderName="<%$ ConnectionStrings:dsHulk.ProviderName %>" 
        SelectCommand="SELECT OWNER_NUMBER, OWNER_EMAIL FROM HVK_OWNER"></asp:SqlDataSource>
    <h1>Log in</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contPageContent" runat="server">
    <div id="logInContainer">
    <div id="logInForm">
        <asp:Label runat="server" ID="lblEmailOrPhone">Email or Phone Number: </asp:Label><br />
        <asp:TextBox runat="server" ID="txtEmailOrPhone"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmailOrPhone" Display="Dynamic" ForeColor="Red" ErrorMessage="Your email or  phone is required to login"></asp:RequiredFieldValidator>
        <br />
        <br />
        <div id="passwordField">
            <asp:Label runat="server" ID="lblPassword">Password: </asp:Label><br />
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
            <h5>
                <asp:LinkButton runat="server" ID="lbtnForgotPass" ForeColor="Black" Text="Forgot password?"></asp:LinkButton>
            </h5>
        </div>

        <br />
        <asp:Label ID="lblErrors" CssClass="errorMsg" runat="server" Text=""></asp:Label>
        <br />
        <asp:CheckBox runat="server" ID="chbRememberMe" Text="Remember me" />
        <br />
        <br />
        <div class="flex-container">
            <asp:Button runat="server" ID="btnLogIn" OnClick="btnLogIn_Click" Text="Log In" />
            <div class="lower flex-container">
                <div>
<%--                    <asp:Label runat="server" ID="lblNotRegistered" ToolTip="You can create a new Happy Valley Kennels Account by clicking here!" Text="Not Registered?"></asp:Label>--%>
                    <asp:LinkButton ID="lbtnNotRegistered" runat="server" OnClick="lbtnNotRegistered_Click">Not Registered?</asp:LinkButton>
                    <br />
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
