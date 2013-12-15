using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using KallpaEntities.Reportes;
using KallpaEntities.General;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;
using KallpaDataAccess.Mappers;

namespace KallpaDataAccess
{
	public class ReportesDataAccess
	{
		public IEnumerable<Poliza> ReportePolizasSql(ReportRequest request)
		{
			var polizas = new List<Poliza>();
			const string queryBase = @"SELECT
					 dbo.Cp.MonedaBase
					,SAB.CpPoliza.PKID
					,dbo.Cp.Fecha
					,dbo.Cp.NumCp AS Numero
					,SAB.Valor.Nemonico AS Valor
					,SAB.Transaccion.Detalle AS Transaccion
					,SAB.CpPoliza.CantidadNegociada AS CantidadAcciones
					,dbo.Cp.Total
				FROM dbo.Cp
					INNER JOIN SAB.CpPoliza ON dbo.Cp.PKID = SAB.CpPoliza.PKID
					INNER JOIN dbo.TipoCp ON dbo.Cp.IDTipoCp = dbo.TipoCp.PKID
					INNER JOIN SAB.TipoCpPoliza ON dbo.TipoCp.PKID = SAB.TipoCpPoliza.PKID
					INNER JOIN SAB.Valor ON SAB.CpPoliza.IDValor = SAB.Valor.PKID
					INNER JOIN SAB.Transaccion ON SAB.CpPoliza.IDTransaccion = SAB.Transaccion.PKID
				WHERE	
					SAB.TipoCpPoliza.EsPostDocumento = 0
				AND	dbo.Cp.Anulado = 0";

			var queryBuilder = new StringBuilder(queryBase);

			var parameters = new List<SqlParameter>();

			parameters.Add(new SqlParameter("@IDCliente", request.IdCliente));
			parameters.Add(new SqlParameter("@FechaDesde", request.Rango.Desde));
			parameters.Add(new SqlParameter("@FechaHasta", request.Rango.Hasta));

			queryBuilder.AppendLine("AND	dbo.Cp.IDPersona = @IDCliente");
			queryBuilder.AppendLine("AND	dbo.Cp.Fecha >= @FechaDesde");
			queryBuilder.AppendLine("AND	dbo.Cp.Fecha <= @FechaHasta");
			if (request.TipoOperacion > 0)
			{
				queryBuilder.AppendLine("AND	SAB.CpPoliza.IDTipoOperacion = @TipoOperacion");
				parameters.Add(new SqlParameter("@TipoOperacion", request.TipoOperacion));
			}
			if (request.Moneda > 0)
			{
				queryBuilder.AppendLine("AND	dbo.Cp.IDMoneda = @Moneda");
				parameters.Add(new SqlParameter("@Moneda", request.Moneda));
			}
			if (request.Valor > 0)
			{
				queryBuilder.AppendLine("AND	SAB.CpPoliza.IDValor = @Valor");
				parameters.Add(new SqlParameter("@Valor", request.Valor));
			}
			if (request.TipoPoliza > 0)
			{
				queryBuilder.AppendLine("AND	SAB.CpPoliza.IDTransaccion = @Transaccion");
				parameters.Add(new SqlParameter("@Transaccion", request.TipoPoliza));
			}

			using (DataAccessManager.SqlConnection)
			{
				var cmd = DataAccessManager.GetSqlCommand(queryBuilder.ToString(), parameters);
				using (var reader = cmd.ExecuteReader())
				{
					var indexMonedaBase = reader.GetOrdinal("MonedaBase");
					var indexPkid = reader.GetOrdinal("PKID");
					var indexFecha = reader.GetOrdinal("Fecha");
					var indexNumero = reader.GetOrdinal("Numero");
					var indexValor = reader.GetOrdinal("Valor");
					var indexTransaccion = reader.GetOrdinal("Transaccion");
					var indexCantidadAcciones = reader.GetOrdinal("CantidadAcciones");
					var indexTotal = reader.GetOrdinal("Total");

					while (reader.Read())
					{
						var poliza = new Poliza
						{
							IdPoliza = reader.GetInt32(indexPkid),
							MonedaBase = reader.GetBoolean(indexMonedaBase),
							FechaPoliza = reader.GetDateTime(indexFecha),
							NumeroPoliza = reader.GetString(indexNumero),
							Valor = reader.GetString(indexValor),
							Transaccion = reader.GetString(indexTransaccion),
							CantidadAcciones = reader.GetInt32(indexCantidadAcciones),
							MontoNeto = reader.GetDecimal(indexTotal),
							Sql = true,
						};
						polizas.Add(poliza);
					}
				}
			}

			return polizas;
		}

