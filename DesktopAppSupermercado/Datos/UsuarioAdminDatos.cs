using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DesktopAppSupermercado.Datos
{
    public class UsuarioAdminDatos
    {
        public DataTable ObtenerRoles()
        {
            DataTable dt = new DataTable();
            Conexion miConexion = new Conexion();
            using (SqlConnection cn = miConexion.ObtenerConexion())
            {
                cn.Open();
                string query = "SELECT id_rol, nombre FROM roles ORDER BY nombre";
                using (SqlDataAdapter da = new SqlDataAdapter(query, cn))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // Unificamos la búsqueda de activos e inactivos en un solo método
        public DataTable ObtenerUsuarios(string nombre, int idRol, object? fechaDesde, object? fechaHasta, int estadoEliminado)
        {
            DataTable dt = new DataTable();
            Conexion miConexion = new Conexion();
            using (SqlConnection cn = miConexion.ObtenerConexion())
            {
                cn.Open();
                string query = @"
                    SELECT u.id_usuario, p.dni, p.nombre, p.apellido,
                           u.nombre_usuario, u.correo, p.direccion, p.telefono,
                           p.sexo, p.fecha_nacimiento, r.nombre AS rol,
                           u.creado_en AS fecha_alta, p.id_persona
                    FROM usuarios u
                    INNER JOIN persona p ON u.id_persona = p.id_persona
                    INNER JOIN roles r ON u.id_rol = r.id_rol
                    WHERE u.eliminado = @estadoEliminado
                      AND (@nombre = '' OR p.nombre LIKE '%' + @nombre + '%' OR p.apellido LIKE '%' + @nombre + '%')
                      AND (@idRol = 0 OR u.id_rol = @idRol)
                      AND (@fechaDesde IS NULL OR u.creado_en >= @fechaDesde)
                      AND (@fechaHasta IS NULL OR u.creado_en <= @fechaHasta)
                    ORDER BY u.id_usuario";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@estadoEliminado", estadoEliminado);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@idRol", idRol);
                    cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@fechaHasta", fechaHasta ?? DBNull.Value);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool ExisteDato(string columna, string tabla, string valor, string columnaExcluir, int idExcluir)
        {
            Conexion miConexion = new Conexion();
            using (SqlConnection cn = miConexion.ObtenerConexion())
            {
                cn.Open();
                string query = $"SELECT COUNT(*) FROM {tabla} WHERE {columna} = @valor AND {columnaExcluir} <> @idExcluir";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@valor", valor);
                    cmd.Parameters.AddWithValue("@idExcluir", idExcluir);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public void GuardarNuevoUsuario(string nom, string ape, string dni, string dir, string tel, string sex, DateTime nac, string mail, int rol, string user, string hash)
        {
            Conexion miConexion = new Conexion();
            using (SqlConnection cn = miConexion.ObtenerConexion())
            {
                cn.Open();
                string sqlPersona = @"INSERT INTO persona (nombre, apellido, dni, direccion, telefono, sexo, fecha_nacimiento, correo)
                                      VALUES (@nombre, @apellido, @dni, @direccion, @telefono, @sexo, @fechaNac, @correo);
                                      SELECT SCOPE_IDENTITY();";
                int idPersona;
                using (SqlCommand cmd = new SqlCommand(sqlPersona, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nom);
                    cmd.Parameters.AddWithValue("@apellido", ape);
                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.Parameters.AddWithValue("@direccion", dir);
                    cmd.Parameters.AddWithValue("@telefono", tel);
                    cmd.Parameters.AddWithValue("@sexo", sex);
                    cmd.Parameters.AddWithValue("@fechaNac", nac);
                    cmd.Parameters.AddWithValue("@correo", mail);
                    idPersona = Convert.ToInt32(cmd.ExecuteScalar());
                }

                string sqlUsuario = @"INSERT INTO usuarios (id_persona, id_rol, correo, nombre_usuario, contrasena)
                                      VALUES (@idPersona, @idRol, @correo, @usuario, @contrasena)";
                using (SqlCommand cmd = new SqlCommand(sqlUsuario, cn))
                {
                    cmd.Parameters.AddWithValue("@idPersona", idPersona);
                    cmd.Parameters.AddWithValue("@idRol", rol);
                    cmd.Parameters.AddWithValue("@correo", mail);
                    cmd.Parameters.AddWithValue("@usuario", user);
                    cmd.Parameters.AddWithValue("@contrasena", hash);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ModificarUsuario(int idPersona, int idUsuario, string nom, string ape, string dni, string dir, string tel, string sex, DateTime nac, string mail, int rol, string user, string hash, bool cambiaClave)
        {
            Conexion miConexion = new Conexion();
            using (SqlConnection cn = miConexion.ObtenerConexion())
            {
                cn.Open();
                string sqlPersona = @"UPDATE persona SET nombre = @nombre, apellido = @apellido, dni = @dni,
                                      direccion = @direccion, telefono = @telefono, sexo = @sexo,
                                      fecha_nacimiento = @fechaNac, correo = @correo WHERE id_persona = @idPersona";
                using (SqlCommand cmd = new SqlCommand(sqlPersona, cn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nom);
                    cmd.Parameters.AddWithValue("@apellido", ape);
                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.Parameters.AddWithValue("@direccion", dir);
                    cmd.Parameters.AddWithValue("@telefono", tel);
                    cmd.Parameters.AddWithValue("@sexo", sex);
                    cmd.Parameters.AddWithValue("@fechaNac", nac);
                    cmd.Parameters.AddWithValue("@correo", mail);
                    cmd.Parameters.AddWithValue("@idPersona", idPersona);
                    cmd.ExecuteNonQuery();
                }

                string sqlUsuario = @"UPDATE usuarios SET id_rol = @idRol, correo = @correo, nombre_usuario = @usuario,
                                      eliminado = 0, eliminado_en = NULL " + (cambiaClave ? ", contrasena = @contrasena " : "") +
                                      "WHERE id_usuario = @idUsuario";
                using (SqlCommand cmd = new SqlCommand(sqlUsuario, cn))
                {
                    cmd.Parameters.AddWithValue("@idRol", rol);
                    cmd.Parameters.AddWithValue("@correo", mail);
                    cmd.Parameters.AddWithValue("@usuario", user);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    if (cambiaClave) cmd.Parameters.AddWithValue("@contrasena", hash);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void BajaLogicaUsuario(int idUsuario)
        {
            Conexion miConexion = new Conexion();
            using (SqlConnection cn = miConexion.ObtenerConexion())
            {
                cn.Open();
                string query = "UPDATE usuarios SET eliminado = 1, eliminado_en = GETDATE() WHERE id_usuario = @idUsuario";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
