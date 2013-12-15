namespace KallpaEntities.General
{
    public class ReportRequest
    {
        public int IdCliente { get; set; }
        public int Cavali { get; set; }
        public RangoFecha Rango { get; set; }
        public int TipoOperacion { get; set; }
        public int Moneda { get; set; }
        public int Valor { get; set; }
        public int TipoPoliza { get; set; }
    }
}
