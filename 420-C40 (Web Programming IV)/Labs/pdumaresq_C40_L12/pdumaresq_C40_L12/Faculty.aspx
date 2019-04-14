<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Faculty.aspx.cs" Inherits="pdumaresq_C40_L12.Faculty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ObjectDataSource ID="odsFaculty" runat="server" SelectMethod="ListFaculty" TypeName="pdumaresq_C40_L12.App_Code.BLL.Faculty"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsDept" runat="server" SelectMethod="ListDepartments" TypeName="pdumaresq_C40_L12.App_Code.BLL.Department"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsLocation" runat="server" SelectMethod="ListLocations" TypeName="pdumaresq_C40_L12.App_Code.BLL.Location"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsFacDetail" runat="server" SelectMethod="GetFacultyByID" TypeName="pdumaresq_C40_L12.App_Code.BLL.Faculty">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlFaculty" DefaultValue="10" Name="facId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsFacMoreDetailed" runat="server" SelectMethod="GetFacultyDetailExpanded" TypeName="pdumaresq_C40_L12.App_Code.BLL.Faculty">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlFaculty" DefaultValue="10" Name="facId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:DropDownList ID="ddlFaculty"  runat="server" AutoPostBack="true" DataSourceID="odsFaculty" DataTextField="facultyName" DataValueField="facultyid">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="true" DataSourceID="odsDept" DataTextField="deptname" DataValueField="deptid">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="true" DataSourceID="odsLocation" DataTextField="roomlocation" DataValueField="roomid">
        </asp:DropDownList>
    
        <br /><br />
        <asp:DetailsView ID="dvDetails" runat="server" AutoGenerateRows="False" DataSourceID="odsFacDetail" Height="50px" Width="125px">
            <Fields>
                <asp:BoundField DataField="facultyid" HeaderText="Faculty Id" SortExpression="facultyid" />
                <asp:BoundField DataField="facultyName" HeaderText="Name" SortExpression="facultyName" />
                <asp:BoundField DataField="roomid" HeaderText="Room ID" SortExpression="roomid" />
                <asp:BoundField DataField="phoneNumber" HeaderText="Phone Number" SortExpression="phoneNumber" />
                <asp:BoundField DataField="deptid" HeaderText="Department ID" SortExpression="deptid" />
            </Fields>
        </asp:DetailsView>
        <br />
        <asp:DetailsView ID="dvDetailsExpanded" runat="server" AutoGenerateRows="False" DataSourceID="odsFacMoreDetailed" Height="50px" Width="125px">
            <Fields>
                <asp:BoundField DataField="facultyid" HeaderText="Faculty ID" SortExpression="facultyid" />
                <asp:BoundField DataField="facultyName" HeaderText="Name" SortExpression="facultyName" />
                <asp:BoundField DataField="roomid" HeaderText="Room ID" SortExpression="roomid" />
                <asp:BoundField DataField="phoneNumber" HeaderText="Phone Number" SortExpression="phoneNumber" />
                <asp:BoundField DataField="deptid" HeaderText="Department ID" SortExpression="deptid" />
                <asp:BoundField DataField="depname" HeaderText="Department Name" SortExpression="depname" />
                <asp:BoundField DataField="roomLocation" HeaderText="Room Location" SortExpression="roomLocation" />
            </Fields>
        </asp:DetailsView>
        <br />
    </div>
    </form>
</body>
</html>
