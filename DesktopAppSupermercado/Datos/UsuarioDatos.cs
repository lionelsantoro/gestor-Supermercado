using DesktopAppSupermercado.Entidades;
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


        public Usuario ObtenerUsuarioParaSesion(string nombreUsuario)
        {
            Usuario usuario = null;
            Conexion miConexion = new Conexion();

            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();

                string query = @"
            SELECT
                id_usuario,
                id_rol,
                nombre_usuario
            FROM dbo.usuarios
            WHERE nombre_usuario = @nombreUsuario
              AND eliminado = 0;";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(
                        "@nombreUsuario",
                        SqlDbType.VarChar,
                        100).Value = nombreUsuario;

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            usuario = new Usuario
                            {
                                IdUsuario = Convert.ToInt32(
                                    lector["id_usuario"]),

                                IdRol = Convert.ToInt32(
                                    lector["id_rol"]),

                                NombreUsuario = lector["nombre_usuario"].ToString()
                            };
                        }
                    }
                }
            }

            return usuario;
        }

    }
}
