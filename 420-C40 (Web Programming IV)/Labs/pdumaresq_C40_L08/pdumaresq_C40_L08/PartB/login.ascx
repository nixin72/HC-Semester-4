<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="login.ascx.cs" Inherits="PartB.login" %>

<asp:Label runat="server" ID="lblUsername" Text="Username"></asp:Label>
<br />
<asp:TextBox runat="server" ID="txtUsername" ></asp:TextBox>

<br /><br />

<asp:Label runat="server" ID="lblPassword" Text="Password"></asp:Label>
<br />
<asp:TextBox runat="server" ID="txtPassword"></asp:TextBox>

<br /><br />

<asp:Button runat="server" Value="Log In" />

<asp:RegularExpressionValidator ID="regUsername" runat="server" ControlToValidate="txtUsername" 
    ValidationExpression="^heritage$" ErrorMessage=""></asp:RegularExpressionValidator>

<asp:RegularExpressionValidator ID="regPassword" runat="server" ControlToValidate="txtPassword" 
    ValidationExpression="^c40$"  ErrorMessage=""></asp:RegularExpressionValidator>