<%@ Page Title="" Language="C#" MasterPageFile="~/mySite.master" AutoEventWireup="true" CodeBehind="surveyComplete.aspx.cs" Inherits="StudentInfo.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divMsg" runat="server">
        Thank you for completing the survey. We value your comments
        <br /><br />
        <a href="studentSurvey.aspx">Return to survey</a>
    </div>
</asp:Content>
