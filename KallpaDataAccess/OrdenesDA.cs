<<<<<<< .mine
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KallpaEntities.General;
using Oracle.DataAccess.Client;
using System.Configuration;
using KallpaDataAccess.Mappers;

namespace KallpaDataAccess
{
    public class OrdenesDA
    {
        ConnectionDB conn;

        public static DataSet getOrdenes(int intCodCavali, int TipoOperacion, RangoFecha rango)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = getOrdenesORACLE(intCodCavali, TipoOperacion, rango);
                
                //if (ds==null)
                    //ds = getOrdenesSQL(intCodCavali, TipoOperacion, rango);
                
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar BD");
            }
        }

        public static DataSet getOrdenesORACLE(int intCodCavali, int TipoOperacion, RangoFecha rango)
        {
            try
            {
                var queryBase = "SELECT to_char(fecorden, 'DD/MM/YYY') AS FECHA, to_char(fecorden, 'HH24:MM:SS') AS HORA, O.NUMORDEN AS ORDEN, " +
                                "O.TIPORDEN AS CV, O.CODIGO AS VALOR, O.CANT_ORI AS CANTIDAD, concat(to_char(O.VIGENCIA), ' día(s)'), " +
                                "tipop.des_oper as OPERACION, O.PRECIO, o.firmadO AS FIRMADO, o.*,c.nomcli,b.*,d1.descripcion as modo_recepcion,tipop.des_oper as modalidad  " +
                                "FROM ordenes o left join clientes c on (o.codcli = c.codcli) " +
                                "left join tipoper tipop on (tipop.tip_oper=o.tipoper), " +
                                "brokers b,  defgen d1 " +
                                "WHERE " +
                                "o.estado='V' and " +
                                "d1.codigo=o.ordcmpaux4 AND d1.campo like 'TIPORD%' AND " +
                                "c.codbroker=b.codbroker " +
                                " AND    C.CODCLI = " + intCodCavali +
                                " AND   trunc(o.fecOrden) >= to_date('" + rango.Desde.ToShortDateString() + "','DD-MM-YYYY') " +
                                " AND   trunc(o.fecOrden) <= to_date('" + rango.Hasta.ToShortDateString() + "','DD-MM-YYYY') ";

                var queryBuilder = new StringBuilder(queryBase);
                if (TipoOperacion > 0)
                {
                    queryBuilder.AppendLine(" AND o.tipoper = " + CustomMapper.TipoOperacion(TipoOperacion) + "");
                }

                queryBuilder.AppendLine(" ORDER BY o.fecOrden, o.numorden");
                
                OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString);
                conn.Open();
                OracleCommand Command = new OracleCommand(queryBuilder.ToString(), conn);

                Command.CommandType = CommandType.Text;
                OracleDataAdapter da = new OracleDataAdapter(Command);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KallpaEntities.General;
using Oracle.DataAccess.Client;
using System.Configuration;
using KallpaDataAccess.Mappers;

namespace KallpaDataAccess
{
    public class OrdenesDA
    {
        ConnectionDB conn;

        public static DataSet getOrdenes(int intCodCavali, int TipoOperacion, RangoFecha rango)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = getOrdenesORACLE(intCodCavali, TipoOperacion, rango);
                
                //if (ds==null)
                    //ds = getOrdenesSQL(intCodCavali, TipoOperacion, rango);
                
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar BD");
            }
        }

        public static DataSet getOrdenesORACLE(int intCodCavali, int TipoOperacion, RangoFecha rango)
        {
            try
            {
                var queryBase = "SELECT FLAG, CODIGO AS Valor, CANTIDAD_T AS Cantidad, CANTIDAD_D AS Disponible, " +
                                "CANTIDAD_B AS Principal, CANTIDAD_M AS Margen, PREPROCOM AS Promedio, " +
                                "COTIZACION AS Mercado, CANTIDAD_T*PREPROCOM AS Invertido, CASE WHEN FLAG='0' THEN VALORIZAMN ELSE VALORIZAME END AS Valorizacion, " +
                                "(CASE WHEN FLAG='0' THEN VALORIZAMN ELSE VALORIZAME END - CANTIDAD_T*PREPROCOM) AS Rentabilidad, " +
                                "(CASE WHEN FLAG='0' THEN VALORIZAMN ELSE VALORIZAME END -CANTIDAD_T*PREPROCOM)/(CANTIDAD_T*PREPROCOM)*100 AS RentPerc, " +
                                "VALORIZAMN/(SELECT sum(valorizamn) as total FROM TESTCARWEB " +
                                "AND (flag ='0' OR flag='1'))*100 AS ECTOT " +
                                "FROM TESTCARWEB WHERE " +
                                "(FLAG=1 OR FLAG=0)" +
                                "ORDER BY flag,clase,monedam,fecoper,monedag,codigo";
                var queryBuilder = new StringBuilder(queryBase);

                var parameters = new List<OracleParameter>();

                parameters.Add(new OracleParameter("cavali", intCodCavali));
                parameters.Add(new OracleParameter("desde", rango.Desde.ToShortDateString()));
                parameters.Add(new OracleParameter("hasta", rango.Hasta.ToShortDateString()));

                queryBuilder.AppendLine("AND    POLIZAS.CODCAVAL = :cavali");
                queryBuilder.AppendLine("AND   Polizas.FecPoli >= :desde");
                queryBuilder.AppendLine("AND    Polizas.FecPoli <= :hasta");

                if (TipoOperacion > 0)
                {
                    queryBuilder.AppendLine("AND    POLIZAS.TIPOPER = :tipoOperacion");
                    parameters.Add(new OracleParameter("tipoOperacion", CustomMapper.TipoOperacion(TipoOperacion)));
                }

                
                OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString);
                conn.Open();
                OracleCommand Command = new OracleCommand(queryBuilder.ToString(), conn);

                Command.CommandType = CommandType.Text;
                OracleDataAdapter da = new OracleDataAdapter(Command);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
>>>>>>> .r6
