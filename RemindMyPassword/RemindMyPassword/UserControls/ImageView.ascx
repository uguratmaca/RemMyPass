<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageView.ascx.cs" Inherits="RemindMyPassword.ImageView" %>
<link href="~/css/ham.css" rel="Stylesheet" type="text/css" />
<table style="width: 250; margin-left: 80px; margin-top: 5px; margin-bottom: 13px;">
    <tr>
        <td>
            <asp:ImageButton ID="ShownLinkImage" runat="server" OnClick="ShownLinkImage_click" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="LabelCaption" runat="server" AssociatedControlID="ShownLinkImage"
                CssClass="labelcaptioncenter"></asp:Label>
        </td>
    </tr>
</table>
