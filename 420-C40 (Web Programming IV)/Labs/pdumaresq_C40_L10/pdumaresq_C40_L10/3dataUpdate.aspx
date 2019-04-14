<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="3dataUpdate.aspx.cs" Inherits="pdumaresq_C40_L10._3dataUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="dsOwner" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="SELECT OWNER_NUMBER, OWNER_FIRST_NAME, OWNER_LAST_NAME, 
                OWNER_STREET, OWNER_CITY, OWNER_POSTAL_CODE, OWNER_PROVINCE, 
                OWNER_PHONE, OWNER_EMAIL FROM HVK_OWNER"
            
            UpdateCommand="UPDATE HVK_OWNER
                            SET OWNER_FIRST_NAME  = :OWNER_FIRS_TNAME, 
                                OWNER_LAST_NAME   = :OWNER_LAST_NAME, 
                                OWNER_STREET      = :OWNER_STREET,
                                OWNER_CITY        = :OWNER_CITY,
                                OWNER_POSTAL_CODE = :OWNER_POSTAL_CODE,
                                OWNER_PROVINCE    = :OWNER_PROVINCE,
                                OWNER_PHONE       = :OWNER_PHONE,
                                OWNER_EMAIL       = :OWNER_EMAIL
                            WHERE OWNER_NUMBER    = :OWNER_NUMBER">
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="OWNER_NUMBER" DataSourceID="dsOwner">
            <Columns>
                <asp:CommandField ShowEditButton="true" EditText="Modify" />
                <asp:BoundField DataField="OWNER_FIRST_NAME" HeaderText="First name" SortExpression="OWNER_FIRST_NAME" />
                <asp:BoundField DataField="OWNER_LAST_NAME" HeaderText="Last name" SortExpression="OWNER_LAST_NAME" />
                <asp:BoundField DataField="OWNER_STREET" HeaderText="Street" SortExpression="OWNER_STREET" />
                <asp:BoundField DataField="OWNER_CITY" HeaderText="City" SortExpression="OWNER_CITY" />
                <asp:BoundField DataField="OWNER_POSTAL_CODE" HeaderText="Postal code" SortExpression="OWNER_POSTAL_CODE" />
                <asp:BoundField DataField="OWNER_PROVINCE" HeaderText="Province" SortExpression="OWNER_PROVINCE" />
                <asp:BoundField DataField="OWNER_PHONE" HeaderText="Phone" SortExpression="OWNER_PHONE" />
                <asp:BoundField DataField="OWNER_EMAIL" HeaderText="Email" SortExpression="OWNER_EMAIL" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
