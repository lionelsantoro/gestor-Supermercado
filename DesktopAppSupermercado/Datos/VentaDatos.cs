using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopAppSupermercado.Datos
{
    internal class VentaDatos
    {
        // Obtiene el próximo ID de venta consultando el valor actual del IDENTITY
        public int ObtenerProximoIdVenta()
        {
            Conexion miConexion = new Conexion();
            int proximoId = 1;

            // Usa tu clase de Conexion existente
            using (SqlConnection con = miConexion.ObtenerConexion())
            {
                // IDENT_CURRENT trae el último identity creado. Le sumamos 1.
                // ISNULL maneja el caso donde la tabla esté vacía.
                string query = "SELECT ISNULL(IDENT_CURRENT('ventas'), 0) + 1";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    proximoId = Convert.ToInt32(result);
                }
            }
            return proximoId;
        }
    }
}
