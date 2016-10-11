<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" Title="Little Italy Vineyard | Shopping Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentplaceholderMain" Runat="Server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td><img src="images/spacer.gif" width="10" height="15" /></td>
            <td width="100%"></td>
            <td><img src="images/spacer.gif" width="10" height="1" /></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td width="16%" align="center" style="height: 13px"><b>Remove</b></td>
                        <td width="30%" style="height: 13px"><b>Product</b></td>
                        <td width="17%" align="center" style="height: 13px"><b>Quantity</b></td>
                        <td width="18%" align="center" style="height: 13px"><b>Unit Cost</b></td>
                        <td width="19%" align="center" style="height: 13px"><b>Subtotal</b></td>
                    </tr>                    
                </table>
            </td>
            <td></td>
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
                <asp:GridView ID="gridviewShoppingCart" runat="server" AutoGenerateColumns="false" DataKeyNames="Quantity,ShoppingCartID"
                    OnRowDataBound="gridviewShoppingCart_RowDataBound" Width="100%" BorderWidth="0px" CellPadding="2" ShowHeader="false">
                <Columns>
                <asp:TemplateField ItemStyle-Width="16%" ItemStyle-HorizontalAlign="center">
                    <ItemTemplate>
                        <asp:CheckBox ID="checkboxDelete" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="30%">
                    <ItemTemplate>
                        <%# Eval("ProductName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="17%" ItemStyle-HorizontalAlign="center">
                    <ItemTemplate>
                        <asp:TextBox id="textQuantity" runat="server" Columns="4" MaxLength="3" Text='<%# Eval("Quantity") %>' width="30px" CssClass="textfield" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="18%" ItemStyle-HorizontalAlign="center">
                    <ItemTemplate>
                        <%# Eval( "UnitPrice" , "{0:c}" )%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="19%" ItemStyle-HorizontalAlign="center">
                    <ItemTemplate>
                        <%# Eval( "TotalPrice" , "{0:c}" )%>
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
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td><b>Total:</b></td>
                        <td style="width: 83px;" align="center"><asp:Label ID="labelTotal" runat="server" Width="100%"></asp:Label></td>
                    </tr>
                </table>
            </td>
            <td></td>
        </tr>
        <tr><td><img src="images/spacer.gif" width="1" height="20" /></td></tr>
        <tr>
            <td></td>
            <td align="right">
                <asp:Button ID="commandContinueShopping" runat="server" OnClick="commandContinueShopping_Click" Text="Continue Shooping" CssClass="button" Width="136px" />
                <img src="images/spacer.gif" width="5" height="1" />
                <asp:Button ID="commandUpdate" runat="server" OnClick="commandUpdate_Click" Text="Update" CssClass="button" />
                <img src="images/spacer.gif" width="5" height="1" />
                <asp:Button ID="commandCheckout" runat="server" OnClick="commandCheckout_Click" Text="Check Out" CssClass="button" />
                <img src="images/spacer.gif" width="15" height="1" />
            </td>
            <td></td>
        </tr>
        <tr><td><img src="images/spacer.gif" width="1" height="15" /></td></tr>
    </table>
</asp:Content>

