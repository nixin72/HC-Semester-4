<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1dataFormat.aspx.cs" Inherits="pdumaresq_C40_L10.L10DataSource" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="dsOwner" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="SELECT OWNER_NUMBER, OWNER_FIRST_NAME, OWNER_LAST_NAME, OWNER_STREET, OWNER_POSTAL_CODE, OWNER_PROVINCE, 
            OWNER_CITY, OWNER_PHONE, OWNER_EMAIL, EMERGENCY_CONTACT_FIRST_NAME, EMERGENCY_CONTACT_LAST_NAME, 
            EMERGENCY_CONTACT_PHONE, VET_VET_NUMBER FROM HVK_OWNER"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="OWNER_NUMBER" DataSourceID="dsOwner">
            <Columns>
                <asp:BoundField DataField="OWNER_NUMBER" HeaderText="Owner number" ReadOnly="True" SortExpression="OWNER_NUMBER" />
                <asp:BoundField DataField="OWNER_FIRST_NAME" HeaderText="First name" SortExpression="OWNER_FIRST_NAME" />
                <asp:BoundField DataField="OWNER_LAST_NAME" HeaderText="Last name" SortExpression="OWNER_LAST_NAME" />
                <asp:BoundField DataField="OWNER_STREET" HeaderText="Street" SortExpression="OWNER_STREET" />
                <asp:BoundField DataField="OWNER_POSTAL_CODE" HeaderText="Postal Code" SortExpression="OWNER_POSTAL_CODE" />
                <asp:BoundField DataField="OWNER_PROVINCE" HeaderText="Province" SortExpression="OWNER_PROVINCE" />
                <asp:BoundField DataField="OWNER_CITY" HeaderText="City" SortExpression="OWNER_CITY" />
                <asp:BoundField DataField="OWNER_PHONE" HeaderText="Phone number" SortExpression="OWNER_PHONE" />
                <asp:BoundField DataField="OWNER_EMAIL" HeaderText="Email" SortExpression="OWNER_EMAIL" />
                <asp:BoundField DataField="EMERGENCY_CONTACT_FIRST_NAME" HeaderText="Emergency contact- first name" SortExpression="EMERGENCY_CONTACT_FIRST_NAME" />
                <asp:BoundField DataField="EMERGENCY_CONTACT_LAST_NAME" HeaderText="Emergency contact- last name" SortExpression="EMERGENCY_CONTACT_LAST_NAME" />
                <asp:BoundField DataField="EMERGENCY_CONTACT_PHONE" HeaderText="Emergency contact- Phone number" SortExpression="EMERGENCY_CONTACT_PHONE" />
                <asp:BoundField DataField="VET_VET_NUMBER" HeaderText="Vet number" SortExpression="VET_VET_NUMBER" />
            </Columns>
        </asp:GridView>
        <br />
        <hr /><hr />
        <br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="OWNER_NUMBER" DataSourceID="dsOwner" AllowPaging="True" AllowSorting="True" BackColor="#CCFFFF" Caption="Owners" PageSize="6" ShowHeaderWhenEmpty="True">
            <AlternatingRowStyle BackColor="#66CCFF" />
            <Columns>
                <asp:TemplateField HeaderText="Name" SortExpression="OWNER_FIRST_NAME">
                    <ItemTemplate>
                        <%# Eval("OWNER_LAST_NAME") + ", " + Eval("OWNER_FIRST_NAME") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone">
                    <ItemTemplate>
                        <%# String.Format("{0: (###) ###-####}", Int64.Parse(Eval("OWNER_PHONE").ToString()))  %>
                        <%--<%# Regex.Replace((String)Eval("OWNER_PHONE"), @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3") %>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="City" SortExpression="OWNER_CITY">
                    <ItemTemplate>
                        <%# Eval("OWNER_CITY")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" Text='<%# Eval("OWNER_EMAIL")%>' NavigateUrl='<%# Eval("OWNER_EMAIL", "mailto:{0}") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="#3399FF" />
            <PagerSettings Mode="NextPreviousFirstLast" NextPageText="Next" PageButtonCount="6" PreviousPageText="Pevious" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
