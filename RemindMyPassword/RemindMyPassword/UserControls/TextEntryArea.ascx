<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextEntryArea.ascx.cs"
    Inherits="RemindMyPassword.TextEntryArea" %>
<div>
    <asp:Label ID="LabelCaption" runat="server" CssClass="labelcaption" Width="250px"></asp:Label>
    <asp:TextBox ID="TextboxValue" runat="server" CssClass="textEntry"></asp:TextBox>
    <asp:RequiredFieldValidator ID="TextValueRequired" runat="server" ControlToValidate="TextboxValue"
        CssClass="failureNotification" ErrorMessage="Bu alan zorunludur.">*</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="NumericValidator" runat="server" ControlToValidate="TextboxValue"
        ErrorMessage="Bu alana sadece nümerik değerler girilebilir" ValidationExpression="^([0-9]*|\d*\,\d{1}?\d*)$"></asp:RegularExpressionValidator>
</div>
