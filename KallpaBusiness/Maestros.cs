using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KallpaEntities.Maestros;
using KallpaDataAccess;

namespace KallpaBusiness
{
    public class Maestros
    {
        MaestrosDA _db;

        public Maestros()
        {
            _db = new MaestrosDA();
        }

        public IEnumerable<Moneda> ConseguirMoneda()
        {
            return _db.ConseguirMoneda();
        }

        public IEnumerable<TipoOperacion> ConseguirTipoOperacion()
        {
            return _db.ConseguirTipoOperacion();
        }

        public IEnumerable<Valor> ConseguirValor()
        {
            return _db.ConseguirValor();
        }

        public IEnumerable<TipoPoliza> ConseguirTipoPoliza()
        {
            return _db.ConseguirTipoPoliza();
        }
    }
}