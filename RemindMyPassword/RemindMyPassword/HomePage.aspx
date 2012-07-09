<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" MasterPageFile="~/Site.master"
    Inherits="RemindMyPassword.HomePage" %>

<%@ Register Src="~/UserControls/TextEntryArea.ascx" TagName="TxtBox" TagPrefix="UCF" %>
<%@ Register Src="~/UserControls/ComboArea.ascx" TagName="Ddl" TagPrefix="UCF" %>
<%@ Register Src="~/UserControls/GridViews.ascx" TagName="Grd" TagPrefix="UCF" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.7.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Fill(id) {
            $.ajax({
                type: 'POST',
                url: 'HomePage.aspx/FillForm',
                data: "{Id:" + id + "}",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (result) {
                    var res = result.d.toString();

                    var obj = eval("(" + res + ")");
                    document.getElementById('MainContent_Username_TextboxValue').value = obj.query[0].UserName;
                    document.getElementById('MainContent_Websitename_TextboxValue').value = obj.query[0].Name;
                    document.getElementById('MainContent_AlgorithmHardness_ComboBox').value = obj.query[0].AlgorithmLevel;
                    document.getElementById('MainContent_Charcount_ComboBox').value = obj.query[0].CharCount;
                },

                error: function () {
                    alert('Talep esnasında sorun oluştu. Yeniden deneyin');
                }

            });
        }

        function Generatepassword() {
            var un = document.getElementById('MainContent_Username_TextboxValue').value;
            var wsn = document.getElementById('MainContent_Websitename_TextboxValue').value;
            var cc = document.getElementById('MainContent_Charcount_ComboBox').value;
            var ah = document.getElementById('MainContent_AlgorithmHardness_ComboBox').value;

            var datum = { username: un, websitename: wsn, charcount: cc, algorithmhardness: ah };
            var obj = JSON.stringify(datum)

            $.ajax({
                type: 'POST',
                url: 'HomePage.aspx/GetPassword',
                data: obj,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (result) {
                    document.getElementById('MainContent_Generatedpassword_TextboxValue').value = result.d.toString();
                },

                error: function () {
                    alert('Talep esnasında sorun oluştu. Yeniden deneyin');
                }

            });

        }

        function Clear() {
            document.getElementById('MainContent_Username_TextboxValue').value = "";
            document.getElementById('MainContent_Websitename_TextboxValue').value = "";
            document.getElementById('MainContent_Charcount_ComboBox').value = "4";
            document.getElementById('MainContent_AlgorithmHardness_ComboBox').value = "Easy";
        }
 
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="LeftPanel">
        <UCF:TxtBox ID="Username" runat="server" />
        <UCF:TxtBox ID="Websitename" runat="server" />
        <UCF:Ddl ID="AlgorithmHardness" runat="server" />
        <UCF:Ddl ID="Charcount" runat="server" />
        <div>
            <input id="pgbnt" onclick="Generatepassword()" type="button" value="Generate Password" />
        </div>
        <div>
            <input id="Clearallbtn" onclick="Clear()" type="button" value="Clear" />
            <asp:Button ID="Savequerybtn" Text="Save" runat="server" OnClick="Savequerybtn_Click" />
        </div>
        <div>
            <UCF:TxtBox ID="Generatedpassword" runat="server" />
        </div>
    </div>
    <div id="RightUpPanel">
        <div>
            <asp:HyperLink ID="Loginuphl" runat="server" NavigateUrl="~/Login.aspx" Visible="false">Log In to See Saved Queries</asp:HyperLink></div>
        <div>
            <asp:HyperLink ID="Signuphl" runat="server" NavigateUrl="~/Signup.aspx" Visible="false">Or Sign Up ...  Easy & Free </asp:HyperLink></div>
        <div>
            <UCF:TxtBox ID="SearchSavedOnes" runat="server" Visible="false" />
        </div>
        <div>
            <asp:Button ID="SearchSavedQueries" runat="server" OnClick="FillDatum" Text="Search"
                Visible="false" />
        </div>
        <asp:Panel ID="SavedOnesPnl" runat="server">
        </asp:Panel>
    </div>
</asp:Content>