		public IEnumerable<Poliza> ReportePolizasOracle(ReportRequest request)
		{
			var polizas = new List<Poliza>();
			const string queryBase = @"SELECT
					 CASE POLIZAS.MONEDA WHEN 'S' THEN 1 ELSE 0 END AS MonedaBase
					,POLIZAS.NUMPOLBVL AS PKID 
					,POLIZAS.FECPOLI AS Fecha
					,CAST(EXTRACT(YEAR FROM POLIZAS.FECPOLI) AS VARCHAR2(4)) || '-' || CAST(POLIZAS.NUMPOLBVL AS VARCHAR2(10)) AS Numero
					,POLIZAS.CODIGO AS Valor
					,CASE POLIZAS.TIPOLI WHEN 'CC' THEN 'Compra' ELSE 'Venta' END AS Transaccion
					,VPOLIZAS.CANTIDAD AS CantidadAcciones
					,POLIZAS.NETO AS Total
				FROM POLIZAS, CLIENTES,VPOLIZAS, BROKERS, TIPOPER
				WHERE
					POLIZAS.ESTADO = 'V'
				AND TIPOPER.tip_oper=POLIZAS.TIPOPER
				AND VPOLIZAS.TIPOPER = POLIZAS.TIPOPER
				AND VPOLIZAS.FECPOLI = POLIZAS.FECPOLI 
				AND VPOLIZAS.NUMPOLI = POLIZAS.NUMPOLI
				AND POLIZAS.codcli = CLIENTES.codcli
				AND CLIENTES.codbroker = BROKERS.codbroker ";

			var queryBuilder = new StringBuilder(queryBase);

			var parameters = new List<OracleParameter>();

			parameters.Add(new OracleParameter("cavali", request.Cavali));
			parameters.Add(new OracleParameter("desde", request.Rango.Desde.ToShortDateString()));
			parameters.Add(new OracleParameter("hasta", request.Rango.Hasta.ToShortDateString()));

			queryBuilder.AppendLine("AND    POLIZAS.CODCAVAL = :cavali");
			queryBuilder.AppendLine("AND   Polizas.FecPoli >= :desde");
			queryBuilder.AppendLine("AND    Polizas.FecPoli <= :hasta");

			if (request.TipoOperacion > 0)
			{
				queryBuilder.AppendLine("AND    POLIZAS.TIPOPER = :tipoOperacion");
				parameters.Add(new OracleParameter("tipoOperacion", CustomMapper.TipoOperacion(request.TipoOperacion)));
			}
			if (request.Moneda > 0)
			{
				queryBuilder.AppendLine("AND    POLIZAS.moneda = :moneda");
				parameters.Add(new OracleParameter("moneda", CustomMapper.Moneda(request.Moneda)));
			}
			if (request.Valor > 0)
			{
				queryBuilder.AppendLine("AND     POLIZAS.CODIGO = :valor");
				parameters.Add(new OracleParameter("valor", CustomMapper.Valor(request.Valor)));
			}
			if (request.TipoPoliza > 0)
			{
				queryBuilder.AppendLine("AND      POLIZAS.tipoli like :tipoPoliza");
				parameters.Add(new OracleParameter("valor", CustomMapper.TipoPoliza(request.TipoPoliza)));
			}

			using (DataAccessManager.OracleConnection)
			{
				var cmd = DataAccessManager.GetOracleCommand(queryBuilder.ToString(), parameters);
				using (var reader = cmd.ExecuteReader())
				{
					var indexMonedaBase = reader.GetOrdinal("MonedaBase");
					var indexPkid = reader.GetOrdinal("PKID");
					var indexFecha = reader.GetOrdinal("Fecha");
					var indexNumero = reader.GetOrdinal("Numero");
					var indexValor = reader.GetOrdinal("Valor");
					var indexTransaccion = reader.GetOrdinal("Transaccion");
					var indexCantidadAcciones = reader.GetOrdinal("CantidadAcciones");
					var indexTotal = reader.GetOrdinal("Total");

					while (reader.Read())
					{
						var poliza = new Poliza
						{
							IdPoliza = reader.GetInt32(indexPkid),
							MonedaBase = reader.GetDecimal(indexMonedaBase) == 1M,
							FechaPoliza = reader.GetDateTime(indexFecha),
							NumeroPoliza = reader.GetString(indexNumero),
							Valor = reader.GetString(indexValor),
							Transaccion = reader.GetString(indexTransaccion),
							CantidadAcciones = Convert.ToInt32(reader.GetDecimal(indexCantidadAcciones)),
							MontoNeto = reader.GetDecimal(indexTotal),
							Sql = false
						};
						polizas.Add(poliza);
					}
				}
			}

			return polizas;
		}

