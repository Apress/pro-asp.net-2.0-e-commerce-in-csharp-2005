<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs"
    Inherits="ContactUs" Title="Little Italy Vineyard | Contact Us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentplaceholderMain" runat="Server">

    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" background="images/rep_3.jpg">
        <tr align="left" valign="top">
            <td height="100%">
                <table width="450" border="0" cellpadding="0" cellspacing="0" background="images/back_4.jpg"
                    style="background-position: top right; background-repeat: no-repeat">
                    <tr>
                        <td align="left" valign="top" style="background-repeat: no-repeat; background-position: top left; height: 103px;">
                            <div style="padding-left: 16px;">
                                <img src="images/tradit_3.jpg" width="73" height="11"></div>
                            <div style="padding-left: 15px; padding-top: 12px; padding-right: 45px; padding-bottom: 24px;
                                line-height: 12px">
                                <img src="images/pic_4.jpg" width="114" height="78" align="left" style="margin-right: 19px"><table
                                    width="260" border="0" cellspacing="0" cellpadding="0">
                                    <tr align="left" valign="top" style="line-height: 12px">
                                        <td class="light" style="width: 221px">
                                            <div style="padding-left: 0px; padding-top: 3px">
                                                Little Italy Vineyards, Inc.<br>
                                                9863 Merlot Dr.&nbsp;<br>
                                                Sonoma Valley, CA 90211</div>
                                            <div style="padding-left: 0px; padding-top: 10px">
                                                <table cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td class="light">Tel:</td>
                                                        <td><img src="images/spacer.gif" width="10" height="1" /></td>
                                                        <td class="light">555-555-5555</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="light">Fax:</td>
                                                        <td><img src="images/spacer.gif" width="10" height="1" /></td>
                                                        <td class="light">555-555-5522</td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td class="light">
                                            <div style="padding-left: 0px; padding-top: 3px">
                                                &nbsp;</div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td height="100%" align="left" valign="top" background="images/rep_line.jpg" bgcolor="#F3E9BF"
                            style="background-repeat: repeat-y; background-position: top left">
                            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" background="images/rep_5.jpg"
                                style="background-repeat: repeat-x; background-position: top">
                                <tr><td><img src="images/spacer.gif" width="1" height="15" /></td></tr>
                                <tr align="left" valign="top">
                                    <td height="100%">
                                        <div  align="Center">
                                            <table width="375" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td height="28" align="left" valign="top" style="width: 191px">
                                                        Name:
                                                        <asp:RequiredFieldValidator ID="requiredName" runat="server" ControlToValidate="textName"
                                                            Display="Dynamic" EnableClientScript="False" ErrorMessage="<br />Please enter your name."></asp:RequiredFieldValidator><br />
                                                        <asp:TextBox ID="textName" runat="server" CssClass="textField"></asp:TextBox>
                                                    <td height="28" align="right" valign="top" style="text-align: left">
                                                        Email:
                                                        <asp:RequiredFieldValidator ID="requiredEmail" runat="server" ControlToValidate="textEmail"
                                                            Display="Dynamic" EnableClientScript="False" ErrorMessage="<br />Please enter your email."></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="regularexpEmail" runat="server" ControlToValidate="textEmail"
                                                            Display="Dynamic" EnableClientScript="False" ErrorMessage="<br />Please enter a valid email."
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />
                                                        <asp:TextBox ID="textEmail" runat="server" CssClass="textField"></asp:TextBox>
                                                </tr>
                                                <tr><td><img src="images/spacer.gif" width="1" height="10" /></td></tr>
                                                <tr>
                                                    <td colspan="2" align="left" valign="top">
                                                        Comments:<br />
                                                        <asp:TextBox ID="textComment" TextMode="MultiLine" runat="server" CssClass="textField" Height="75px"></asp:TextBox></td>
                                                </tr>
                                                <tr><td><img src="images/spacer.gif" width="1" height="5" /></td></tr>
                                                <tr align="right">
                                                    <td colspan="2" valign="bottom" style="height: 17px">
                                                        <asp:Button ID="commandReset" runat="server" Text="Reset" CausesValidation="False" OnClick="commandReset_Click" CssClass="button" />&nbsp;
                                                        <asp:Button ID="commandSubmit" runat="server" OnClick="commandSubmit_Click" Text="Submit" CssClass="button" />&nbsp;</td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr><td><img src="images/spacer.gif" width="1" height="15" /></td></tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
