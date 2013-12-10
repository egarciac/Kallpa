<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="KallpaUI.home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>:: KALLPA Securities SAB ::</title>
</head>
<body class="bgcolor: #e5e5e5">
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="2">
                    <img src="Images/logo.jpg" alt="" /></td>
            </tr>
            <tr>
                <td style="width:100px">
                    <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width:100px">
                    <asp:Label ID="Label2" runat="server" Text="Clave"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" align="center" height="60px">
                    <asp:Button ID="btnLogin" runat="server" Text="Aceptar" 
                        onclick="btnLogin_Click" /></td>
            </tr>
        </table>    
    </div>
    </form>
</body>
</html>
