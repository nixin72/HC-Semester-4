<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2PagingData.aspx.cs" Inherits="pdumaresq_C40_L10._2PagingData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="dsPet" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT O.OWNER_FIRST_NAME, O.OWNER_LAST_NAME, P.PET_NAME, P.PET_BREED, P.PET_BIRTHDATE, P.PET_GENDER, P.DOG_SIZE, P.PET_FIXED FROM PDUMARESQ.HVK_OWNER O INNER JOIN PDUMARESQ.HVK_PET P ON O.OWNER_NUMBER = P.OWN_OWNER_NUMBER ORDER BY O.OWNER_FIRST_NAME"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="dsPet" PageSize="6">
            <Columns>
                <asp:TemplateField HeaderText="Owner Name">
                    <ItemTemplate>
                        <%# Eval("OWNER_FIRST_NAME") + " " + Eval("OWNER_LAST_NAME") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PET_NAME" HeaderText="Pet name" SortExpression="PET_NAME" />
                <asp:BoundField DataField="PET_BREED" HeaderText="breed" SortExpression="PET_BREED" />
                <asp:TemplateField HeaderText="Birthdate">
                    <ItemTemplate>
                        <%# Eval("PET_BIRTHDATE", "{0:yyyy/MM/dd}") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PET_GENDER" HeaderText="Sex" SortExpression="PET_GENDER" />
                <asp:BoundField DataField="DOG_SIZE" HeaderText="Size" SortExpression="DOG_SIZE" />
                <asp:BoundField DataField="PET_FIXED" HeaderText="fixed" SortExpression="PET_FIXED" />
            </Columns>
            <PagerSettings NextPageImageUrl="~/images/forward.jpg" PreviousPageImageUrl="~/images/backwards.jpg" Mode="NextPreviousFirstLast" NextPageText="" PageButtonCount="6" PreviousPageText="" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
