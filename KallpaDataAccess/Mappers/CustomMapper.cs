using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace KallpaDataAccess.Mappers
{
    public static class CustomMapper
    {
        public static string TipoOperacion(int id)
        {
            var result = string.Empty;
            switch (id)
            {
                case 0: result = "00"; break;
                case 1: result = "01"; break;
                case 2: result = "02"; break;
                case 5: result = "07"; break;
                case 6: result = "10"; break;
                case 8: result = "12"; break;
                case 14: result = "40"; break;
                case 16: result = "49"; break;
                case 17: result = "09"; break;
                case 21: result = "16"; break;
                case 24: result = "18"; break;
            }
            return result;
        }

        public static string Moneda(int id)
        {
            var result = string.Empty;

            switch (id)
            {
                case 1: result = "S"; break;
                case 2: result = "D"; break;
            }

            return result;
        }

        public static string Valor(int id)
        {
            using (DataAccessManager.SqlConnection)
            {
                var query = "SELECT Descripcion FROM SAB.Valor WHERE PKID = @id";
                using (var cmd = DataAccessManager.GetSqlCommand(query, new List<SqlParameter> { new SqlParameter("@id", id) }))
                {
                    return cmd.ExecuteScalar().ToString();
                }
            }
        }

        public static string TipoPoliza(int id)
        {
            var result = string.Empty;

            switch (id)
            {
                case 1: result = "C%"; break;
                case 2: result = "V%"; break;
            }

            return result;
        }
    }
}