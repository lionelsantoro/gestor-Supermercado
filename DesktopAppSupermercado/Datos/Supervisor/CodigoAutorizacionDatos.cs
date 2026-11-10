using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopAppSupermercado.Datos.Supervisor
{
    public class CodigoAutorizacionDatos
    {
        public string ObtenerCodigoAutorizacion(
            int idUsuario,
            string dni,
            string contrasenaHash)
        {
            string codigo = null;

            Conexion miConexion = new Conexion();

            using (SqlConnection conexionFisica =
                   miConexion.ObtenerConexion())
            {
                conexionFisica.Open();

                string query = @"
                    SELECT u.codigo_autorizacion
                    FROM dbo.usuarios u
                    INNER JOIN dbo.persona p
                        ON u.id_persona = p.id_persona
                    WHERE u.id_usuario = @idUsuario
                      AND REPLACE(
                            REPLACE(
                                REPLACE(CONVERT(VARCHAR(20), p.dni), '.', ''),
                            ' ', ''),
                          '-', '') = @dni
                      AND u.contrasena = @contrasena
                      AND u.id_rol = 4
                      AND u.codigo_autorizacion IS NOT NULL
                      AND u.eliminado = 0";

                using (SqlCommand comando =
                       new SqlCommand(query, conexionFisica))
                {
                    comando.Parameters.AddWithValue(
                        "@idUsuario", idUsuario);

                    comando.Parameters.AddWithValue(
                        "@dni", dni);

                    comando.Parameters.AddWithValue(
                        "@contrasena", contrasenaHash);

                    object resultado = comando.ExecuteScalar();

                    if (resultado != null && resultado != DBNull.Value)
                    {
                        codigo = Convert.ToString(resultado).Trim();

                        if (int.TryParse(codigo, out int codigoNumerico))
                        {
                            codigo = codigoNumerico.ToString("D4");
                        }
                    }
                }
            }

            return codigo;
        }
    }
}
