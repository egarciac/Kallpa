﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Portafolio.aspx.cs" Inherits="KallpaUI.Portafolio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>Kallpa Securities SAB</title>
      <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
      <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
      <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
      <script src="../Scripts/kallpa/reportes.js" type="text/javascript"></script>
      <link href="css/stilos-reporte-detalle.css" rel="stylesheet" type="text/css" />
      <script type="text/javascript">
          function validarFecha() {
              var input = document.getElementById("DesdeInput");
              
              if (input.value == "") {
                  //document.getElementById("contenedor-reportes").style.display = "none";
                  var label = document.getElementById("lblError");
                  label.innerHTML = "*";
                  return false;
                }
                else {
                    //document.getElementById("contenedor-reportes").style.display = "block";
                    label.innerHTML = "";
                    return false;
              }
          }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="contenedor">
	<div class="header">
	  <div class="logo"><img src="img/logo.jpg" width="290" height="60" /></div>
      <div class="cabecera-der">
       	<%--<div style="float:left; margin-right:2px;"><a href="#" style="text-decoration:none"> <span class="texto13azul">Manual de usos del aplicativo</span></a></div>
            <div style="float:left; margin-right:20px;"><a href="#" style="text-decoration:none"><img src="img/pdf.jpg" width="16" height="18" border:"0" /></a></div>
        <div style="float:left; margin-right:5px;"> <a href="#" style="text-decoration:none"><span class="texto13azul">salir</span></a></div>
            <div style="float:left;"><a href="#" style="text-decoration:none"><img src="img/cerrar.png" width="17" height="17" border:"0" /></a></div>--%>
      </div>
    </div>
  <div class="menu">
	<a href="Portafolio.aspx" target="_self">
    <div class="e" style="float:left; margin-right:33px; padding-bottom:5px; padding-top:7px; padding-left:5px; padding-right:5px;"><span class="texto18e">Portafolio</span></div>
    </a>
    <a href="DetalleOperaciones.aspx" target="_self">
    <div class="e"  style="float:left; margin-right:33px; padding-bottom:5px; padding-top:7px; padding-left:5px; padding-right:5px;"><span class="texto18e">Detalle operaciones</span></div>
    </a>
   <a href="CuentaCorriente.aspx" target="_self"> 
   <div class="e" style="float:left; margin-right:33px; padding-bottom:5px; padding-top:7px; padding-left:5px; padding-right:5px;"><span class="texto18e">Cuenta corriente</span></div>
   </a>
   <a href="Ordenes.aspx" target="_self"> 
   <div class="e" style="float:left; margin-right:33px; padding-bottom:5px; padding-top:7px; padding-left:5px; padding-right:5px;"><span class="texto18e">Órdenes</span></div>
   </a>
   <a href="Poliza.aspx" target="_self">
     <div class="e" style="float:left; padding-bottom:5px; padding-top:7px; padding-left:5px; padding-right:5px;"><span class="texto18e">Polizas</span></div>
     </a>
   <div style="float:right; margin-top:5px; margin-right:5px;"> <a href="login.aspx" style="text-decoration:none"><span class="texto13azul"> Salir</span></a></div>
	<div style="float:right; margin-top:5px;"> <a href="login.aspx" style="text-decoration:none"><img src="img/cerrar.png" width="17" height="17" border="0" /></a></div>            
   </div>
    <div class="portada-imagen">
    	<div class="text2">
			
			<h1 style="margin: 0;" class="blanco36">Portafolio</h1>
		</div>
    <img src="img/00_rep_polizas.jpg" width="1307" height="76" />
    </div>
    
    <div class="contenido-medio">
   	  
      <div class="titbienvenida">
        	<div style="float:left; overflow:hidden;">
       	  	<span class="texto14azul"><strong>&nbsp;&nbsp;&nbsp<asp:Label ID="lblNombre" runat="server"
                     ></asp:Label></strong><br/>&nbsp;&nbsp;&nbsp;<asp:Label ID="lblDireccion" runat="server"
                     ></asp:Label></span></div>
            <div style="float:right; overflow:hidden; width:262px">
       	  	<span class="texto14azul">Código Cavali:  <asp:Label ID="lblCavali" runat="server"></asp:Label><br/>
              Representante:   <asp:Label ID="lblTrader" runat="server"></asp:Label><br/>
              <asp:Label ID="lblTipoCambio" runat="server"></asp:Label>
          	</span>
          	</div>
      </div>
      <div class="bienvenida"> 
         	<div style="float:left; overflow:hidden; margin-right:15px;">
         	<span class="texto18azul">Fecha de corte:</span>
            </div>
            <div style="float:left; overflow:hidden; margin-right:15px;">
         	<input id="DesdeInput" runat="server" style="height:25px; width:90px" type="text"  class="date-picker"/>
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>
            </div>
            <div style="float:left; overflow:hidden; margin-right:15px;">
   	            <asp:ImageButton ImageUrl="../img/visualizar.jpg" 
                    OnClientClick="return validarFecha();" ID="visualizar" Width="100" Height="30" 
                    runat="server" onclick="visualizar_Click" />
            </div>
      </div>
      
      <div id="CR" class="contenedor-reportes" runat="Server" visible="false">
      		 <div style="overflow:hidden; margin-top:15px;text-align:right; margin-right:35px;"><span class="texto13azul" style="padding-right:10px;">imprimir</span><img src="../img/imp.gif" width="21" height="18" /></div>
             
             <div style="overflow:hidden; margin-top:10px;">
                <div class="texto14azul" style="margin-bottom:10px;"><strong>Total de Cartera USD$ 
                    <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></strong> <br/><br/></div>

                <div class="texto14azul" style="margin-bottom:10px;"><strong>En moneda extranjera US$</strong><br></div>
           	   
               <asp:GridView ID="gvDolares" runat="server" ShowFooter="true"
                AutoGenerateColumns="False" BackColor="White" BorderWidth="0"
                     onrowdatabound="gvDolares_RowDataBound" ShowHeaderWhenEmpty="true" >
                <EmptyDataTemplate>
                   <label id=lbl style="color:GrayText">No hay registros que mostrar</label>
                </EmptyDataTemplate>
                <headerstyle backcolor="#758a9d" HorizontalAlign="Center" CssClass="texto13blanco"></headerstyle>
                <alternatingrowstyle backcolor="White" ForeColor="GrayText" HorizontalAlign="Center"></alternatingrowstyle>
                <RowStyle backcolor="#d2d9df" ForeColor="GrayText" HorizontalAlign="Center"/>
                <FooterStyle HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField HeaderStyle-Width="72" HeaderText="Valor" DataField="Valor"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Tenencia Total de Valores" DataFormatString="{0:N0}" DataField="Tenencia"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Compras Pendientes" DataFormatString="{0:N2}" DataField="ComprasP"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="90" HeaderText="Ventas Pendientes" DataFormatString="{0:N2}" DataField="VentasP"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="85" HeaderText="Garantia Reporte" DataFormatString="{0:N2}" DataField="GarantiaR"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="85" HeaderText="Garantia Margen" DataFormatString="{0:N2}" DataField="GarantiaM"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Precio de Mercado" DataFormatString="{0:N2}" DataField="Mercado"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Valorización" DataFormatString="{0:N2}" DataField="Valorizacion"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="E.C. (%)**" DataFormatString="{0:N2}" DataField="ECTOT"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <br/><br/>
            <div class="texto14azul" style="margin-bottom:10px;"><strong>En Nuevos Soles S/.</strong><br></div>
               <asp:GridView ID="gvSoles" runat="server" ShowFooter="true" ShowHeaderWhenEmpty="true"
                AutoGenerateColumns="False" BackColor="White" BorderWidth="0" 
                     onrowdatabound="gvSoles_RowDataBound" >
                <EmptyDataTemplate>
                    <label id="lbl" style="color:GrayText">No hay registros que mostrar</label>
                </EmptyDataTemplate>
                <headerstyle backcolor="#758a9d" HorizontalAlign="Center" CssClass="texto13blanco"></headerstyle>
                <alternatingrowstyle backcolor="White" ForeColor="GrayText" HorizontalAlign="Center"></alternatingrowstyle>
                <RowStyle backcolor="#d2d9df" ForeColor="GrayText" HorizontalAlign="Center" />
                <FooterStyle HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField HeaderStyle-Width="72" HeaderText="Valor" DataField="Valor"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Tenencia Total de Valores" DataFormatString="{0:N0}" DataField="Tenencia"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Compras Pendientes" DataFormatString="{0:N2}" DataField="ComprasP"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="90" HeaderText="Ventas Pendientes" DataFormatString="{0:N2}" DataField="VentasP"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="85" HeaderText="Garantia Reporte" DataFormatString="{0:N2}" DataField="GarantiaR"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="85" HeaderText="Garantia Margen" DataFormatString="{0:N2}" DataField="GarantiaM"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Precio de Mercado"  DataFormatString="{0:N2}" DataField="Mercado"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Valorización"  DataFormatString="{0:N2}" DataField="Valorizacion"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="E.C. (%)**" DataFormatString="{0:N2}" DataField="ECTOT"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <%--<table width="1170" border="0" cellspacing="2" cellpadding="0">
              <tr>
                <td width="170" height="20" align="center">Total 230,543 acciones</td>
                <td width="100" align="center">&nbsp;</td>
                <td align="center">&nbsp;</td>
                <td align="center">&nbsp;</td>
                <td align="right"><p>Sub Total&nbsp;en la comision moneda nacional S/.&nbsp;&nbsp; &nbsp;</p></td>
                <td width="100" align="center">147,254.86</td>
                <td width="100" align="center">63,603.10</td>
                <td width="100" align="center">-83,651.76</td>
                <td width="100" align="center">-56.81%</td>
                <td width="100" align="center"><strong>100.00%</strong></td>
              </tr>
            </table>--%>

               <table width="1170" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF" style="display:none;">
  <tr>
    <td><table width="1170" border="0" cellspacing="2" cellpadding="0">
      <tr>
        <td width="70" height="42" align="center" bgcolor="#758a9d"><span class="texto13blanco">Valor</span></td>
        <td width="100" align="center" bgcolor="#758a9d"><span class="texto13blanco">Cantidad</span></td>
        <td width="100" align="center" bgcolor="#758a9d"><span class="texto13blanco">Disponible</span></td>
        <td width="90" align="center" bgcolor="#758a9d"><span class="texto13blanco">Principal <br />
          en Reporte</span></td>
        <td width="85" align="center" bgcolor="#758a9d"><span class="texto13blanco">Margen <br />
          Garantia</span></td>
        <td width="100" align="center" bgcolor="#758a9d"><p><span class="texto13blanco">Precio Prom<br />
          Compra</span>
        </p></td>
        <td width="100" align="center" bgcolor="#758a9d"><span class="texto13blanco">Precio de<br />
          Mercado</span></td>
        <td width="100" align="center" bgcolor="#758a9d"><span class="texto13blanco">Monto <br />
          Invertido</span></td>
        <td width="100" align="center" bgcolor="#758a9d"><span class="texto13blanco">Valorización</span></td>
        <td width="100" align="center" bgcolor="#758a9d"><span class="texto13blanco">Rentabilidad<br />
          (monto)</span></td>
        <td align="center" bgcolor="#758a9d"><span class="texto13blanco">Rent.<br />(%)</span></td>
        <td width="100" align="center" bgcolor="#758a9d"><span class="texto13blanco">E.C. (%)**</span></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td>
      <table width="1170" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="70" height="20" align="center" bgcolor="#d2d9df">MMEX</td>
          <td width="100" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="100" align="center" bgcolor="#d2d9df">10, 000</td>
          <td align="center" bgcolor="#d2d9df">0</td>
          <td align="center" bgcolor="#d2d9df">0</td>
          <td width="100" align="center" bgcolor="#d2d9df"><p>1,00 00</p></td>
          <td width="100" align="center" bgcolor="#d2d9df">0,1426</td>
          <td width="100" align="center" bgcolor="#d2d9df">10,000 00</td>
          <td width="100" align="center" bgcolor="#d2d9df">1,423.00</td>
          <td width="100" align="center" bgcolor="#d2d9df">1,423.00</td>
          <td width="100" align="center" bgcolor="#d2d9df">-85.77%</td>
          <td width="100" align="center" bgcolor="#d2d9df">-85.77%</td>
          </tr>
        </table>
      </td>
  </tr>
  
  <tr>
    <td>
    <table width="1170" border="0" cellspacing="2" cellpadding="0">
      <tr>
        <td width="70" height="20" align="center">MMEX</td>
        <td width="100" align="center">10, 000</td>
        <td width="100" align="center">10, 000</td>
        <td align="center">0</td>
        <td align="center">0</td>
        <td width="100" align="center"><p>1,00 00</p></td>
        <td width="100" align="center">0,1426</td>
        <td width="100" align="center">10,000 00</td>
        <td width="100" align="center">1,423.00</td>
        <td width="100" align="center">1,423.00</td>
        <td width="100" align="center">-85.77%</td>
        <td width="100" align="center">-85.77%</td>
      </tr>
    </table>
    </td>
  </tr>
  <tr>
    <td>
    	<table width="1170" border="0" cellspacing="2" cellpadding="0">
      <tr>
        <td width="70" height="20" align="center" bgcolor="#d2d9df">MPLE</td>
        <td width="100" align="center" bgcolor="#d2d9df">10, 000</td>
        <td width="100" align="center" bgcolor="#d2d9df">10, 000</td>
        <td align="center" bgcolor="#d2d9df">0</td>
        <td align="center" bgcolor="#d2d9df">0</td>
        <td width="100" align="center" bgcolor="#d2d9df"><p>1,00 00</p></td>
        <td width="100" align="center" bgcolor="#d2d9df">0,1426</td>
        <td width="100" align="center" bgcolor="#d2d9df">10,000 00</td>
        <td width="100" align="center" bgcolor="#d2d9df">1,423.00</td>
        <td width="100" align="center" bgcolor="#d2d9df">1,423.00</td>
        <td width="100" align="center" bgcolor="#d2d9df">-85.77%</td>
        <td width="100" align="center" bgcolor="#d2d9df">-85.77%</td>
      </tr>
    </table>
    </td>
  </tr>
  <tr>
    <td>
    <table width="1170" border="0" cellspacing="2" cellpadding="0">
      <tr>
        <td width="70" height="20" align="center">RIO</td>
        <td width="100" align="center">10, 000</td>
        <td width="100" align="center">10, 000</td>
        <td align="center">0</td>
        <td align="center">0</td>
        <td width="100" align="center"><p>1,00 00</p></td>
        <td width="100" align="center">0,1426</td>
        <td width="100" align="center">10,000 00</td>
        <td width="100" align="center">1,423.00</td>
        <td width="100" align="center">1,423.00</td>
        <td width="100" align="center">-85.77%</td>
        <td width="100" align="center">-85.77%</td>
      </tr>
    </table>
    </td>
  </tr>
  <tr>
    <td>
    <table width="1170" border="0" cellspacing="2" cellpadding="0">
      <tr>
        <td width="70" height="20" align="center" bgcolor="#d2d9df">SUE</td>
        <td width="100" align="center" bgcolor="#d2d9df">10, 000</td>
        <td width="100" align="center" bgcolor="#d2d9df">10, 000</td>
        <td align="center" bgcolor="#d2d9df">0</td>
        <td align="center" bgcolor="#d2d9df">0</td>
        <td width="100" align="center" bgcolor="#d2d9df"><p>1,00 00</p></td>
        <td width="100" align="center" bgcolor="#d2d9df">0,1426</td>
        <td width="100" align="center" bgcolor="#d2d9df">10,000 00</td>
        <td width="100" align="center" bgcolor="#d2d9df">1,423.00</td>
        <td width="100" align="center" bgcolor="#d2d9df">1,423.00</td>
        <td width="100" align="center" bgcolor="#d2d9df">-85.77%</td>
        <td width="100" align="center" bgcolor="#d2d9df">-85.77%</td>
      </tr>
    </table>
    </td>
  </tr>
  <tr>
    <td>
    <table width="1170" border="0" cellspacing="2" cellpadding="0">
      <tr>
        <td width="70" height="20" align="center">TV</td>
        <td width="100" align="center">10, 000</td>
        <td width="100" align="center">10, 000</td>
        <td align="center">0</td>
        <td align="center">0</td>
        <td width="100" align="center"><p>1,00 00</p></td>
        <td width="100" align="center">0,1426</td>
        <td width="100" align="center">10,000 00</td>
        <td width="100" align="center">1,423.00</td>
        <td width="100" align="center">1,423.00</td>
        <td width="100" align="center">-85.77%</td>
        <td width="100" align="center">-85.77%</td>
      </tr>
    </table>
    </td>
  </tr>
  <tr>
    <td>
    	<table width="1170" border="0" cellspacing="2" cellpadding="0">
      <tr>
        <td width="170" height="20" align="center">Total 230,543 acciones</td>
        <td width="100" align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td align="right"><p>Sub Total&nbsp;en la comision extranjera USS$&nbsp;&nbsp; &nbsp;</p></td>
        <td width="100" align="center">147,254.86</td>
        <td width="100" align="center">63,603.10</td>
        <td width="100" align="center">-83,651.76</td>
        <td width="100" align="center">-56.81%</td>
        <td width="100" align="center"><strong>100.00%</strong></td>
      </tr>
    </table>
    </td>
  </tr>
  <tr>
    <td>
    	<table width="1170" border="0" cellspacing="2" cellpadding="0">
      <tr>
        <td height="20" align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
      </tr>
      <tr>
        <td width="70" height="20" align="center">&nbsp;</td>
        <td width="100" align="center">&nbsp;</td>
        <td width="100" align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td width="100" align="center"><p>&nbsp;</p></td>
        <td width="100" align="center">TOTALES US$</td>
        <td width="100" align="center">10,000 00</td>
        <td width="100" align="center">1,423.00</td>
        <td width="100" align="center">1,423.00</td>
        <td width="100" align="center">-56.81%</td>
        <td width="100" align="center">&nbsp;</td>
      </tr>
    </table>
    </td>
  </tr>
  <tr>
    <td>
    	<table width="1170" border="0" cellspacing="2" cellpadding="0">
      <tr>
        <td width="70" height="20" align="center">&nbsp;</td>
        <td width="100" align="center">&nbsp;</td>
        <td width="100" align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td width="100" align="center"><p>&nbsp;</p></td>
        <td width="100" align="center">s/.</td>
        <td width="100" align="center">10,000 00</td>
        <td width="100" align="center">1,423.00</td>
        <td width="100" align="center">1,423.00</td>
        <td width="100" align="center">-85.77%</td>
        <td width="100" align="center">&nbsp;</td>
      </tr>
    </table>
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
</table>

             </div>
             
             <div class="descrip">
             	<span>
                	**E.C (%) Porcentaje de participacón en su estructura de Cartera.
