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
        readonly ReportesDataAccess _db;

        public Reportes()
        {
            _db = new ReportesDataAccess();
        }

        public IEnumerable<Poliza> ReportePolizas(ReportRequest request)
        {
            return new SourceSelector().GetReportData(request, _db.ReportePolizasSql, _db.ReportePolizasOracle);
        }

        public DetallePoliza ReporteDetallePoliza(int idPoliza, bool sqlReport)
        {
            return sqlReport ? _db.ReporteDetallePolizaSql(idPoliza) : _db.ReporteDetallePolizaOracle(idPoliza);
        }

        public IEnumerable<CuentaCorriente> ReporteCuentaCorriente(ReportRequest request)
        {
            return new SourceSelector().GetReportData(request, _db.ReportCuentaCorrienteSql, _db.ReportCuentaCorrienteOracle);
        }

        public IEnumerable<DetalleOperacion> ReportDetalleOperaciones(ReportRequest request)
        {
            return new SourceSelector().GetReportData(request, _db.ReporteDetalleOperacionesSql, _db.ReporteDetalleOperacionesOracle);
        }
    }
}