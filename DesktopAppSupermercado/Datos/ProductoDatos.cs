using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using static DesktopAppSupermercado.Entidades.Entidadescs;

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
                // Solo traemos los productos que no estén eliminados
                string query = "SELECT descripcion FROM productos WHERE eliminado = 0";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            descripciones.Add(lector["descripcion"].ToString());
                        }
                    }
                }
            }
            return descripciones;
        }

        public Producto ObtenerProductoPorDescripcion(string descripcion)
        {
            Producto producto = null;
            Conexion miConexion = new Conexion();

            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();
                string query = "SELECT id_producto, nombre, descripcion, precio, stock FROM productos WHERE descripcion = @descripcion AND eliminado = 0";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@descripcion", descripcion);

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            producto = new Producto
                            {
                                IdProducto = Convert.ToInt32(lector["id_producto"]),
                                Nombre = lector["nombre"].ToString(),
                                Descripcion = lector["descripcion"].ToString(),
                                Precio = Convert.ToDecimal(lector["precio"]),
                                Stock = Convert.ToInt32(lector["stock"])
                            };
                        }
                    }
                }
            }
            return producto;
        }
    }
}
