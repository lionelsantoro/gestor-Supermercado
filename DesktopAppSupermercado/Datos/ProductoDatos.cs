using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using DesktopAppSupermercado.Entidades;

namespace DesktopAppSupermercado.Datos
{
    public class ProductoDatos
    {
        public List<string> ObtenerDescripcionesAutocomplete()
        {
            List<string> nombreProducto = new List<string>();
            Conexion miConexion = new Conexion();

            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();
                // Solo traemos los productos que no estén eliminados
                string query = "SELECT nombre FROM productos WHERE eliminado = 0";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            nombreProducto.Add(lector["nombre"].ToString());
                        }
                    }
                }
            }
            return nombreProducto;
        }

        public Producto ObtenerProductoPorNombre(string nombre)
        {
            Producto producto = null;
            Conexion miConexion = new Conexion();

            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();

                string query = @"
                                 SELECT
                                        id_producto,
                                        nombre,
                                        precio,
                                        stock,
                                        unidad_medida
                                 FROM productos
                                 WHERE nombre = @nombre
                                 AND eliminado = 0;";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            producto = new Producto
                            {
                                IdProducto = Convert.ToInt32(
                                    lector["id_producto"]),

                                Nombre = lector["nombre"].ToString(),

                                Precio = Convert.ToDecimal(
                                    lector["precio"]),

                                Stock = Convert.ToDecimal(
                                    lector["stock"]),

                                UnidadMedida = lector["unidad_medida"].ToString()
                            };
                        }
                    }
                }
            }

            return producto;
        }
    }
}
