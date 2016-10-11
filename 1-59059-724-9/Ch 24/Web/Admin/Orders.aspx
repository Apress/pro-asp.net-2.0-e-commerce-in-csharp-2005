<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="Admin_Orders" Title="Admin Control Panel | Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentplaceholderAdmin" Runat="Server">
    <br />
    <table border="0" cellpadding="0" cellspacing="0" width="95%">
        <tr>
            <td><strong>All Orders</strong></td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
<asp:GridView ID="gridviewAllOrders" runat="server" AutoGenerateColumns="false">
    <Columns>
    <asp:TemplateField HeaderText="Transaction ID">
        <ItemTemplate>
            <a href="OrderDetails.aspx?TransID=<%# Eval("TransactionID") %>&OrderID=<%# Eval("OrderID") %>&Email=<%# Eval("Email") %>"><%# Eval("TransactionID") %></a>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Name">
        <ItemTemplate>
            <%# Eval("FirstName") %> <%# Eval("LastName") %><br />
            <%# Eval("AddressLine") %> <%# Eval("AddressLine2") %><br />
            <%# Eval("City") %>, <%# Eval("State") %> <%# Eval("PostalCode") %>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Email">
        <ItemTemplate>
            <%# Eval("Email") %>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Phone">
        <ItemTemplate>
            <%# Eval("Phone") %>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Order Date">
        <ItemTemplate>
            <%# Eval("OrderDate") %>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Status">
        <ItemTemplate>
            <%# Eval("OrderStatusName") %>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <br />
</asp:Content>

