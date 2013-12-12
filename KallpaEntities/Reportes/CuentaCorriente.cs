using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KallpaEntities.Reportes
{
    public class CuentaCorriente
    {
        public DateTime Fecha { get; set; }
        public DateTime FechaOperacion { get; set; }
        public DateTime FechaValor { get; set; }
        public string Movimiento { get; set; }
        public decimal Ingresos { get; set; }
        public decimal Egresos { get; set; }
        public decimal Saldo { get; set; }
        public string CodigoCliente { get; set; }
        public string Cliente { get; set; }
        public string CodigoCavali { get; set; }
        public int IdMoneda { get; set; }
        public string DocumentoPagoNumero { get; set; }
        public string Operacion { get; set; }
        public string Transaccion { get; set; }
        public string Observacion { get; set; }
        public int IdCp { get; set; }
        public string Direccion { get; set; }
        public string Ubigeo { get; set; }
        public string TipoOperacion { get; set; }
        public decimal SaldoInicial { get; set; }
        public string TipoInformacion { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string TraderAsignado { get; set; }
    }
}
