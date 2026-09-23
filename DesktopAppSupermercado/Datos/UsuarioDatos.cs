using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DesktopAppSupermercado.Datos
{
    public class UsuarioDatos
    {
        public DataTable ObtenerUsuariosFiltrados(string textoBuscado, string nombreRol)
        {
            DataTable tabla = new DataTable();
            Conexion miConexion = new Conexion();

            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();

                string query = @"
                    SELECT 
                        u.id_usuario AS [Id Empleado], 
                        p.nombre AS [Nombre], 
                        p.apellido AS [Apellido], 
                        r.nombre AS [Rol]
                    FROM usuarios u
                    INNER JOIN persona p ON u.id_persona = p.id_persona
                    INNER JOIN roles r ON u.id_rol = r.id_rol
                    WHERE u.eliminado = 0 ";

                // Filtro por texto
                if (!string.IsNullOrWhiteSpace(textoBuscado))
                {
                    query += " AND (p.nombre LIKE @buscar OR p.apellido LIKE @buscar) ";
                }

                // Filtro por rol exacto
                if (!string.IsNullOrWhiteSpace(nombreRol) && nombreRol != "Todos")
                {
                    query += " AND r.nombre = @rol ";
                }

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    if (!string.IsNullOrWhiteSpace(textoBuscado))
                        comando.Parameters.AddWithValue("@buscar", "%" + textoBuscado + "%");

                    if (!string.IsNullOrWhiteSpace(nombreRol) && nombreRol != "Todos")
                        comando.Parameters.AddWithValue("@rol", nombreRol);

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
