using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;

namespace KallpaDataAccess
{
    public class PolizaDA
    {
        ConnectionDB conn;

        public DataSet ListaPolizas()
        {
            DataSet ds;
            try
            {
                conn = new ConnectionDB();
                List<OracleParameter> lstParam = new List<OracleParameter>();
                OracleParameter param1 = new OracleParameter("ResCursor", OracleDbType.RefCursor);
                param1.Direction  = ParameterDirection.Output;
                lstParam.Add(param1);

                ds = new DataSet();
                ds = conn.getDataSetOracle("SP_LIST_POLIZAS", lstParam);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Cursor SP_LIST_POLIZAS", ex);
            }
            return ds;
        }

        public DataSet ListaPolizas(int NumPoliza)
        {
            DataSet ds;
            try
            {
                conn = new ConnectionDB();
                List<OracleParameter> lstParam = new List<OracleParameter>();
                OracleParameter param1 = new OracleParameter("NumPoliza", OracleDbType.Int32);
                param1.Value = NumPoliza;
                lstParam.Add(param1);

                OracleParameter param2 = new OracleParameter("ResCursor", OracleDbType.RefCursor);
                param2.Direction = ParameterDirection.Output;
                lstParam.Add(param2);

                ds = new DataSet();
                ds = conn.getDataSetOracle("SP_LIST_POLIZAS", lstParam);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Cursor SP_LIST_POLIZAS", ex);
            }
            return ds;
        }
    }
}
