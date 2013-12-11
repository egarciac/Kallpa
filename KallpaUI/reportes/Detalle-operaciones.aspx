<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detalle-operaciones.aspx.cs" Inherits="KallpaUI.reportes.detalle_operaciones" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Kallpa Securities SAB</title>
    <link href="css/stilos-reporte-detalle.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/kallpa/reportes.js" type="text/javascript"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
	<script src="http://code.jquery.com/jquery-1.9.1.js"></script>
	<script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
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
    <a href="Detalle-operaciones.aspx" target="_self">
    <div class="e"  style="float:left; margin-right:33px; padding-bottom:5px; padding-top:7px; padding-left:5px; padding-right:5px;"><span class="texto18e">Detalle operaciones</span></div>
    </a>
   <a href="Cuentas-Corrientes.aspx" target="_self"> 
   <div class="e" style="float:left; margin-right:33px; padding-bottom:5px; padding-top:7px; padding-left:5px; padding-right:5px;"><span class="texto18e">Cuenta corriente</span></div>
   </a>
   <a href="Ordenes.aspx" target="_self"> 
   <div class="e" style="float:left; margin-right:33px; padding-bottom:5px; padding-top:7px; padding-left:5px; padding-right:5px;"><span class="texto18e">Órdenes</span></div>
   </a>
   <a href="Poliza.aspx" target="_self">
     <div class="e" style="float:left; padding-bottom:5px; padding-top:7px; padding-left:5px; padding-right:5px;"><span class="texto18e">Polizas</span></div>
     </a>
            
  </div>
    <div class="portada-imagen">
    	<div class="text">
			
			<h1 style="margin: 0; margin-left:-135px;">Detalle de Operaciones</h1>
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
      <div class="bienvenida-intern2"> 
         	<div style="float:left; overflow:hidden; width:280px">

                    <div style="margin-bottom:26px; overflow:hidden">
                    	<div style="float:left; overflow:hidden; margin-right:50px;">
         					<span class="texto18azul">Desde</span>
            			</div>
            			<div style="float:left; overflow:hidden; margin-right:15px;">
         					<input id="DesdeInput" runat="server" style="height:20px; width:155px" type="text" class="date-picker"/>
            			</div>
                        
                    </div>
                    
                    
            </div>
            
            
            
            
            <div style="float:left; overflow:hidden; width:280px">

                    <div style="margin-bottom:26px; overflow:hidden">
                    	<div style="float:left; overflow:hidden; margin-right:40px;">
         					<span class="texto18azul">Hasta</span>
            			</div>
            			<div style="float:left; overflow:hidden; margin-right:15px;">
         					<input id="HastaInput" runat="server" style="height:20px; width:155px" type="text"  class="date-picker"/>
            			</div>
                       
                    </div>
                    
                 
            </div>
            
            
            
             <div style="float:left; overflow:hidden; width:200px">


                   <div style="margin-bottom:26px; overflow:hidden">
                    	
                     <div style="float:left; overflow:hidden">
   	     					<img src="img/visualizar.jpg" width="100" height="30" /> 
         				</div>
                       
                     
               </div>
                    
                    
            </div>
            
            
            

           
      </div>
      
      <div style="overflow:hidden; width:800px; margin-top:20px; display:none" >
       	  	<span class="texto14azul"><strong>> Detalle de operaciones: </strong></span>01/11/2012 al 30/11/2012</div>
      
      <div class="contenedor-reportes"  style="display:none">
      		 <div style="overflow:hidden; margin-top:15px;text-align:left;"><span class="texto13azul" style="padding-right:10px;">imprimir</span><img src="img/imp.gif" width="21" height="18" /></div>
             <div style="margin-bottom:10px;"><strong>Nuevos Soles</strong><br></div>
             <div style="overflow:hidden; margin-top:10px;">
               
           	   <table width="957" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
  <tr>
    <td><table width="957" border="0" cellspacing="2" cellpadding="0">
      <tr>
        <td width="104" height="42" align="center" bgcolor="#758a9d"><span class="texto13blanco">Fecha <br />
          Operación</span></td>
        <td width="95" align="center" bgcolor="#758a9d"><span class="texto13blanco">Fecha de<br />
          Vencimiento</span></td>
        <td width="91" align="center" bgcolor="#758a9d"><span class="texto13blanco">Póliza</span></td>
        <td width="91" align="center" bgcolor="#758a9d"><span class="texto13blanco">Mercado</span></td>
        <td width="120" align="center" bgcolor="#758a9d"><span class="texto13blanco">Tipo Operacón</span></td>
        <td width="91" align="center" bgcolor="#758a9d"><p><span class="texto13blanco">Valor</span>
        </p></td>
        <td width="93" align="center" bgcolor="#758a9d"><span class="texto13blanco">Cantidad</span></td>
        <td width="81" align="center" bgcolor="#758a9d"><span class="texto13blanco">Precio</span></td>
        <td width="92" align="center" bgcolor="#758a9d"><span class="texto13blanco">Monto<br />
        Compra</span></td>
        <td width="91" align="center" bgcolor="#758a9d"><span class="texto13blanco">Monto<br />
          Venta
        </span></td>
        </tr>
    </table></td>
  </tr>
  <tr><td height="20"></td></tr>
  <tr>
    <td>
      <table width="957" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="104" height="20" align="center" bgcolor="#d2d9df">30/11/2012</td>
          <td width="95" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="91" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="91" align="center" bgcolor="#d2d9df">0</td>
          <td width="120" align="center" bgcolor="#d2d9df">0</td>
          <td width="91" align="center" bgcolor="#d2d9df"><p>1,00 00</p></td>
          <td width="93" align="center" bgcolor="#d2d9df">0,1426</td>
          <td width="81" align="center" bgcolor="#d2d9df">10,000 00</td>
          <td width="92" align="center" bgcolor="#d2d9df">1,423.00</td>
          <td width="91" align="center" bgcolor="#d2d9df">&nbsp;</td>
          </tr>
        </table>
      </td>
  </tr>
  
  <tr>
    <td><table width="957" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="104" height="20" align="center">30/11/2012</td>
          <td width="95" align="center">10, 000</td>
          <td width="91" align="center">10, 000</td>
          <td width="91" align="center">0</td>
          <td width="120" align="center">0</td>
          <td width="91" align="center"><p>1,00 00</p></td>
          <td width="93" align="center">0,1426</td>
          <td width="81" align="center">&nbsp;</td>
          <td width="92" align="center">&nbsp;</td>
          <td width="91" align="center">&nbsp;</td>
          </tr>
        </table></td>
  </tr>
  <tr>
    <td><table width="957" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="104" height="20" align="center" bgcolor="#d2d9df">30/11/2012</td>
          <td width="95" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="91" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="91" align="center" bgcolor="#d2d9df">0</td>
          <td width="120" align="center" bgcolor="#d2d9df">0</td>
          <td width="91" align="center" bgcolor="#d2d9df"><p>1,00 00</p></td>
          <td width="93" align="center" bgcolor="#d2d9df">0,1426</td>
          <td width="81" align="center" bgcolor="#d2d9df">&nbsp;</td>
          <td width="92" align="center" bgcolor="#d2d9df">&nbsp;</td>
          <td width="91" align="center" bgcolor="#d2d9df">1,423.00</td>
          </tr>
        </table></td>
  </tr>
  <tr>
    <td height="30">&nbsp;</td>
  </tr>
  <tr>
    <td height="20">.........................................................................................................................................................................................................................................................................................</td>
  </tr>
  <tr>
    <td height="20"><table width="957" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="104" height="20" align="center">&nbsp;</td>
          <td width="95" align="center">&nbsp;</td>
          <td width="91" align="center">&nbsp;</td>
          <td width="91" align="center">&nbsp;</td>
          <td width="120" align="center">&nbsp;</td>
          <td width="91" align="center"><p>&nbsp;</p></td>
          <td align="center">Total Nuevos Soles</td>
          <td width="92" align="center">5,894.63 </td>
          <td width="91" align="center"> 5,839.79</td>
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
      
      
      <div class="contenedor-reportes"  style="display:none">
        <div style="margin-bottom:10px;"><strong>Dólares Americanos</strong><br></div>
             <div style="overflow:hidden; margin-top:10px;">
               
           	   <table width="957" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
  <tr>
    <td><table width="957" border="0" cellspacing="2" cellpadding="0">
      <tr>
        <td width="104" height="42" align="center" bgcolor="#758a9d"><span class="texto13blanco">Fecha <br />
          Operación</span></td>
        <td width="95" align="center" bgcolor="#758a9d"><span class="texto13blanco">Fecha de<br />
          Vencimiento</span></td>
        <td width="91" align="center" bgcolor="#758a9d"><span class="texto13blanco">Póliza</span></td>
        <td width="91" align="center" bgcolor="#758a9d"><span class="texto13blanco">Mercado</span></td>
        <td width="120" align="center" bgcolor="#758a9d"><span class="texto13blanco">Tipo Operacón</span></td>
        <td width="91" align="center" bgcolor="#758a9d"><p><span class="texto13blanco">Valor</span>
        </p></td>
        <td width="93" align="center" bgcolor="#758a9d"><span class="texto13blanco">Cantidad</span></td>
        <td width="81" align="center" bgcolor="#758a9d"><span class="texto13blanco">Precio</span></td>
        <td width="92" align="center" bgcolor="#758a9d"><span class="texto13blanco">Monto<br />
        Compra</span></td>
        <td width="91" align="center" bgcolor="#758a9d"><span class="texto13blanco">Monto<br />
          Venta
        </span></td>
        </tr>
    </table></td>
  </tr>
  <tr><td height="20"></td></tr>
  <tr>
    <td>
      <table width="957" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="104" height="20" align="center" bgcolor="#d2d9df">30/11/2012</td>
          <td width="95" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="91" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="91" align="center" bgcolor="#d2d9df">0</td>
          <td width="120" align="center" bgcolor="#d2d9df">0</td>
          <td width="91" align="center" bgcolor="#d2d9df"><p>1,00 00</p></td>
          <td width="93" align="center" bgcolor="#d2d9df">0,1426</td>
          <td width="81" align="center" bgcolor="#d2d9df">10,000 00</td>
          <td width="92" align="center" bgcolor="#d2d9df">1,423.00</td>
          <td width="91" align="center" bgcolor="#d2d9df">&nbsp;</td>
          </tr>
        </table>
      </td>
  </tr>
  
  <tr>
    <td><table width="957" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="104" height="20" align="center">30/11/2012</td>
          <td width="95" align="center">10, 000</td>
          <td width="91" align="center">10, 000</td>
          <td width="91" align="center">0</td>
          <td width="120" align="center">0</td>
          <td width="91" align="center"><p>1,00 00</p></td>
          <td width="93" align="center">0,1426</td>
          <td width="81" align="center">&nbsp;</td>
          <td width="92" align="center">&nbsp;</td>
          <td width="91" align="center">&nbsp;</td>
          </tr>
        </table></td>
  </tr>
  <tr>
    <td><table width="957" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="104" height="20" align="center" bgcolor="#d2d9df">30/11/2012</td>
          <td width="95" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="91" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="91" align="center" bgcolor="#d2d9df">0</td>
          <td width="120" align="center" bgcolor="#d2d9df">0</td>
          <td width="91" align="center" bgcolor="#d2d9df"><p>1,00 00</p></td>
          <td width="93" align="center" bgcolor="#d2d9df">0,1426</td>
          <td width="81" align="center" bgcolor="#d2d9df">&nbsp;</td>
          <td width="92" align="center" bgcolor="#d2d9df">&nbsp;</td>
          <td width="91" align="center" bgcolor="#d2d9df">1,423.00</td>
          </tr>
        </table></td>
  </tr>
  <tr>
    <td height="30"><table width="957" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="104" height="20" align="center">30/11/2012</td>
          <td width="95" align="center">&nbsp;</td>
          <td width="91" align="center">&nbsp;</td>
          <td width="91" align="center">&nbsp;</td>
          <td width="120" align="center">&nbsp;</td>
          <td width="91" align="center"><p>&nbsp;</p></td>
          <td width="93" align="center">Total </td>
          <td width="81" align="center">FERREYC1 </td>
          <td width="92" align="center">24,356.56 </td>
          <td width="91" align="center">24,144.66</td>
          </tr>
        </table></td>
  </tr>
  <tr>
    <td height="30">&nbsp;</td>
  </tr>
  <tr>
    <td height="30"><table width="957" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="104" height="20" align="center" bgcolor="#d2d9df">30/11/2012</td>
          <td width="95" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="91" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="91" align="center" bgcolor="#d2d9df">0</td>
          <td width="120" align="center" bgcolor="#d2d9df">0</td>
          <td width="91" align="center" bgcolor="#d2d9df"><p>1,00 00</p></td>
          <td width="93" align="center" bgcolor="#d2d9df">0,1426</td>
          <td width="81" align="center" bgcolor="#d2d9df">10,000 00</td>
          <td width="92" align="center" bgcolor="#d2d9df">1,423.00</td>
          <td width="91" align="center" bgcolor="#d2d9df">&nbsp;</td>
          </tr>
        </table></td>
  </tr>
  <tr>
    <td height="30"><table width="957" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="104" height="20" align="center">30/11/2012</td>
          <td width="95" align="center">10, 000</td>
          <td width="91" align="center">10, 000</td>
          <td width="91" align="center">0</td>
          <td width="120" align="center">0</td>
          <td width="91" align="center"><p>1,00 00</p></td>
          <td width="93" align="center">0,1426</td>
          <td width="81" align="center">&nbsp;</td>
          <td width="92" align="center">&nbsp;</td>
          <td width="91" align="center">&nbsp;</td>
          </tr>
        </table></td>
  </tr>
  <tr>
    <td height="30"><table width="957" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="104" height="20" align="center" bgcolor="#d2d9df">30/11/2012</td>
          <td width="95" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="91" align="center" bgcolor="#d2d9df">10, 000</td>
          <td width="91" align="center" bgcolor="#d2d9df">0</td>
          <td width="120" align="center" bgcolor="#d2d9df">0</td>
          <td width="91" align="center" bgcolor="#d2d9df"><p>1,00 00</p></td>
          <td width="93" align="center" bgcolor="#d2d9df">0,1426</td>
          <td width="81" align="center" bgcolor="#d2d9df">&nbsp;</td>
          <td width="92" align="center" bgcolor="#d2d9df">&nbsp;</td>
          <td width="91" align="center" bgcolor="#d2d9df">1,423.00</td>
          </tr>
        </table></td>
  </tr>
  <tr>
    <td height="20"><table width="957" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="104" height="20" align="center">30/11/2012</td>
          <td width="95" align="center">&nbsp;</td>
          <td width="91" align="center">&nbsp;</td>
          <td width="91" align="center">&nbsp;</td>
          <td width="120" align="center">&nbsp;</td>
          <td width="91" align="center"><p>&nbsp;</p></td>
          <td width="93" align="center">Total </td>
          <td width="81" align="center">FERREYC1 </td>
          <td width="92" align="center">24,356.56 </td>
          <td width="91" align="center">24,144.66</td>
          </tr>
        </table></td>
  </tr>
  <tr>
    <td height="30">&nbsp;</td>
  </tr>
  <tr>
    <td height="20">.........................................................................................................................................................................................................................................................................................</td>
  </tr>
  <tr>
    <td height="20"><table width="957" border="0" cellspacing="2" cellpadding="0">
        <tr>
          <td width="104" height="20" align="center">&nbsp;</td>
          <td width="95" align="center">&nbsp;</td>
          <td width="91" align="center">&nbsp;</td>
          <td width="91" align="center">&nbsp;</td>
          <td width="120" align="center">&nbsp;</td>
          <td width="91" align="center"><p>&nbsp;</p></td>
          <td align="center">Total Dólares</td>
          <td width="92" align="center">5,894.63 </td>
          <td width="91" align="center"> 5,839.79</td>
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
