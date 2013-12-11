using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using KallpaEntities.Reportes;
using KallpaEntities.General;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;
using KallpaDataAccess.Mappers;

namespace KallpaDataAccess
{
    public class ReportesDA
    {
        public IEnumerable<Poliza> ReportePolizasSQL(int idCliente, int tipoOperacion, int moneda, int valor, int tipoPoliza, RangoFecha rango)
        {
            var polizas = new List<Poliza>();
            var queryBase =
                @"SELECT
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

            parameters.Add(new SqlParameter("@IDCliente", idCliente));
            parameters.Add(new SqlParameter("@FechaDesde", rango.Desde));
            parameters.Add(new SqlParameter("@FechaHasta", rango.Hasta));

            queryBuilder.AppendLine("AND	dbo.Cp.IDPersona = @IDCliente");
            queryBuilder.AppendLine("AND	dbo.Cp.Fecha >= @FechaDesde");
            queryBuilder.AppendLine("AND	dbo.Cp.Fecha <= @FechaHasta");
            if (tipoOperacion > 0)
            {
                queryBuilder.AppendLine("AND	SAB.CpPoliza.IDTipoOperacion = @TipoOperacion");
                parameters.Add(new SqlParameter("@TipoOperacion", tipoOperacion));
            }
            if (moneda > 0)
            {
                queryBuilder.AppendLine("AND	dbo.Cp.IDMoneda = @Moneda");
                parameters.Add(new SqlParameter("@Moneda", moneda));
            }
            if (valor > 0)
            {
                queryBuilder.AppendLine("AND	SAB.CpPoliza.IDValor = @Valor");
                parameters.Add(new SqlParameter("@Valor", valor));
            }
            if (tipoPoliza > 0)
            {
                queryBuilder.AppendLine("AND	SAB.CpPoliza.IDTransaccion = @Transaccion");
                parameters.Add(new SqlParameter("@Transaccion", tipoPoliza));
            }

            using (DataAccessManager.SqlConnection)
            {
                var cmd = DataAccessManager.GetSqlCommand(queryBuilder.ToString(), parameters);
                using (var reader = cmd.ExecuteReader())
                {
                    var indexMonedaBase = reader.GetOrdinal("MonedaBase");
                    var indexPKID = reader.GetOrdinal("PKID");
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
                            IdPoliza = reader.GetInt32(indexPKID),
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

        public IEnumerable<Poliza> ReportePolizasORACLE(int cavali, int tipoOperacion, int moneda, int valor, int tipoPoliza, RangoFecha rango)
        {
            var polizas = new List<Poliza>();
            var queryBase =
                @"SELECT
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

            parameters.Add(new OracleParameter("cavali", cavali));
            parameters.Add(new OracleParameter("desde", rango.Desde.ToShortDateString()));
            parameters.Add(new OracleParameter("hasta", rango.Hasta.ToShortDateString()));

            queryBuilder.AppendLine("AND    POLIZAS.CODCAVAL = :cavali");
            queryBuilder.AppendLine("AND   Polizas.FecPoli >= :desde");
            queryBuilder.AppendLine("AND    Polizas.FecPoli <= :hasta");

            if (tipoOperacion > 0)
            {
                queryBuilder.AppendLine("AND    POLIZAS.TIPOPER = :tipoOperacion");
                parameters.Add(new OracleParameter("tipoOperacion", CustomMapper.TipoOperacion(tipoOperacion)));
            }
            if (moneda > 0)
            {
                queryBuilder.AppendLine("AND    POLIZAS.moneda = :moneda");
                parameters.Add(new OracleParameter("moneda", CustomMapper.Moneda(moneda)));
            }
            if (valor > 0)
            {
                queryBuilder.AppendLine("AND     POLIZAS.CODIGO = :valor");
                parameters.Add(new OracleParameter("valor", CustomMapper.Valor(valor)));
            }
            if (tipoPoliza > 0)
            {
                queryBuilder.AppendLine("AND      POLIZAS.tipoli like :tipoPoliza");
                parameters.Add(new OracleParameter("valor", CustomMapper.TipoPoliza(tipoPoliza)));
            }

            using (DataAccessManager.OracleConnection)
            {
                var cmd = DataAccessManager.GetOracleCommand(queryBuilder.ToString(), parameters);
                using (var reader = cmd.ExecuteReader())
                {
                    var indexMonedaBase = reader.GetOrdinal("MonedaBase");
                    var indexPKID = reader.GetOrdinal("PKID");
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
                            IdPoliza = reader.GetInt32(indexPKID),
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

        public DetallePoliza ReporteDetallePolizaSQL(int idPoliza)
        {
            using (DataAccessManager.SqlConnection)
            {
                var query = @"
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
                    var res = cmd.ExecuteScalar();
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
                        var indexComisionSAB = reader.GetOrdinal("ComisionSAB");
                        var indexComisionCONASEV = reader.GetOrdinal("ComisionCONASEV");
                        var indexComisionBVL = reader.GetOrdinal("ComisionBVL");
                        var indexComisionFondoBVL = reader.GetOrdinal("ComisionFONDOBVL");
                        var indexComisionCAVALI = reader.GetOrdinal("ComisionCAVALI");
                        var indexComisionFondoCAVALI = reader.GetOrdinal("ComisionFONDOCAVALI");
                        var indexComisionInternacional = reader.GetOrdinal("ComisionINTERNACIONAL");
                        var indexIGV = reader.GetOrdinal("IGV");
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
                                    ComisionSAB = reader.GetDecimal(indexComisionSAB),
                                    ComisionCONASEV = reader.GetDecimal(indexComisionCONASEV),
                                    ComisionBVL = reader.GetDecimal(indexComisionFondoBVL),
                                    ComisionFondoBVL = reader.GetDecimal(indexComisionFondoBVL),
                                    ComisionCAVALI = reader.GetDecimal(indexComisionCAVALI),
                                    ComisionFondoCAVALI = reader.GetDecimal(indexComisionFondoCAVALI),
                                    ComisionInternacional = reader.GetDecimal(indexComisionInternacional),
                                    IGV = reader.GetDecimal(indexIGV),
                                    Total = reader.GetDecimal(indexTotal)
                                };
                        }
                        return null;
                    }
                }
            }
        }

        public DetallePoliza ReporteDetallePolizaORACLE(int idPoliza)
        {
            using (DataAccessManager.OracleConnection)
            {
                var query = @"";
                using (var cmd = DataAccessManager.GetOracleCommand(query))
                {
                    cmd.Parameters.Add(new OracleParameter("IdPoliza", idPoliza));
                    var res = cmd.ExecuteScalar();
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
                        var indexComisionSAB = reader.GetOrdinal("ComisionSAB");
                        var indexComisionCONASEV = reader.GetOrdinal("ComisionCONASEV");
                        var indexComisionBVL = reader.GetOrdinal("ComisionBVL");
                        var indexComisionFondoBVL = reader.GetOrdinal("ComisionFONDOBVL");
                        var indexComisionCAVALI = reader.GetOrdinal("ComisionCAVALI");
                        var indexComisionFondoCAVALI = reader.GetOrdinal("ComisionFONDOCAVALI");
                        var indexComisionInternacional = reader.GetOrdinal("ComisionINTERNACIONAL");
                        var indexIGV = reader.GetOrdinal("IGV");
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
                                ComisionSAB = reader.GetDecimal(indexComisionSAB),
                                ComisionCONASEV = reader.GetDecimal(indexComisionCONASEV),
                                ComisionBVL = reader.GetDecimal(indexComisionFondoBVL),
                                ComisionFondoBVL = reader.GetDecimal(indexComisionFondoBVL),
                                ComisionCAVALI = reader.GetDecimal(indexComisionCAVALI),
                                ComisionFondoCAVALI = reader.GetDecimal(indexComisionFondoCAVALI),
                                ComisionInternacional = reader.GetDecimal(indexComisionInternacional),
                                IGV = reader.GetDecimal(indexIGV),
                                Total = reader.GetDecimal(indexTotal)
                            };
                        }
                        return null;
                    }
                }
            }
        }
    }
}