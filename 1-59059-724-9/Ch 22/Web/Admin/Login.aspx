<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>

<html>
<head id="Head1" runat="server">
    <title>Admin Log In</title>
    <meta http-equiv="Content-Style-Type" content="text/css" />
    <link href="../Css/style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" style="background-image: url(../images/til_1.jpg);">
            <tr>
                <td>&nbsp;</td>
                <td width="490" align="left" valign="top">
                    <table width="490" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="10">&nbsp;</td>
                            <td width="470" align="left" valign="top">
                                <table width="470" height="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="164" align="left" valign="top" background="../images/top_1.jpg">
                                            <div style="padding-left: 156px; padding-top: 69px"><img src="../images/logo.jpg" width="159" height="36" border="0"><br />
                                                &nbsp;</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="172" align="right" valign="top" background="../images/back_1.jpg">
                                            <div style="padding-left: 0px; padding-top: 14px; padding-right: 23px; padding-bottom: 0px">
                                                &nbsp;</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="100%" align="left" valign="top">
                                            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" background="../images/rep_3.jpg">
                                                <tr align="left" valign="top">
                                                    <td background="../images/rep_left.jpg" style="width: 10px">
                                                        <img src="../images/rep_left.jpg" width="10" height="1"></td>
                                                    <td height="100%">
                                                        <table width="450" height="100%" border="0" cellpadding="0" cellspacing="0">
                                                            <tr align="left" valign="top">
                                                                <td background="../images/rep_line.jpg" bgcolor="#F3E9BF" style="background-repeat: repeat-y;
                                                                    background-position: top left; text-align: center;">
                                                                    &nbsp;<br />
                                                                    <strong>Administrator Control Panel Log In</strong><br />
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="99%" height="99%" align="center" valign="middle">
				                                                    <tr>
					                                                    <td align="center" valign="top">
                                                                            <br />
						                                                    
                                                                                    <table border="0" cellpadding="3" cellspacing="0" style="width: 360px">
                                                                                        <tr>
                                                                                            <td style="width: 28px">
                                                                                                <img height="5" src="../images/spacer.gif" width="1" /></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 28px">
                                                                                                <img height="1" src="../images/spacer.gif" width="50" /></td>
                                                                                            <td>
                                                                                                Username:</td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="textUsername" runat="server" CssClass="textField"></asp:TextBox><br />
                                                                                                <asp:RequiredFieldValidator ID="requiredUsername" runat="server" ControlToValidate="textUsername"
                                                                                                    Display="Dynamic" EnableClientScript="False" ErrorMessage="Username required."
                                                                                                    Width="152px"></asp:RequiredFieldValidator></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 28px">
                                                                                            </td>
                                                                                            <td>
                                                                                                Password:</td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="textPassword" runat="server" CssClass="textField" TextMode="Password"></asp:TextBox><br />
                                                                                                <asp:RequiredFieldValidator ID="requiredPassword" runat="server" ControlToValidate="textPassword"
                                                                                                    Display="Dynamic" EnableClientScript="False" ErrorMessage="Password required."
                                                                                                    Width="152px"></asp:RequiredFieldValidator></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2">
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Button ID="commandLogin" runat="server" CssClass="button" OnClick="commandLogin_Click"
                                                                                                    Text="Login" /></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2">
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Label ID="labelMessage" runat="server"></asp:Label></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    </td>
				                                                    </tr>
			                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="10" background="../images/rep_right.jpg"><img src="../images/rep_right.jpg" width="10" height="1"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" valign="top" align="center"><img src="../images/bottom_1.jpg" width="470" height="23"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td></td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td></td>
                <td height="100%">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%" height="100%">
                        <tr>
                            <td style="height: 100%; background-image: url(../images/rep_bot.jpg); background-repeat: repeat-y; background-position: center;"></td>
                        </tr>
                    </table>
                </td>
                <td></td>
            </tr>
        </table>
    </form>
</body>
</html>
