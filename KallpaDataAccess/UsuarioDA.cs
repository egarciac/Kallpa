using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.DataAccess.Client;
using System.Security.Cryptography;
using System.Configuration;
using System.Data.SqlClient;

namespace KallpaDataAccess
{
    public class UsuarioDA
    {
        ConnectionDB conn;

        public DataSet Login()
        {
            DataSet ds;
            try
            {
                conn = new ConnectionDB();
                List<OracleParameter> lstParam = new List<OracleParameter>();
                OracleParameter param1 = new OracleParameter("ResCursor", OracleDbType.RefCursor);
                param1.Direction = ParameterDirection.Output;
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

        public static string CrearHashSQL(string cadena)
        {
            byte[] bytes = new UnicodeEncoding().GetBytes(cadena);
            SHA1CryptoServiceProvider provider = new SHA1CryptoServiceProvider();
            return Convert.ToBase64String(provider.ComputeHash(bytes));
        }

        public static string CrearHashORACLE(string cadena)
        {
            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(cadena));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public static DataSet ValidarDatos(string usuario, string password)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = ValidarDatosSQL(usuario, CrearHashSQL(password));
                if (ds.Tables[0].Rows.Count == 0)
                    return ValidarDatosOracle(usuario, CrearHashORACLE(password));
                
                return ds;
            }
            catch (Exception ex)
            {
                return ValidarDatosOracle(usuario, CrearHashORACLE(password));
            }
        }

        public static DataSet ValidarDatosSQL(string usuario, string password) 
        {
            SqlConnection conn = null;
            //DataSet ds = null;
            string str = string.Empty;
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
                //SqlCommand command = new SqlCommand("SELECT dbo.UsuarioEmpresa.PKID AS IDUsuarioEmpresa, dbo.Usuario.Password, dbo.Empresa.Nombre, dbo.Usuario.IDUsuario FROM dbo.UsuarioEmpresa INNER JOIN dbo.Usuario ON dbo.UsuarioEmpresa.IDUsuario = dbo.Usuario.PKID INNER JOIN dbo.Empresa ON dbo.UsuarioEmpresa.IDEmpresa = dbo.Empresa.PKID WHERE (dbo.Empresa.Nombre = @nombreEmpresa) AND (dbo.Usuario.IDUsuario = @IDUsuario)");
                SqlCommand command = new SqlCommand("Select u.Nombre, d.Descripcion, c.CodigoCavali, t.Nombres from usuario u " +
                                            "inner join sab.cliente c on u.PKID=c.IDUsuarioWeb " +
                                            "inner join Direccion d on c.IDDireccionResidencia=d.PKID " +
                                            "inner join sab.trader t on c.IDTraderAsignado=t.PKID " +
                                            "where u.IDUsuario=@IDUsuario AND u.Password=@Clave", conn);
                command.Parameters.Add(new SqlParameter("@IDUsuario", SqlDbType.Char, 50, "IDUsuario"));
                command.Parameters.Add(new SqlParameter("@Clave", SqlDbType.Char, 50, "Clave"));
                command.Parameters["@IDUsuario"].Value = usuario;
                command.Parameters["@Clave"].Value = password;
                command.Connection = conn;
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                return ds;

                //SqlDataReader reader = command.ExecuteReader();
                //if (!reader.HasRows)
                //{
                //    throw new ApplicationException("El usuario no existe: " + usuario);
                //}
                //reader.Read();
                //string strB = reader["Password"].ToString();
                //str = reader["IDUsuarioEmpresa"].ToString();
                //if (string.CompareOrdinal(password, strB) != 0)
                //{
                //    throw new ApplicationException("Usuario o contrase\x00f1a no validos");
                //}
                conn.Close();
            }
            catch (Exception exception1)
            {
                Exception innerException = exception1;
                str = string.Empty;
                if ((conn != null) && (conn.State != ConnectionState.Open))
                {
                    conn.Close();
                }
                if (innerException is ApplicationException)
                {
                    throw innerException;
                }
                throw new ApplicationException("Error al validar usuario", innerException);
                
            }
            
            //return ds;
            //Login login = new Login();
            //login.ValidarUsuario(ConfigurationManager.AppSettings["NombreEmpresa"], usuario, password);
            //ObtenerCliente();
        }

        public static DataSet ValidarDatosOracle(string usuario, string password)
        {
            try
            {
                OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString);
                conn.Open();
                OracleCommand Command = new OracleCommand("select a.nomcli, a.direccion, a.codcli, b.nombroker from clientes a " +
                                                "inner join brokers b on A.CODBROKER = b.codbroker " +
                                                "inner join web_usuarios c on A.codcli = C.ID_USUARIO_SISTEMA " +
                                                "where c.usuario='" + usuario + "' and contrasenia='" + password + "' and activo=1", conn);
                
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

        public static int ObtenerID(string codCavali)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString))
            {
                try
                {
                    string sqlQuery = "SELECT PKID FROM SAB.Cliente WHERE CodigoCavali = @CodCavali";
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = sqlQuery;
                        var parmCodCavali = cmd.CreateParameter();
                        parmCodCavali.ParameterName = "@CodCavali";
                        parmCodCavali.Value = codCavali;
                        cmd.Parameters.Add(parmCodCavali);
                        connection.Open();
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }                
            }
        }


    }
}