		public DetallePoliza ReporteDetallePolizaSql(int idPoliza)
		{
			using (DataAccessManager.SqlConnection)
			{
				const string query = @"
					SELECT	
						 dbo.Cp.Fecha
						,dbo.Cp.NumCp
						,dbo.Persona.Nombre
						,dbo.Direccion.Descripcion AS Direccion
						,dbo.TipoDocIdentidad.Descripcion + ' ' + dbo.Persona.DocIdentidad AS DocumentoIdentidad
						,SAB.Cliente.CodigoCavali AS Cavali
						,SAB.Pais.Descripcion AS PaisNacionalidad
						,dbo.Moneda.Descripcion AS Moneda
						,upper(SAB.TipoOperacion.Descripcion) AS TipoOperacion
						,upper(SAB.Transaccion.Detalle) AS Transaccion
						,SAB.Valor.Nemonico AS Valor
						,dbo.ItemCp.Cantidad
						,dbo.ItemCp.ValorUnitario AS Precio
						,dbo.ItemCp.Total AS Importe
						,SAB.CpPoliza.FechaLiquidacion
						,SAB.CpPoliza.ComisionSAB
						,SAB.CpPoliza.ComisionCONASEV
						,SAB.CpPoliza.ComisionBVL
						,SAB.CpPoliza.ComisionFONDOBVL
						,SAB.CpPoliza.ComisionCAVALI
						,SAB.CpPoliza.ComisionFONDOCAVALI
						,SAB.CpPoliza.ComisionINTERNACIONAL
						,SAB.CpPoliza.IGV_CONASEV
							+ SAB.CpPoliza.IGV_FONDOBVL
							+ SAB.CpPoliza.IGV_FONDOCAVALI
							+ SAB.CpPoliza.IGV_CAVALI
							+ SAB.CpPoliza.IGV_SAB
							+ SAB.CpPoliza.IGV_BVL AS IGV
						,dbo.Cp.Total
						,SAB.CpPoliza.IDTipoOperacion
						,dbo.Cp.IDMoneda
						,SAB.CpPoliza.IDValor
						,SAB.CpPoliza.IDTransaccion
					FROM dbo.Cp
						INNER JOIN SAB.CpPoliza ON dbo.Cp.PKID = SAB.CpPoliza.PKID
						INNER JOIN dbo.Persona ON dbo.Cp.IDPersona = dbo.Persona.PKID
						INNER JOIN SAB.Cliente ON dbo.Persona.PKID = SAB.Cliente.PKID
						INNER JOIN dbo.TipoCp ON dbo.Cp.IDTipoCp = dbo.TipoCp.PKID
						INNER JOIN SAB.TipoCpPoliza ON dbo.TipoCp.PKID = SAB.TipoCpPoliza.PKID
						INNER JOIN dbo.Direccion ON SAB.Cliente.IDDireccionResidencia = dbo.Direccion.PKID
						INNER JOIN dbo.TipoDocIdentidad ON dbo.Persona.IDTipoDocIdentidad = dbo.TipoDocIdentidad.PKID
						INNER JOIN SAB.Pais ON SAB.Cliente.IDPaisNacionalidad = SAB.Pais.PKID
						INNER JOIN dbo.Moneda ON dbo.Cp.IDMoneda = dbo.Moneda.PKID
						INNER JOIN SAB.TipoOperacion ON SAB.CpPoliza.IDTipoOperacion = SAB.TipoOperacion.PKID
						INNER JOIN SAB.Transaccion ON SAB.CpPoliza.IDTransaccion = SAB.Transaccion.PKID
						INNER JOIN dbo.ItemCp ON dbo.Cp.PKID = dbo.ItemCp.IDCp
						INNER JOIN SAB.ItemPoliza ON dbo.ItemCp.PKID = SAB.ItemPoliza.PKID
						INNER JOIN SAB.Valor ON SAB.CpPoliza.IDValor = SAB.Valor.PKID
					WHERE
						dbo.Cp.PKID = @IdPoliza";
				using (var cmd = DataAccessManager.GetSqlCommand(query))
				{
					cmd.Parameters.Add(new SqlParameter("@IdPoliza", idPoliza));
					using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
					{
						var indexFecha = reader.GetOrdinal("Fecha");
						var indexNumeroPoliza = reader.GetOrdinal("NumCp");
						var indexNombre = reader.GetOrdinal("Nombre");
						var indexDireccion = reader.GetOrdinal("Direccion");
						var indexDocumentoIdentidad = reader.GetOrdinal("DocumentoIdentidad");
						var indexCavali = reader.GetOrdinal("Cavali");
						var indexPaisNacionalidad = reader.GetOrdinal("PaisNacionalidad");
						var indexMoneda = reader.GetOrdinal("Moneda");
						var indexTipoOperacion = reader.GetOrdinal("TipoOperacion");
						var indexTransaccion = reader.GetOrdinal("Transaccion");
						var indexValor = reader.GetOrdinal("Valor");
						var indexCantidad = reader.GetOrdinal("Cantidad");
						var indexPrecio = reader.GetOrdinal("Precio");
						var indexImporte = reader.GetOrdinal("Importe");
						var indexFechaLiquidacion = reader.GetOrdinal("FechaLiquidacion");
						var indexComisionSab = reader.GetOrdinal("ComisionSAB");
						var indexComisionConasev = reader.GetOrdinal("ComisionCONASEV");
						var indexComisionBvl = reader.GetOrdinal("ComisionBVL");
						var indexComisionFondoBvl = reader.GetOrdinal("ComisionFONDOBVL");
						var indexComisionCavali = reader.GetOrdinal("ComisionCAVALI");
						var indexComisionFondoCavali = reader.GetOrdinal("ComisionFONDOCAVALI");
						var indexComisionInternacional = reader.GetOrdinal("ComisionINTERNACIONAL");
						var indexIgv = reader.GetOrdinal("IGV");
						var indexTotal = reader.GetOrdinal("Total");
						while (reader.Read())
						{
							return new DetallePoliza
								{
									Fecha = reader.GetDateTime(indexFecha),
									NumeroPoliza = reader.GetString(indexNumeroPoliza),
									Nombre = reader.GetString(indexNombre),
									Direccion = reader.GetString(indexDireccion),
									DocumentoIdentidad = reader.GetString(indexDocumentoIdentidad),
									Cavali = reader.GetString(indexCavali),
									PaisNacionalidad = reader.GetString(indexPaisNacionalidad),
									Moneda = reader.GetString(indexMoneda),
									TipoOperacion = reader.GetString(indexTipoOperacion),
									Transaccion = reader.GetString(indexTransaccion),
									Valor = reader.GetString(indexValor),
									Cantidad = reader.GetInt32(indexCantidad),
									Precio = reader.GetDecimal(indexPrecio),
									Importe = reader.GetDecimal(indexImporte),
									FechaLiquidacion = reader.GetDateTime(indexFechaLiquidacion),
									ComisionSAB = reader.GetDecimal(indexComisionSab),
									ComisionCONASEV = reader.GetDecimal(indexComisionConasev),
									ComisionBVL = reader.GetDecimal(indexComisionBvl),
									ComisionFondoBVL = reader.GetDecimal(indexComisionFondoBvl),
									ComisionCAVALI = reader.GetDecimal(indexComisionCavali),
									ComisionFondoCAVALI = reader.GetDecimal(indexComisionFondoCavali),
									ComisionInternacional = reader.GetDecimal(indexComisionInternacional),
									IGV = reader.GetDecimal(indexIgv),
									Total = reader.GetDecimal(indexTotal)
								};
						}
						return null;
					}
				}
			}
		}

