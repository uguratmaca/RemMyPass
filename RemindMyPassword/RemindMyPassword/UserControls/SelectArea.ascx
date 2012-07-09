<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SelectArea.ascx.cs"
    Inherits="RemindMyPassword.SelectArea" %>
<link href="~/css/ham.css" rel="Stylesheet" type="text/css" />
<link href="~/css/site.css" rel="Stylesheet" type="text/css" />
<asp:Panel ID="Panel1" runat="server" GroupingText="Text Girin">
    <div>
        <asp:Label ID="LabelCaption" runat="server" CssClass="labelcaptioncenter" Width="210px"></asp:Label>
        <asp:Label ID="SecondaryLabelCaption" runat="server" CssClass="labelcaptioncenter"
            Width="210px"></asp:Label>
    </div>
    <div>
        <asp:ListBox ID="AllItems" runat="server" Width="175px" Height="175px" CssClass="marginlist">
        </asp:ListBox>
        <asp:ListBox ID="SelectedItems" runat="server" Width="175px" Height="175px" CssClass="marginlist">
        </asp:ListBox>
        <asp:CustomValidator ID="SelectedItemsRequired" runat="server" ControlToValidate="SelectedItems"
            ClientValidationFunction="ValidateHasItem" OnServerValidate="ValidateSelectedItems"
            CssClass="failureNotification" ErrorMessage="Bu alan zorunludur.">*</asp:CustomValidator>
    </div>
    <div>
        <asp:ImageButton ID="AddItem" runat="server" ImageUrl="~/Images/add.jpg" OnClick="Add_click"
            ToolTip="Kayıt Ekle" Width="40px" Height="40px" CssClass="buttoncenter" CausesValidation="false" />
        <asp:ImageButton ID="RemoveItem" runat="server" ImageUrl="~/Images/remove.jpg" OnClick="Remove_click"
            ToolTip="Kayıt Çıkar" Width="40px" Height="40px" CssClass="buttoncenter" CausesValidation="false" />
    </div>
</asp:Panel>
<script type="text/javascript">
    function ValidateHasItem(source, arguments) {
        debugger;
        var input = arguments.Value; //Validate edilecek olan degerin alinmasi
        arguments.IsValid = false; //İlk degerin false olarak atanmasi
        var isvalid = false;
        if (input.length > 8)
            isvalid = true; //karakter uzunlugu 8 den buyukse ilk validation gecilir.
        if (!isvalid)
            return;
        isvalid = false;
        if (isvalid) //Data validate edildi.
            arguments.IsValid = true;
    }
</script>
