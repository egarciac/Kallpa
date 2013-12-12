<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CuentaCorriente.aspx.cs" Inherits="KallpaUI.reportes.CuentaCorriente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Kallpa Securities SAB</title>
	<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">
	<script src="http://code.jquery.com/jquery-1.9.1.js"></script>
	<script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
	<link href="css/stilos-reporte-detalle.css" rel="stylesheet" type="text/css" />
	<script src="../Scripts/kallpa/reportes.js" type="text/javascript"></script>
</head>
<body>
	<form id="Form1" runat="server">
	<div class="contenedor">
	<div class="header">
	  <div class="logo"><img src="../img/logo.jpg" width="290" height="60" /></div>
	  <div class="cabecera-der">
		<div style="float:left; margin-right:2px;"><a href="#" style="text-decoration:none"> <span class="texto13azul">Manual de usos del aplicativo</span></a></div>
			<div style="float:left; margin-right:20px;"><a href="#" style="text-decoration:none"><img src="img/pdf.jpg" width="16" height="18" border="0" /></a></div>
		<div style="float:left; margin-right:5px;"> <a href="#" style="text-decoration:none"><span class="texto13azul">salir</span></a></div>
			<div style="float:left;"><a href="#" style="text-decoration:none"><img src="img/cerrar.png" width="17" height="17" border="0" /></a></div>
	  </div>
	</div>
  <div class="menu">
	<a href="Portafolio.aspx" target="_self">
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
   <a href="Poliza.aspx" target="_self">
	 <div class="e" style="float:left; padding-bottom:5px; padding-top:7px; padding-left:5px; padding-right:5px;"><span class="texto18e">Polizas</span></div>
	 </a>
			
  </div>
	<div class="portada-imagen">
		<div class="text">			
			<h1 style="margin: 0; margin-left:-135px;">Pólizas</h1>
		</div>
	<img src="img/00_rep_polizas.jpg" width="1307" height="76" />
	</div>
	
	<asp:Panel ID="MainPanel" runat="server" class="contenido-medio">    
	  <div class="titbienvenida">
		<div style="float:left; overflow:hidden;">
			<span class="texto14azul">
				<strong>
					&nbsp;&nbsp;&nbsp<asp:Label ID="lblNombre" runat="server"></asp:Label>
				</strong><br/>
				&nbsp;&nbsp;&nbsp;<asp:Label ID="lblDireccion" runat="server"></asp:Label>
			</span>
		</div>
		<div style="float:right; overflow:hidden; width:262px">
			<span class="texto14azul">
				Código Cavali:<asp:Label ID="lblCavali" runat="server"></asp:Label><br/>
				Representante:<asp:Label ID="lblTrader" runat="server"></asp:Label>
			</span>
		</div>
	  </div>
	  
	  <div class="bienvenida-intern">
		<div style="float:left; overflow:hidden; width:310px">
			<div style="margin-bottom:26px; overflow:hidden">
				<div style="float:left; overflow:hidden; margin-right:50px;">
					<span class="texto18azul">Moneda</span>
				</div>
				<div style="float:left; overflow:hidden; margin-right:15px;">
					<asp:DropDownList ID="MonedaDropDownList" Width="160px" runat="server"></asp:DropDownList>
				</div>
			</div>
			<div style="margin-bottom:26px; overflow:hidden">
				<div style="float:left; overflow:hidden; margin-right:60px;">
					<span class="texto18azul">Desde</span>
				</div>
				<div style="float:left; overflow:hidden; margin-right:15px;">
					<input id="DesdeInput" runat="server" style="height:20px; width:155px" type="text" class="date-picker"/>
				</div>
			</div>
		</div>
		<div style="float:left; overflow:hidden; width:350px">
			<div style="margin-bottom:26px; overflow:hidden">
				<div style="float:left; overflow:hidden; margin-right:90px;">
					<span class="texto18azul">Hasta</span>
				</div>
				<div style="float:left; overflow:hidden; margin-right:15px;">
					<input id="HastaInput" runat="server" style="height:20px; width:155px" type="text"  class="date-picker"/>
				</div>
				<div style="float:left; overflow:hidden; margin-left:185px; margin-top:15px;">
					<asp:ImageButton ImageUrl="../img/visualizar.jpg" ID="VisualizarImageButton" 
						Width="100" Height="30" runat="server" onclick="VisualizarImageButton_Click" />
				</div>
			</div>
		</div>
	  </div>
	  <asp:Panel id="CuentaCorrientePanel" runat="server" Visible="false" class="contenedor-reportes">
		<div style="overflow:hidden; margin-top:15px;text-align:left;">
			<span class="texto13azul" style="padding-right:10px;">imprimir</span>
			<img src="img/imp.gif" width="21" height="18" />
		</div>
		<div style="overflow:hidden; margin-top:10px;">
			Soles
            <table>
                <thead>
                    <tr>
                        <td>Fecha Operacion</td>
                        <td>Fecha Liquidacion</td>
                        <td>Poliza</td>
                        <td>Descripcion</td>
                        <td>Cargo</td>
                        <td>Abono</td>
                        <td>Saldo</td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td><asp:Label runat="server" ID="DescripcionSolesLabel"></asp:Label></td>
                        <td></td>
                        <td></td>
                        <td><asp:Label runat="server" ID="SaldoSolesLabel"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
            Operaciones vencidas
			<asp:GridView ID="CuentaCorrienteVSolesGridView" runat="server" 
				AutoGenerateColumns="False" BackColor="White" ShowHeader="False" >
				<EmptyDataTemplate>
					<div>
						No hay registros que mostrar
					</div>
				</EmptyDataTemplate>
				<headerstyle CssClass="texto13blanco grilla-header-datos"></headerstyle>
				<alternatingrowstyle backcolor="White"></alternatingrowstyle>
				<RowStyle backcolor="#d2d9df" />
				<Columns>
					<asp:BoundField ItemStyle-Width="72" 
						DataField="FechaOperacion" >
					</asp:BoundField>
					<asp:BoundField ItemStyle-Width="103" 
						DataField="FechaValor" >
					</asp:BoundField>
					<asp:BoundField ItemStyle-Width="104" DataField="DocumentoPagoNumero" >
					</asp:BoundField>
					<asp:BoundField ItemStyle-Width="81" 
						DataField="Observacion" >
					</asp:BoundField>
					<asp:BoundField DataField="Egresos" />
                    <asp:BoundField ItemStyle-Width="111" 
						DataField="Ingresos" >
					</asp:BoundField>
					<asp:BoundField DataField="Saldo" />
				</Columns>
			</asp:GridView>
            Operaciones por vencer
			<asp:GridView ID="CuentaCorrientePVSolesGridView" runat="server" 
				AutoGenerateColumns="False" BackColor="White" ShowHeader="False" >
				<EmptyDataTemplate>
					<div>
						No hay registros que mostrar
					</div>
				</EmptyDataTemplate>
				<headerstyle CssClass="texto13blanco grilla-header-datos"></headerstyle>
				<alternatingrowstyle backcolor="White"></alternatingrowstyle>
				<RowStyle backcolor="#d2d9df" />
				<Columns>
					<asp:BoundField ItemStyle-Width="72" 
						DataField="FechaOperacion" >
					</asp:BoundField>
					<asp:BoundField ItemStyle-Width="103" 
						DataField="FechaValor" >
					</asp:BoundField>
					<asp:BoundField ItemStyle-Width="104" DataField="DocumentoPagoNumero" >
					</asp:BoundField>
					<asp:BoundField ItemStyle-Width="81" 
						DataField="Observacion" >
					</asp:BoundField>
					<asp:BoundField DataField="Egresos" />
                    <asp:BoundField ItemStyle-Width="111" 
						DataField="Ingresos" >
					</asp:BoundField>
					<asp:BoundField DataField="Saldo" />
				</Columns>
			</asp:GridView>
			<br/><br/>
			Dolares
            <table>
                <thead>
                    <tr>
                        <td>Fecha Operacion</td>
                        <td>Fecha Liquidacion</td>
                        <td>Poliza</td>
                        <td>Descripcion</td>
                        <td>Cargo</td>
                        <td>Abono</td>
                        <td>Saldo</td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td><asp:Label runat="server" ID="DescripcionDolaresLabel"></asp:Label></td>
                        <td></td>
                        <td></td>
                        <td><asp:Label runat="server" ID="SaldoDolaresLabel"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
            Operaciones vencidas
			<asp:GridView ID="CuentaCorrienteVDolaresGridView" runat="server" 
				AutoGenerateColumns="False" BackColor="White" ShowHeader="False" >
				<EmptyDataTemplate>
					<div>
						No hay registros que mostrar
					</div>
				</EmptyDataTemplate>
				<headerstyle CssClass="texto13blanco grilla-header-datos"></headerstyle>
				<alternatingrowstyle backcolor="White"></alternatingrowstyle>
				<RowStyle backcolor="#d2d9df" />
				<Columns>
					<asp:BoundField ItemStyle-Width="72" 
						DataField="FechaOperacion" >
					</asp:BoundField>
					<asp:BoundField ItemStyle-Width="103" 
						DataField="FechaValor" >
					</asp:BoundField>
					<asp:BoundField ItemStyle-Width="104" DataField="DocumentoPagoNumero" >
					</asp:BoundField>
					<asp:BoundField ItemStyle-Width="81" 
						DataField="Observacion" >
					</asp:BoundField>
					<asp:BoundField DataField="Egresos" />
                    <asp:BoundField ItemStyle-Width="111" 
						DataField="Ingresos" >
					</asp:BoundField>
					<asp:BoundField DataField="Saldo" />
				</Columns>
			</asp:GridView>
            Operaciones por vencer
			<asp:GridView ID="CuentaCorrientePVDolaresGridView" runat="server" 
				AutoGenerateColumns="False" BackColor="White" ShowHeader="False" >
				<EmptyDataTemplate>
					<div>
						No hay registros que mostrar
					</div>
				</EmptyDataTemplate>
				<headerstyle CssClass="texto13blanco grilla-header-datos"></headerstyle>
				<alternatingrowstyle backcolor="White"></alternatingrowstyle>
				<RowStyle backcolor="#d2d9df" />
				<Columns>
					<asp:BoundField ItemStyle-Width="72" 
						DataField="FechaOperacion" >
					</asp:BoundField>
					<asp:BoundField ItemStyle-Width="103" 
						DataField="FechaValor" >
					</asp:BoundField>
					<asp:BoundField ItemStyle-Width="104" DataField="DocumentoPagoNumero" >
					</asp:BoundField>
					<asp:BoundField ItemStyle-Width="81" 
						DataField="Observacion" >
					</asp:BoundField>
					<asp:BoundField DataField="Egresos" />
                    <asp:BoundField ItemStyle-Width="111" 
						DataField="Ingresos" >
					</asp:BoundField>
					<asp:BoundField DataField="Saldo" />
				</Columns>
			</asp:GridView>
		</div>
		<div class="descrip2"></div>
	  </asp:Panel>
	</asp:Panel>

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