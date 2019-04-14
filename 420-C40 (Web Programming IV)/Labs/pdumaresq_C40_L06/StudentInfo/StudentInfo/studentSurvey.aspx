<%@ Page Title="" Language="C#" MasterPageFile="~/mySite.master" AutoEventWireup="true" CodeBehind="studentSurvey.aspx.cs" Inherits="StudentInfo.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:pdumaresq %>" 
        ProviderName="<%$ ConnectionStrings:pdumaresq.ProviderName %>" 
        SelectCommand="SELECT STUDENTID, LAST, FIRST FROM IU_STUDENT"></asp:SqlDataSource>
    <asp:DropDownList ID="DropDownList1"  runat="server" DataSourceID="SqlDataSource1" DataTextField="FIRST" DataValueField="STUDENTID">
    </asp:DropDownList>
    <br />
    <br /><br />
    <asp:Button ID="btnGetCourses" runat="server" Text="Get course" />
    <br />
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:pdumaresq %>" ProviderName="<%$ ConnectionStrings:pdumaresq.ProviderName %>" 
        SelectCommand="SELECT TITLE
FROM iu_course c, iu_crssection cr, iu_registration r
WHERE r.studentid        = :STUDENTID
  AND r.csid                     = cr.csid
  AND cr.courseid           = c.courseid">
        <SelectParameters>
            <asp:ControlParameter PropertyName="SelectedValue" Type="String" ControlID="DropDownList1" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />

    <asp:Panel runat="server" ID="panDis">

    <asp:DropDownList runat="server" ID="ddlCourses" DataSourceID="SqlDataSource2" DataTextField="TITLE" DataValueField="TITLE">
    </asp:DropDownList>
    <br /><br />
    <table>
        <tr>
            <td><br />Met Expectations</td>
        </tr>
        <tr>
            <td><asp:RadioButton name="expectations" ID="e0" runat="server" />Not Satisfied</td>
            <td><asp:RadioButton name="expectations" id="e1" runat="server" />Somewhat satisfied</td>
            <td><asp:RadioButton name="expectations" id="e2" runat="server" />Satisfied</td>
            <td><asp:RadioButton name="expectations" id="e3" runat="server" />Completely Satisfied</td>
        </tr>
        
        <tr>
            <td><br />Professor's knowledge</td>
        </tr>
        <tr>
            <td><asp:RadioButton name="professor" id="p0" runat="server" />Not satisfied</td>
            <td><asp:RadioButton name="professor" id="p1" runat="server" />Somewhat satisfied</td>
            <td><asp:RadioButton name="professor" id="p2" runat="server" />Satisfied</td>
            <td><asp:RadioButton name="professor" id="p3" runat="server" />Completely Satisfied</td>
        </tr>

        <tr>
            <td><br />Fair assessments</td>
        </tr>
        <tr>
            <td><asp:RadioButton name="Fair" id="a0" runat="server" />Not satisfied</td>
            <td><asp:RadioButton name="Fair" id="a1" runat="server" />Somewhat satisfied</td>
            <td><asp:RadioButton name="Fair" id="a2" runat="server" />Satisfied</td>
            <td><asp:RadioButton name="Fair" id="a3" runat="server" />Completely Satisfied</td>
        </tr>
        <tr>
            <td><br /></td>
        </tr>
        <tr>
            <td>
                Additional Comments:
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:TextBox TextMode="MultiLine" Columns="75" Rows="5" runat="server" ID="txtComments"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <br />
                Please contact me to discuss this survey 
                <asp:CheckBox runat="server" ID="cont" />
            </td>
        </tr>
        <tr>
            <td><asp:RadioButton name="cont" id="c0" runat="server" />Contact by email</td>
            <td><asp:RadioButton name="cont" id="c1" runat="server" />Contact by phone</td>
        </tr>

        <tr>
            <td>
                <br />
                <asp:Button runat="server" ID="btnSubmit" Text="Submit" PostBackUrl="surveyComplete.aspx" OnClick="btnSubmit_Click"/>
            </td>
        </tr>
    </table>

    </asp:Panel>
    


</asp:Content>
