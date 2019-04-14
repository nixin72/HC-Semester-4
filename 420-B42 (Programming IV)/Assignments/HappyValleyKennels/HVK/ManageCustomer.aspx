<%@ Page Title="" Language="C#" MasterPageFile="~/HVK.Master" AutoEventWireup="True" CodeBehind="ManageCustomer.aspx.cs" Inherits="HVKA03.ManageCustomer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage Customer</title>
    <link href="Styles/styles.css" type="text/css" rel="stylesheet"/>
</asp:Content>

<asp:Content ID="contPageTitle" ContentPlaceHolderID="pageTitle" runat="server">
    <asp:SqlDataSource ID="dbOwner" runat="server" ConnectionString="<%$ ConnectionStrings:dsHulk %>" 
        DeleteCommand="DELETE FROM HVK_OWNER WHERE OWNER_NUMBER = :OWNER_NUMBER" 
        InsertCommand="INSERT INTO HVK_OWNER (OWNER_NUMBER, OWNER_FIRST_NAME, OWNER_LAST_NAME, OWNER_STREET, OWNER_CITY, 
            OWNER_PROVINCE, OWNER_POSTAL_CODE, OWNER_PHONE, OWNER_EMAIL, EMERGENCY_CONTACT_FIRST_NAME, 
            EMERGENCY_CONTACT_LAST_NAME, EMERGENCY_CONTACT_PHONE) VALUES (:OWNER_NUMBER, :OWNER_FIRST_NAME, :OWNER_LAST_NAME, 
            :OWNER_STREET, :OWNER_CITY, :OWNER_PROVINCE, :OWNER_POSTAL_CODE, :OWNER_PHONE, :OWNER_EMAIL, 
            :EMERGENCY_CONTACT_FIRST_NAME, :EMERGENCY_CONTACT_LAST_NAME, :EMERGENCY_CONTACT_PHONE)" 
        ProviderName="<%$ ConnectionStrings:dsHulk.ProviderName %>" 
        SelectCommand="SELECT OWNER_NUMBER, OWNER_FIRST_NAME, OWNER_LAST_NAME, OWNER_STREET, OWNER_CITY, OWNER_PROVINCE, 
            OWNER_POSTAL_CODE, OWNER_PHONE, OWNER_EMAIL, EMERGENCY_CONTACT_FIRST_NAME, EMERGENCY_CONTACT_LAST_NAME, 
            EMERGENCY_CONTACT_PHONE FROM HVK_OWNER" 
        UpdateCommand="UPDATE HVK_OWNER SET OWNER_FIRST_NAME = :OWNER_FIRST_NAME, OWNER_LAST_NAME = :OWNER_LAST_NAME, 
            OWNER_STREET = :OWNER_STREET, OWNER_CITY = :OWNER_CITY, OWNER_PROVINCE = :OWNER_PROVINCE, 
            OWNER_POSTAL_CODE = :OWNER_POSTAL_CODE, OWNER_PHONE = :OWNER_PHONE, OWNER_EMAIL = :OWNER_EMAIL, 
            EMERGENCY_CONTACT_FIRST_NAME = :EMERGENCY_CONTACT_FIRST_NAME, 
            EMERGENCY_CONTACT_LAST_NAME = :EMERGENCY_CONTACT_LAST_NAME, 
            EMERGENCY_CONTACT_PHONE = :EMERGENCY_CONTACT_PHONE WHERE OWNER_NUMBER = :OWNER_NUMBER">
        <DeleteParameters>
            <asp:Parameter Name="OWNER_NUMBER" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="OWNER_NUMBER" Type="Decimal" />
            <asp:Parameter Name="OWNER_FIRST_NAME" Type="String" />
            <asp:Parameter Name="OWNER_LAST_NAME" Type="String" />
            <asp:Parameter Name="OWNER_STREET" Type="String" />
            <asp:Parameter Name="OWNER_CITY" Type="String" />
            <asp:Parameter Name="OWNER_PROVINCE" Type="String" />
            <asp:Parameter Name="OWNER_POSTAL_CODE" Type="String" />
            <asp:Parameter Name="OWNER_PHONE" Type="String" />
            <asp:Parameter Name="OWNER_EMAIL" Type="String" />
            <asp:Parameter Name="EMERGENCY_CONTACT_FIRST_NAME" Type="String" />
            <asp:Parameter Name="EMERGENCY_CONTACT_LAST_NAME" Type="String" />
            <asp:Parameter Name="EMERGENCY_CONTACT_PHONE" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="OWNER_FIRST_NAME" Type="String" />
            <asp:Parameter Name="OWNER_LAST_NAME" Type="String" />
            <asp:Parameter Name="OWNER_STREET" Type="String" />
            <asp:Parameter Name="OWNER_CITY" Type="String" />
            <asp:Parameter Name="OWNER_PROVINCE" Type="String" />
            <asp:Parameter Name="OWNER_POSTAL_CODE" Type="String" />
            <asp:Parameter Name="OWNER_PHONE" Type="String" />
            <asp:Parameter Name="OWNER_EMAIL" Type="String" />
            <asp:Parameter Name="EMERGENCY_CONTACT_FIRST_NAME" Type="String" />
            <asp:Parameter Name="EMERGENCY_CONTACT_LAST_NAME" Type="String" />
            <asp:Parameter Name="EMERGENCY_CONTACT_PHONE" Type="String" />
            <asp:Parameter Name="OWNER_NUMBER" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <h2>
        <asp:Label ID="lblPageTitle" runat="server" Text="Create User"></asp:Label>
    </h2>
