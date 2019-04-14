<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="4dataDataList.aspx.cs" Inherits="pdumaresq_C40_L10._4dataDataList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:SqlDataSource ID="dsOwner" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;OWNER_NUMBER&quot;, &quot;OWNER_FIRST_NAME&quot;, &quot;OWNER_LAST_NAME&quot;, &quot;OWNER_STREET&quot;, &quot;OWNER_CITY&quot;, &quot;OWNER_PROVINCE&quot;, &quot;OWNER_POSTAL_CODE&quot;, &quot;OWNER_PHONE&quot;, &quot;OWNER_EMAIL&quot; FROM &quot;HVK_OWNER&quot;"></asp:SqlDataSource>
        <asp:DataList ID="DataList1" runat="server" DataKeyField="OWNER_NUMBER" DataSourceID="dsOwner">
            <ItemTemplate>
                <asp:Label ID="lblOWNER_NAME" runat="server" Text='<%# Eval("OWNER_FIRST_NAME") + " " +  Eval("OWNER_LAST_NAME") %>' />
                <br />

                <asp:Label ID="OWNER_STREETLabel" runat="server" Text='<%# Eval("OWNER_STREET").ToString() != "" ? Eval("OWNER_STREET").ToString() + "<br />" : "" %>' />

                <asp:Label ID="OWNER_CITYLabel" runat="server" Text='<%# 
                    ((Eval("OWNER_CITY").ToString() != ""    )  ? Eval("OWNER_CITY").ToString() +  
                    ((Eval("OWNER_PROVINCE").ToString() != "")  ? ", " + Eval("OWNER_PROVINCE") + "<br />"     : 
                                                     "<br />")                                                 :
                    (Eval("OWNER_PROVINCE").ToString() != "" )  ? Eval("OWNER_PROVINCE").ToString() + "<br />" :
                                                           "") 
                %>' />
                
                <asp:Label ID="OWNER_POSTAL_CODELabel" runat="server" Text='<%# 
                    Eval("OWNER_POSTAL_CODE").ToString() != "" ? 
                        Eval("OWNER_POSTAL_CODE").ToString().Substring(0,3) + " " + Eval("OWNER_POSTAL_CODE").ToString().Substring(3) + "<br />"
                        : "" %>' />

                <asp:Label ID="OWNER_PHONELabel" runat="server" Text='<%# 
                    Eval("OWNER_PHONE") != null ? 
                        Regex.Replace((String)Eval("OWNER_PHONE"), @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3") 
                        : ""%>' />
                <br />
                <br />
            </ItemTemplate>
        </asp:DataList>
    
    </div>
    </form>
</body>
</html>
