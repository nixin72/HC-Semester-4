<%@ Page Title="" Language="C#" MasterPageFile="~/mySite.master" AutoEventWireup="true" CodeBehind="ManageFaculty.aspx.cs" Inherits="StudentInfo.AddFacultyMember" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:pdumaresq %>" 
        DeleteCommand="DELETE FROM IU_FACULTY 
            WHERE FACULTYID = :FACULTYID" 
        InsertCommand="INSERT INTO IU_FACULTY (
            FACULTYID, NAME, ROOMID, PHONE, DEPTID
        ) VALUES (
            iu_faculty_seq.nextval, :NAME, :ROOMID, :PHONE, :DEPTID
        )" 
        ProviderName="<%$ ConnectionStrings:pdumaresq.ProviderName %>" 
        SelectCommand="SELECT FACULTYID, NAME, ROOMID, PHONE, DEPTID 
            FROM IU_FACULTY" 
        UpdateCommand="UPDATE IU_FACULTY 
            SET NAME = :NAME, 
                ROOMID = :ROOMID, 
                PHONE = :PHONE, 
                DEPTID = :DEPTID 
            WHERE FACULTYID = :FACULTYID">
        <DeleteParameters>
            <asp:Parameter Name="FACULTYID" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="NAME" Type="String" />
            <asp:Parameter Name="ROOMID" Type="Decimal" />
            <asp:Parameter Name="PHONE" Type="String" />
            <asp:Parameter Name="DEPTID" Type="Decimal" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="NAME" Type="String" />
            <asp:Parameter Name="ROOMID" Type="Decimal" />
            <asp:Parameter Name="PHONE" Type="String" />
            <asp:Parameter Name="DEPTID" Type="Decimal" />
            <asp:Parameter Name="FACULTYID" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" 
        DataKeyNames="FACULTYID" DataSourceID="SqlDataSource1" Height="50px" Width="125px">
        <Fields>
            <asp:BoundField DataField="FACULTYID" HeaderText="FACULTYID" InsertVisible="false" ReadOnly="True" SortExpression="FACULTYID" />
            <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
            <asp:BoundField DataField="ROOMID" HeaderText="ROOMID" SortExpression="ROOMID" />
            <asp:BoundField DataField="PHONE" HeaderText="PHONE" SortExpression="PHONE" />
            <asp:BoundField DataField="DEPTID" HeaderText="DEPTID" SortExpression="DEPTID" />
            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ShowEditButton="True" ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
</asp:Content>
