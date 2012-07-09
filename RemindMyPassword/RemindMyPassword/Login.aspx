<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" MasterPageFile="~/Site.master"
    Inherits="RemindMyPassword.Login" %>

<%@ Register Src="~/UserControls/TextEntryArea.ascx" TagName="TxtBox" TagPrefix="UCF" %>
<%@ Register Src="~/UserControls/ComboArea.ascx" TagName="Ddl" TagPrefix="UCF" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <UCF:TxtBox ID="Loginname" runat="server" />
    <UCF:TxtBox ID="Password" runat="server" />
    <asp:Button ID="Loginbtn" runat="server" Text="Login" OnClick="Loginbtn_Click" />
    <asp:HyperLink ID="Signuphl" runat="server" NavigateUrl="~/Signup.aspx">Sign Up ...  Easy & Free </asp:HyperLink>
    <asp:Label ID="Warninglbl" runat="server" Text=""></asp:Label>
</asp:Content>
