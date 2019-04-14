<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListPicker2.ascx.cs" Inherits="pdumaresq_C40_L081.ListPicker2" %>
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
            <asp:Button runat="server" ID="btnBackOne" Text=" < " OnClick="btnBackOne_Click"/>
            <br /><br />
            <asp:Button runat="server" ID="btnBackAll" Text=" << " OnClick="btnBackAll_Click"/>
        </td>
        <td>
            Selected 
            <asp:ListBox runat="server" ID="lstSelected">

            </asp:ListBox>
        </td>
    </tr>
</table>

<asp:CustomValidator runat="server" ErrorMessage="There is no teams available." ID="cusAvailableEmpty" Text="*" Display="None" ></asp:CustomValidator>

<asp:CustomValidator runat="server" ErrorMessage="There is no teams selected." ID="cusSelectedEmpty" Text="*" Display="None"></asp:CustomValidator>