</asp:Content>

<asp:Content ID="contContent" ContentPlaceHolderID="contPageContent" runat="server">

    <asp:ValidationSummary ID="valSum" ForeColor="red" runat="server"/>
    <div class="top">
        <div id="owner_photo" class="left">
            <img src="images/defaultProfile.png" alt="user photo" width="200" height="200"/>
        </div>
        <br/>
        <br/>
        <div id="contInfo" class="right">
            <div class="data">
                <label>*First Name: </label>
                <asp:TextBox ID="txtFName" runat="server" TabIndex="1" MaxLength="25">
                </asp:TextBox>
            </div>
            <br/>
            <div class="data">
                <label>*Last Name: </label>
                <asp:TextBox ID="txtlname" runat="server" TabIndex="2" MaxLength="25"></asp:TextBox>
            </div>
            <br/>
            <div class="data">
                <label>*Email Address: </label>
                <asp:TextBox ID="txtemail" runat="server" TabIndex="3" MaxLength="50"></asp:TextBox>
            </div>
            <br/>
            <div class="data">
                <label>Phone number: </label>
                <asp:TextBox ID="txtphone" runat="server" MaxLength="14" TabIndex="4"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="bottom">
        <div id="addressInfo" class="left">
            <div class="data">
                <label>Street: </label>
                <asp:TextBox ID="txtStreet" runat="server" TabIndex="5" MaxLength="40"></asp:TextBox>
            </div>
            <br/>
            <div class="data">
                <label>City: </label>
                <asp:TextBox ID="txtCity" runat="server" TabIndex="6" MaxLength="25"></asp:TextBox>
            </div>
            <br/>
            <div class="data">
                <label>Province: </label>
                <asp:DropDownList runat="server" ID="ddlProvince" TabIndex="7">
                    <asp:ListItem>Quebec</asp:ListItem>
                    <asp:ListItem>Ontario</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br/>
            <div class="data">
                <label>Postal Code: </label>
                <asp:TextBox ID="txtPostal" runat="server" TabIndex="8" MaxLength="7"></asp:TextBox>
            </div>
            <br/>