		public DetallePoliza ReporteDetallePolizaOracle(int idPoliza)
		{
			using (DataAccessManager.OracleConnection)
			{
				const string query = @"";
				using (var cmd = DataAccessManager.GetOracleCommand(query))
				{
					cmd.Parameters.Add(new OracleParameter("IdPoliza", idPoliza));
					using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
					{
						var indexFecha = reader.GetOrdinal("Fecha");
						var indexNumeroPoliza = reader.GetOrdinal("NumCp");
						var indexNombre = reader.GetOrdinal("Nombre");
						var indexDireccion = reader.GetOrdinal("Direccion");
						var indexDocumentoIdentidad = reader.GetOrdinal("DocumentoIdentidad");
						var indexCavali = reader.GetOrdinal("Cavali");
						var indexPaisNacionalidad = reader.GetOrdinal("PaisNacionalidad");
						var indexMoneda = reader.GetOrdinal("Moneda");
						var indexTipoOperacion = reader.GetOrdinal("TipoOperacion");
						var indexTransaccion = reader.GetOrdinal("Transaccion");
						var indexValor = reader.GetOrdinal("Valor");
						var indexCantidad = reader.GetOrdinal("Cantidad");
						var indexPrecio = reader.GetOrdinal("Precio");
						var indexImporte = reader.GetOrdinal("Importe");
						var indexFechaLiquidacion = reader.GetOrdinal("FechaLiquidacion");
						var indexComisionSab = reader.GetOrdinal("ComisionSAB");
						var indexComisionConasev = reader.GetOrdinal("ComisionCONASEV");
						var indexComisionBvl = reader.GetOrdinal("ComisionBVL");
						var indexComisionFondoBvl = reader.GetOrdinal("ComisionFONDOBVL");
						var indexComisionCavali = reader.GetOrdinal("ComisionCAVALI");
						var indexComisionFondoCavali = reader.GetOrdinal("ComisionFONDOCAVALI");
						var indexComisionInternacional = reader.GetOrdinal("ComisionINTERNACIONAL");
						var indexIgv = reader.GetOrdinal("IGV");
						var indexTotal = reader.GetOrdinal("Total");
						while (reader.Read())
						{
							return new DetallePoliza
							{
								Fecha = reader.GetDateTime(indexFecha),
								NumeroPoliza = reader.GetString(indexNumeroPoliza),
								Nombre = reader.GetString(indexNombre),
								Direccion = reader.GetString(indexDireccion),
								DocumentoIdentidad = reader.GetString(indexDocumentoIdentidad),
								Cavali = reader.GetString(indexCavali),
								PaisNacionalidad = reader.GetString(indexPaisNacionalidad),
								Moneda = reader.GetString(indexMoneda),
								TipoOperacion = reader.GetString(indexTipoOperacion),
								Transaccion = reader.GetString(indexTransaccion),
								Valor = reader.GetString(indexValor),
								Cantidad = reader.GetInt32(indexCantidad),
								Precio = reader.GetDecimal(indexPrecio),
								Importe = reader.GetDecimal(indexImporte),
								FechaLiquidacion = reader.GetDateTime(indexFechaLiquidacion),
								ComisionSAB = reader.GetDecimal(indexComisionSab),
								ComisionCONASEV = reader.GetDecimal(indexComisionConasev),
								ComisionBVL = reader.GetDecimal(indexComisionBvl),
								ComisionFondoBVL = reader.GetDecimal(indexComisionFondoBvl),
								ComisionCAVALI = reader.GetDecimal(indexComisionCavali),
								ComisionFondoCAVALI = reader.GetDecimal(indexComisionFondoCavali),
								ComisionInternacional = reader.GetDecimal(indexComisionInternacional),
								IGV = reader.GetDecimal(indexIgv),
								Total = reader.GetDecimal(indexTotal)
							};
						}
						return null;
					}
				}
			}
		}

