using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KallpaEntities.General;
using System.Data;
using KallpaDataAccess;

namespace KallpaBusiness
{
    public class Ordenes
    {
        public static DataSet getOrdenes(int intCodCavali, int tipoOperacion, RangoFecha rango)
        {
            DataSet ds = null;
            try
            {
                return OrdenesDA.getOrdenes(intCodCavali, tipoOperacion, rango);
            }
            catch (Exception ex) { return ds; }
        }
    }
}
