<%@ Page Title="" Language="C#" MasterPageFile="~/HVK.Master" AutoEventWireup="true" CodeBehind="ManagePet.aspx.cs" Inherits="HVKA03.ManagePet" %>

<%@ Register Src="~/DatePicker.ascx" TagPrefix="uc1" TagName="DatePicker" %>

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
        <asp:ScriptManager ID="sm" runat="server">
        </asp:ScriptManager>

        <h3>
            <asp:Label ID="lblCUDErrorORWarning" runat="server" style="color: #FF0000"></asp:Label>
        </h3>

        <asp:ValidationSummary ID="valSum" ForeColor="red" runat="server" />
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
                        <asp:ListItem Value='M' Selected="true">Male</asp:ListItem>
                        <asp:ListItem Value='F'>Female</asp:ListItem>
                    </asp:RadioButtonList>
                    
                </div>

                <label>Fixed:&nbsp;&nbsp;&nbsp;</label>
                <asp:CheckBox ID="chbFixed" runat="server" TabIndex="6" />
            </div>

            <div id="size">
                <br />
                <label>Pet Size: </label>
                <asp:RadioButtonList ID="rblPetSizeList" runat="server" TabIndex="7">
                    <asp:ListItem Value='S' Selected="True">Small</asp:ListItem>
                    <asp:ListItem Value='M'>Medium</asp:ListItem>
                    <asp:ListItem Value='L'>Large</asp:ListItem>
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
                                <uc1:DatePicker runat="server" ID="txtBordetella" />
                                
                            </div>
                            &nbsp;&nbsp;&nbsp;
                            <asp:CheckBox runat="server" ID="chbValBordetella" ToolTip="Should not be checked if vaccination date is before current date" CssClass="Vaccinevalidator checkButton" />
                            
                        </div>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <div class="flex-container">
                            <div class="data">
                                <asp:Label runat="server" ID="lblDistemper">Distemper</asp:Label>
                                <uc1:DatePicker runat="server" ID="txtDistemper" />
                            </div>
                            &nbsp;&nbsp;&nbsp;
                            <asp:CheckBox runat="server" ID="chbValDistemper" ToolTip="Should not be checked if vaccination date is before current date" CssClass="Vaccinevalidator checkButton" />
                            
                        </div>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <div class="flex-container">
                            <div class="data">
                                <asp:Label runat="server" ID="lblHepatitis">Hepatitis</asp:Label>
                                <uc1:DatePicker runat="server" ID="txtHepatitis" />
                                
                            </div>
                            &nbsp;&nbsp;&nbsp;
                            <asp:CheckBox runat="server" ID="chbValHepatitis" ToolTip="Should not be checked if vaccination date is before current date" CssClass="Vaccinevalidator checkButton" />
                             
                        </div>

                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <div class="flex-container">
                            <div class="data">
                                <asp:Label runat="server" ID="lblParainfluenza">Parainfluenza</asp:Label>
                                <uc1:DatePicker runat="server" ID="txtParainfluenza" />
                                
                            </div>
                            &nbsp;&nbsp;&nbsp;
                            <asp:CheckBox runat="server" ID="chbValParainfluenza" ToolTip="Should not be checked if vaccination date is before current date" CssClass="Vaccinevalidator checkButton" />
                           
                        </div>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <div class="flex-container">
                            <div class="data">
                                <asp:Label runat="server" ID="lblParovirus">Parovirus</asp:Label>
                                <uc1:DatePicker runat="server" ID="txtParovirus" />
                                
                            </div>
                            &nbsp;&nbsp;&nbsp;
                            <asp:CheckBox runat="server" ID="chbValParovirus" ToolTip="Should not be checked if vaccination date is before current date" CssClass="Vaccinevalidator checkButton" />
                            
                        </div>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <div class="flex-container">
                            <div class="data">
                                <asp:Label runat="server" ID="lblRabies">Rabies</asp:Label>
                                <uc1:DatePicker runat="server" ID="txtRabies" />
                                
                            </div>
                            &nbsp;&nbsp;&nbsp;
                            <asp:CheckBox runat="server" ID="chbValRabies" ToolTip="Should not be checked if vaccination date is before current date" CssClass="Vaccinevalidator, checkButton" />
                            
                        </div>

                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <br />
        <h3>Pet Personality</h3>
        <hr />


        <br />
        <label>Please Tell us a bit about your dog!</label><br />
        <asp:TextBox ID="txtPetNotes" MaxLength="200" TextMode="multiline" Columns="50" Rows="4" runat="server" TabIndex="11"></asp:TextBox>
        <br />
        <br />

        

        <div class="actions">
            <asp:Button ID="btnSave" runat="server" Text="Add Pet" TabIndex="12" OnClick="btnSave_Click" EnableViewState="False" CausesValidation="False" />
            <asp:LinkButton runat="server" ID="btnCancel" TabIndex="13" CausesValidation="False" OnClick="btnCancel_Click"> &nbsp;|&nbsp;&nbsp;&nbsp;Cancel&nbsp;&nbsp;&nbsp;</asp:LinkButton>
            <asp:LinkButton ID="btnRemovePet" runat="server" OnClick="btnRemovePet_Click">|&nbsp;&nbsp;&nbsp;Remove Pet</asp:LinkButton>
        </div>
    </div>

    <asp:CustomValidator OnServerValidate="cusBordetella_Validate" ID="cusBordetella" runat="server" ErrorMessage="The expiry date for Bordetella must be withing a five year range" Text="*" Display="None"></asp:CustomValidator>
    <asp:CustomValidator OnServerValidate="cusDistemper_Validate" ID="cusDistemper" runat="server" ErrorMessage="The expiry date for Distemper must be withing a five year range" Text="*" Display="None"></asp:CustomValidator>
    <asp:CustomValidator OnServerValidate="cusHepatitus_Validate" ID="cusHepatitus" runat="server" ErrorMessage="The expiry date for Hepatitus must be withing a five year range" Text="*" Display="None"></asp:CustomValidator>
    <asp:CustomValidator OnServerValidate="cusParainfluenza_Validate" ID="cusParainfluenza" runat="server" ErrorMessage="The expiry date for Parainfluenza must be withing a five year range" Text="*" Display="None"></asp:CustomValidator>
    <asp:CustomValidator OnServerValidate="cusParovirus_Validate" ID="cusParovirus" runat="server" ErrorMessage="The expiry date for Parovirus must be withing a five year range" Text="*" Display="None"></asp:CustomValidator>
    <asp:CustomValidator OnServerValidate="cusRabies_Validate" ID="cusRabies" runat="server" ErrorMessage="The expiry date for Rabies must be withing a five year range" Text="*" Display="None"></asp:CustomValidator>
    
    <asp:RequiredFieldValidator ID="reqPetName" EnableClientScript="true" ErrorMessage="You must enter a name for your pet." runat="server" ControlToValidate="txtName" Text="*" Display="None"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="regPetName" ValidationExpression="^[À-ÿ\w\d,.'-]*$" ErrorMessage="You must enter a valid name." runat="server" ControlToValidate="txtName" Text="*" Display="None"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="regBreed" ValidationExpression="^[À-ÿ\w\d\s,.'-]*$" ErrorMessage="Please enter a valid breed." runat="server" ControlToValidate="txtBreed" Text="*" Display="None"></asp:RegularExpressionValidator>        
    <asp:RegularExpressionValidator ID="ranPetNotes" runat="server" ControlToValidate="txtPetNotes" Display="None" ErrorMessage="Pet Notes can only contain a maximum of 200 characters" ValidationExpression="^(\s|\S){0,200}$">*</asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator runat="server" ID="reqPetSex" ControlToValidate="rblSexList" ErrorMessage="Please enter a sex." Text="*" Display="None"></asp:RequiredFieldValidator>
    <asp:CustomValidator runat="server" OnServerValidate="cusBirth_Validate" ID="cusBirth" ErrorMessage="Please enter a valid birthdate before the current date" Display="None" Text="*"></asp:CustomValidator>

</asp:Content>