<%--            <asp:Panel ID="pnlSetPassword" runat="server" Visible="True">--%>
<%--                <h3>--%>
<%--                    <asp:Label runat="server" ID="lblChgPswrd">Set Password</asp:Label>--%>
<%--                </h3>--%>
<%--                <div class="data">--%>
<%--                    <asp:Label runat="server" ID="lblOldPswrd">*Password: </asp:Label>--%>
<%--                    <asp:TextBox TextMode="Password" ID="txtSetPswd" MaxLength="24" runat="server" TabIndex="12"></asp:TextBox>--%>
<%--                </div>--%>
<%--                <br/>--%>
<%--                <div class="data">--%>
<%--                    <asp:Label runat="server" ID="lblNewPswrd">*Confirm Password: </asp:Label>--%>
<%--                    <asp:TextBox TextMode="Password" ID="txtConfPswd" MaxLength="24" runat="server" TabIndex="13"></asp:TextBox>--%>
<%--                </div>--%>
<%--            </asp:Panel>--%>
<%--            <asp:Panel ID="pnlChangePassword" Display="none" runat="server" Wrap="True">--%>
<%--                <h3>--%>
<%--                    <asp:Label runat="server" ID="lblChangePassword">Change Password</asp:Label>--%>
<%--                </h3>--%>
<%--                <div class="data">--%>
<%--                    <asp:Label runat="server" ID="lblOldPassword">Old Password: </asp:Label>--%>
<%--                    <asp:TextBox TextMode="Password" ID="txtOldPassword" MaxLength="24" runat="server" TabIndex="12"></asp:TextBox>--%>
<%--                </div>--%>
<%--                <br/>--%>
<%--                <div class="data">--%>
<%--                    <asp:Label runat="server" ID="lblNewPassword">New Password: </asp:Label>--%>
<%--                    <asp:TextBox TextMode="Password" ID="txtNewPassword" runat="server" MaxLength="24" TabIndex="13"></asp:TextBox>--%>
<%--                </div>--%>
<%--            </asp:Panel>--%>
            <br/>
            <br/>
            <asp:Button ID="btnSave" runat="server" Text="Save" TabIndex="14" OnClick="btnSave_Click"/><%-- OnClick="btnSave_click"--%>
            <asp:LinkButton runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False"></asp:LinkButton>
            <asp:Panel runat="server" ID="deleteCustomer">
                <hr/>
                <asp:LinkButton runat="server" ID="btnDeleteCustomer" Text="Delete customer" OnClick="btnDeleteCustomer_Click"></asp:LinkButton>
            </asp:Panel>
        </div>

        <div id="emgCont" class="right">
            <h3>Emergency Contact Information</h3>
            <br/>
            <div class="data">
                <label>First Name: </label>
                <br/>
                <asp:TextBox ID="txtEmgF" runat="server" TabIndex="9" MaxLength="25"></asp:TextBox>
            </div>
            <br/>
            <div class="data">
                <label>Last Name: </label>
                <br/>
                <asp:TextBox ID="txtEmgL" runat="server" TabIndex="10" MaxLength="25"></asp:TextBox>
            </div>
            <br/>
            <div class="data">
                <label>Phone Number: </label>
                <br/>
                <asp:TextBox ID="txtEmgP" runat="server" MaxLength="14" TabIndex="11"></asp:TextBox>
            </div>
        </div>
    </div>


<%--     First Name Validation --%>
    <asp:RequiredFieldValidator ID="reqFirstName" runat="server" ErrorMessage="Please enter a first name." 
        ControlToValidate="txtFName" Display="None" Text="*"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="regFirstName" ValidationExpression="[À-ÿ\w,'\.-]{1,25}" runat="server" 
        ErrorMessage="Please enter a valid name" ControlToValidate="txtfname" 
        Display="None" Text="*"></asp:RegularExpressionValidator>

