<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="myName.ascx.cs" Inherits="Part_C___Say_Hello.myName" %>

<asp:Label runat="server" Text="First name: " ></asp:Label>
<asp:TextBox runat="server" ID="txtFirstName" ></asp:TextBox>

<br /><br />

<asp:Label runat="server" Text="Last name: " ></asp:Label>
<asp:TextBox runat="server" ID="txtLastName" ></asp:TextBox>


<br /><br />

<asp:Label runat="server" Text="Count: " ></asp:Label>
<asp:TextBox runat="server" ID="txtCount" ></asp:TextBox>

<br /><br />

<asp:Button runat="server" Text="Say Hello" ID="btnGreet" OnClick="btnGreet_Click"/>