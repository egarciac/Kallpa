<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="indicadores.aspx.cs" Inherits="KallpaUI.indicadores" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="css/style.css">
    <script src="js/vendor/modernizr-2.6.2.min.js"></script>
</head>
<body style="margin-top:0; margin-left:0;">
<form id="form1" runat="server">
<div class="wrapper group">
<table>
<tr>
    <td>
        <div class="indicators col span-6-of-12">
        <table>
            <thead>
                    <tr>
                    <td>indice</td>
                    <td>valor</td>
                    <td>variación</td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td style="height:25px"><asp:LinkButton ID="linkIndice1" runat="server" 
                            onclick="linkIndice1_Click1">S&P 500 (EEUU)</asp:LinkButton></td>
                    <td><asp:label ID="lblValue1" runat="server"></asp:label></td>
                    <td class="down"><asp:label ID="lblChange1" runat="server"></asp:label></td>
                </tr>
                <tr>
                    <td style="height:25px"><asp:LinkButton ID="linkIndice2" Text="TSX (CANADÁ)" 
                            runat="server" onclick="linkIndice2_Click1"></asp:LinkButton></td>
                    <td><asp:label ID="lblValue2" runat="server" text=""></asp:label></td>
                    <td class="down"><asp:label ID="lblChange2" runat="server" text=""></asp:label></td>
                </tr>
                <tr>
                    <td style="height:25px"><asp:LinkButton ID="linkIndice3" Text="EURO STOXX 50 (EUROPA)" 
                        runat="server" onclick="linkIndice3_Click1"/></td>
                    <td><asp:label ID="lblValue3" runat="server" text=""></asp:label></td>
                    <td class="down"><asp:label ID="lblChange3" runat="server" text=""></asp:label></td>
                </tr>
                <tr>
                    <td style="height:25px"><asp:LinkButton ID="linkIndice4" Text="DAX (ALEMANIA)" 
                        runat="server" onclick="linkIndice4_Click1"/></td>
                    <td><asp:label ID="lblValue4" runat="server" text=""></asp:label></td>
                    <td class="down"><asp:label ID="lblChange4" runat="server" text=""></asp:label></td>
                </tr>
                <tr>
                    <td style="height:25px"><asp:LinkButton ID="linkIndice5" Text="FTSE 100 (REINO UNIDO)" 
                        runat="server" onclick="linkIndice5_Click1"/></td>
                    <td><asp:label ID="lblValue5" runat="server" text=""></asp:label></td>
                    <td class="down"><asp:label ID="lblChange5" runat="server" text=""></asp:label></td>
                </tr>
                <tr>
                    <td style="height:25px"><asp:LinkButton ID="linkIndice6" Text="NIKKEI 225 (JAPÓN)" 
                        runat="server" onclick="linkIndice6_Click1"/></td>
                    <td><asp:label ID="lblValue6" runat="server" text=""></asp:label></td>
                    <td class="down"><asp:label ID="lblChange6" runat="server" text=""></asp:label></td>
                </tr>
                <tr>
                    <td style="height:25px"><asp:LinkButton ID="linkIndice7" Text="EPU (ETF-PERÚ)" 
                        runat="server" onclick="linkIndice7_Click1"/></td>
                    <td><asp:label ID="lblValue7" runat="server" text=""></asp:label></td>
                    <td class="down"><asp:label ID="lblChange7" runat="server" text=""></asp:label></td>
                </tr>
            </tbody>
        </table>
        </div>
    </td>
    <td>
        <div class="graphic col span-6-of-12">
            <div style="text-transform: uppercase; color: #193c5a; font-weight: 600; margin-bottom: .15em;"><asp:Label ID="lblIndiceTittle" runat="server"></asp:Label></div>
                  <asp:ImageButton ID="imagen" runat="server" Width="270" Height="194" PostBackUrl=""></asp:ImageButton>
        </div>
    </td>
</tr>
</table>
</div>
    <script src="js/vendor/jquery-1.10.2.min.js"></script>
    <script src="js/vendor/jquery.easing.1.3.js"></script>
    <script src="js/main.js"></script>
    </form>

</body>
</html>


