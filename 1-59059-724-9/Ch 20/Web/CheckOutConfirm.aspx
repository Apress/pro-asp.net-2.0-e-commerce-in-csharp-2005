<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="CheckOutConfirm.aspx.cs" Inherits="CheckOutConfirm" Title="Little Italy Vineyard | Check Out Confirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentplaceholderMain" Runat="Server">
    <table cellpadding="0" cellspacing="0" border="0" width="95%" align="Center">
        <tr>
            <td><img src="images/spacer.gif" width="10" height="15" /></td>
            <td width="100%"></td>
            <td><img src="images/spacer.gif" width="10" height="1" /></td>
        </tr>
        
        <tr>
            <td></td>
            <td class="prodUnderlineBG" width="100%"><img src="images/spacer.gif" width="1" height="4" /></td>
            <td></td>
        </tr>
        <tr><td><img src="images/spacer.gif" width="1" height="3" /></td></tr>
        <tr>
            <td></td>
            <td>
                <asp:GridView ID="gridviewShoppingCart" runat="server" AutoGenerateColumns="false" ShowHeader="true" 
                    Width="100%" DataKeyNames="Quantity,ShoppingCartID,ProductID" BorderWidth="0px">
                    <Columns>
                        
                        <asp:TemplateField ItemStyle-Width="25%" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center" HeaderText="Product">
                            <ItemTemplate>
                            <asp:Label id="labelProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="center" ItemStyle-Width="25%" HeaderStyle-HorizontalAlign="center" HeaderText="Quantity">
                            <ItemTemplate>
                            <asp:Label id="labelQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="center" ItemStyle-Width="25%" HeaderStyle-HorizontalAlign="center" HeaderText="Unit Cost">
                            <ItemTemplate>
                            <asp:Label id="labelUnitPrice" runat="server" Text='<%# Eval( "UnitPrice" , "{0:c}" )%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="center" ItemStyle-Width="25%" HeaderStyle-HorizontalAlign="center" HeaderText="Subtotal">
                            <ItemTemplate>
                                <asp:Label id="labelTotalPrice" runat="server" Text='<%# Eval( "TotalPrice" , "{0:c}" )%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td></td>
        </tr>
        <tr><td><img src="images/spacer.gif" width="1" height="3" /></td></tr>
        <tr>
            <td></td>
            <td class="prodUnderlineBG" width="100%"><img src="images/spacer.gif" width="1" height="1" /></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td class="prodUnderlineBG" width="100%"><img src="images/spacer.gif" width="1" height="2" /></td>
            <td></td>
        </tr>
        <tr><td><img src="images/spacer.gif" width="1" height="5" /></td></tr>
        <tr>
            <td></td>
            <td align="right">
                <table border="0" cellpadding="2" cellspacing="0">
                    <tr>
                        <td><b>Subtotal:</b></td>
                        <td><img src="images/spacer.gif" width="15" height="1" /></td>
                        <td style="width: 69px;"><asp:Label ID="labelSubTotal" runat="server" Width="100%"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><b>Tax:</b></td>
                        <td></td>
                        <td><asp:Label ID="labelTax" runat="server" Width="100%"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><b>Shipping:</b></td>
                        <td></td>
                        <td><asp:Label ID="labelShippingCost" runat="server" Width="100%"></asp:Label></td>
                    </tr>
                    <tr><td><img src="images/spacer.gif" width="1" height="1" /></td></tr>
                    <tr>
                        <td colspan="3" class="prodUnderlineBG"><img src="images/spacer.gif" width="1" height="2" /></td>
                    </tr>
                    <tr><td><img src="images/spacer.gif" width="1" height="1" /></td></tr>
                    <tr>
                        <td><b>Order Total:</b></td>
                        <td></td>
                        <td><asp:Label ID="labelTotal" runat="server" Width="100%"></asp:Label></td>
                    </tr>
                </table>
            </td>
            <td></td>
        </tr>
    </table>
    <br />
    <table border="0" cellpadding="0" cellspacing="3" width="90%" align="Center">
        <tr>
            <td colspan="3"><b>Shipping Information</b></td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="100%" class="separatorBG"><img src="images/spacer.gif" width="1" height="1" border="0" /></td>
                        <td><img src="images/textSeparatorRight.gif" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td><img src="images/spacer.gif" width="1" height="3" /></td></tr>
        <tr>
            <td><img src="images/spacer.gif" width="10" height="1" /></td>
            <td nowrap="nowrap">First Name:</td>
            <td width="60%"><asp:Label ID="labelFirstname" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Last Name:</td>
            <td><asp:Label ID="labelLastname" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td></td>
            <td>Address:</td>
            <td><asp:Label ID="labelAddress" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Address 2:</td>
            <td><asp:Label ID="labelAddress2" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td></td>
            <td>City:</td>
            <td><asp:Label ID="labelCity" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td></td>
            <td>State:</td>
            <td><asp:Label ID="labelState" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Postal Code:</td>
            <td><asp:Label ID="labelPostalCode" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Shipping Options:</td>
            <td></td>
        </tr>
        <tr><td><img src="images/spacer.gif" width="1" height="15" /></td></tr>
        <tr>
            <td colspan="3"><b>Payment</b></td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="100%" class="separatorBG"><img src="images/spacer.gif" width="1" height="1" border="0" /></td>
                        <td><img src="images/textSeparatorRight.gif" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td><img src="images/spacer.gif" width="1" height="3" /></td></tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Credit Card:</td>
            <td><asp:Label ID="labelCreditCardType" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Credit Card Number:</td>
            <td><asp:Label ID="labelCreditCardNumber" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Security Code:</td>
            <td><asp:Label ID="labelCreditCardSecurityCode" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Expiration Date:</td>
            <td><asp:Label ID="labelExpirationDate" runat="server"></asp:Label></td>
        </tr>
        <tr><td><img src="images/spacer.gif" width="1" height="15" /></td></tr>
        <tr>
            <td colspan="3"><b>Billing Address</b></td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="100%" class="separatorBG"><img src="images/spacer.gif" width="1" height="1" border="0" /></td>
                        <td><img src="images/textSeparatorRight.gif" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td><img src="images/spacer.gif" width="1" height="3" /></td></tr>
        <tr>
            <td></td>
            <td>Address:</td>
            <td><asp:Label ID="labelBillingAddress" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Address 2:</td>
            <td><asp:Label ID="labelBillingAddress2" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td></td>
            <td>City:</td>
            <td><asp:Label ID="labelBillingCity" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td></td>
            <td>State:</td>
            <td><asp:Label ID="labelBillingState" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td></td>
            <td nowrap="nowrap">Postal Code:</td>
            <td><asp:Label ID="labelBillingPostalCode" runat="server"></asp:Label></td>
        </tr>
        <tr><td><img src="images/spacer.gif" width="1" height="15" /></td></tr>
        <tr>
            <td colspan="3" align="right">
                <table cellpadding="3" cellspacing="0" border="0">
                    <tr>
                        <td><asp:Button ID="commandEdit" runat="server" Text="Edit Information" Width="136px" OnClick="commandEdit_Click" CssClass="button" /></td>
                        <td><asp:Button ID="commandConfirm" runat="server" OnClick="commandConfirm_Click" Text="Confirm Payment" CssClass="button" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td><img src="images/spacer.gif" width="1" height="5" /></td></tr>
    </table>
</asp:Content>

