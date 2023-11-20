<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="nmhh_stickers.add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div><table style="margin-left: auto; margin-right: auto; margin-top:150px">
            <tr>
                <td> <asp:Label ID="lbBarcode" runat="server" Text="Barcode: "></asp:Label></td> <td> <asp:TextBox ID="tbBarcode" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lbLaptop" runat="server" Text="Laptop/Tablet"> </asp:Label> <asp:CheckBox ID="cbLaptop" runat="server"/></td>
                <td><asp:Label ID="lblBarcode" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td> </td>
                <td>
                    <asp:Button ID="btAdd" runat="server" Text="Add" OnClick="btAdd_Click" /></td>
            </tr>
             </table>
        </div>
    </form>
</body>
</html>
