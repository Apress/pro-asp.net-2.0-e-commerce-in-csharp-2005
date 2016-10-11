<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" Title="Little Italy Vineyard | Product Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentplaceholderMain" Runat="Server">
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
    <tr>
        <td vAlign="top" align="left">
            <table border="0" cellpadding="1" cellspacing="0" width="100%">
                <tr>
                    <td><img src="images/spacer.gif" width="1" height="15" border="0" /></td>
                </tr>
                <tr>
                    <td><img src="images/spacer.gif" width="50" height="1" border="0" /></td>
                    <td valign="top" align="right">
                        <asp:Image ID="imageProductDetail" runat="server" width="100px" BorderStyle="Double" BorderWidth="3px" BorderColor="#92775C" />
                    </td>
                    <td width="100%" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td width="17"><img src="images/spacer.gif" width="17" height="3" border="0" /></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td class="ProductListHead"><b><asp:label id="labelProductName" runat="server" /></b></td>
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
                                <td><asp:label id="labelDescription" runat="server"></asp:label></td>
                            </tr>
                            <tr><td><img src="images/spacer.gif" width="1" height="8" border="0" /></td></tr>
                            <tr>
                                <td></td>
                                <td>
                                    <span class="ProductListItem"><b>Price: </b>
                                        <asp:label id="labelPrice" runat="server" />
                                    </span>
                                </td>
                            </tr>
                            <tr><td><img src="images/spacer.gif" width="1" height="8" border="0" /></td></tr>
                            <tr>
                                <td></td>
                                <td>Category:&nbsp;<asp:label id="labelCategory" runat="server" />
                                </td>
                            </tr>
                            <tr><td><img src="images/spacer.gif" width="1" height="12" border="0" /></td></tr>
                            <tr>
                                <td></td>
                                <td>
                                
                                    <b><a href="AddToCart.aspx?ProductID=<%= Request.QueryString[ "ProductID" ] %>" class="red">Add To Cart</a></b>
                                </td>
                            </tr>
                            <tr><td><img src="images/spacer.gif" width="1" height="5" border="0" /></td></tr>
                            <tr>
                                <td></td>
                                <td><asp:hyperlink id="linkContinueShopping" runat="server" Text="Continue Shopping" NavigateUrl="Winery.aspx"></asp:hyperlink></td>
                            </tr>
                        </table>
                    </td>
                    <td><img src="images/spacer.gif" width="15" height="1" border="0" /></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td><img src="images/spacer.gif" width="1" height="10" border="0" /></td>
    </tr>
</table>
</asp:Content>
