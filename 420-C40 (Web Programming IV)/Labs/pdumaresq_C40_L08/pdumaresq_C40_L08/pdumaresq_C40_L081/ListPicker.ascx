<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListPicker.ascx.cs" Inherits="pdumaresq_C40_L081.ListPicker" %>
<style>
    td:nth-child(2n+1) {
        display: flex
    }
</style>

<table>
    <tr>
        <td>
            Available
            <asp:ListBox runat="server" ID="lstAvailable">
                <asp:ListItem>Maple Leafs</asp:ListItem>
                <asp:ListItem>Canadiens</asp:ListItem>
                <asp:ListItem>Senators</asp:ListItem>
                <asp:ListItem>Jets</asp:ListItem>
            </asp:ListBox>
        </td>
        <td>
            <asp:Button runat="server" ID="btnAddAll" Text=">>" OnClick="btnAddAll_Click"/>
            <br /><br />
            <asp:Button runat="server" ID="btnAddOne" Text=" > " OnClick="btnAddOne_Click" />
            <br /><br />
            <asp:Button runat="server" ID="btnRemove" Text=" X " OnClick="btnRemove_Click"/>
        </td>
        <td>
            Selected 
            <asp:ListBox runat="server" ID="lstSelected">

            </asp:ListBox>
        </td>
    </tr>
</table>