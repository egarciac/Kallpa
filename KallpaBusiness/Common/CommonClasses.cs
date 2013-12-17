using System;
using System.Collections.Generic;
using System.Linq;
using KallpaEntities.General;
using System.Configuration;

namespace KallpaBusiness.Common
{
    class DateSplitter
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

    public class SourceSelector
    {
        public IEnumerable<T> GetReportData<T>(ReportRequest request, Func<ReportRequest, IEnumerable<T>> sqlReportQuery, Func<ReportRequest, IEnumerable<T>> oracleReportQuery)
        {
            IEnumerable<T> listaOracle = null;
            IEnumerable<T> listaSql = null;
            var splitter = new DateSplitter(request.Rango);
            //if (splitter.OracleQuery)
            //    listaOracle = oracleReportQuery(request);
            //if (splitter.SqlQuery)
                listaSql =sqlReportQuery(request);
            List<T> listaFinal = null;
            if (listaOracle != null)
            {
                listaFinal = listaOracle.ToList();
                if (listaSql != null)
                    listaFinal.AddRange(listaSql);
            }
            else if (listaSql != null)
                listaFinal = listaSql.ToList();
            return listaFinal;
        }
    }
}