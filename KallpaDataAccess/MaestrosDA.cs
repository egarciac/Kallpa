using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KallpaEntities.Maestros;

namespace KallpaDataAccess
{
    public class MaestrosDA
    {
        public IEnumerable<Moneda> ConseguirMoneda()
        {
            var monedas = new List<Moneda>
            {
                new Moneda
                {
                    IdMoneda = 0,
                    Codigo = "00",
                    Simbolo = string.Empty,
                    Descripcion = "-- TODAS --"
                }
            };

            using (DataAccessManager.SqlConnection)
            {
                var sqlQuery = "SELECT PKID, Descripcion, Simbolo, Codigo FROM [dbo].[Moneda]";
                using (var command = DataAccessManager.GetSqlCommand(sqlQuery))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var indexID = reader.GetOrdinal("PKID");
                        var indexCodigo = reader.GetOrdinal("Codigo");
                        var indexSimbolo = reader.GetOrdinal("Simbolo");
                        var indexDescripcion = reader.GetOrdinal("Descripcion");

                        while (reader.Read())
                        {
                            var moneda = new Moneda
                            {
                                IdMoneda = reader.GetInt32(indexID),
                                Codigo = reader.GetString(indexCodigo),
                                Simbolo = reader.GetString(indexSimbolo),
                                Descripcion = reader.GetString(indexDescripcion)
                            };
                            monedas.Add(moneda);
                        }

                        return monedas;
                    }
                }
            }
        }

        public IEnumerable<TipoOperacion> ConseguirTipoOperacion()
        {
            var tiposOperaciones = new List<TipoOperacion>
            {
                new TipoOperacion
                {
                    IdTipoOperacion = 0,
                    Codigo = "00",
                    Descripcion = "-- TODOS --"
                }
            };

            using (DataAccessManager.SqlConnection)
            {
                var sqlQuery = "SELECT PKID, Codigo, Descripcion FROM [SAB].[TipoOperacion]";
                using (var command = DataAccessManager.GetSqlCommand(sqlQuery))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var indexID = reader.GetOrdinal("PKID");
                        var indexCodigo = reader.GetOrdinal("Codigo");
                        var indexDescripcion = reader.GetOrdinal("Descripcion");

                        while (reader.Read())
                        {
                            var tipoOperacion = new TipoOperacion
                            {
                                IdTipoOperacion = reader.GetInt32(indexID),
                                Codigo = reader.GetString(indexCodigo),
                                Descripcion = reader.GetString(indexDescripcion)
                            };
                            tiposOperaciones.Add(tipoOperacion);
                        }

                        return tiposOperaciones;
                    }
                }
            }
        }

        public IEnumerable<Valor> ConseguirValor()
        {
            var tiposValores = new List<Valor>
            {
                new Valor
                {
                    IdValor = 0,
                    Codigo = "00",
                    Descripcion = "-- TODOS --"
                }
            };

            using (DataAccessManager.SqlConnection)
            {
                var sqlQuery = "SELECT PKID, Codigo, Descripcion FROM [SAB].[Valor] WHERE IDSector = 15";
                using (var command = DataAccessManager.GetSqlCommand(sqlQuery))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var indexID = reader.GetOrdinal("PKID");
                        var indexCodigo = reader.GetOrdinal("Codigo");
                        var indexDescripcion = reader.GetOrdinal("Descripcion");

                        while (reader.Read())
                        {
                            var valor = new Valor
                            {
                                IdValor = reader.GetInt32(indexID),
                                Codigo = reader.GetString(indexCodigo),
                                Descripcion = reader.GetString(indexDescripcion)
                            };
                            tiposValores.Add(valor);
                        }

                        return tiposValores;
                    }
                }
            }
        }

        public IEnumerable<TipoPoliza> ConseguirTipoPoliza()
        {
            var tiposPolizas = new List<TipoPoliza>
            {
                new TipoPoliza
                {
                    IdTipoPoliza = 0,
                    Codigo = "00",
                    Descripcion = string.Empty,
                    Detalle = "-- TODOS --"
                }
            };

            using (DataAccessManager.SqlConnection)
            {
                var sqlQuery = "SELECT PKID, Codigo, Descripcion, Detalle FROM SAB.Transaccion";
                using (var command = DataAccessManager.GetSqlCommand(sqlQuery))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var indexID = reader.GetOrdinal("PKID");
                        var indexCodigo = reader.GetOrdinal("Codigo");
                        var indexDescripcion = reader.GetOrdinal("Descripcion");
                        var indexDetalle = reader.GetOrdinal("Detalle");

                        while (reader.Read())
                        {
                            var tipoPoliza = new TipoPoliza
                            {
                                IdTipoPoliza = reader.GetInt32(indexID),
                                Codigo = reader.GetString(indexCodigo),
                                Descripcion = reader.GetString(indexDescripcion),
                                Detalle = reader.GetString(indexDetalle)
                            };
                            tiposPolizas.Add(tipoPoliza);
                        }

                        return tiposPolizas;
                    }
                }
            }
        }
    }
}