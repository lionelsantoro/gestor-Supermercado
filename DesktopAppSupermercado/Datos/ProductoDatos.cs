using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using DesktopAppSupermercado.Entidades;

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
    }
}