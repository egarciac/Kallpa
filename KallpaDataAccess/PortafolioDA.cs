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
    public class PortafolioDA
    {
        ConnectionDB conn;

        public static DataSet getPortafolio(string strFecha, int intCodCavali, string Moneda)
        {
            DataSet ds = new DataSet();
            try
            {
                DateTime FecCorte = Convert.ToDateTime(strFecha).Date;
                //DateTime FecCaducidad = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha_Caducidad"].ToString()).Date;
                //if (FecCorte <= FecCaducidad) // Si la fecha indicada es menor o igual a la fecha actual
                //{
                ds = getPortafolioORACLE(strFecha, intCodCavali, Moneda);
                //}
                //else
                //{
                //    ds = getPortafolioSQL(strFecha, intCodCavali);
                //}


                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar BD");
            }
        }

        public static DataSet getPortafolioORACLE(string strFecha, int intCodCavali, string Moneda)
        {
            try
            {
                OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString);
                conn.Open();
                OracleCommand Command = new OracleCommand(" SELECT DISTINCT FLAG, CODIGO AS Valor, CANTIDAD_T AS Cantidad, CANTIDAD_D AS Disponible, " +
                                                    " CANTIDAD_B AS Principal, CANTIDAD_M AS Margen, ROUND(PREPROCOM, 2) AS Promedio, " +
                                                    " COTIZACION AS Mercado, ROUND(CANTIDAD_T*PREPROCOM, 2) AS Invertido, ROUND(CASE WHEN FLAG='0' THEN VALORIZAMN ELSE VALORIZAME END, 2) AS Valorizacion, " +
                                                    " ROUND((CASE WHEN FLAG='0' THEN VALORIZAMN ELSE VALORIZAME END - CANTIDAD_T*PREPROCOM), 2) AS Rentabilidad, " +
                                                    " ROUND((CASE WHEN FLAG='0' THEN VALORIZAMN ELSE VALORIZAME END -CANTIDAD_T*PREPROCOM)/(CANTIDAD_T*PREPROCOM)*100, 2) AS RentPerc, " +
                                                    " ROUND(VALORIZAMN/(SELECT sum(valorizamn) as total FROM TESTCARWEB " +
                                                    " WHERE codcli=" + intCodCavali + " and TO_CHAR(FECCORTE, 'DD/MM/YYYY')='" + strFecha + "' AND (flag ='0' OR flag='1'))*100, 2) AS ECTOT " +
                                                    " FROM TESTCARWEB WHERE " +
                                                    " CODCLI=" + intCodCavali + " and TO_CHAR(FECCORTE, 'DD/MM/YYYY')='" + strFecha + "' AND (FLAG=1 OR FLAG=0) AND MONEDAM='" + Moneda + "'" +
                                                    " --ORDER BY flag,clase,monedam,fecoper,monedag,codigo", conn);

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

        public static DataSet getPortafolioSQL(string strFecha, int intCodCavali) 
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
                command.Parameters["@IDUsuario"].Value = strFecha;
                command.Parameters["@Clave"].Value = intCodCavali;
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
