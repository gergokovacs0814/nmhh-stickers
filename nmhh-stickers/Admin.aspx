<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="nmhh_stickers.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <table style="margin-left: auto; margin-right: auto; margin-top:150px; border:2px ">
                <tr><td>  <asp:Button ID="btnExport" runat="server" Text="Export to Excel" OnClick="btnExport_Click"/></td> <td></td></tr>
                <tr><td></td><td></td></tr>
            </table>
            <p>

            </p>
            <table style="margin-left: auto; margin-right: auto; margin-top:150px; border:2px ">
                <tr><td><asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label></td><td><asp:TextBox ID="tbUsername" runat="server"></asp:TextBox></td></tr>
                <tr><td><asp:Label ID="Label2" runat="server" Text="Company: "></asp:Label></td><td><asp:TextBox ID="tbCeg" runat="server"></asp:TextBox></td> </tr>
                <tr><td><asp:Label ID="Label3" runat="server" Text="Email: "></asp:Label></td><td><asp:TextBox ID="tbEmail" runat="server"></asp:TextBox></td> </tr>
                <tr><td></td><td><asp:Button ID="btnAdd" runat="server" Text="új felhasználó" OnClick="btnAdd_Click" /></td></tr>
                
            </table>
            <p>

            </p>
            <table style="margin-left: auto; margin-right: auto; margin-top:150px; border:2px ">
                <tr><td><asp:Label ID="Label4" runat="server" Text="Username: "></asp:Label></td><td><asp:DropDownList ID="dplbUsername2" runat="server"></asp:DropDownList></td></tr>
                <tr><td><asp:Label ID="Label6" runat="server" Text="Email: "></asp:Label></td><td><asp:TextBox ID="tbEmail2" runat="server"></asp:TextBox></td> </tr>
                <tr><td></td><td><asp:Button ID="btnNewPass" runat="server" Text="New Password" OnClick="btnNewPass_Click" /></td></tr>
               
            </table>
        </div>
    </form>
</body>
</html>
