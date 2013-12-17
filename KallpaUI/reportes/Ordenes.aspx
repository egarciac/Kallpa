<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ordenes.aspx.cs" Inherits="KallpaUI.reportes.Ordenes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Kallpa Securities SAB</title>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
	<script src="http://code.jquery.com/jquery-1.9.1.js"></script>
	<script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
	<link href="css/stilos-reporte-detalle.css" rel="stylesheet" type="text/css" />
	<script src="../Scripts/kallpa/reportes.js" type="text/javascript"></script>
    <script type="text/javascript">
    function validarFecha() {
              var input = document.getElementById("DesdeInput");
              
              if (input.value == "") {
                  document.getElementById("contenedor-reportes").style.display = "none";
                  var label = document.getElementById("lblError");
                  label.innerHTML = "*";
                  return false;
                }
                else {
                    document.getElementById("contenedor-reportes").style.display = "block";
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
		<!--<div style="float:left; margin-right:2px;"><a href="#" style="text-decoration:none"> <span class="texto13azul">Manual de usos del aplicativo</span></a></div>-->
		<!--<div style="float:left; margin-right:20px;"><a href="#" style="text-decoration:none"><img src="img/pdf.jpg" width="16" height="18" border="0" /></a></div>-->
		<div style="float:left; margin-right:5px;"> <a href="Login.aspx" style="text-decoration:none"><span class="texto13azul">salir</span></a></div>
		<div style="float:left;"><a href="Login.aspx" style="text-decoration:none"><img src="img/cerrar.png" width="17" height="17" border="0" /></a></div>
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
   <div style="float:right; margin-top:5px; margin-right:5px;"> <a href="login.aspx" style="text-decoration:none"><span class="texto13azul">salir</span></a></div>
	<div style="float:right; margin-top:5px;"> <a href="login.aspx" style="text-decoration:none"><img src="img/cerrar.png" width="17" height="17" border="0" /></a></div>            
   </div>
    <div class="portada-imagen">
    	<div class="text">
			
			<h1 style="margin: 0; margin-left:-135px;">Ordenes</h1>
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
       	  	<span class="texto14azul">Código Cavali:  <asp:Label ID="lblCavali" runat="server"
                     ></asp:Label><br/>
              Representante:   <asp:Label ID="lblTrader" runat="server"
                     ></asp:Label>
          	</span>
          	</div>
      </div>
      <div class="bienvenida-intern"> 
         	<div style="float:left; overflow:hidden; width:350px">
         			<div style="margin-bottom:26px; overflow:hidden">
                    	<div style="float:left; overflow:hidden; margin-right:45px;">
         					<span class="texto18azul">Tipo de operación</span>
            			</div>
            			<div style="float:left; overflow:hidden; margin-right:15px;">
         					<asp:DropDownList ID="TipoOperacionDropDownList" Width="160px" runat="server"></asp:DropDownList>
            			</div>
                       
                    </div>

                   
                    
                    <div style="margin-bottom:26px; overflow:hidden">
                    	<div style="float:left; overflow:hidden; margin-right:110px;">
         					<span class="texto18azul">Desde</span>
            			</div>
            			<div style="float:left; overflow:hidden; margin-right:15px;">
         					<input id="DesdeInput" runat="server" style="height:20px; width:155px" type="text" class="date-picker"/>
            			</div>
                        
                    </div>
                    
                    
            </div>
            
            
            
            
            <div style="float:left; overflow:hidden; width:350px">
         			<div style="margin-bottom:26px; overflow:hidden">
                    	<div style="float:left; overflow:hidden; margin-right:20px;">
         					<span class="texto18azul"></span>
            			</div>
            			<div style="float:left; overflow:hidden; margin-right:15px;">
         					
            			</div>
                        
                    </div>
                    
                    
                    <div style="margin-bottom:26px;  overflow:hidden">
                    	<div style="float:left; overflow:hidden; margin-right:40px;">
         					<br/>
                            <span class="texto18azul">Hasta</span>
            			</div>
            			<div style="float:left; overflow:hidden; margin-right:15px;"><br/>
         					<input id="HastaInput" runat="server" style="height:20px; width:155px" type="text"  class="date-picker"/>
            			</div>
                       
                    </div>
                    
                    
                   <div style="margin-bottom:26px; overflow:hidden">
                    	
                        <div style="float:left; overflow:hidden; margin-left:130px; margin-top:15px;">
   	     					<asp:ImageButton ImageUrl="../img/visualizar.jpg" ID="VisualizarImageButton" OnClientClick="return validarFecha();"
						Width="100" Height="30" runat="server" onclick="VisualizarImageButton_Click" />
         				</div>
                       
                     
                    </div>
                    
                    
            </div>
            
            
            

           
      </div>
      
      <div id="contenedor-reportes" class="contenedor-reportes">
      		 <div style="overflow:hidden; margin-top:15px;text-align:left;"><span class="texto13azul" style="padding-right:10px;">imprimir</span><img src="img/imp.gif" width="21" height="18" /></div>
             
             <div style="overflow:hidden; margin-top:10px;">
               <asp:GridView ID="gvOrdenes" runat="server" AutoGenerateColumns="false" BackColor="#FFFFFF" >
				<EmptyDataTemplate>
					<div>
						No se han encontrado registros
					</div>
				</EmptyDataTemplate>
				<headerstyle backcolor="#758a9d" HorizontalAlign="Center" CssClass="texto13blanco"></headerstyle>
				<alternatingrowstyle backcolor="White" HorizontalAlign="Center" ForeColor="GrayText"></alternatingrowstyle>
				<RowStyle backcolor="#d2d9df" HorizontalAlign="Center" ForeColor="GrayText" />
				<Columns>
					<asp:BoundField ItemStyle-Width="103" HeaderText="Fecha Orden" DataFormatString="{0:d}" DataField="Fecha" />
					<asp:BoundField ItemStyle-Width="62" HeaderText="Hora" DataField="Hora" />
					<asp:BoundField ItemStyle-Width="91" HeaderText="Nº orden" DataField="Orden" />
					<asp:BoundField ItemStyle-Width="91" HeaderText="C/V" DataField="CV" />
					<asp:BoundField ItemStyle-Width="91" HeaderText="Valor" DataField="Valor" />
					<asp:BoundField ItemStyle-Width="91" HeaderText="Cantidad Acciones" DataFormatString="{0:N2}" DataField="Cantidad" />
                    <asp:BoundField ItemStyle-Width="91" HeaderText="Moneda" DataField="Moneda" Visible="false" />
                    <asp:BoundField ItemStyle-Width="91" HeaderText="Vigencia en días" DataField="Vigencia" />
                    <asp:BoundField ItemStyle-Width="91" HeaderText="Tipo Operación" DataField="Operacion" />
                    <asp:BoundField ItemStyle-Width="91" HeaderText="Mercado" DataField="Mercado" Visible="false" />
                    <%--<asp:BoundField ItemStyle-Width="91" HeaderText="Precio" DataFormatString="{0:N2}" DataField="Precio" />--%>
                    <asp:BoundField ItemStyle-Width="91" HeaderText="Firmadas" DataField="Firmado" />
				</Columns>
			</asp:GridView>

           	   <table width="1170" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF" style="display:none">
  <tr>
    <td><table width="1170" border="0" cellspacing="2" cellpadding="0">
      <tr>
        <td width="103" height="42" align="center" bgcolor="#758a9d"><span class="texto13blanco">Fecha Orden</span></td>
        <td width="62" align="center" bgcolor="#758a9d"><span class="texto13blanco">Hora</span></td>
        <td width="91" align="center" bgcolor="#758a9d"><span class="texto13blanco">Nº orden </span></td>
        <td width="91" align="center" bgcolor="#758a9d"><span class="texto13blanco">C/V</span></td>
        <td width="91" align="center" bgcolor="#758a9d"><span class="texto13blanco">valor</span></td>
        <td width="117" align="center" bgcolor="#758a9d"><p><span class="texto13blanco">Cantidad<br />
          Acciones</span>
        </p></td>
        <td width="93" align="center" bgcolor="#758a9d"><span class="texto13blanco">Moneda</span></td>
        <td width="92" align="center" bgcolor="#758a9d"><span class="texto13blanco">vigencia</span></td>
        <td width="129" align="center" bgcolor="#758a9d"><span class="texto13blanco">Tipo de operación</span></td>
        <td width="86" align="center" bgcolor="#758a9d"><span class="texto13blanco">Mercado</span></td>
        <td width="86" align="center" bgcolor="#758a9d"><span class="texto13blanco">Precio</span></td>
        <td width="85" align="center" bgcolor="#758a9d"><span class="texto13blanco">Firmadas</span></td>
      </tr>
    </table></td>
  </tr>
  <tr><td height="20"></td></tr>
  <tr>
    <td>
      <table width="1170" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="103" height="20" align="center" bgcolor="#d2d9df">MMEX</td>
          <td width="62" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="91" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="91" align="center" bgcolor="#d2d9df">0</td>
          <td width="91" align="center" bgcolor="#d2d9df">0</td>
          <td width="117" align="center" bgcolor="#d2d9df"><p>1,00 00</p></td>
          <td width="93" align="center" bgcolor="#d2d9df">0,1426</td>
          <td width="92" align="center" bgcolor="#d2d9df">10,000 00</td>
          <td width="129" align="center" bgcolor="#d2d9df">1,423.00</td>
          <td width="86" align="center" bgcolor="#d2d9df">1,423.00</td>
          <td width="86" align="center" bgcolor="#d2d9df">-85.77%</td>
          <td width="85" align="center" bgcolor="#d2d9df">-85.77%</td>
          </tr>
        </table>
      </td>
  </tr>
  
  <tr>
    <td><table width="1170" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="103" height="20" align="center" bgcolor="#d2d9df">MMEX</td>
          <td width="62" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="91" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="91" align="center" bgcolor="#d2d9df">0</td>
          <td width="91" align="center" bgcolor="#d2d9df">0</td>
          <td width="117" align="center" bgcolor="#d2d9df"><p>1,00 00</p></td>
          <td width="93" align="center" bgcolor="#d2d9df">0,1426</td>
          <td width="92" align="center" bgcolor="#d2d9df">10,000 00</td>
          <td width="129" align="center" bgcolor="#d2d9df">1,423.00</td>
          <td width="86" align="center" bgcolor="#d2d9df">1,423.00</td>
          <td width="86" align="center" bgcolor="#d2d9df">-85.77%</td>
          <td width="85" align="center" bgcolor="#d2d9df">-85.77%</td>
          </tr>
        </table></td>
  </tr>
  <tr>
    <td><table width="1170" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="103" height="20" align="center" bgcolor="#d2d9df">MMEX</td>
          <td width="62" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="91" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="91" align="center" bgcolor="#d2d9df">0</td>
          <td width="91" align="center" bgcolor="#d2d9df">0</td>
          <td width="117" align="center" bgcolor="#d2d9df"><p>1,00 00</p></td>
          <td width="93" align="center" bgcolor="#d2d9df">0,1426</td>
          <td width="92" align="center" bgcolor="#d2d9df">10,000 00</td>
          <td width="129" align="center" bgcolor="#d2d9df">1,423.00</td>
          <td width="86" align="center" bgcolor="#d2d9df">1,423.00</td>
          <td width="86" align="center" bgcolor="#d2d9df">-85.77%</td>
          <td width="85" align="center" bgcolor="#d2d9df">-85.77%</td>
          </tr>
        </table></td>
  </tr>
  <tr>
    <td height="20">&nbsp;</td>
  </tr>
  <tr>
    <td height="20" bgcolor="#D2D9DF">&nbsp;</td>
  </tr>
  </table>

             </div>
        <div class="descrip2"> </div>
      </div>
    </div>
    
     <div class="submenu">
	<div class="se" style="float:left; margin-right:32px;"><span class="texto18azul"><a href="#">Política de cliente </a></span></div>
    <div class="se" style="float:left; margin-right:32px;"><span class="texto18azul"><a href="#">Aviso Legal</a></span></div>
    <div class="se" style="float:left; margin-right:32px;"><span class="texto18azul"><a href="#">Seguridad </a></span></div>
    <div class="se" style="float:left;"><span class="texto18azul"><a href="#">Cuentas corrientes</a></span></div>
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
