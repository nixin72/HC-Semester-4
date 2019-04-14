<%@ Page Title="" Language="C#" MasterPageFile="~/mySite.master" AutoEventWireup="true" CodeBehind="StudentCourses.aspx.cs" Inherits="StudentInfo.StudentCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:pdumaresq %>" 
        ProviderName="<%$ ConnectionStrings:pdumaresq.ProviderName %>" 
        SelectCommand="SELECT STUDENTID, LAST, FIRST, POSTCODE, BIRTHDATE 
            FROM IU_STUDENT">

    </asp:SqlDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" 
        AutoGenerateRows="False" DataKeyNames="STUDENTID" 
        DataSourceID="SqlDataSource1" Height="50px" Width="125px">
        <Fields>
            <asp:BoundField DataField="STUDENTID" HeaderText="STUDENTID" ReadOnly="True" SortExpression="STUDENTID" />
            <asp:BoundField DataField="LAST" HeaderText="LAST" SortExpression="LAST" />
            <asp:BoundField DataField="FIRST" HeaderText="FIRST" SortExpression="FIRST" />
            <asp:BoundField DataField="POSTCODE" HeaderText="POSTCODE" SortExpression="POSTCODE" />
            <asp:BoundField DataField="BIRTHDATE" HeaderText="BIRTHDATE" SortExpression="BIRTHDATE" />
        </Fields>
    </asp:DetailsView>

    
    <br />
    <br />


    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:pdumaresq %>" 
        ProviderName="<%$ ConnectionStrings:pdumaresq.ProviderName %>" 
        SelectCommand="SELECT c.COURSEID, c.TITLE, c.CREDITS, r.MIDTERM, r.FINAL, r.CSID
            FROM IU_REGISTRATION r, IU_CRSSECTION cr, IU_COURSE c
            WHERE (STUDENTID = :STUDENTID)
              AND r.csid = cr.csid
              AND cr.courseid = c.courseid">
        <SelectParameters>
            <asp:ControlParameter ControlID="DetailsView1" Name="STUDENTID" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
        <EmptyDataTemplate>
            This student is not enrolled in any courses.
        </EmptyDataTemplate>
        <Columns>
            <asp:BoundField DataField="COURSEID" HeaderText="COURSEID" SortExpression="COURSEID" />
            <asp:BoundField DataField="TITLE" HeaderText="TITLE" SortExpression="TITLE" />
            <asp:BoundField DataField="CREDITS" HeaderText="CREDITS" SortExpression="CREDITS" />
            <asp:BoundField DataField="MIDTERM" HeaderText="MIDTERM" SortExpression="MIDTERM" />
            <asp:BoundField DataField="FINAL" HeaderText="FINAL" SortExpression="FINAL" />
            <asp:BoundField DataField="CSID" HeaderText="CSID" SortExpression="CSID" Visible="False" />
        </Columns>
    </asp:GridView>
</asp:Content>
