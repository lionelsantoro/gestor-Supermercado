using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
