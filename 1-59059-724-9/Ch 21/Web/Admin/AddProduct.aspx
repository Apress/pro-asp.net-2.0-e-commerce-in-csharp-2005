<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="Admin_AddProduct" Title="Admin Control Panel | Add Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentplaceholderAdmin" Runat="Server">
    <br />
    <table border="0" cellpadding="0" cellspacing="0" style="width: 432px">
        <tr>
            <td style="width: 100px">
                Product Name:</td>
            <td style="width: 100px">
                <asp:TextBox ID="textProductName" runat="server" CssClass="textField"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requireName" runat="server" ErrorMessage="Product name required." ControlToValidate="textProductName" Display="Dynamic" EnableClientScript="False" Width="160px"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Category:</td>
            <td style="width: 100px">
                <asp:DropDownList ID="dropdownlistCategory" runat="server" CssClass="textField">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 100%; height: 124px;">
            </td>
            <td style="width: 100%; height: 124px;">
                <asp:TextBox ID="textDescription" runat="server" Height="136px" TextMode="MultiLine"
                    Width="100%"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td style="width: 100px">
                Price:</td>
            <td style="width: 100px">
                <asp:TextBox ID="textPrice" runat="server" CssClass="textField"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requirePrice" runat="server" ErrorMessage="Price required." ControlToValidate="textPrice" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 22px">
                Image:</td>
            <td style="width: 100px; height: 22px">
                <asp:FileUpload ID="fileuploadImage" runat="server" Width="320px" CssClass="textField" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                &nbsp;<table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 100px">
                <asp:Button ID="commandAdd" runat="server" OnClick="commandAdd_Click" Text="Add Product" CssClass="button" /></td>
                        <td style="width: 58px">
                <asp:Button ID="commandCancel" runat="server" Text="Cancel" CausesValidation="False" OnClick="commandCancel_Click" CssClass="button" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table> 
</asp:Content>

