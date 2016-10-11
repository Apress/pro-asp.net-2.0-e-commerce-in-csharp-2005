<%@ Page Language="C#" MasterPageFile="Account.master" AutoEventWireup="true" CodeFile="CustomerOrderDetails.aspx.cs" Inherits="Account_CustomerOrderDetails" Title="Little Italy Vineyards | Order Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentplaceholderMain" Runat="Server">
    <br />
    <table border="0" cellpadding="0" cellspacing="0" width="90%">
        <tr>
            <td style="width: 151px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 151px; height: 13px;">
                Transaction ID</td>
            <td style="width: 100px; height: 13px;">
                <asp:Label ID="labelTransactionID" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 151px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 151px">
                Purchased Items:</td>
            <td style="width: 100px">
                <asp:GridView ID="gridviewOrderDetailsProducts" runat="server" AutoGenerateColumns="false" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Qty.">
                        <ItemTemplate>
                            <%# Eval("Quantity") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product">
                        <ItemTemplate>
                            <%# Eval("ProductName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <%# Eval( "Price" , "{0:c}" )%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 151px; height: 16px;">
                Tax:</td>
            <td style="width: 100px; height: 16px;">
                <asp:Label ID="labelTax" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 151px; height: 16px;">
                Order Total:</td>
            <td style="width: 100px; height: 16px;">
                <asp:Label ID="labelOrderTotal" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 151px; height: 19px">
            </td>
            <td style="width: 100px; height: 19px">
            </td>
        </tr>
        <tr>
            <td style="width: 151px">
            </td>
            <td style="width: 100px">
                <asp:Button ID="commandReturn" runat="server" Text="Return" CssClass="button" OnClick="commandReturn_Click" /></td>
        </tr>
    </table>
</asp:Content>

