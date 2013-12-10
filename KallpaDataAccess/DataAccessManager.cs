using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Oracle.DataAccess.Client;

namespace KallpaDataAccess
{
    public static class DataAccessManager
    {
        static SqlConnection _sqlConnection;

        public static SqlConnection SqlConnection
        {
            get
            {
                if (_sqlConnection == null)
                    _sqlConnection = new SqlConnection();
                if (_sqlConnection.State == ConnectionState.Closed)
                    _sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
                return _sqlConnection;
            }
        }

        public static SqlCommand GetSqlCommand(string query, List<SqlParameter> parameters = null)
        {
            var command = _sqlConnection.CreateCommand();
            command.CommandText = query;
            command.Connection = _sqlConnection;
            if (parameters != null)
                command.Parameters.AddRange(parameters.ToArray());
            _sqlConnection.Open();
            return command;
        }

        static OracleConnection _oracleConnection;

        public static OracleConnection OracleConnection
        {
            get
            {
                if (_oracleConnection == null || _oracleConnection.State == ConnectionState.Closed)
                    _oracleConnection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString);                
                return _oracleConnection;
            }
        }

        public static OracleCommand GetOracleCommand(string query, List<OracleParameter> parameters = null)
        {
            var command = _oracleConnection.CreateCommand();
            command.CommandText = query;
            command.Connection = _oracleConnection;
            if (parameters != null)
                foreach (var parameter in parameters)
                    command.Parameters.Add(parameter);
            _oracleConnection.Open();
            return command;
        }        
    }
}