<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="EditProduct.aspx.cs" Inherits="Admin_EditProduct" Title="Admin Control Panel | Edit Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentplaceholderAdmin" Runat="Server">
<table cellSpacing="0" cellPadding="0" width="100%" border="0" style="height: 362px">
            <tr>
                <td colSpan="2">
                    
                </td>
            </tr>
            <tr>
                <td vAlign="top" style="width: 21px">

                </td>
                <td vAlign="top" align="left">
                    <table height="100%" cellSpacing="0" cellPadding="0" width="620" align="left" border="0">
                        <tr vAlign="top">
                            <td>
                                <br>
                                &nbsp;<table cellSpacing="0" cellPadding="0" width="100%" border="0">
                                    <tr>
                                        <td class="ContentHead" style="width: 60px; height: 13px">
                                            Name:</td>
                                        <td class="ContentHead" style="height: 13px">
                                            <asp:TextBox ID="textName" runat="server" CssClass="textField"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="requireName" runat="server" ErrorMessage="Product name required." ControlToValidate="textName" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td class="ContentHead" style="width: 60px">
                                            Description:
                                        </td>
                                        <td class="ContentHead">
                                            <asp:TextBox ID="textDescription" runat="server" Height="104px" TextMode="MultiLine"
                                                Width="352px" CssClass="textField"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="ContentHead" style="width: 60px; height: 24px;">
                                            Price:</td>
                                        <td class="ContentHead" style="height: 24px">
                                            <asp:TextBox ID="textPrice" runat="server" CssClass="textField"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="requirePrice" runat="server" ErrorMessage="Price Required." ControlToValidate="textPrice" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td class="ContentHead" style="width: 60px">
                                            Category:</td>
                                        <td class="ContentHead">
                                            <asp:DropDownList ID="dropdownlistCategory" runat="server" CssClass="textField">
                                            </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td class="ContentHead" style="width: 60px">
                                            Image:</td>
                                        <td class="ContentHead">
                                            <asp:Image ID="imageProductDetail" runat="server" BorderColor="#92775C" BorderStyle="Double"
                                                BorderWidth="3px" Width="100px" /></td>
                                    </tr>
                                    <tr>
                                        <td class="ContentHead" style="width: 60px">
                                        </td>
                                        <td class="ContentHead">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="ContentHead" style="width: 60px">
                                        </td>
                                        <td class="ContentHead">
                                            <asp:FileUpload ID="fileuploadProductImage" runat="server" Width="320px" CssClass="textField" /></td>
                                    </tr>
                                </table>
                                <table cellSpacing="0" cellPadding="0" width="100%" border="0" valign="top">
                                    <tr>
                                        <td rowspan="1" style="width: 4px">
                                            &nbsp;
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 120px">
                                                <tr>
                                                    <td style="width: 59px">
                                            <asp:Button ID="commandUpdate" runat="server" OnClick="commandUpdate_Click" Text="Update" CssClass="button" /></td>
                                                    <td style="width: 59px">
                                                    </td>
                                                    <td style="width: 100px">
                                                        <asp:Button
                                                ID="commandCancel" runat="server" OnClick="commandCancel_Click" Text="Cancel" CssClass="button" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
</asp:Content>

