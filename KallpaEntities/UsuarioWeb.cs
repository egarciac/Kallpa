using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KallpaEntities
{
    class UsuarioWeb
    {
        public string usuario { get; set; }
        public string password { get; set; }
        public string codigocavali { get; set; }

        private List<Poliza> _poliza = new List<Poliza>();
        public List<Poliza> poliza
        {
            get { return _poliza; }
            set { _poliza = value; }
        }

        public UsuarioWeb(string _usuario, string _password, string _codigocavali, List<Poliza> poliza)
        {
            this.usuario = _usuario;
            this.password = _password;
            this.codigocavali = _codigocavali;
            this._poliza = poliza;
        }

    }
}