		public IEnumerable<CuentaCorriente> ReportCuentaCorrienteSql(ReportRequest request)
		{
			using (DataAccessManager.SqlConnection)
			{
				var cuentasCorrientes = new List<CuentaCorriente>();

				const string query = @"
					SELECT
						IDPersona
						,Fecha
						,FechaOperacion
						,FechaValor
						,Movimiento
						,Ingresos
						,Egresos
						,CodigoCliente
						,Cliente
						,CodigoCavali
						,IDMoneda
						,DocumentoPagoNumero
						,Operacion
						,Transaccion
						,Observacion
						,IDCp
						,Direccion
						,Ubigeo
						,TipoOperacion
						,SaldoInicial
						,TipoInformacion
						,DocumentoIdentidad
						,TraderAsignado
					FROM dbo.fnt_rptSAB_EstadoCuentaCorrienteTotal(@desde, @hasta, @idCliente)";

				var parameters = new List<SqlParameter>
					{
						new SqlParameter("@desde", request.Rango.Desde.ToShortDateString()),
						new SqlParameter("@hasta", request.Rango.Hasta.ToShortDateString()),
						new SqlParameter("@idCliente", request.IdCliente)
					};

				var queryBuilder = new StringBuilder(query);

				if (request.Moneda > 0)
				{
					queryBuilder.AppendLine("WHERE IDMoneda = @idMoneda");
					parameters.Add(new SqlParameter("@idMoneda", request.Moneda));
				}

				var cmd = DataAccessManager.GetSqlCommand(queryBuilder.ToString(), parameters);

				using (var reader = cmd.ExecuteReader())
				{
					var indexFecha = reader.GetOrdinal("Fecha");
					var indexFechaOperacion = reader.GetOrdinal("FechaOperacion");
					var indexFechaValor = reader.GetOrdinal("FechaValor");
					var indexMovimiento = reader.GetOrdinal("Movimiento");
					var indexIngresos = reader.GetOrdinal("Ingresos");
					var indexEgresos = reader.GetOrdinal("Egresos");
					var indexCodigoCliente = reader.GetOrdinal("CodigoCliente");
					var indexCliente = reader.GetOrdinal("Cliente");
					var indexCodigoCavali = reader.GetOrdinal("CodigoCavali");
					var indexIdMoneda = reader.GetOrdinal("IDMoneda");
					var indexDocumentoPagoNumero = reader.GetOrdinal("DocumentoPagoNumero");
					var indexOperacion = reader.GetOrdinal("Operacion");
					var indexTransaccion = reader.GetOrdinal("Transaccion");
					var indexObservacion = reader.GetOrdinal("Observacion");
					var indexIdCp = reader.GetOrdinal("IDCp");
					var indexDireccion = reader.GetOrdinal("Direccion");
					var indexUbigeo = reader.GetOrdinal("Ubigeo");
					var indexTipoOperacion = reader.GetOrdinal("TipoOperacion");
					var indexSaldoInicial = reader.GetOrdinal("SaldoInicial");
					var indexTipoInformacion = reader.GetOrdinal("TipoInformacion");
					var indexDocumentoIdentidad = reader.GetOrdinal("DocumentoIdentidad");
					var indexTraderAsignado = reader.GetOrdinal("TraderAsignado");
					while (reader.Read())
					{
						var cuentaCorriente = new CuentaCorriente
							{
								Fecha = reader.GetDateTime(indexFecha),
								FechaOperacion = reader.GetDateTime(indexFechaOperacion),
								FechaValor = reader.GetDateTime(indexFechaValor),
								Movimiento = reader.GetString(indexMovimiento),
								Ingresos = reader.GetDecimal(indexIngresos),
								Egresos = reader.GetDecimal(indexEgresos),
								Saldo = reader.GetDecimal(indexIngresos) - reader.GetDecimal(indexEgresos),
								CodigoCliente = reader.GetString(indexCodigoCliente),
								Cliente = reader.GetString(indexCliente),
								CodigoCavali = reader.GetString(indexCodigoCavali),
								IdMoneda = reader.GetInt32(indexIdMoneda),
								DocumentoPagoNumero = reader.GetString(indexDocumentoPagoNumero),
								Operacion = reader.GetString(indexOperacion),
								Transaccion = reader.GetString(indexTransaccion),
								Observacion = reader.GetString(indexObservacion),
								IdCp = reader.GetInt32(indexIdCp),
								Direccion = reader.GetString(indexDireccion),
								Ubigeo = reader.GetString(indexUbigeo),
								TipoOperacion = reader.GetString(indexTipoOperacion),
								SaldoInicial = reader.GetDecimal(indexSaldoInicial),
								TipoInformacion = reader.GetString(indexTipoInformacion),
								DocumentoIdentidad = reader.GetString(indexDocumentoIdentidad),
								TraderAsignado = reader.GetString(indexTraderAsignado)
							};
						cuentasCorrientes.Add(cuentaCorriente);
					}
				}

				return cuentasCorrientes;
			}
		}

