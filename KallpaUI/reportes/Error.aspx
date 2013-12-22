<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="KallpaUI.reportes.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Kallpa Securities SAB</title>
<%--<link href="css/stilos-reporte.css" rel="stylesheet" type="text/css" />--%>
<link href="css/stilos-reporte-detalle.css" rel="stylesheet" type="text/css" />
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
	<a href="#" target="_self">
    <div class="e" style="float:left; margin-right:33px; padding-bottom:5px; padding-top:7px; padding-left:5px; padding-right:5px;"><span class="texto18e">Portafolio</span></div>
    </a>
    <a href="#" target="_self">
    <div class="e"  style="float:left; margin-right:33px; padding-bottom:5px; padding-top:7px; padding-left:5px; padding-right:5px;"><span class="texto18e">Detalle operaciones</span></div>
    </a>
   <a href="#" target="_self"> 
   <div class="e" style="float:left; margin-right:33px; padding-bottom:5px; padding-top:7px; padding-left:5px; padding-right:5px;"><span class="texto18e">Cuenta corriente</span></div>
   </a>
   <a href="#" target="_self"> 
   <div class="e" style="float:left; margin-right:33px; padding-bottom:5px; padding-top:7px; padding-left:5px; padding-right:5px;"><span class="texto18e">Órdenes</span></div>
   </a>
   <a href="#" target="_self">
     <div class="e" style="float:left; padding-bottom:5px; padding-top:7px; padding-left:5px; padding-right:5px;"><span class="texto18e">Polizas</span></div>
     </a>
   <div style="float:right; margin-top:5px; margin-right:5px;"> <a href="login.aspx" style="text-decoration:none"><span class="texto13azul">&nbsp;Salir</span></a></div>
	<div style="float:right; margin-top:5px;"> <a href="login.aspx" style="text-decoration:none"><img src="img/cerrar.png" width="17" height="17" border="0" /></a></div>            
   </div>
    <div class="portada-imagen">
    	<div class="text2">
			
			<h1 style="margin: 0;" class="blanco36"></h1>
		</div>
    <img src="img/error.jpg" width="1307" height="168" />
    </div>

    
    <div class="contenido-error">
      <div style="margin-bottom:5px; margin-left:126px; margin-top:77px"><span class="texto30azul1"><strong>Disculpe los inconvenientes, <br />
estamos trabajando para brindarle <br />
un mejor servicio</strong></span></div>
		</div>
    
     <div class="submenu">
	<div class="se" style="float:left; margin-right:32px;"><span class="texto18azul"><a href="#"></a></span></div>
    <div class="se" style="float:left; margin-right:32px;"><span class="texto18azul"><a href="#"></a></span></div>
    <div class="se" style="float:left; margin-right:32px;"><span class="texto18azul"><a href="#"></a> </span></div>
    <div class="se" style="float:left;"><span class="texto18azul"><a href="#"></a></span></div>
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
