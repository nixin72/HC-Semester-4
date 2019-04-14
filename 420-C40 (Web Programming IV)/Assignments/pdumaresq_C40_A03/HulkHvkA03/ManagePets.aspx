<%@ Page Title="" Language="C#" MasterPageFile="~/PD_HVK.Master" AutoEventWireup="true" CodeBehind="ManagePets.aspx.cs" Inherits="HulkHvkA03.ManagePets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage Pets</title>
    <link href="Styles/styles.css" type="text/css" rel="stylesheet" />

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            $(".datepicker").datepicker();
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="pageTitle" runat="server">
    <h2>
        <asp:Label runat="server" ID="lblPageTitle">Add Pet</asp:Label></h2>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contPageContent" runat="server">
    <div id="petForm">
        <asp:Panel runat="server" ID="petList">
            <fieldset>
                <legend>Pets
                </legend>
                    <asp:SqlDataSource ID="dsPetsForOwner" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:dsHulk %>" 
                        ProviderName="<%$ ConnectionStrings:dsHulk.ProviderName %>" 
                        SelectCommand="
                            SELECT PET_NUMBER, PET_NAME, PET_GENDER, PET_FIXED, 
                                PET_BREED, PET_BIRTHDATE, DOG_SIZE, SPECIAL_NOTES 
                            FROM TEAMHULK.HVK_PET 
                            WHERE (OWN_OWNER_NUMBER = :OWNER_NUMBER)">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="15" SessionField="OWNER_NUMBER" Type="Int16" Name="OWNER_NUMBER" />
                            <%--<asp:Parameter Direction="Input" DefaultValue="18" Type="Int16" Name="OWNER_NUMBER" />--%>
                        </SelectParameters>
                    </asp:SqlDataSource>

                <asp:RadioButtonList ID="rblAllPets" runat="server" DataSourceID="dsPetsForOwner" DataTextField="PET_NAME" DataValueField="PET_NUMBER" AutoPostBack="True">
                </asp:RadioButtonList>
                <br />
                <asp:LinkButton ID="addPet" runat="server" Text="Add Pet"></asp:LinkButton>
            </fieldset>
            
        </asp:Panel>

        <asp:ValidationSummary ID="valSum" ForeColor="red" runat="server" />

        <asp:SqlDataSource ID="dsPetInfo" runat="server" 
            ConnectionString="<%$ ConnectionStrings:dsHulk %>" 
            DeleteCommand="DELETE FROM HVK_PET WHERE PET_NUMBER = ?"
            InsertCommand="
                INSERT INTO HVK_PET (
                    PET_NUMBER, PET_NAME, PET_GENDER, PET_FIXED, PET_BREED, PET_BIRTHDATE, 
                    OWN_OWNER_NUMBER, PET_PICTURE, DOG_SIZE, SPECIAL_NOTES
                ) VALUES (
                    :PET_NUMBER, :PET_NAME, :PET_GENDER, :PET_FIXED, :PET_BREED, :PET_BIRTHDATE, 
                    :OWN_OWNER_NUMBER, :PET_PICTURE, :DOG_SIZE, :SPECIAL_NOTES
                )" 
            ProviderName="<%$ ConnectionStrings:dsHulk.ProviderName %>" 
            SelectCommand="SELECT * FROM HVK_PET WHERE (PET_NUMBER = :PET_NUMBER)" 
            UpdateCommand="
                UPDATE HVK_PET 
                    SET PET_NAME = :PET_NAME, 
                    PET_GENDER = :PET_GENDER, 
                    PET_FIXED = :PET_FIXED, 
                    PET_BREED = :PET_BREED, 
                    PET_BIRTHDATE = :PET_BIRTHDATE, 
                    DOG_SIZE = :DOG_SIZE, 
                    SPECIAL_NOTES = :SPECIAL_NOTES
                WHERE PET_NUMBER = ?">
            <SelectParameters>
                <asp:ControlParameter ControlID="rblAllPets" Type="Int16" DefaultValue="1" PropertyName="SelectedValue" Name="PET_NUMBER" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="PET_NUMBER" Type="Decimal" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="PET_NAME" Type="String" />
                <asp:Parameter Name="PET_GENDER" Type="String" />
                <asp:Parameter Name="PET_FIXED" Type="String" />
                <asp:Parameter Name="PET_BREED" Type="String" />
                <asp:Parameter Name="PET_BIRTHDATE" Type="DateTime" />
                <asp:Parameter Name="DOG_SIZE" Type="String" />
                <asp:Parameter Name="SPECIAL_NOTES" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="PET_NAME" Type="String" />
                <asp:Parameter Name="PET_GENDER" Type="String" />
                <asp:Parameter Name="PET_FIXED" Type="String" />
                <asp:Parameter Name="PET_BREED" Type="String" />
                <asp:Parameter Name="PET_BIRTHDATE" Type="DateTime" />
                <asp:Parameter Name="DOG_SIZE" Type="String" />
                <asp:Parameter Name="SPECIAL_NOTES" Type="String" />
                <asp:Parameter Name="PET_NUMBER" Type="Decimal" />
            </UpdateParameters>
        </asp:SqlDataSource>

        <br />
        <asp:DetailsView ID="dvFormData" runat="server" DataSourceID="dsPetInfo" Height="138px" Width="604px" AutoGenerateRows="False" DataKeyNames="PET_NUMBER">
            <Fields>
                <asp:BoundField DataField="PET_NAME" HeaderText="PET_NAME" SortExpression="PET_NAME" />
                <asp:BoundField DataField="PET_GENDER" HeaderText="PET_GENDER" SortExpression="PET_GENDER" />
                <asp:BoundField DataField="PET_FIXED" HeaderText="PET_FIXED" SortExpression="PET_FIXED" />
                <asp:BoundField DataField="PET_BREED" HeaderText="PET_BREED" SortExpression="PET_BREED" />
                <asp:BoundField DataField="PET_BIRTHDATE" HeaderText="PET_BIRTHDATE" SortExpression="PET_BIRTHDATE" />
                <asp:BoundField DataField="DOG_SIZE" HeaderText="DOG_SIZE" SortExpression="DOG_SIZE" />
                <asp:BoundField DataField="SPECIAL_NOTES" HeaderText="SPECIAL_NOTES" SortExpression="SPECIAL_NOTES" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
        <br />
        <div class="top">
            <div class="data">
                <label class="textInput">*Pet Name:</label>
                <asp:TextBox ID="txtName" MaxLength="25" runat="server" TabIndex="1"></asp:TextBox>
            </div>
            <br />
            <div class="data">
                <label>Breed: </label>
                <asp:TextBox ID="txtBreed" MaxLength="50" runat="server" TabIndex="2"></asp:TextBox>
            </div>
        </div>

        <br />
        <br />
        <h3>Medical Information: </h3>
        <hr />
        <br />
        <div class="data">
            <label>Birthdate: </label>
            <asp:DropDownList runat="server" ID="ddlYear" TabIndex="3">
                <asp:ListItem Selected="True" Value="--Year--">--Year--</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;|&nbsp;&nbsp;
            <asp:DropDownList runat="server" ID="ddlMonth" TabIndex="4">
                <asp:ListItem Selected="True" Value="--Month--">--Month--</asp:ListItem>
            </asp:DropDownList>
        </div>

        <br />
        <div id="lists">
            <div id="sexFixed">
                <div id="sex">
                    <label>*Sex:&nbsp;</label><br />
                    <asp:RadioButtonList ID="rblSexList" runat="server" TabIndex="5">
                        <asp:ListItem Value="m" Selected="true">Male</asp:ListItem>
                        <asp:ListItem Value="f">Female</asp:ListItem>
                    </asp:RadioButtonList>
                </div>

                <label>Fixed:&nbsp;&nbsp;&nbsp;</label>
                <asp:CheckBox ID="chbFixed" runat="server" TabIndex="6" />
            </div>

            <div id="size">
                <br />
                <label>Pet Size: </label>
                <asp:RadioButtonList ID="rblPetSizeList" runat="server" TabIndex="7">
                    <asp:ListItem Value="s" Selected="True">Small</asp:ListItem>
                    <asp:ListItem Value="m">Medium</asp:ListItem>
                    <asp:ListItem Value="l">Large</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <br />
        <div id="vaccinations">
            <asp:Table ID="vaccTable" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <div class="flex-container">
                            <div class="data">
                                <asp:Label runat="server" ID="lblBordetella">Bordetella</asp:Label>
                                <input runat="server" id="txtBordetella" type="text" class="datepicker" />
                            </div>
                            &nbsp;&nbsp;&nbsp;
                            <asp:CheckBox runat="server" ID="chbValBordetella" Text="Valide?" CssClass="Vaccinevalidator" />
                        </div>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <div class="flex-container">
                            <div class="data">
                                <asp:Label runat="server" ID="lblDistemper">Distemper</asp:Label>
                                <input runat="server" id="txtDistemper" type="text" class="datepicker" />
                            </div>
                            &nbsp;&nbsp;&nbsp;
                            <asp:CheckBox runat="server" ID="chbValDistemper" Text="Valide?" CssClass="Vaccinevalidator" />
                        </div>

                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <div class="flex-container">
                            <div class="data">
                                <asp:Label runat="server" ID="lblHepatitis">Hepatitis</asp:Label>
                                <input runat="server" id="txtHepatitis" type="text" class="datepicker" />
                            </div>
                            &nbsp;&nbsp;&nbsp;
                            <asp:CheckBox runat="server" ID="chbValHepatitis" Text="Valide?" CssClass="Vaccinevalidator" />
                        </div>

                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <div class="flex-container">
                            <div class="data">
                                <asp:Label runat="server" ID="lblParainfluenza">Parainfluenza</asp:Label>
                                <input runat="server" id="txtParainfluenza" type="text" class="datepicker" />
                            </div>
                            &nbsp;&nbsp;&nbsp;
                            <asp:CheckBox runat="server" ID="chbValParainfluenza" Text="Valide?" CssClass="Vaccinevalidator" />

                        </div>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <div class="flex-container">
                            <div class="data">
                                <asp:Label runat="server" ID="lblParovirus">Parovirus</asp:Label>
                                <input runat="server" id="txtParovirus" type="text" class="datepicker" />
                            </div>
                            &nbsp;&nbsp;&nbsp;
                            <asp:CheckBox runat="server" ID="chbValParovirus" Text="Valide?" CssClass="Vaccinevalidator" />
                        </div>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <div class="flex-container">
                            <div class="data">
                                <asp:Label runat="server" ID="lblRabies">Rabies</asp:Label>
                                <input runat="server" id="txtRabies" type="text" class="datepicker" />
                            </div>
                            &nbsp;&nbsp;&nbsp;
                            <asp:CheckBox runat="server" ID="chbValRabies" Text="Valide?" CssClass="Vaccinevalidator" />
                        </div>

                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <br />
        <h3>Pet Personality</h3>
        <hr />
        <!--<br />
            <div id="traits">
                <label>Traits:</label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <div>
                    <asp:CheckBox runat="server" ID="chbBarker" Text="Barker" TabIndex="9"></asp:CheckBox>
                    <br />
                    <asp:CheckBox runat="server" ID="chbClimber" Text="Climber" TabIndex="10"></asp:CheckBox>
                </div>   
            </div>-->

        <br />
        <label>Please Tell us a bit about your dog!</label><br />
        <asp:TextBox ID="txtPetNotes" MaxLength="200" TextMode="multiline" Columns="50" Rows="7" runat="server" TabIndex="11"></asp:TextBox>
        <br />
        <br />

        <div class="actions">
            <asp:Button ID="btnSave" runat="server" Text="Add Pet"  TabIndex="12" /><%--OnClick="btnSave_Click"--%>
            <asp:LinkButton runat="server" ID="btnCancel" TabIndex="13" CausesValidation="false"> |&nbsp;&nbsp;&nbsp;Cancel</asp:LinkButton>
        </div>
    </div>

    <%-- Validation controls --%><%-- Pet name    --%>
    <asp:RequiredFieldValidator ID="reqPetName" EnableClientScript="true" ErrorMessage="You must enter a name for your pet." runat="server" ControlToValidate="txtName" Text="*" Display="None"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="regPetName" ValidationExpression="^[À-ÿ\w\d,.'-]*$" ErrorMessage="You must enter a valid name." runat="server" ControlToValidate="txtName" Text="*" Display="None"></asp:RegularExpressionValidator>

    <%-- Pet breed --%>
    <asp:RegularExpressionValidator ID="regBreed" ValidationExpression="^[À-ÿ\w\d,.'-]*$" ErrorMessage="Please enter a valid breed." runat="server" ControlToValidate="txtBreed" Text="*" Display="None"></asp:RegularExpressionValidator>

    <%-- Pet Gender --%>
    <asp:RequiredFieldValidator runat="server" ID="reqPetSex" ControlToValidate="rblSexList" ErrorMessage="Please enter a sex." Display="None" Text="*"></asp:RequiredFieldValidator>

    <%-- Pet birthday --%>
    <asp:CustomValidator runat="server" ClientValidationFunction="cusBirth_Validate" ID="cusBirth" ErrorMessage="Please enter a valid birthdate" Display="None" Text="*"></asp:CustomValidator>

    <%-- Vaccination validators --%><%-- Bordetella --%>
    <%--<asp:CustomValidator runat="server" ID="cusBordetella" ControlToValidate="txtBordetella" OnServerValidate="valDateRange_ServerValidate" ErrorMessage="Please enter a valid expiration date for bordetella" />--%>

    <%-- Distemper --%>
    <%--<asp:CustomValidator runat="server" ID="cusDistemper" ControlToValidate="txtDistemper" OnServerValidate="valDateRange_ServerValidate" ErrorMessage="Please enter a valid expiration date for distemper" />--%>

    <%-- Hepatitis --%>
    <%--<asp:CustomValidator runat="server" ID="cusHepatitis" ControlToValidate="txtHepatitis" OnServerValidate="valDateRange_ServerValidate" ErrorMessage="Please enter a valid expiration date for hepatitis" />--%>

    <%-- Parainfluenza --%>
    <%--<asp:CustomValidator runat="server" ID="cusParainfluenza" ControlToValidate="txtParainfluenza" OnServerValidate="valDateRange_ServerValidate" ErrorMessage="Please enter a valid expiration date for parainfluenza" />--%>

    <%-- Parovirus --%>
    <%--<asp:CustomValidator runat="server" ID="cusParovirus" ControlToValidate="txtParovirus" OnServerValidate="valDateRange_ServerValidate" ErrorMessage="Please enter a valid expiration date for parovirus" />--%>

    <%-- Rabies --%>
    <%--<asp:CustomValidator runat="server" ID="cusRabies" ControlToValidate="txtRabies" OnServerValidate="valDateRange_ServerValidate" ErrorMessage="Please enter a valid expiration date for rabies" />--%>

</asp:Content>
