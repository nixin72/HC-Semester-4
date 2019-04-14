<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="DatePicker.ascx.cs" Inherits="HulkHVKA03.DatePicker" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:TextBox ID="txtCalendar" runat="server" CausesValidation="True"></asp:TextBox>
<ajaxToolkit:CalendarExtender ID="calExt" runat="server" Animated="true" TargetControlID="txtCalendar" />
<asp:RequiredFieldValidator runat="server" ControlToValidate="txtCalendar" ErrorMessage="Please enter a date." />