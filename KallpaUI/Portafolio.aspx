<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Portafolio.aspx.cs" Inherits="KallpaUI.Portafolio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PORTAFOLIO</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table id="Table1" width="100%">
        <tr><td><h1>Portafolio</h1></td>
            <td align="right"><img alt="" id="Img1" src="Images/iconokallpa.gif" width="10%" height="10%"/></td></tr>
    </table>
    <input type="button" onclick="window.print()" value="Imprimir..."/>    <h3>Portafolio</h3>
    <table id="cabecera_reporte" width="100%">
        <tr valign="top">
            <td>Sra.<br/>
                CUEVA GARATE, ELIZABETH DOMITILA<br/>
                CALLE IBIS 176/178 SAN ISIDRO<br/>
            </td>
            <td >
                C&oacute;digo Interno: 11890<br/>
                Representante: ALBERTO ARISPE<br/> 
                Tipo de Cambio: <strong>2.78</strong>
            </td>
        </tr>
    </table>    </div>
    </form>
</body>
</html>
