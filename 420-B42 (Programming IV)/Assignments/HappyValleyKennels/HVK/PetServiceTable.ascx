<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PetServiceTable.ascx.cs" Inherits="HVK.PetServiceTable" %>

<asp:Table runat="server">
    <asp:TableRow>
        <asp:TableCell>
            <asp:Label runat="server" CssClass="petName" ID="lblPetName"></asp:Label>
            <asp:CheckBox runat="server" ID="chbInclude" Text="Include" Checked="true" AutoPostBack="false" CausesValidation="false" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell runat="server">
            <asp:CheckBoxList runat="server" ID="cblServices">
                <asp:ListItem Value="1">Walk</asp:ListItem>
                <asp:ListItem Value="2">Playtime</asp:ListItem>
            </asp:CheckBoxList>
        </asp:TableCell>
        <asp:TableCell>
            <asp:CheckBoxList runat="server" Id="cblVaccines">
                <asp:ListItem 1>Bordetella</asp:ListItem>
                <asp:ListItem 2>Distemper</asp:ListItem>
                <asp:ListItem 3>Parovirus</asp:ListItem>
                <asp:ListItem 4>Parainfluenza</asp:ListItem>
                <asp:ListItem 5>Parovirus</asp:ListItem>
                <asp:ListItem 6>Rabies</asp:ListItem>
            </asp:CheckBoxList>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>

