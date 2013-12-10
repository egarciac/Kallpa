using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KallpaEntities.General
{
    public class RangoFecha
    {
        DateTime _desde;
        public DateTime Desde
        {
            get { return _desde; }
            set { _desde = value; }
        }

        DateTime _hasta;
        public DateTime Hasta
        {
            get { return _hasta; }
            set { _hasta = value; }
        }

        public RangoFecha(DateTime desde, DateTime hasta)
        {
            _desde = desde;
            _hasta = hasta;
        }
    }
}