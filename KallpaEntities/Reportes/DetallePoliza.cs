using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KallpaEntities.Reportes
{
    public class DetallePoliza
    {
        public Poliza Poliza { get; set; }

        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string Cavali { get; set; }
        public string PaisNacionalidad { get; set; }
        public string Moneda { get; set; }
        public string TipoOperacion { get; set; }
        public string Transaccion { get; set; }
        public string Valor { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }
        public DateTime FechaLiquidacion { get; set; }
        public decimal ComisionSAB { get; set; }
        public decimal ComisionCONASEV { get; set; }
        public decimal ComisionBVL { get; set; }
        public decimal ComisionFondoBVL { get; set; }
        public decimal ComisionCAVALI { get; set; }
        public decimal ComisionFondoCAVALI { get; set; }
        public decimal ComisionInternacional { get; set; }
        public decimal Total { get; set; }
    }
}
