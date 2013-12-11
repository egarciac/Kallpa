using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KallpaEntities.Reportes
{
    public class Poliza
    {
        public int IdPoliza { get; set; }
        public bool MonedaBase { get; set; }
        public DateTime FechaPoliza { get; set; }
        public string NumeroPoliza { get; set; }
        public string Valor { get; set; }
        public string Transaccion { get; set; }
        public int CantidadAcciones { get; set; }
        public decimal MontoNeto { get; set; }
        public bool Sql { get; set; }
    }
}
