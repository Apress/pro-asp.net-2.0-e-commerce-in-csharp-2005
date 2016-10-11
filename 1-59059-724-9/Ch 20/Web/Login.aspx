<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Little Italy Vineyard | Customer Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentplaceholderMain" Runat="Server">
    <table border="0" cellpadding="3" cellspacing="0" style="width: 360px">
        <tr>
            <td><img src="images/spacer.gif" width="1" height="5" /></td>
        </tr>
        <tr>
            <td><img src="images/spacer.gif" width="50" height="1" /></td>
            <td>Username:</td>
            <td><asp:TextBox ID="textUsername" runat="server" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredUsername" runat="server" ErrorMessage="Username required." 
                    ControlToValidate="textUsername" Display="Dynamic" EnableClientScript="False" Width="152px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td></td>
            <td>Password:</td>
            <td><asp:TextBox ID="textPassword" runat="server" TextMode="Password" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredPassword" runat="server" ErrorMessage="Password required." 
                    ControlToValidate="textPassword" Display="Dynamic" Width="152px" EnableClientScript="False"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td><asp:Button ID="commandLogin" runat="server" Text="Login" OnClick="commandLogin_Click" CssClass="button" /></td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td><asp:Label ID="labelMessage" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td><asp:HyperLink ID="hyperlinkNewAccount" runat="server" NavigateUrl="Register.aspx" Width="144px">Register New Account</asp:HyperLink></td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td></td>
        </tr>
    </table>
</asp:Content>

