<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComboArea.ascx.cs" Inherits="RemindMyPassword.ComboArea" %>
<div>
    <asp:Label ID="LabelCaption" runat="server" CssClass="labelcaption" Width="250px"></asp:Label>
    <asp:DropDownList ID="ComboBox" runat="server" OnSelectedIndexChanged="ComboBox_SelectedIndexChanged"
        Width="150px">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="ComboRequired" runat="server" ControlToValidate="ComboBox"
        CssClass="failureNotification" ErrorMessage="Bu alan zorunludur.">*</asp:RequiredFieldValidator>
</div>
