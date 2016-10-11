<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Winery.aspx.cs"
    Inherits="Winery" Title="Little Italy Vineyard | The Vineyard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentplaceholderMain" runat="Server">
    <img src="images/spacer.gif" width="1" height="5" border="0" /><br />
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr><td><img src="images/spacer.gif" width="1" height="5" border="0" /></td></tr>
        <tr>
            <td valign="middle" align="right" width="100%">
                <asp:TextBox ID="textSearch" runat="server" CssClass="textField"></asp:TextBox><img
                    src="images/spacer.gif" width="5" height="1" border="0" /><asp:Button ID="commandSearch" 
                    runat="server" Text="Search" OnClick="commandSearch_Click" CssClass="button" />
            </td>
            <td><img src="images/spacer.gif" width="35" height="1" border="0" /></td>
        </tr>
        <tr><td><img src="images/spacer.gif" width="1" height="5" border="0" /></td></tr>
        <tr>
            <td align="center" colspan="2">
                <table cellpadding="0" cellspacing="0" border="0" width="95%">
                    <tr>
                        <td width="100%" class="separatorBG"><img src="images/spacer.gif" width="1" height="1" border="0" /></td>
                        <td><img src="images/textSeparatorRight.gif" /></td>
                    </tr>
                </table>
            </td>
            <td></td>
        </tr>
    </table>
    <img src="images/spacer.gif" width="1" height="10" border="0" /><br />
    <asp:Panel ID="panelResults" runat="Server" Visible="false" Height="24px">
        <table border="0" cellpadding="1" cellspacing="0" width="100%">
            <tr>
                <td><img src="images/spacer.gif" width="50" height="1" border="0" /></td>
                <td valign="top" width="100%" nowrap>No Results Found!</td>
            </tr>
        </table>
    </asp:Panel>
    <asp:DataList ID="datalistProducts" RepeatColumns="1" runat="server" Width="100%">
        <ItemTemplate>
            <table border="0" cellpadding="1" cellspacing="0" width="100%">
                <tr>
                    <td><img src="images/spacer.gif" width="50" height="1" border="0" /></td>
                    <td valign="top" align="right">
                        <a href='ProductDetails.aspx?ProductID=<%# Eval("ProductID") %>'>
                            <img src='ImageViewer.ashx?ImageID=<%# Eval("ProductImageID") %>' height="85" border="0"
                                class="prodBorder">
                        </a>
                    </td>
                    <td width="100%" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td width="17"><img src="images/spacer.gif" width="17" height="3" border="0" /></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td class="ProductListHead"><a href='ProductDetails.aspx?ProductID=<%# Eval("ProductID") %>'><b><%# Eval("ProductName") %></b></a></td>
                            </tr>
                            <tr><td><img src="images/spacer.gif" width="1" height="5" border="0" /></td></tr>
                            <tr>
                                <td colspan="2">
                                    <table cellpadding="0" cellspacing="0" border="0" width="75%">
                                        <tr><td class="prodUnderlineBG" width="100%"></td></tr>
                                        <tr><td><img src="images/spacer.gif" width="1" height="1" border="0" /></td></tr>
                                        <tr><td><img src="images/prodDecorRight.gif" /></td></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><%# Eval("Description") %></td>
                            </tr>
                            <tr><td><img src="images/spacer.gif" width="1" height="5" border="0" /></td></tr>
                            <tr>
                                <td></td>
                                <td>
                                    <span class="ProductListItem"><b>Price: </b>
                                        <%# Eval("Price", "{0:c}") %>
                                    </span>
                                </td>
                            </tr>
                            <tr><td><img src="images/spacer.gif" width="1" height="5" border="0" /></td></tr>
                            <tr>
                                <td></td>
                                <td>
                                    <a href='AddToCart.aspx?ProductID=<%# Eval("ProductID") %>'><span class="ProductListItem">
                                    <font color="#9D0000"><b>Add To Cart<b></font></span> </a>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td><img src="images/spacer.gif" width="15" height="1" border="0" /></td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <img src="images/spacer.gif" width="1" height="10" border="0" /><br />
</asp:Content>
