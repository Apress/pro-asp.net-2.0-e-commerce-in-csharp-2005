<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="CheckOut" Title="Little Italy Vineyard | Check Out" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentplaceholderMain" Runat="Server">
    
    <table cellpadding="0" cellspacing="0" border="0" width="95%" align="center">
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
                <asp:GridView ID="gridviewShoppingCart" runat="server" AutoGenerateColumns="false" ShowHeader="True" Width="100%"
                    DataKeyNames="Quantity,ShoppingCartID" OnRowDataBound="gridviewShoppingCart_RowDataBound" BorderWidth="0px">
                    <Columns>
                        
                        <asp:TemplateField ItemStyle-Width="25%" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center" HeaderText="Product">
                            <ItemTemplate>
                                <%# Eval("ProductName") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="center" ItemStyle-Width="25%" HeaderStyle-HorizontalAlign="center" HeaderText="Quantity"> 
                            <ItemTemplate>
                                <%# Eval("Quantity") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="center" ItemStyle-Width="25%" HeaderStyle-HorizontalAlign="center" HeaderText="Unit Cost">
                            <ItemTemplate>
                                <%# Eval( "UnitPrice" , "{0:c}" )%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="center" ItemStyle-Width="25%" HeaderStyle-HorizontalAlign="center" HeaderText="Subtotal">
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
                </table>
            </td>
            <td></td>
        </tr>
    </table>
    <br />
    <table border="0" cellpadding="0" cellspacing="2" width="90%" align="center">
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
            <td>First Name:</td>
            <td><asp:TextBox ID="textFirstname" runat="server" CssClass="textField"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td>Last Name:</td>
            <td><asp:TextBox ID="textLastname" runat="server" CssClass="textField"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td>Address:</td>
            <td><asp:TextBox ID="textAddress" runat="server" CssClass="textField"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requiredAddress" runat="server" Display="Dynamic"
                    EnableClientScript="False" ErrorMessage="Address Required." ControlToValidate="textAddress" Width="152px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td></td>
            <td>Address 2:</td>
            <td><asp:TextBox ID="textAddress2" runat="server" CssClass="textField"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td>City:</td>
            <td><asp:TextBox ID="textCity" runat="server" CssClass="textField"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requiredCity" runat="server" Display="Dynamic"
                    EnableClientScript="False" ErrorMessage="<br />City Required." ControlToValidate="textCity"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td></td>
            <td>State:</td>
            <td><asp:TextBox ID="textState" runat="server" CssClass="textField"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requiredState" runat="server" Display="Dynamic"
                    EnableClientScript="False" ErrorMessage="State Required." ControlToValidate="textState"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td></td>
            <td>Postal Code:</td>
            <td><asp:TextBox ID="textPostalCode" runat="server" CssClass="textField"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requiredPostalCode" runat="server" Display="Dynamic"
                    EnableClientScript="False" ErrorMessage="Postal Code Required." ControlToValidate="textPostalCode" Width="152px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td></td>
            <td>Shipping Options:</td>
            <td><asp:DropDownList ID="dropdownlistShippingOption" runat="server" CssClass="textField">
                    <asp:ListItem Value="5.99">Ground $5.99</asp:ListItem>
                    <asp:ListItem Value="8.99">2nd Day $8.99</asp:ListItem>
                    <asp:ListItem Value="10.99">Next Day Air $10.99</asp:ListItem>
                </asp:DropDownList></td>
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
            <td>Credit Card:</td>
            <td><asp:DropDownList ID="dropdownlistCreditCardType" runat="server" CssClass="textField">
                    <asp:ListItem Text="American Express" Value="Amex"></asp:ListItem>
                    <asp:ListItem Text="Master Card" Value="MasterCard"></asp:ListItem>
                    <asp:ListItem Text="Visa" Value="Visa"></asp:ListItem>
                    <asp:ListItem Text="Discover" Value="Discover"></asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td></td>
            <td>Credit Card Number:</td>
            <td><asp:TextBox ID="textCreditCardNumber" runat="server" CssClass="textField"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requireCreditCardNumber" runat="server" Display="Dynamic"
                    EnableClientScript="False" ErrorMessage="Credit Card Number Required." ControlToValidate="textCreditCardNumber"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td></td>
            <td>Security Code:</td>
            <td><asp:TextBox ID="textSecurityCode" runat="server" CssClass="textField"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requireSecurityCode" runat="server" Display="Dynamic"
                    EnableClientScript="False" ErrorMessage="Security Code Required." ControlToValidate="textSecurityCode"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td></td>
            <td>Expiration Date:</td>
            <td><asp:DropDownList ID="dropdownlistExpMonth" runat="server" CssClass="monthYear">
                    <asp:ListItem Text="01" Value="01"></asp:ListItem>
                    <asp:ListItem Text="02" Value="02"></asp:ListItem>
                    <asp:ListItem Text="03" Value="03"></asp:ListItem>
                    <asp:ListItem Text="04" Value="04"></asp:ListItem>
                    <asp:ListItem Text="05" Value="05"></asp:ListItem>
                    <asp:ListItem Text="06" Value="06"></asp:ListItem>
                    <asp:ListItem Text="07" Value="07"></asp:ListItem>
                    <asp:ListItem Text="08" Value="08"></asp:ListItem>
                    <asp:ListItem Text="09" Value="09"></asp:ListItem>
                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="dropdownlistExpYear" runat="server" CssClass="monthYear">
                    <asp:ListItem Text="2006" Value="2006"></asp:ListItem>
                    <asp:ListItem Text="2007" Value="2007"></asp:ListItem>
                    <asp:ListItem Text="2008" Value="2008"></asp:ListItem>
                    <asp:ListItem Text="2009" Value="2009"></asp:ListItem>
                    <asp:ListItem Text="2010" Value="2010"></asp:ListItem>
                    <asp:ListItem Text="2011" Value="2011"></asp:ListItem>
                    <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                </asp:DropDownList></td>
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
            <td><asp:TextBox ID="textBillingAddress" runat="server" CssClass="textField"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requireBillingAddress" runat="server" Display="Dynamic"
                    EnableClientScript="False" ErrorMessage="Billing Address Required." ControlToValidate="textBillingAddress"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td></td>
            <td>Address 2:</td>
            <td><asp:TextBox ID="textBillingAddress2" runat="server" CssClass="textField"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td>City:</td>
            <td><asp:TextBox ID="textBillingCity" runat="server" CssClass="textField"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requireBillingCity" runat="server" Display="Dynamic"
                    EnableClientScript="False" ErrorMessage="Billing City Required." ControlToValidate="textBillingCity"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td></td>
            <td>State:</td>
            <td><asp:TextBox ID="textBillingState" runat="server" CssClass="textField"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requireBillingState" runat="server" Display="Dynamic"
                    EnableClientScript="False" ErrorMessage="Billing State Required." ControlToValidate="textBillingState"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td></td>
            <td>Postal Code:</td>
            <td><asp:TextBox ID="textBillingPostalCode" runat="server" CssClass="textField"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requireBillingPostalCode" runat="server" Display="Dynamic"
                    EnableClientScript="False" ErrorMessage="Billing Postal Code Required." ControlToValidate="textBillingPostalCode"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:CheckBox ID="checkboxVerify" runat="server" AutoPostBack="True" OnCheckedChanged="checkboxVerify_CheckedChanged"
                    Text="I certify that I am of legal age to purchase." Width="100%" /></td>
        </tr>
        <tr><td><img src="images/spacer.gif" width="1" height="15" /></td></tr>
        <tr>
            <td colspan="2"></td>
            <td><asp:Button ID="commandSubmit" runat="server" Text="Continue" Width="136px" OnClick="commandSubmit_Click" CssClass="button" Enabled="False" /></td>
        </tr>
        <tr><td><img src="images/spacer.gif" width="1" height="5" /></td></tr>
    </table>
</asp:Content>

