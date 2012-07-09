<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateTimePicker.ascx.cs"
    Inherits="RemindMyPassword.DateTimePicker" %>
<table style="width: 250">
    <tr>
        <td>
            <asp:Calendar ID="DateTime" runat="server"></asp:Calendar>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LabelCaption" runat="server" AssociatedControlID="DateTime"
                CssClass="labelcaptioncenter"></asp:Label>
        </td>
    </tr>
</table>