Los valores de última cotización que muestran 0.00 son aquellas acciones que no han realizado cotización alguna durante 20 ruedas.<br />
Los precios visualizados son al día/nov/2013
                </span>
             </div>
              <div style="overflow:hidden; width:400px; margin-top:20px;">
       	  	<span class="texto14azul"><strong>> Reportado</strong></span></div>
            
            <div style="overflow:hidden; margin-top:34px;">
            <asp:GridView ID="gvReportado" runat="server" ShowHeaderWhenEmpty="true" BorderWidth="0"
                AutoGenerateColumns="False" BackColor="White" >
                <EmptyDataTemplate>
                    <label id=lbl style="color:GrayText">No hay registros que mostrar</label>
                </EmptyDataTemplate>
                <headerstyle backcolor="#758a9d" HorizontalAlign="Center" CssClass="texto13blanco"></headerstyle>
                <alternatingrowstyle backcolor="White" ForeColor="GrayText" HorizontalAlign="Center"></alternatingrowstyle>
                <RowStyle backcolor="#d2d9df" ForeColor="GrayText" HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField HeaderStyle-Width="72" HeaderText="Valor" DataField="Valor"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Fecha Operación" DataFormatString="{0:d}" DataField="FechaOperacion"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Número Operación" DataField="NumeroOperacion"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="90" HeaderText="Poliza" DataField="Poliza"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="85" HeaderText="Cantidad" DataField="Cantidad"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="FL1" DataFormatString="{0:d}" DataField="FL1"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="FL2" DataFormatString="{0:d}" DataField="FL2"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Moneda" DataField="Moneda"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Contado" DataFormatString="{0:N2}" DataField="Contado" Visible="false"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Plazo" DataFormatString="{0:N2}" DataField="Plazo" Visible="false"></asp:BoundField>
                </Columns>
            </asp:GridView>

           	   <table width="888" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF" style="display:none">
  <tr>
    <td><table width="888" border="0" cellspacing="2" cellpadding="0">
      <tr>
        <td width="70" height="42" align="center" bgcolor="#758a9d"><span class="texto13blanco">Valor</span></td>
        <td width="94" align="center" bgcolor="#758a9d"><span class="texto13blanco">Fecha<br />
