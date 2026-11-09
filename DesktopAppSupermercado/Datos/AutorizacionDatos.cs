using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DesktopAppSupermercado.Datos
{
    public class AutorizacionDatos
    {
        public bool ExisteCodigoAutorizacionSupervisor(string codigo)
        {
            Conexion miConexion = new Conexion();

            using (SqlConnection con = miConexion.ObtenerConexion())
            {
                con.Open();

                string query = @"
                    SELECT CASE
                        WHEN EXISTS (
                            SELECT 1
                            FROM dbo.usuarios
                            WHERE codigo_autorizacion = @codigo
                              AND ISNULL(eliminado, 0) = 0
                        )
                        THEN 1
                        ELSE 0
                    END;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(
                        "@codigo", SqlDbType.VarChar, 4).Value = codigo;

                    int resultado = Convert.ToInt32(
                        cmd.ExecuteScalar());

                    return resultado == 1;
                }
            }
        }
    }
}
