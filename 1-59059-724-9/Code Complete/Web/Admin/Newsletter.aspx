<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Newsletter.aspx.cs" Inherits="Admin_Newsletter" Title="Admin Control Panel | Newsletter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentplaceholderAdmin" Runat="Server">
    <br />
    <table border="0" cellpadding="0" cellspacing="0" width="85%">
        <tr>
            <td>
                <strong>Compose Newsletter</strong></td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="textMessageBody" runat="server" CssClass="textField" Height="208px"
                    TextMode="MultiLine" Width="100%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Button ID="commandSend" runat="server" CssClass="button" OnClick="commandSend_Click"
                    Text="Send Newsletter" /></td>
        </tr>
    </table>
</asp:Content>