operación</span></td>
        <td width="100" align="center" bgcolor="#758a9d"><span class="texto13blanco">Número <br />
          operación</span></td>
        <td width="100" align="center" bgcolor="#758a9d"><span class="texto13blanco">Póliza</span></td>
        <td width="90" align="center" bgcolor="#758a9d"><span class="texto13blanco">Cantidad</span></td>
        <td width="60" align="center" bgcolor="#758a9d"><span class="texto13blanco">FL1</span></td>
        <td width="60" align="center" bgcolor="#758a9d"><span class="texto13blanco">FL2</span></td>
        <td width="97" align="center" bgcolor="#758a9d"><span class="texto13blanco">Moneda</span></td>
        <td width="92" align="center" bgcolor="#758a9d"><span class="texto13blanco">Contado</span></td>
        <td width="100" align="center" bgcolor="#758a9d"><span class="texto13blanco">Plaza</span></td>
        
        </tr>
      </table></td>
  </tr>
  <tr>
    <td>
      <table width="888" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="70" height="20" align="center" bgcolor="#d2d9df">LCY</td>
          <td width="94" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="100" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="100" align="center" bgcolor="#d2d9df">0</td>
          <td width="90" align="center" bgcolor="#d2d9df">0</td>
          <td width="60" align="center" bgcolor="#d2d9df"><p>&nbsp;</p></td>
          <td width="60" align="center" bgcolor="#d2d9df">1,0000</td>
          <td width="97" align="center" bgcolor="#d2d9df">0.1423</td>
          <td width="92" align="center" bgcolor="#d2d9df">10,000.00</td>
          <td width="100" align="center" bgcolor="#d2d9df">1,423.00</td>
          </tr>
        </table>
      </td>
  </tr>
  <tr>
    <td>
    	<table width="888" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="70" height="20" align="center">MMEX</td>
          <td width="94" align="center">150, 000</td>
          <td width="100" align="center">150, 000</td>
          <td width="100" align="center">0</td>
          <td width="90" align="center">0</td>
          <td width="60" align="center"><p>&nbsp;</p></td>
          <td width="60" align="center">0,2000</td>
          <td width="97" align="center">0.0090</td>
          <td width="92" align="center">30,000.00</td>
          <td width="100" align="center">1,423.00</td>
          </tr>
        </table>
    </td>
  </tr>
  <tr>
    <td>
      <table width="888" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="70" height="20" align="center" bgcolor="#d2d9df">MPLE</td>
          <td width="94" align="center" bgcolor="#d2d9df">6,637</td>
          <td width="100" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="100" align="center" bgcolor="#d2d9df">0</td>
          <td width="90" align="center" bgcolor="#d2d9df">6,637</td>
          <td width="60" align="center" bgcolor="#d2d9df"><p>&nbsp;</p></td>
          <td width="60" align="center" bgcolor="#d2d9df">1,1099</td>
          <td width="97" align="center" bgcolor="#d2d9df">0.5700</td>
          <td width="92" align="center" bgcolor="#d2d9df">71,366.55</td>
          <td width="100" align="center" bgcolor="#d2d9df">1,423.00</td>
          </tr>
        </table>
      </td>
  </tr>
  <tr>
    <td>
      <table width="888" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td height="20" align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          </tr>
        <tr>
          <td width="100" height="20" align="center">&nbsp;</td>
          <td width="100" align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td width="100" align="center"><p>&nbsp;</p></td>
          <td width="100" align="center">&nbsp;</td>
          <td width="100" align="center">&nbsp;</td>
          <td width="100" align="center">Total en s/.</td>
          <td width="100" align="center">0.00</td>
          <td width="100" align="center">0.00</td>
          </tr>
        </table>
      </td>
  </tr>
  <tr>
    <td><span class="texto13azul">_______________________________________________________________________________________________________________________________________________________________________________</span></td></tr>
  <tr>
    <td>
    	<table width="888" border="0" cellspacing="2" cellpadding="0">
      <tr>
        <td width="100" height="20" align="center">&nbsp;</td>
        <td width="100" align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td width="100" align="center"><p>&nbsp;</p></td>
        <td width="100" align="center">&nbsp;</td>
        <td width="100" align="center">&nbsp;</td>
        <td width="100" align="center">Total en US$</td>
        <td width="100" align="center">0.00</td>
        <td width="100" align="center">31,455.02</td>
        </tr>
    </table>
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
</table>

        </div>
        
        <div class="descrip"> </div>
        
        <div style="overflow:hidden; width:400px; margin-top:20px;">
       	  	<span class="texto14azul"><strong>> Reportante</strong></span></div>
            
        <div style="overflow:hidden; margin-top:34px;">
        <asp:GridView ID="gvReportante" runat="server"  ShowHeaderWhenEmpty="true" BorderWidth="0"
                AutoGenerateColumns="False" BackColor="White" >
                <EmptyDataTemplate>
                    <label id=lbl style="color:GrayText">No hay registros que mostrar</label>
                </EmptyDataTemplate>
                <alternatingrowstyle backcolor="White" ForeColor="GrayText" HorizontalAlign="Center"></alternatingrowstyle>
                <RowStyle backcolor="#d2d9df" ForeColor="GrayText" HorizontalAlign="Center" />
                <headerstyle backcolor="#758a9d" HorizontalAlign="Center" CssClass="texto13blanco"></headerstyle>
                <Columns>
                    <asp:BoundField HeaderStyle-Width="72" HeaderText="Valor" DataField="Valor"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Fecha Operación" DataFormatString="{0:d}" DataField="FechaOperacion"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Número Operación" DataField="NumeroOperacion"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="90" HeaderText="Poliza" DataField="Poliza"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="85" HeaderText="Cantidad" DataField="Cantidad"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="FL1" DataFormatString="{0:d}" DataField="FL1"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="FL2" DataFormatString="{0:d}" DataField="FL2"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Moneda" DataField="Moneda"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Contado" DataFormatString="{0:N2}" DataField="Contado" Visible="false"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Plazo" DataFormatString="{0:N2}" DataField="Plazo" Visible="false"></asp:BoundField>
                </Columns>
            </asp:GridView>

           	   <table width="888" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF" style="display:none">
  <tr>
    <td><table width="888" border="0" cellspacing="2" cellpadding="0">
      <tr>
        <td width="70" height="42" align="center" bgcolor="#758a9d"><span class="texto13blanco">Valor</span></td>
        <td width="94" align="center" bgcolor="#758a9d"><span class="texto13blanco">Fecha<br />
