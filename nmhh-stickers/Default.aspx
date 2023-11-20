<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="nmhh_stickers.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div><table style="margin-left: auto; margin-right: auto; margin-top:150px">
            <tr>
                <td> <asp:Label ID="lbUser" runat="server" Text="User name: "></asp:Label></td> <td> <asp:TextBox ID="tbUser" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td> <asp:Label ID="lbPass" runat="server" Text="Password: "></asp:Label> </td> <td><asp:TextBox ID="tbPass" runat="server" TextMode="Password"></asp:TextBox></td>

            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btLogin" runat="server" Text="Login" OnClick="btLogin_Click" /></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Label ID="lblerror" runat="server" Text="Either the username or password is incorrect"></asp:Label> </td>
                </tr>
             </table>
        </div>
    </form>
</body>
</html>