		public IEnumerable<CuentaCorriente> ReportCuentaCorrienteOracle(ReportRequest request)
		{
			using (DataAccessManager.OracleConnection)
			{
				var cuentasCorrientes = new List<CuentaCorriente>();

				const string query = @"";

				var cmd = DataAccessManager.GetOracleCommand(query);

				cmd.Parameters.Add(new OracleParameter("@desde", request.Rango.Desde));
				cmd.Parameters.Add(new OracleParameter("@hasta", request.Rango.Hasta));
				cmd.Parameters.Add(new OracleParameter("@idCliente", request.IdCliente));

				using (var reader = cmd.ExecuteReader())
				{
					var indexFecha = reader.GetOrdinal("Fecha");
					var indexFechaOperacion = reader.GetOrdinal("FechaOperacion");
					var indexFechaValor = reader.GetOrdinal("FechaValor");
					var indexMovimiento = reader.GetOrdinal("Movimiento");
					var indexIngresos = reader.GetOrdinal("Ingresos");
					var indexEgresos = reader.GetOrdinal("Egresos");
					var indexCodigoCliente = reader.GetOrdinal("CodigoCliente");
					var indexCliente = reader.GetOrdinal("Cliente");
					var indexCodigoCavali = reader.GetOrdinal("CodigoCavali");
					var indexIdMoneda = reader.GetOrdinal("IDMoneda");
					var indexDocumentoPagoNumero = reader.GetOrdinal("DocumentoPagoNumero");
					var indexOperacion = reader.GetOrdinal("Operacion");
					var indexTransaccion = reader.GetOrdinal("Transaccion");
					var indexObservacion = reader.GetOrdinal("Observacion");
					var indexIdCp = reader.GetOrdinal("IDCp");
					var indexDireccion = reader.GetOrdinal("Direccion");
					var indexUbigeo = reader.GetOrdinal("Ubigeo");
					var indexTipoOperacion = reader.GetOrdinal("TipoOperacion");
					var indexSaldoInicial = reader.GetOrdinal("SaldoInicial");
					var indexTipoInformacion = reader.GetOrdinal("TipoInformacion");
					var indexDocumentoIdentidad = reader.GetOrdinal("DocumentoIdentidad");
					var indexTraderAsignado = reader.GetOrdinal("TraderAsignado");
					while (reader.Read())
					{
						var cuentaCorriente = new CuentaCorriente
						{
							Fecha = reader.GetDateTime(indexFecha),
							FechaOperacion = reader.GetDateTime(indexFechaOperacion),
							FechaValor = reader.GetDateTime(indexFechaValor),
							Movimiento = reader.GetString(indexMovimiento),
							Ingresos = reader.GetDecimal(indexIngresos),
							Egresos = reader.GetDecimal(indexEgresos),
							Saldo = reader.GetDecimal(indexIngresos) - reader.GetDecimal(indexEgresos),
							CodigoCliente = reader.GetString(indexCodigoCliente),
							Cliente = reader.GetString(indexCliente),
							CodigoCavali = reader.GetString(indexCodigoCavali),
							IdMoneda = reader.GetInt32(indexIdMoneda),
							DocumentoPagoNumero = reader.GetString(indexDocumentoPagoNumero),
							Operacion = reader.GetString(indexOperacion),
							Transaccion = reader.GetString(indexTransaccion),
							Observacion = reader.GetString(indexObservacion),
							IdCp = reader.GetInt32(indexIdCp),
							Direccion = reader.GetString(indexDireccion),
							Ubigeo = reader.GetString(indexUbigeo),
							TipoOperacion = reader.GetString(indexTipoOperacion),
							SaldoInicial = reader.GetDecimal(indexSaldoInicial),
							TipoInformacion = reader.GetString(indexTipoInformacion),
							DocumentoIdentidad = reader.GetString(indexDocumentoIdentidad),
							TraderAsignado = reader.GetString(indexTraderAsignado)
						};
						cuentasCorrientes.Add(cuentaCorriente);
					}
				}

				return cuentasCorrientes;
			}
		}

