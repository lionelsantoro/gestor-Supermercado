using DesktopAppSupermercado.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DesktopAppSupermercado.Datos
{
    public class ProductoDatos
    {
        public List<string> ObtenerDescripcionesAutocomplete()
        {
            List<string> descripciones = new List<string>();
            Conexion miConexion = new Conexion();

            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();

                string query = @"
                    SELECT descripcion
                    FROM dbo.productos
                    WHERE eliminado = 0
                    ORDER BY descripcion;";

                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        descripciones.Add(
                            lector["descripcion"].ToString());
                    }
                }
            }

            return descripciones;
        }

        public Producto ObtenerProductoPorDescripcion(
            string descripcion)
        {
            Producto producto = null;
            Conexion miConexion = new Conexion();

            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();

                string query = @"
                    SELECT
                        id_producto,
                        descripcion,
                        precio,
                        stock,
                        unidad_medida
                    FROM dbo.productos
                    WHERE descripcion = @descripcion
                      AND eliminado = 0;";

                using (SqlCommand comando =
                    new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(
                        "@descripcion",
                        System.Data.SqlDbType.VarChar,
                        150).Value = descripcion;

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            producto = new Producto
                            {
                                IdProducto = Convert.ToInt32(
                                    lector["id_producto"]),

                                // La descripción se conserva en la
                                // propiedad Nombre de la entidad C#.
                                Nombre = lector["descripcion"].ToString(),

                                Precio = Convert.ToDecimal(
                                    lector["precio"]),

                                Stock = Convert.ToDecimal(
                                    lector["stock"]),

                                UnidadMedida =
                                    lector["unidad_medida"].ToString()
                            };
                        }
                    }
                }
            }

            return producto;
        }

        public DataTable BuscarProductosParaSeleccion(
    string filtro,
    int? idCategoria)
        {
            DataTable tabla = new DataTable();
            Conexion miConexion = new Conexion();

            filtro = filtro?.Trim() ?? "";

            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();

                string query = @"
            SELECT
                p.id_categoria,
                p.descripcion,
                p.codigo_barra,
                p.precio,
                p.stock
            FROM dbo.productos AS p
            WHERE ISNULL(p.eliminado, 0) = 0
              AND (
                    @filtro = N''
                    OR p.descripcion LIKE @patron
                    OR CONVERT(NVARCHAR(50), p.codigo_barra) LIKE @patron
                  )
              AND (
                    @idCategoria IS NULL
                    OR p.id_categoria = @idCategoria
                  )
            ORDER BY p.descripcion ASC;";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(
                        "@filtro", SqlDbType.NVarChar, 100).Value = filtro;

                    comando.Parameters.Add(
                        "@patron", SqlDbType.NVarChar, 102).Value =
                        "%" + filtro + "%";

                    comando.Parameters.Add(
                        "@idCategoria", SqlDbType.Int).Value =
                        (object)idCategoria ?? DBNull.Value;

                    comando.CommandTimeout = 10;

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }

            return tabla;
        }
    }
}