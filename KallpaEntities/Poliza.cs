using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KallpaEntities
{
    public class Poliza
    {
        public string PolizaID { get; set; }
        public string monto { get; set; }
        public string usuario { get; set; }

        public Poliza(string _PolizaID, string _monto, string _usuario)
        {
            this.PolizaID = _PolizaID;
            this.monto = _monto;
            this.usuario = _usuario;
        }

        public Poliza() 
        { 
        }
    }
}