		public IEnumerable<DetalleOperacion> ReporteDetalleOperacionesSql(ReportRequest request)
		{
			var resultado = new List<DetalleOperacion>();

			using (DataAccessManager.SqlConnection)
			{
				const string query = @"
					SELECT
						 Cp.MonedaBase
						,SAB.Transaccion.Detalle AS Transaccion
						,dbo.Cp.Fecha AS FechaOperacion
						,SAB.CpPoliza.FechaLiquidacion AS FechaVencimiento
						,dbo.Cp.NumCp AS Poliza
						,(CASE WHEN SAB.Mercado.Descripcion = 'BVL' THEN 'NAC' ELSE SAB.Mercado.Descripcion END) AS Mercado
						,SAB.TipoOperacion.Descripcion AS TipoOperacion
						,SAB.Valor.Nemonico AS Valor
						,SAB.CpPoliza.CantidadNegociada AS Cantidad
						,dbo.Cp.SubTotal / SAB.CpPoliza.CantidadNegociada AS Precio
						,dbo.Cp.SubTotal
						,(CASE SAB.Transaccion.Descripcion WHEN 'C' THEN dbo.Cp.Total ELSE NULL END) AS TotalCompra
	                    ,(CASE SAB.Transaccion.Descripcion WHEN 'V' THEN dbo.Cp.Total ELSE NULL END) AS TotalVenta
					FROM dbo.Cp
						INNER JOIN SAB.CpPoliza ON dbo.Cp.PKID = SAB.CpPoliza.PKID
						INNER JOIN SAB.Mercado ON SAB.CpPoliza.IDMercado = SAB.Mercado.PKID
						INNER JOIN SAB.TipoOperacion ON SAB.CpPoliza.IDTipoOperacion = SAB.TipoOperacion.PKID
						INNER JOIN SAB.Valor ON SAB.CpPoliza.IDValor = SAB.Valor.PKID
						INNER JOIN dbo.TipoCp ON dbo.Cp.IDTipoCp = dbo.TipoCp.PKID
						INNER JOIN SAB.TipoCpPoliza ON dbo.TipoCp.PKID = SAB.TipoCpPoliza.PKID
						INNER JOIN SAB.Transaccion ON SAB.CpPoliza.IDTransaccion = SAB.Transaccion.PKID
					WHERE
						SAB.TipoCpPoliza.EsPostDocumento = 0
					AND dbo.Cp.IDPersona = @IDCliente
					AND dbo.Cp.Fecha >= @FechaDesde
					AND dbo.Cp.Fecha <= @FechaHasta";

				var cmd = DataAccessManager.GetSqlCommand(query);
				cmd.Parameters.Add(new SqlParameter("@IDCliente", request.IdCliente));
				cmd.Parameters.Add(new SqlParameter("@FechaDesde", request.Rango.Desde));
				cmd.Parameters.Add(new SqlParameter("@FechaHasta", request.Rango.Hasta));

				using (var reader = cmd.ExecuteReader())
				{
					var indexIdMoneda = reader.GetOrdinal("MonedaBase");
					var indexTransaccion = reader.GetOrdinal("Transaccion");
					var indexFechaOperacion = reader.GetOrdinal("FechaOperacion");
					var indexFechaVencimiento = reader.GetOrdinal("FechaVencimiento");
					var indexPoliza = reader.GetOrdinal("Poliza");
					var indexMercado = reader.GetOrdinal("Mercado");
					var indexTipoOperacion = reader.GetOrdinal("TipoOperacion");
					var indexValor = reader.GetOrdinal("Valor");
					var indexCantidad = reader.GetOrdinal("Cantidad");
					var indexPrecio = reader.GetOrdinal("Precio");
					var indexSubTotal = reader.GetOrdinal("SubTotal");
					var indexTotalVenta = reader.GetOrdinal("TotalVenta");
					var indexTotalCompra = reader.GetOrdinal("TotalCompra");

					while (reader.Read())
					{
						var item = new DetalleOperacion
							{
								EsMoneda = reader.GetBoolean(indexIdMoneda),
								Moneda = reader.GetBoolean(indexIdMoneda) ? "Soles" : "Dolares",
								Transaccion = reader.GetString(indexTransaccion),
								FechaOperacion = reader.GetDateTime(indexFechaOperacion),
								FechaVencimiento = reader.GetDateTime(indexFechaVencimiento),
								Poliza = reader.GetString(indexPoliza),
								Mercado = reader.GetString(indexMercado),
								TipoOperacion = reader.GetString(indexTipoOperacion),
								Valor = reader.GetString(indexValor),
								Cantidad = reader.GetInt32(indexCantidad),
								Precio = reader.GetDecimal(indexPrecio),
								Subtotal = reader.GetDecimal(indexSubTotal),
								TotalVenta = reader.GetValue(indexTotalVenta) as decimal?,
								TotalCompra = reader.GetValue(indexTotalCompra) as decimal?
							};
						resultado.Add(item);
					}
				}
			}

			return resultado;
		}

