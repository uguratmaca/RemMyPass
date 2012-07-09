<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CheckboxArea.ascx.cs"
    Inherits="RemindMyPassword.CheckboxArea" %>
<div>
    <asp:Label ID="LabelCaption" runat="server" CssClass="labelcaption" Width="250px"></asp:Label>
    <asp:CheckBox ID="CheckBox" runat="server" OnCheckedChanged="CheckBox_CheckedChanged"
        AutoPostBack="True" Width="150px"></asp:CheckBox>
</div>
