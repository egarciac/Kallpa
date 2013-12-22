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
        public static DataSet getPortafolio(string strFecha, int intCodCavali, string Moneda)
        {
            DataSet ds = null;
            try
            {
                ds = PortafolioDA.getPortafolio(strFecha, intCodCavali, Moneda);
                DataTable dt = ds.Tables[0];
                DataView dv = dt.DefaultView;
                dv.RowFilter = "Moneda='" + Moneda + "'";
                return ds;
            }
            catch (Exception ex) { return ds; }
        }


        public static DataSet getRpteTptdoSQL(string strFecha, int intCodCavali, string Dato)
        {
            DataSet ds = null;
            try
            {
                ds = PortafolioDA.getRpteTptdoSQL(strFecha, intCodCavali);
                DataTable dt = ds.Tables[0];
                DataView dv = dt.DefaultView;
                dv.RowFilter = "Grupo='" + Dato + "'";
                return ds;
            }
            catch (Exception ex) { return ds; }
        }

        public static DataSet getMargen(string strFecha, int intCodCavali)
        {
            DataSet ds = null;
            try
            {
                return PortafolioDA.getMargenSQL(strFecha, intCodCavali);
            }
            catch (Exception ex) { return ds; }
        }

    }
}
