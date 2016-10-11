<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="CheckOutReceipt.aspx.cs" Inherits="CheckOutReceipt" Title="Little Italy Vineyard | Check Out Receipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentplaceholderMain" Runat="Server">
    &nbsp;<br />
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%">
                <asp:Panel ID="panelSuccess" runat="server" Height="100%" Visible="False" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td width="25%" style="text-align: center">
                                <img src="Images/Success.gif" /></td>
                            <td width="75%">
                                <strong>Your order has been processed successfully.&nbsp; 
                                    <br />
                                    <br />
                                    Little Italy Vineyard thanks
                                    you for your business.</strong></td>
                        </tr>
                        <tr>
                            <td width="25%">
                Transaction ID:</td>
                           <td width="75%">
                                <asp:Label ID="labelTransactionID" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="25%">
                Order Total:</td>
                            <td width="75%">
                                <asp:Label ID="labelOrderTotal" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                    &nbsp;</asp:Panel>
            </td>
        </tr>
        <tr>
            <td width="100%">
                <asp:Panel ID="panelFailure" runat="server" Height="100%" Visible="False" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td width="25%" style="text-align: center">
                                <img src="Images/error.gif" /></td>
                            <td width="75%">
                                <strong>We apologize for the inconvenience, but an error occured with the payment of
                                    your order.<br />
                                    <br />
                                    Error Message:</strong></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td width="25%">
                                <asp:Label ID="labelErrorMessage" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>

