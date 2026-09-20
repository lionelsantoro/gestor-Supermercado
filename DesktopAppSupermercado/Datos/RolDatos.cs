using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopAppSupermercado.Datos
{
    public class RolDatos
    {
        public List<string> ObtenerRoles()
        {
            List<string> roles = new List<string>();
            Conexion miConexion = new Conexion();

            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();
                string query = "SELECT nombre FROM roles";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            roles.Add(lector["nombre"].ToString());
                        }
                    }
                }
            }
            return roles;
        }
    }
}
