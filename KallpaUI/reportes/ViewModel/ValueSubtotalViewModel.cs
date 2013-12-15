using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KallpaUI.reportes.ViewModel
{
    public class ValueSubtotalViewModel
    {
        public string Header { get; set; }
        public bool EsMoneda { get; set; }
        public string Valor { get; set; }
        public decimal MontoCompra { get; set; }
        public decimal MontoVenta { get; set; }
    }
}