using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KallpaDataAccess;
using System.Data;

namespace KallpaBusiness
{
    public class Usuario
    {
        public static DataSet Validar(string strUsuario, string strClave)
        {
            DataSet ds = null;
            try
            {
                return UsuarioDA.ValidarDatos(strUsuario, strClave);
            }
            catch (Exception ex) { return ds; }
        }

        public static int ObtenerID(string codCavali)
        {
            try
            {
                return UsuarioDA.ObtenerID(codCavali);
            }
            catch
            {
                return 0;
            }
        }
    }
}
