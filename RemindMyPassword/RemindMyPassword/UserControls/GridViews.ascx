<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GridViews.ascx.cs" Inherits="RemindMyPassword.GridViews" %>
<%@ Register Src="~/UserControls/UCBase.ascx" TagName="BaseUC" TagPrefix="UC" %>
<table style="width: 250">
    <tr>
        <td>
            <asp:Label ID="LabelCaption" runat="server" CssClass="labelcaptioncenter" Width="250px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="DataGrid" runat="server" BorderStyle="None" GridLines="None" 
                PageSize="5" ShowHeader="False">
                <Columns>
                    <asp:ButtonField Text="Button" />
                    <asp:CheckBoxField />
                </Columns>
                <HeaderStyle BorderColor="#666699" BorderStyle="Groove" BorderWidth="2px" 
                    HorizontalAlign="Center" VerticalAlign="Middle" />
                <PagerStyle BorderColor="#666699" BorderStyle="Groove" BorderWidth="2px" 
                    HorizontalAlign="Center" VerticalAlign="Middle" />
                <RowStyle BorderColor="#666699" BorderStyle="Groove" BorderWidth="2px" 
                    HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:GridView>
        </td>
    </tr>
</table>
