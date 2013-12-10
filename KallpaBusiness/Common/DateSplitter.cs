using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KallpaEntities.General;
using System.Configuration;

namespace KallpaBusiness.Common
{
    public class DateSplitter
    {
        public bool OracleQuery { get; set; }
        public bool SqlQuery { get; set; }
        public RangoFecha RangoOracle { get; set; }
        public RangoFecha RangoSql { get; set; }

        public DateSplitter(RangoFecha rango)
        {
            var fechaCorte = DateTime.Parse(ConfigurationManager.AppSettings["Fecha_Caducidad"]);

            if (rango.Desde <= fechaCorte)
            {
                OracleQuery = true;
                if (rango.Hasta <= fechaCorte)
                {
                    SqlQuery = false;
                    RangoOracle = new RangoFecha(rango.Desde, rango.Hasta);
                }
                else
                {
                    SqlQuery = true;
                    RangoOracle = new RangoFecha(rango.Desde, fechaCorte);
                    RangoSql = new RangoFecha(fechaCorte.AddDays(1), rango.Hasta);
                }
            }
            else
            {
                OracleQuery = false;
                SqlQuery = true;
                RangoSql = new RangoFecha(rango.Desde, rango.Hasta);
            }
        }        
    }
}