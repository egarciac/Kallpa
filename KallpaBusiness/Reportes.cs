using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KallpaEntities.General;
using KallpaDataAccess;
using KallpaEntities.Reportes;
using KallpaBusiness.Common;

namespace KallpaBusiness
{
    public class Reportes
    {
        ReportesDA _db;

        public Reportes()
        {
            _db = new ReportesDA();
        }

        public IEnumerable<Poliza> ReportePolizas(int idCliente, int cavali, int tipoOperacion, int moneda, int valor, int tipoPoliza, RangoFecha rango)
        {
            IEnumerable<Poliza> listaOracle = null;
            IEnumerable<Poliza> listaSql = null;
            var splitter = new DateSplitter(rango);
            if(splitter.OracleQuery)
                listaOracle = _db.ReportePolizasORACLE(cavali, tipoOperacion, moneda, valor, tipoPoliza, splitter.RangoOracle);
            if (splitter.SqlQuery)
                listaSql = _db.ReportePolizasSQL(idCliente, tipoOperacion, moneda, valor, tipoPoliza, splitter.RangoSql);
            List<Poliza> listaFinal = null;
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

        public DetallePoliza ReporteDetallePoliza(int idPoliza, bool sqlReport)
        {
            return sqlReport ? _db.ReporteDetallePolizaSQL(idPoliza) : _db.ReporteDetallePolizaORACLE(idPoliza);
        }

        public IEnumerable<CuentaCorriente> ReporteCuentaCorriente(int idCliente, int cavali, RangoFecha rango, int idMoneda)
        {
            IEnumerable<CuentaCorriente> listaOracle = null;
            IEnumerable<CuentaCorriente> listaSql = null;
            var splitter = new DateSplitter(rango);
            if (splitter.OracleQuery)
                listaOracle = _db.ReportCuentaCorrienteOracle(cavali, splitter.RangoOracle, idMoneda);
            if (splitter.SqlQuery)
                listaSql = _db.ReportCuentaCorrienteSql(idCliente, splitter.RangoSql, idMoneda);
            List<CuentaCorriente> listaFinal = null;
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