<%--     Last Name Validation --%>
    <asp:RequiredFieldValidator ID="reqLastName" runat="server" ErrorMessage="Please enter a last name." 
        ControlToValidate="txtlname" Display="None" Text="*"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="regLastName" ValidationExpression="[À-ÿ\w,'\.-]{1,25}" 
        runat="server" ErrorMessage="Please enter a valid last name" ControlToValidate="txtlname" 
        Display="None" Text="*"></asp:RegularExpressionValidator>

    <%-- Email Address --%>
    <asp:RequiredFieldValidator ControlToValidate="txtemail" ErrorMessage="Please enter an email address" 
        Display="None" Text="*" ID="reqEmail" runat="server"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator 
        ValidationExpression="^(?!.*(\s)).*[^.\s][À-ÿ\d\w!#$%&'*\.+\-/=?^_`{|}~;]+[^.]*\@[\d\w\-À-ÿ]+\.[À-ÿ\w]{1,10}$" 
        ID="regexEmail" runat="server" ErrorMessage="Please enter a valid email address" 
        ControlToValidate="txtemail" Display="None" Text="*"></asp:RegularExpressionValidator>

    <%-- Phone Number --%>
    <asp:RegularExpressionValidator ValidationExpression="^((\(\d{3}\))|\d{3}|\d{3}-)\s?\d{3}[\s\-]?\d{4}$" 
        ID="regPhoneNumber" runat="server" ErrorMessage="Please enter a valid phone number" 
        ControlToValidate="txtphone" Display="None" Text="*"></asp:RegularExpressionValidator>

    <%-- Street Address --%>
    <asp:RegularExpressionValidator ValidationExpression="^([\d\s\wÀ-ÿ!.\-_()]){1,40}$" ID="regStreet" 
        runat="server" ErrorMessage="Please enter a valid street name." ControlToValidate="txtStreet" 
        Display="None" Text="*"></asp:RegularExpressionValidator>

    <%-- City --%>
    <asp:RegularExpressionValidator ValidationExpression="^([\d\s\wÀ-ÿ!.\-_()]){1,40}$" ID="regCity" 
        runat="server" ErrorMessage="Please enter a city name." ControlToValidate="txtCity" Display="None" 
        Text="*"></asp:RegularExpressionValidator>

    <%-- Postal Code --%>
    <asp:RegularExpressionValidator ID="regPostal" runat="server" ErrorMessage="Please enter a valid postal code." 
        ControlToValidate="txtPostal" ValidationExpression="^\w\d\w(\s?)\d\w\d$" 
        Display="None" Text="*"></asp:RegularExpressionValidator>

    <%-- Emergency contact first name --%>
    <asp:RegularExpressionValidator ID="regEmgF" ValidationExpression="[À-ÿ\w,'\.-]{1,25}" runat="server" 
        ControlToValidate="txtEmgF" ErrorMessage="Please enter a valid first name for your emergency contact." 
        Display="None" Text="*"></asp:RegularExpressionValidator>

    <%-- Emergency contact last name --%>
    <asp:RegularExpressionValidator ID="regEmgL" ValidationExpression="[À-ÿ\w,'\.-]{1,25}" runat="server" 
        ControlToValidate="txtEmgL" ErrorMessage="Please enter a valid last name for your emergency contact." 
        Display="None" Text="*"></asp:RegularExpressionValidator>

    <%-- Emergency contact Phone number --%>
    <asp:RegularExpressionValidator ValidationExpression="^((\(\d{3}\))|\d{3}|\d{3}-)\s?\d{3}[\s\-]?\d{4}$" 
        ID="regEmgP" runat="server" ErrorMessage="Please enter a valid phone number" ControlToValidate="txtEmgP" 
        Display="None" Text="*"></asp:RegularExpressionValidator>

    <%-- Set Password --%>