		public IEnumerable<DetalleOperacion> ReporteDetalleOperacionesOracle(ReportRequest request)
		{
			var resultado = new List<DetalleOperacion>();

			using (DataAccessManager.OracleConnection)
			{
				const string query = @"";

				var cmd = DataAccessManager.GetOracleCommand(query);
				cmd.Parameters.Add(new OracleParameter("IDCliente", request.Cavali));
				cmd.Parameters.Add(new OracleParameter("FechaDesde", request.Rango.Desde));
				cmd.Parameters.Add(new OracleParameter("FechaHasta", request.Rango.Hasta));

				using (var reader = cmd.ExecuteReader())
				{
					var indexIdMoneda = reader.GetOrdinal("MonedaBase");
					var indexTransaccion = reader.GetOrdinal("Transaccion");
					var indexFechaOperacion = reader.GetOrdinal("FechaOperacion");
					var indexFechaVencimiento = reader.GetOrdinal("FechaVencimiento");
					var indexPoliza = reader.GetOrdinal("Poliza");
					var indexMercado = reader.GetOrdinal("Mercado");
					var indexTipoOperacion = reader.GetOrdinal("TipoOperacion");
					var indexValor = reader.GetOrdinal("Valor");
					var indexCantidad = reader.GetOrdinal("Cantidad");
					var indexPrecio = reader.GetOrdinal("Precio");
					var indexSubTotal = reader.GetOrdinal("SubTotal");
					var indexTotalVenta = reader.GetOrdinal("TotalVenta");
					var indexTotalCompra = reader.GetOrdinal("TotalCompra");

					while (reader.Read())
					{
						var item = new DetalleOperacion
						{
							EsMoneda = reader.GetBoolean(indexIdMoneda),
							Moneda = reader.GetBoolean(indexIdMoneda) ? "Soles" : "Dolares",
							Transaccion = reader.GetString(indexTransaccion),
							FechaOperacion = reader.GetDateTime(indexFechaOperacion),
							FechaVencimiento = reader.GetDateTime(indexFechaVencimiento),
							Poliza = reader.GetString(indexPoliza),
							Mercado = reader.GetString(indexMercado),
							TipoOperacion = reader.GetString(indexTipoOperacion),
							Valor = reader.GetString(indexValor),
							Cantidad = reader.GetInt32(indexCantidad),
							Precio = reader.GetDecimal(indexPrecio),
							Subtotal = reader.GetDecimal(indexSubTotal),
							TotalVenta = reader.GetValue(indexTotalVenta) as decimal?,
							TotalCompra = reader.GetValue(indexTotalCompra) as decimal?
						};
						resultado.Add(item);
					}
				}
			}

			return resultado;
		}
	}
}