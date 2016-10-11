<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" Title="Little Italy Vineyard | Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentplaceholderMain" Runat="Server">
    <table border="0" cellpadding="2" cellspacing="0" style="width: 432px">
        <tr>
            <td style="width: 23px"><img src="images/spacer.gif" width="1" height="8" /></td>
        </tr>
        <tr>
            <td style="width: 23px"><img src="images/spacer.gif" width="50" height="1" /></td>
            <td style="width: 167px">Firstname:</td>
            <td><asp:TextBox ID="textFirstname" runat="server" Width="176px" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredFirstname" runat="server" ControlToValidate="textFirstname"
                    Display="Dynamic" EnableClientScript="False" ErrorMessage="Firstname required."
                    Width="152px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Lastname:</td>
            <td><asp:TextBox ID="textLastname" runat="server" Width="176px" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredLastname" runat="server" ControlToValidate="textLastname"
                    Display="Dynamic" EnableClientScript="False" ErrorMessage="Lastname required."
                    Width="152px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Address:</td>
            <td><asp:TextBox ID="textAddress" runat="server" Width="176px" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredAddress" runat="server" ControlToValidate="textAddress"
                    Display="Dynamic" EnableClientScript="False" ErrorMessage="Address required."
                    Width="152px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Address 2:</td>
            <td><asp:TextBox ID="textAddress2" runat="server" Width="176px" CssClass="textField"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">City:</td>
            <td><asp:TextBox ID="textCity" runat="server" Width="176px" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredCity" runat="server" ControlToValidate="textCity"
                    Display="Dynamic" EnableClientScript="False" ErrorMessage="City required."
                    Width="152px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">State:</td>
            <td><asp:TextBox ID="textState" runat="server" Width="176px" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredState" runat="server" ControlToValidate="textState"
                    Display="Dynamic" EnableClientScript="False" ErrorMessage="State required."
                    Width="152px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Postal Code:</td>
            <td><asp:TextBox ID="textPostalCode" runat="server" Width="176px" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredPostalCode" runat="server" ControlToValidate="textPostalCode"
                    Display="Dynamic" EnableClientScript="False" ErrorMessage="Postal Code required."
                    Width="152px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Password:</td>
            <td><asp:TextBox ID="textPassword" runat="server" TextMode="Password" Width="176px" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredPassword" runat="server" ControlToValidate="textPassword"
                    Display="Dynamic" ErrorMessage="Password required." Width="152px" EnableClientScript="False"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="comparePasswords" runat="server" Display="Dynamic" EnableClientScript="False"
                    ErrorMessage="The passwords entered do not match" ControlToCompare="textPassword" ControlToValidate="textConfirmPassword" Width="240px"></asp:CompareValidator></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Confirm Password:</td>
            <td><asp:TextBox ID="textConfirmPassword" runat="server" TextMode="Password" Width="176px" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredConfirmPassword" runat="server" ControlToValidate="textConfirmPassword"
                    Display="Dynamic" EnableClientScript="False" ErrorMessage="Confirm password required."
                    Width="176px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Email:</td>
            <td><asp:TextBox ID="textEmail" runat="server" TextMode="singleLine" Width="176px" CssClass="textField"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="requiredEmail" runat="server" ControlToValidate="textEmail"
                    Display="Dynamic" EnableClientScript="False" ErrorMessage="Email required."
                    Width="152px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Phone:</td>
            <td><asp:TextBox ID="textPhone" runat="server" Width="176px" CssClass="textField"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Phone 2:</td>
            <td><asp:TextBox ID="textPhone2" runat="server" Width="176px" CssClass="textField"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Fax:</td>
            <td><asp:TextBox ID="textFax" runat="server" Width="176px" CssClass="textField"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 23px"></td>
            <td style="width: 167px">Subscribe to Newsletter:</td>
            <td><asp:CheckBox ID="checkboxNewsletter" runat="server" Width="176px" CssClass="textField" /></td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td><asp:Button ID="commandRegister" runat="server" Text="Register Account" OnClick="commandRegister_Click" CssClass="button" /></td>
        </tr>
    </table>
</asp:Content>

