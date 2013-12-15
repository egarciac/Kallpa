using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KallpaEntities.Reportes
{
    public class DetalleOperacion
    {
        public bool EsMoneda { get; set; }
        public string Moneda { get; set; }
        public string Transaccion { get; set; }
        public DateTime FechaOperacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Poliza { get; set; }
        public string Mercado { get; set; }
        public string TipoOperacion { get; set; }
        public string Valor { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }
        public decimal? TotalVenta { get; set; }
        public decimal? TotalCompra { get; set; }
    }
}
