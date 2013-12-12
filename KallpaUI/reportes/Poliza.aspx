<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Poliza.aspx.cs" Inherits="KallpaUI.reportes.Poliza" %>

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

   <a href="Ordenes.aspx" target="_self"> 
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
				<div style="float:left; overflow:hidden; margin-right:65px;">
					<span class="texto18azul">Valor</span>
				</div>
				<div style="float:left; overflow:hidden; margin-right:15px;">
					<asp:DropDownList ID="ValorDropDownList"  Width="160px" runat="server"></asp:DropDownList>
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
				<div style="float:left; overflow:hidden; margin-right:20px;">
					<span class="texto18azul">Tipo de operación</span>
				</div>
				<div style="float:left; overflow:hidden; margin-right:15px;">
					<asp:DropDownList ID="TipoOperacionDropDownList" Width="160px" runat="server"></asp:DropDownList>
				</div>
			</div>
			<div style="margin-bottom:26px; overflow:hidden">
				<div style="float:left; overflow:hidden; margin-right:43px;">
					<span class="texto18azul">Tipo de póliza</span>
				</div>
				<div style="float:left; overflow:hidden; margin-right:15px;">
					<asp:DropDownList ID="TipoPolizaDropDownList" Width="160px" runat="server"></asp:DropDownList>
				</div>
			</div>
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
	  <asp:Panel id="PolizaPanel" runat="server" Visible="false" class="contenedor-reportes">
		<div style="overflow:hidden; margin-top:15px;text-align:left;">
			<span class="texto13azul" style="padding-right:10px;">imprimir</span>
			<img src="img/imp.gif" width="21" height="18" />
		</div>
		<div style="overflow:hidden; margin-top:10px;">
			Soles
			<asp:GridView ID="PolizaSolesGridView" runat="server" 
				AutoGenerateColumns="False" BackColor="White" 
				onrowcommand="PolizaSolesGridView_RowCommand" >
				<EmptyDataTemplate>
					<div>
						No hay registros que mostrar
					</div>
				</EmptyDataTemplate>
				<headerstyle CssClass="texto13blanco grilla-header-datos"></headerstyle>
				<alternatingrowstyle backcolor="White"></alternatingrowstyle>
				<RowStyle backcolor="#d2d9df" />
				<Columns>
					<asp:BoundField ItemStyle-Width="72" HeaderText="Fecha" 
						DataField="FechaPoliza" >
					<ItemStyle Width="72px" />
					</asp:BoundField>
					<asp:BoundField ItemStyle-Width="103" HeaderText="N° Poliza" 
						DataField="NumeroPoliza" >
					<ItemStyle Width="103px" />
					</asp:BoundField>
					<asp:BoundField ItemStyle-Width="104" HeaderText="Valor" DataField="Valor" >
					<ItemStyle Width="104px" />
					</asp:BoundField>
					<asp:BoundField ItemStyle-Width="81" HeaderText="Cantidad Acciones" 
						DataField="CantidadAcciones" >
					<ItemStyle Width="81px" />
					</asp:BoundField>
					<asp:BoundField ItemStyle-Width="111" HeaderText="Monto Neto" 
						DataField="MontoNeto" >
					<ItemStyle Width="111px" />
					</asp:BoundField>
					<asp:TemplateField>
						<ItemTemplate>
							<asp:HiddenField runat="server" ID="sqlHiddenField" Value='<%# Bind("Sql") %>'></asp:HiddenField>
							<asp:LinkButton ID="VerPolizaSolesLinkButton" runat="server" CommandName="Detalle" CommandArgument='<%# Bind("IdPoliza") %>'>Ver poliza ></asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
			</asp:GridView>
			<br/><br/>
			Dolares
			<asp:GridView ID="PolizaDolaresGridView" runat="server" AutoGenerateColumns="false" BackColor="#FFFFFF" onrowcommand="PolizaSolesGridView_RowCommand" >
				<EmptyDataTemplate>
					<div>
						No hay registros que mostrar
					</div>
				</EmptyDataTemplate>
				<headerstyle backcolor="#758a9d" HorizontalAlign="Center" CssClass="texto13blanco"></headerstyle>
				<alternatingrowstyle backcolor="White"></alternatingrowstyle>
				<RowStyle backcolor="#d2d9df" />
				<Columns>
					<asp:BoundField ItemStyle-Width="72" HeaderText="Fecha" DataField="FechaPoliza" />
					<asp:BoundField ItemStyle-Width="103" HeaderText="N° Poliza" DataField="NumeroPoliza" />
					<asp:BoundField ItemStyle-Width="104" HeaderText="Valor" DataField="Valor" />
					<asp:BoundField ItemStyle-Width="81" HeaderText="Cantidad Acciones" DataField="CantidadAcciones" />
					<asp:BoundField ItemStyle-Width="111" HeaderText="Monto Neto" DataField="MontoNeto" />
					<asp:TemplateField>
						<ItemTemplate>
						    <asp:HiddenField runat="server" ID="sqlHiddenField" Value='<%# Bind("Sql") %>'></asp:HiddenField>
							<asp:LinkButton ID="VerPolizaDolaresLinkButton" runat="server" CommandName="Detalle" CommandArgument='<%# Bind("IdPoliza") %>'>Ver poliza ></asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
			</asp:GridView>
		</div>
		<div class="descrip2"></div>
	  </asp:Panel>
	</asp:Panel>
	<asp:Panel ID="DetallePolizaPanel" runat="server" class="contenedor-reportes" Visible="false">
		<div style="overflow:hidden">
			<div style=" float:left; overflow:hidden; width:100px; margin-top:20px;">
				<span class="texto14azul">
					<strong>>&nbsp;Poliza nacional</strong>
				</span>
			</div>
			<div style=" float:left; overflow:hidden; width:100px; margin-top:20px; margin-left:690px;">
				<span class="texto14plomo">
					<strong>
						<asp:LinkButton ID="RegresarLinkButton" runat="server" 
					onclick="RegresarLinkButton_Click">>&nbsp;Regresar</asp:LinkButton>
					</strong>
				</span>
			</div>
		</div>
		<div class="bienvenida-intern2">
			<div class="cont-poliza">
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td>
							<table width="100%" border="0" cellspacing="0" cellpadding="0">
								<tr>
									<td width="290"><img src="img/logo.jpg" width="290" height="60" /></td>
									<td width="105">&nbsp;</td>
									<td>
										<table width="100%" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td align="right">RUC:20492942121</td>
											</tr>
											<tr>
												<td align="right">
													Av. la Encalada 1388 Of. 802. Santiago de Surco<br />
													Central Telefónica: (01) 630-7500
												</td>
											</tr>
											<tr>
												<td align="right">
													<strong>www.kallpasab.com</strong>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td align="left">
							<span class="texto18az">
								<strong>&nbsp;&nbsp;PÓLIZA NACIONAL</strong>
							</span>
						</td>
					</tr>
					<tr>
						<td>
							<table width="100%" border="0" cellspacing="0" cellpadding="0">
								<tr>
									<td height="10"></td>
									<td></td>
									<td></td>
									<td></td>
								</tr>
								<tr>
									<td>&nbsp;</td>
									<td width="50">
										<table width="50" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td>Póliza #</td>
											</tr>
											<tr>
												<td>Fecha</td>
											</tr>
										</table>
									</td>
									<td width="30">&nbsp;</td>
									<td width="70">
										<table width="70" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td align="right"><asp:Label runat="server" ID="NumeroPolizaLabel"></asp:Label></td>
											</tr>
											<tr>
												<td align="right"><asp:Label runat="server" ID="FechaLabel"></asp:Label></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td>
							<table width="100%" border="0" cellspacing="0" cellpadding="0">
								<tr>
									<td>Señor(es): <asp:Label runat="server" ID="NombreLabel"></asp:Label></td>
								</tr>
								<tr>
									<td height="10"></td>
								</tr>
								<tr>
									<td>Dirección: <asp:Label runat="server" ID="DireccionLabel"></asp:Label></td>
								</tr>
								<tr>
									<td height="10"></td>
								</tr>
								<tr>
									<td>Documento de identidad: <asp:Label runat="server" ID="DNILabel"></asp:Label></td>
								</tr>
								<tr>
									<td height="10"></td>
								</tr>
								<tr>
									<td>Código CAVALI:  <asp:Label runat="server" ID="CavaliLabel"></asp:Label></td>
								</tr>
								<tr>
									<td height="5"></td>
								</tr>
								<tr>
									<td>Cumpliendo con sus intrucciones en  Report del dia de hoy, hemos ejecutado su orden de COMPRA de los siguientes valores:</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td height="20"></td>
					</tr>
					<tr>
						<td>
							<table width="597" border="0" cellspacing="0" cellpadding="0">
								<tr>
									<td>
										<table width="597" border="0">
											<tr>
												<td width="127" align="center" bgcolor="#758a9c">
													<strong>VALOR</strong>
												</td>
												<td width="127" align="center" bgcolor="#758a9c" >
													<strong>CANTIDAD</strong>
												</td>
												<td width="127" align="center" bgcolor="#758a9c">
													<strong>PRECIO (S/.)</strong>
												</td>
												<td width="160" align="center" bgcolor="#758a9c">
													<strong>IMPORTE (S/.)</strong>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td valign="top">
										<table width="597" border="0" cellspacing="2" cellpadding="0">
											<tr>
												<td width="127" align="center" bgcolor="#d2d9df">
												    <asp:Label runat="server" ID="ValorLabel"></asp:Label>
												</td>
												<td width="127" align="center" bgcolor="#d2d9df">
												    <asp:Label runat="server" ID="CantidadLabel"></asp:Label>
												</td>
												<td width="127" align="center" bgcolor="#d2d9df">
												    <asp:Label runat="server" ID="PrecioLabel"></asp:Label>
												</td>
												<td width="160" align="center" bgcolor="#d2d9df">
												    <asp:Label runat="server" ID="ImporteLabel"></asp:Label>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td>
										<table width="450" border="0" align="right" cellpadding="0" cellspacing="2">
											<tr>
												<td width="195" align="right">
													<strong>(S/.)</strong>
												</td>
												<td width="160">
													<table width="177" border="0" align="right" cellpadding="0" cellspacing="0" >
														<tr>
															<td align="center">
																<strong>
																    <asp:Label runat="server" ID="ImporteTotalLabel"></asp:Label>
																</strong>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td>...............................................................................................................................................................................</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td height="95">&nbsp;</td>
					</tr>
					<tr>
						<td>
							<table width="597" border="0" cellspacing="0" cellpadding="0">
								<tr>
									<td valign="top">
										<table width="200" border="0" align="left" cellpadding="0" cellspacing="0">
											<tr>
												<td>
													<strong>Fecha de Liquidación:</strong> <asp:Label runat="server" ID="FechaLiquidacionLabel"></asp:Label>
												</td>
											</tr>
										</table>
									</td>
									<td width="296">
										<table width="296" border="0" cellspacing="0" cellpadding="0" style="border:solid 1px #000000">
											<tr>
												<td style="border:solid 1px #000000">
													<table width="296" border="0" cellspacing="0" cellpadding="0">
														<tr>
															<td>
																<table width="296" border="0" cellspacing="0" cellpadding="0">
																	<tr>
																		<td>&nbsp;&nbsp;Comisión SAB</td>
																		<td width="90">&nbsp;</td>
																		<td width="40">
																		    <asp:Label runat="server" ID="ComisionSABLabel"></asp:Label>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr>
															<td height="11"></td>
														</tr>
														<tr>
															<td>
																<table width="296" border="0" cellspacing="0" cellpadding="0">
																	<tr>
																		<td>&nbsp;&nbsp;Contribución CONASEV </td>
																		<td width="90">&nbsp;</td>
																		<td width="40">
																		    <asp:Label runat="server" ID="ComisionCONASEVLabel"></asp:Label>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr>
															<td height="11"></td>
														</tr>
														<tr>
															<td>
																<table width="296" border="0" cellspacing="0" cellpadding="0">
																	<tr>
																		<td>&nbsp;&nbsp;Cuota BVL</td>
																		<td width="90">&nbsp;</td>
																		<td width="40">
																		    <asp:Label runat="server" ID="CuotaBVLLabel"></asp:Label>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr>
															<td height="11"></td>
														</tr>
														<tr>
															<td>
																<table width="296" border="0" cellspacing="0" cellpadding="0">
																	<tr>
																		<td>&nbsp;&nbsp;Fondo de Garantía BVL</td>
																		<td width="90">&nbsp;</td>
																		<td width="40">
																		    <asp:Label runat="server" ID="FondoGarantiaBVLLabel"></asp:Label>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr>
															<td height="11"></td>
														</tr>
														<tr>
															<td>
																<table width="296" border="0" cellspacing="0" cellpadding="0">
																	<tr>
																		<td>&nbsp;&nbsp;Retribución CAVALI</td>
																		<td width="90">&nbsp;</td>
																		<td width="40">
																		    <asp:Label runat="server" ID="RedistribucionCAVALILabel"></asp:Label>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr>
															<td height="11"></td>
														</tr>
														<tr>
															<td>
																<table width="296" border="0" cellspacing="0" cellpadding="0">
																	<tr>
																		<td>&nbsp;&nbsp;Fondo de Garantía CAVALI</td>
																		<td width="90">&nbsp;</td>
																		<td width="40">
																		    <asp:Label runat="server" ID="FondoGarantiaCAVALILabel"></asp:Label>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr>
															<td height="11"></td>
														</tr>
														<tr>
															<td>
																<table width="296" border="0" cellspacing="0" cellpadding="0">
																	<tr>
																		<td>&nbsp;&nbsp;IGV</td>
																		<td width="90">&nbsp;</td>
																		<td width="40">
																		    <asp:Label runat="server" ID="IGVLabel"></asp:Label>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
												</td>
											</tr>
											<tr>
												<td height="44" bgcolor="#758a9c" style="border:solid 1px #000000">
													<table width="220" border="0" align="right" cellpadding="0" cellspacing="0">
														<tr>
															<td>
																<span class="texto18negro">TOTAL(S/.)</span>
															</td>
															<td>
																<span class="texto18negro">
																    <asp:Label runat="server" ID="TotalLabel"></asp:Label>
																</span>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td>
							<table width="597" border="0" cellspacing="0" cellpadding="0">
								<tr>
									<td>
										<strong>KALLPA Securities Sociedad Agente de Bolsa</strong> agradece a Ud. haber solicitado nuestros servicios de intermediación
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td>&nbsp;</td>
					</tr>
					<tr>
						<td>&nbsp;</td>
					</tr>
					<tr>
						<td>&nbsp;</td>
					</tr>
				</table>
			</div>
		</div>
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