<%--    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtSetPswd" ErrorMessage="Please enter a password." --%>
<%--        Display="None" Text="*"></asp:RequiredFieldValidator>--%>
<%--    <asp:RegularExpressionValidator ValidationExpression="^(?=.*[A-Z]).*$" ID="regPassUpper" ControlToValidate="txtSetPswd" --%>
<%--        runat="server" ErrorMessage="Your password must contain at least one Upper case letter." Display="None" --%>
<%--        Text="*"></asp:RegularExpressionValidator>--%>
<%--    <asp:RegularExpressionValidator ValidationExpression="^(?=.*[a-z]).*$" ID="regPassLower" --%>
<%--        ControlToValidate="txtSetPswd" runat="server" ErrorMessage="Your password must contain at least one Lower case letter." --%>
<%--        Display="None" Text="*"></asp:RegularExpressionValidator>--%>
<%--    <asp:RegularExpressionValidator ValidationExpression="^(?=.*[!@#$%^&*()_+{}[\]\\|:;'<,>.?/~`,\"]).*$" --%>
<%--        ControlToValidate="txtSetPswd" ID="regPassSymbol" runat="server" --%>
<%--        ErrorMessage="Your password must contain at least one special character." Display="None" --%>
<%--        Text="*"></asp:RegularExpressionValidator>--%>
<%--    <asp:RegularExpressionValidator ValidationExpression="^(?=.*[0-9]).*$" ID="regPassDigit" ControlToValidate="txtSetPswd" --%>
<%--        runat="server" ErrorMessage="Your password must contain at least one number." Display="None" --%>
<%--        Text="*"></asp:RegularExpressionValidator>--%>
<%--    <asp:RegularExpressionValidator ValidationExpression="^(?!.*[\s]).*$" ID="regPassIllegal" --%>
<%--        ControlToValidate="txtSetPswd" runat="server" ErrorMessage="Your password may not contain any whitespece characters." --%>
<%--        Display="None" Text="*"></asp:RegularExpressionValidator>--%>
<%--    <asp:RegularExpressionValidator ValidationExpression="^.{8,24}$" ID="regPassLength" ControlToValidate="txtSetPswd" --%>
<%--        runat="server" ErrorMessage="Your password must be betweem 8 and 24 characters long." --%>
<%--        Display="None" Text="*"></asp:RegularExpressionValidator>--%>

    <%-- Confirm password --%>
<%--    <asp:RequiredFieldValidator ID="cusConfPswd" runat="server" ErrorMessage="Please confirm your password." --%>
<%--        Display="None" Text="*" ControlToValidate="txtConfPswd"></asp:RequiredFieldValidator>--%>
<%--    <asp:CompareValidator ID="compConfPswd" runat="server" ErrorMessage="Passwords do not match" Display="None" --%>
<%--        Text="*" ControlToValidate="txtConfPswd" ControlToCompare="txtSetPswd" Operator="Equal"></asp:CompareValidator>--%>

    <%-- New Password --%>
<%--    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Please enter a password." Display="None" --%>
<%--        Text="*"></asp:CustomValidator>--%>
<%--    <asp:RegularExpressionValidator ValidationExpression="^(?=.*[A-Z]).*$" ID="regNewUpper" --%>
<%--        ControlToValidate="txtNewPassword" runat="server" ErrorMessage="Your password must contain at least one Upper case letter." --%>
<%--        Display="None" Text="*"></asp:RegularExpressionValidator>--%>
<%--    <asp:RegularExpressionValidator ValidationExpression="^(?=.*[a-z]).*$" ID="regNewLower" --%>
<%--        ControlToValidate="txtNewPassword" runat="server" ErrorMessage="Your password must contain at least one Lower case letter." --%>
<%--        Display="None" Text="*"></asp:RegularExpressionValidator>--%>
<%--    <asp:RegularExpressionValidator ValidationExpression="^(?=.*[!@#$%^&*()_+{}[\]\\|:;'<,>.?/~`,\"]).*$" --%>
<%--        ControlToValidate="txtNewPassword" ID="RegularExpressionValidator3" runat="server" --%>
<%--        ErrorMessage="Your password must contain at least one special character." Display="None" --%>
<%--        Text="*"></asp:RegularExpressionValidator>--%>
<%--    <asp:RegularExpressionValidator ValidationExpression="^(?=.*[0-9]).*$" ID="regNewDigit" ControlToValidate="txtNewPassword" --%>
<%--        runat="server" ErrorMessage="Your password must contain at least one number." Display="None" --%>
<%--        Text="*"></asp:RegularExpressionValidator>--%>
<%--    <asp:RegularExpressionValidator ValidationExpression="^(?!.*[\s]).*$" ID="regNewSpecial" --%>
<%--        ControlToValidate="txtNewPassword" runat="server" ErrorMessage="Your password may not contain any whitespece characters." --%>
<%--        Display="None" Text="*"></asp:RegularExpressionValidator>--%>
<%--    <asp:RegularExpressionValidator ValidationExpression="^.{8,24}$" ID="regNewLength" ControlToValidate="txtNewPassword" --%>
<%--        runat="server" ErrorMessage="Your password must be betweem 8 and 24 characters long." Display="None" --%>
<%--        Text="*"></asp:RegularExpressionValidator>--%>
</asp:Content>
