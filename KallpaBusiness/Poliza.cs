using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KallpaDataAccess;

namespace KallpaBusiness
{
    public class Poliza
    {
        public DataSet ListPolizas()
        {
            PolizaDA polizaDA = new PolizaDA();
            return polizaDA.ListaPolizas();
        }

        public DataSet ListPolizas(int NumPoliza)
        {
            PolizaDA polizaDA = new PolizaDA();
            return polizaDA.ListaPolizas(NumPoliza);
        }
    }
}
