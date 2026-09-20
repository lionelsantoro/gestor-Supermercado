using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopAppSupermercado.Datos
{
    public class LoginDatos
    {
        public int ValidarUsuario(string usuario, string contrasenaHash)
        {
            int idRol = 0; // 0 significará que no se encontró el usuario
            Conexion miConexion = new Conexion();

            using (SqlConnection conexionFisica = miConexion.ObtenerConexion())
            {
                conexionFisica.Open();
                string query = @"SELECT id_rol FROM usuarios 
                                 WHERE nombre_usuario = @usuario 
                                   AND contrasena = @contrasena 
                                   AND eliminado = 0";

                using (SqlCommand comando = new SqlCommand(query, conexionFisica))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@contrasena", contrasenaHash);

                    object resultado = comando.ExecuteScalar();

                    if (resultado != null)
                    {
                        idRol = Convert.ToInt32(resultado);
                    }
                }
            }
            return idRol;
        }
    }
}
