using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DesktopAppSupermercado.Datos
{
    public class ReporteDatos
    {
        public DataTable ObtenerVentasPorRango(DateTime fechaDesde, DateTime fechaHasta)
        {
            DataTable tabla = new DataTable();
            Conexion miConexion = new Conexion();

            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();

                string query = @"
                    SELECT 
                        v.id_venta AS IdVenta,
                        v.creado_en AS FechaHora,
                        u.id_usuario AS IdUsuario,
                        u.nombre_usuario AS NombreUsuario,
                        (p.nombre + ' ' + p.apellido) AS NombreCajero,
                        v.monto_total AS MontoTotal
                    FROM dbo.ventas v
                    INNER JOIN dbo.usuarios u ON v.id_usuario = u.id_usuario
                    INNER JOIN dbo.persona p ON u.id_persona = p.id_persona
                    WHERE v.creado_en >= @FechaDesde 
                      AND v.creado_en <= @FechaHasta
                    ORDER BY v.creado_en DESC;";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add(
                        "@FechaDesde",
                        SqlDbType.DateTime).Value = fechaDesde;

                    comando.Parameters.Add(
                        "@FechaHasta",
                        SqlDbType.DateTime).Value = fechaHasta;

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        tabla.Load(lector);
                    }
                }
            }

            return tabla;
        }
    }
}
