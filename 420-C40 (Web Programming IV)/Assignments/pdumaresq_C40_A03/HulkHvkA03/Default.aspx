<%@ Page Title="" Language="C#" MasterPageFile="~/PD_HVK.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HulkHvkA03.Default" %>

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
    <div id="logInForm">
        <asp:Label runat="server" ID="lblEmailOrPhone">Email or Phone Number: </asp:Label><br />
        <asp:TextBox runat="server" ID="txtEmailOrPhone"></asp:TextBox>
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
        <br />
        <asp:CheckBox runat="server" ID="chbRememberMe" Text="Remember me" />
        <br />
        <br />
        <div class="flex-container">
            <asp:Button runat="server" ID="btnLogIn" OnClick="btnLogIn_Click" Text="Log In" />
            <div class="lower flex-container">
                <div>
                    <asp:Label runat="server" ID="lblNotRegistered" Text="Not Registered?"></asp:Label>
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