operación</span></td>
        <td width="100" align="center" bgcolor="#758a9d"><span class="texto13blanco">Número <br />
          operación</span></td>
        <td width="100" align="center" bgcolor="#758a9d"><span class="texto13blanco">Póliza</span></td>
        <td width="90" align="center" bgcolor="#758a9d"><span class="texto13blanco">Cantidad</span></td>
        <td width="60" align="center" bgcolor="#758a9d"><span class="texto13blanco">FL1</span></td>
        <td width="60" align="center" bgcolor="#758a9d"><span class="texto13blanco">FL2</span></td>
        <td width="97" align="center" bgcolor="#758a9d"><span class="texto13blanco">Moneda</span></td>
        <td width="92" align="center" bgcolor="#758a9d"><span class="texto13blanco">Contado</span></td>
        <td width="100" align="center" bgcolor="#758a9d"><span class="texto13blanco">Plaza</span></td>
        
        </tr>
      </table></td>
  </tr>
  <tr>
    <td valign="middle" bgcolor="#dee4ea">&nbsp; <br />
      No se encuentraron registros </td>
  </tr>
  </table>

        </div>
            
            
            <div class="descrip"> </div>
            
        <div style="overflow:hidden; width:400px; margin-top:20px;">
   	  	<span class="texto14azul"><strong>> Margen de garantía</strong></span></div>
            
            <div style="overflow:hidden; margin-top:34px;">
            <asp:GridView ID="gvMargen" runat="server"  ShowHeaderWhenEmpty="true"
                AutoGenerateColumns="False" BackColor="White" >
                <EmptyDataTemplate>
                    <label id=lbl style="color:GrayText">No hay registros que mostrar</label>
                </EmptyDataTemplate>
                <headerstyle backcolor="#758a9d" HorizontalAlign="Center" CssClass="texto13blanco"></headerstyle>
                <alternatingrowstyle backcolor="White" ForeColor="GrayText" HorizontalAlign="Center"></alternatingrowstyle>
                <RowStyle backcolor="#d2d9df" ForeColor="GrayText" HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField HeaderStyle-Width="72" HeaderText="Valor" DataField="Valor"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Fecha Garantía" DataFormatString="{0:d}" DataField="FechaGarantia"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Número Operación" DataField="NumeroOperacion"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="85" HeaderText="Cantidad" DataField="CantidadGarantia"></asp:BoundField>
                    <%--<asp:BoundField HeaderStyle-Width="100" HeaderText="Moneda" DataField="Moneda"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Efectivo" DataField="Efectivo"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Valorización" DataField="Valorizacion"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Valor Mercado" DataField="Mercado"></asp:BoundField>
                    <asp:BoundField HeaderStyle-Width="100" HeaderText="Cotización" DataField="Cotizacion"></asp:BoundField>--%>
                </Columns>
            </asp:GridView>

           	   <table width="888" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF" style="display:none">
  <tr>
    <td><table width="888" border="0" cellspacing="2" cellpadding="0">
      <tr>
        <td width="70" height="42" align="center" bgcolor="#758a9d"><span class="texto13blanco">Valor</span></td>
        <td width="94" align="center" bgcolor="#758a9d"><span class="texto13blanco">Fecha<br />
