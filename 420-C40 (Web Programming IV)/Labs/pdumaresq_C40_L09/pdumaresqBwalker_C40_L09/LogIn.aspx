<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="pdumaresqBwalker_C40_L09.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        p {
            display: flex;
        }

        span {
            width: 20%;
        }

        input[type=submit] {
            width: 30%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 70%; margin: auto;">
            <h2>Sign up now!</h2>

            <p>
                <asp:Label runat="server">First Name: </asp:Label>
                <asp:TextBox runat="server" ID="fname"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Please enter a first name." ControlToValidate="fname"></asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label runat="server">Last Name: </asp:Label>
                <asp:TextBox runat="server" ID="lname"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Please enter a last name." ControlToValidate="lname"></asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label runat="server">Username:</asp:Label>
                <asp:TextBox runat="server" ID="user"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Please enter a username." ControlToValidate="user"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ErrorMessage="Username must begin with two letters" ControlToValidate="user" ValidationExpression="^[\w]{2,}.*$"></asp:RegularExpressionValidator>
            </p>
            <p>
                <asp:Label runat="server">Email: </asp:Label>
                <asp:TextBox runat="server" ID="email"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Please enter an email." ControlToValidate="email"></asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label runat="server">Birthdate: </asp:Label>
                <asp:Calendar runat="server" ID="birth"></asp:Calendar>
                <asp:TextBox runat="server" ID="txtbirth"></asp:TextBox>
                <asp:CustomValidator runat="server" ControlToValidate="txtbirth" ID="cusBirth" OnServerValidate="Unnamed_ServerValidate"></asp:CustomValidator>
            </p>
            <p>
                <asp:Label runat="server">Password: </asp:Label>
                <asp:TextBox runat="server" ID="pass"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Please enter a password." ControlToValidate="pass"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ErrorMessage="Please enter a valid password" ControlToValidate="pass" ValidationExpression="^(?=.*[\w\d]).{6,18}$"></asp:RegularExpressionValidator>
            </p>
            <p>
                <asp:Label runat="server">Confirm password: </asp:Label>
                <asp:TextBox runat="server" ID="cPass"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Please enter confirm your password." ControlToValidate="cPass"></asp:RequiredFieldValidator>
                <asp:CompareValidator runat="server" ErrorMessage="Your passwords do not match." ControlToCompare="pass" ControlToValidate="cPass"></asp:CompareValidator>
            </p>
            <asp:CheckBox runat="server" Text="I agree to the terms and conditions" />
            
                <br />
                <br />
                <asp:Button runat="server" Text="Create account."/>
        </div>
    </form>
</body>
</html>
