using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KallpaDataAccess;

namespace KallpaBusiness
{
    public class Portafolio
    {
        public static DataSet getPortafolio(string strFecha, int intCodCavali)
        {
            DataSet ds = null;
            try
            {
                return PortafolioDA.getPortafolio(strFecha, intCodCavali);
            }
            catch (Exception ex) { return ds; }
        }

        //public static int ObtenerID(string codCavali)
        //{
        //    try
        //    {
        //        return UsuarPortafolioDA.ObtenerID(codCavali);
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}
    }
}