operación</span></td>
        <td width="100" align="center" bgcolor="#758a9d"><span class="texto13blanco">Número <br />
          operación</span></td>
        <td width="100" align="center" bgcolor="#758a9d"><span class="texto13blanco">Póliza</span></td>
        <td width="90" align="center" bgcolor="#758a9d"><span class="texto13blanco">Cantidad</span></td>
        <td width="60" align="center" bgcolor="#758a9d"><span class="texto13blanco">FL1</span></td>
        <td width="60" align="center" bgcolor="#758a9d"><span class="texto13blanco">FL2</span></td>
        <td width="97" align="center" bgcolor="#758a9d"><span class="texto13blanco">Moneda</span></td>
        <td width="92" align="center" bgcolor="#758a9d"><span class="texto13blanco">Contado</span></td>
        <td width="100" align="center" bgcolor="#758a9d"><span class="texto13blanco">Plaza</span></td>
        
        </tr>
      </table></td>
  </tr>
  <tr>
    <td>
      <table width="888" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="70" height="20" align="center" bgcolor="#d2d9df">LCY</td>
          <td width="94" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="100" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="100" align="center" bgcolor="#d2d9df">0</td>
          <td width="90" align="center" bgcolor="#d2d9df">0</td>
          <td width="60" align="center" bgcolor="#d2d9df"><p>1,00 00</p></td>
          <td width="60" align="center" bgcolor="#d2d9df">0,1426</td>
          <td width="97" align="center" bgcolor="#d2d9df">10,000 00</td>
          <td width="92" align="center" bgcolor="#d2d9df">1,423.00</td>
          <td width="100" align="center" bgcolor="#d2d9df">1,423.00</td>
          </tr>
        </table>
      </td>
  </tr>
  <tr>
    <td>
    	<table width="888" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="70" height="20" align="center">MMEX</td>
          <td width="94" align="center">10, 000</td>
          <td width="100" align="center">10, 000</td>
          <td width="100" align="center">0</td>
          <td width="90" align="center">0</td>
          <td width="60" align="center"><p>1,00 00</p></td>
          <td width="60" align="center">0,1426</td>
          <td width="97" align="center">10,000 00</td>
          <td width="92" align="center">1,423.00</td>
          <td width="100" align="center">1,423.00</td>
          </tr>
        </table>
    </td>
  </tr>
  <tr>
    <td>
      <table width="888" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="70" height="20" align="center" bgcolor="#d2d9df">MPLE</td>
          <td width="94" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="100" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="100" align="center" bgcolor="#d2d9df">0</td>
          <td width="90" align="center" bgcolor="#d2d9df">0</td>
          <td width="60" align="center" bgcolor="#d2d9df"><p>1,00 00</p></td>
          <td width="60" align="center" bgcolor="#d2d9df">0,1426</td>
          <td width="97" align="center" bgcolor="#d2d9df">10,000 00</td>
          <td width="92" align="center" bgcolor="#d2d9df">1,423.00</td>
          <td width="100" align="center" bgcolor="#d2d9df">1,423.00</td>
          </tr>
        </table>
      </td>
  </tr>
  <tr>
    <td>
      <table width="888" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="70" height="20" align="center">RIO</td>
          <td width="94" align="center">10, 000</td>
          <td width="100" align="center">10, 000</td>
          <td width="100" align="center">0</td>
          <td width="90" align="center">0</td>
          <td width="60" align="center"><p>1,00 00</p></td>
          <td width="60" align="center">0,1426</td>
          <td width="97" align="center">10,000 00</td>
          <td width="92" align="center">1,423.00</td>
          <td width="100" align="center">1,423.00</td>
          </tr>
        </table>
      </td>
  </tr>
  <tr>
    <td>
      <table width="888" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="70" height="20" align="center" bgcolor="#d2d9df">SUE</td>
          <td width="94" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="100" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="100" align="center" bgcolor="#d2d9df">0</td>
          <td width="90" align="center" bgcolor="#d2d9df">0</td>
          <td width="60" align="center" bgcolor="#d2d9df"><p>1,00 00</p></td>
          <td width="60" align="center" bgcolor="#d2d9df">0,1426</td>
          <td width="97" align="center" bgcolor="#d2d9df">10,000 00</td>
          <td width="92" align="center" bgcolor="#d2d9df">1,423.00</td>
          <td width="100" align="center" bgcolor="#d2d9df">1,423.00</td>
          </tr>
        </table>
      </td>
  </tr>
  <tr>
    <td>
      <table width="888" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="70" height="20" align="center">TV</td>
          <td width="94" align="center">10, 000</td>
          <td width="100" align="center">10, 000</td>
          <td width="100" align="center">0</td>
          <td width="90" align="center">0</td>
          <td width="60" align="center"><p>1,00 00</p></td>
          <td width="60" align="center">0,1426</td>
          <td width="97" align="center">10,000 00</td>
          <td width="92" align="center">1,423.00</td>
          <td width="100" align="center">1,423.00</td>
          </tr>
        </table>
      </td>
  </tr>
  <tr>
    <td>
      <table width="888" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td height="20" align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          </tr>
        <tr>
          <td height="20" colspan="9">
      <span class="texto13azul">_______________________________________________________________________________________________________________________________________________________________________________</span>
          </td>
          </tr>
        <tr>
          <td width="100" height="20" align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td width="100" align="center"><p>&nbsp;</p></td>
          <td width="100" align="center">&nbsp;</td>
          <td width="100" align="center">&nbsp;</td>
          <td width="100" align="center">Total en s/.</td>
          <td width="100" align="center">1,423.00</td>
          <td width="100" align="center">-56.81%</td>
          </tr>
        </table>
      </td>
  </tr>
  <tr>
    <td><span class="texto13azul">_______________________________________________________________________________________________________________________________________________________________________________</span></td></tr>
  <tr>
    <td>
    	<table width="888" border="0" cellspacing="2" cellpadding="0">
      <tr>
        <td width="100" height="20" align="center">&nbsp;</td>
        <td width="100" align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td align="center">&nbsp;</td>
        <td width="100" align="center"><p>&nbsp;</p></td>
        <td width="100" align="center">&nbsp;</td>
        <td width="100" align="center">&nbsp;</td>
        <td width="100" align="center">Total en US$</td>
        <td width="100" align="center">1,423.00</td>
        <td width="100" align="center">-85.77%</td>
        </tr>
    </table>
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
</table>

        </div>
            
            
          <div style="overflow:hidden; width:400px; margin-top:20px;">
       	  	<span class="texto14azul"></div>   
            
      </div>
    </div>
    
     <div class="submenu">
	<div class="se" style="float:left; margin-right:32px;"><span class="texto18azul"><a href="Politica de Clientes.pdf">Política de cliente </a></span></div>
    <div class="se" style="float:left; margin-right:32px;"><span class="texto18azul"><a href="aviso-legal.html">Aviso Legal</a></span></div>
    <div class="se" style="float:left; margin-right:32px;"><span class="texto18azul"><a href="seguridad.html">Seguridad</a> </span></div>
    <%--<div class="se" style="float:left;"><span class="texto18azul"><a href="#">Cuentas corrientes</a></span></div>--%>
 </div>
    
    
     <footer class="section">
      <div class="wrapper group">
        <div class="col span-4-of-12 copyright">Todos los derechos reservados © Kallpa Securities SAB</div>
        <div class="col span-8-of-12 address">Central telefónica: (511) 630-7500 - contacto@kallpasab.com - Av. La Encalada 1388 of. 802. Surco, Lima</div>
      </div>
    </footer>
</div>
    </form>
</body>
</html>
