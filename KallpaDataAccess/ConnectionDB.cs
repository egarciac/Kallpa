using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KallpaDataAccess
{
    public class ConnectionDB
    {
        public static SqlConnection ConexionSQL
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
            }
        }

        public static OracleConnection ConexionOracle
        {
            get
            {
                return new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString);
            }
        }

        public DataSet getDataSetSQL(string SPName, List<SqlParameter> parameters)
        {
            try
            {
                using (ConexionSQL)
                {
                    ConexionSQL.Open();
                    using (SqlCommand Command = new SqlCommand("", ConexionSQL))
                    {
                        if (parameters != null && parameters.Count > 0)
                        {
                            Command.CommandType = CommandType.StoredProcedure;

                            foreach (var p in parameters)
                            {
                                Command.Parameters.Add(p);
                            }
                        }
                        SqlDataAdapter da = new SqlDataAdapter(Command);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed connection to DB", ex);
            }
        }

        public DataSet getDataSetOracle(string SPName, List<OracleParameter> parameters)
        {
            try
            {
                using (ConexionOracle)
                {
                    ConexionOracle.Open();
                    using (OracleCommand Command = new OracleCommand(SPName, ConexionOracle))
                    {
                        if (parameters != null && parameters.Count > 0)
                        {
                            Command.CommandType = CommandType.StoredProcedure;

                            foreach (var p in parameters)
                            {
                                Command.Parameters.Add(p);
                            }
                        }
                        OracleDataAdapter da = new OracleDataAdapter(Command);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        return ds;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed connection to DB", ex);
            }
        }
    }
}
