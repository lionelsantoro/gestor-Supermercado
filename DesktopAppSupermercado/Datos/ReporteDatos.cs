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
                        v.numero_ticket AS NumeroTicket,
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
                    ORDER BY v.numero_ticket ASC;";

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

        // 1. Obtener el detalle de ventas para dgvVentas
        public DataTable ObtenerVentasParaGrilla(DateTime fechaDesde, DateTime fechaHasta)
        {
            DataTable tabla = new DataTable();
            Conexion miConexion = new Conexion();

            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();
                string query = @"
                    SELECT 
                        v.numero_ticket AS numero_ticket,
                        v.monto_total AS monto_total,
                        v.creado_en AS creado_en
                    FROM dbo.ventas v
                    WHERE v.creado_en >= @FechaDesde 
                      AND v.creado_en <= @FechaHasta
                    ORDER BY v.numero_ticket ASC;";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@FechaDesde", SqlDbType.DateTime).Value = fechaDesde;
                    comando.Parameters.Add("@FechaHasta", SqlDbType.DateTime).Value = fechaHasta;

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        tabla.Load(lector);
                    }
                }
            }

            return tabla;
        }

        // 2. Obtener el resumen por cajero para dgvCajero
        public DataTable ObtenerResumenCajerosParaGrilla(DateTime fechaDesde, DateTime fechaHasta)
        {
            DataTable tabla = new DataTable();
            Conexion miConexion = new Conexion();

            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();
                string query = @"
                    SELECT 
                        (p.nombre + ' ' + p.apellido) AS nombre_cajero,
                        COUNT(v.id_venta) AS cantidad_ventas,
                        SUM(v.monto_total) AS monto_recaudado
                    FROM dbo.ventas v
                    INNER JOIN dbo.usuarios u ON v.id_usuario = u.id_usuario
                    INNER JOIN dbo.persona p ON u.id_persona = p.id_persona
                    WHERE v.creado_en >= @FechaDesde 
                      AND v.creado_en <= @FechaHasta
                    GROUP BY p.nombre, p.apellido
                    ORDER BY monto_recaudado DESC;";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@FechaDesde", SqlDbType.DateTime).Value = fechaDesde;
                    comando.Parameters.Add("@FechaHasta", SqlDbType.DateTime).Value = fechaHasta;

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        tabla.Load(lector);
                    }
                }
            }

            return tabla;
        }

        // 3. Obtener ganancia por categoría para dgvCategoria y para el PDF
        public DataTable ObtenerCategoriasPorRango(DateTime fechaDesde, DateTime fechaHasta)
        {
            DataTable tabla = new DataTable();
            Conexion miConexion = new Conexion();

            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();

                string query = @"
            SELECT 
                c.nombre AS nombre_categoria,
                ISNULL(SUM(dv.subtotal), 0) AS ganancia_generada
            FROM dbo.categorias c
            LEFT JOIN dbo.productos p 
                ON c.id_categoria = p.id_categoria 
               AND ISNULL(p.eliminado, 0) = 0
            LEFT JOIN dbo.detalle_venta dv 
                ON p.id_producto = dv.id_producto
               AND dv.creado_en >= @FechaDesde 
               AND dv.creado_en <= @FechaHasta
            WHERE ISNULL(c.eliminado, 0) = 0
            GROUP BY c.id_categoria, c.nombre
            ORDER BY ganancia_generada DESC, c.nombre ASC;";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@FechaDesde", SqlDbType.DateTime).Value = fechaDesde;
                    comando.Parameters.Add("@FechaHasta", SqlDbType.DateTime).Value = fechaHasta;

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        tabla.Load(lector);
                    }
                }
            }

            return tabla;
        }

        // 4. Obtener productos con formato listo para mostrar en dgvProductos
        public DataTable ObtenerProductosParaGrilla(DateTime fechaDesde, DateTime fechaHasta)
        {
            DataTable tabla = new DataTable();
            Conexion miConexion = new Conexion();

            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();

                // Formatea cantidad_vendida y stock_sobrante distinguiendo Kg vs Unidad
                string query = @"
            SELECT 
                p.descripcion AS nombre_producto,
                CASE 
                    WHEN LOWER(LTRIM(RTRIM(ISNULL(p.unidad_medida, '')))) = 'kg' 
                        THEN FORMAT(ISNULL(SUM(dv.cantidad), 0), '0.###') + ' Kg'
                    ELSE FORMAT(ISNULL(SUM(dv.cantidad), 0), '0') + ' u.'
                END AS cantidad_vendida,
                CASE 
                    WHEN LOWER(LTRIM(RTRIM(ISNULL(p.unidad_medida, '')))) = 'kg' 
                        THEN FORMAT(p.stock, '0.###') + ' Kg'
                    ELSE FORMAT(p.stock, '0') + ' u.'
                END AS stock_sobrante,
                ISNULL(SUM(dv.subtotal), 0) AS ganancia_generada
            FROM dbo.productos p
            LEFT JOIN dbo.detalle_venta dv 
                ON p.id_producto = dv.id_producto
               AND dv.creado_en >= @FechaDesde 
               AND dv.creado_en <= @FechaHasta
            WHERE ISNULL(p.eliminado, 0) = 0
            GROUP BY p.id_producto, p.descripcion, p.stock, p.unidad_medida
            ORDER BY ganancia_generada DESC, p.descripcion ASC;";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@FechaDesde", SqlDbType.DateTime).Value = fechaDesde;
                    comando.Parameters.Add("@FechaHasta", SqlDbType.DateTime).Value = fechaHasta;

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        tabla.Load(lector);
                    }
                }
            }

            return tabla;
        }

        // 5. Obtener todos los datos crudos de productos para armar las 2 tablas del PDF (Vendidos y No Vendidos)
        public DataTable ObtenerProductosDetalladoPorRango(DateTime fechaDesde, DateTime fechaHasta)
        {
            DataTable tabla = new DataTable();
            Conexion miConexion = new Conexion();

            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();

                string query = @"
            SELECT 
                p.id_producto AS IdProducto,
                p.descripcion AS NombreProducto,
                c.nombre AS NombreCategoria,
                p.precio AS PrecioUnitario,
                ISNULL(p.unidad_medida, 'Unidad') AS UnidadMedida,
                p.stock AS StockSobrante,
                ISNULL(SUM(dv.cantidad), 0) AS CantidadVendida,
                ISNULL(SUM(dv.subtotal), 0) AS GananciaGenerada
            FROM dbo.productos p
            INNER JOIN dbo.categorias c ON p.id_categoria = c.id_categoria
            LEFT JOIN dbo.detalle_venta dv 
                ON p.id_producto = dv.id_producto
               AND dv.creado_en >= @FechaDesde 
               AND dv.creado_en <= @FechaHasta
            WHERE ISNULL(p.eliminado, 0) = 0
            GROUP BY 
                p.id_producto, 
                p.descripcion, 
                c.nombre, 
                p.precio, 
                p.unidad_medida, 
                p.stock
            ORDER BY GananciaGenerada DESC, p.descripcion ASC;";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@FechaDesde", SqlDbType.DateTime).Value = fechaDesde;
                    comando.Parameters.Add("@FechaHasta", SqlDbType.DateTime).Value = fechaHasta;

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        tabla.Load(lector);
                    }
                }
            }

            return tabla;
        }

        // 6. Obtener clientes y sus ventas (incluyendo los que no tienen ventas) para dgvCliente
        public DataTable ObtenerClientesParaGrilla(DateTime fechaDesde, DateTime fechaHasta)
        {
            DataTable tabla = new DataTable();
            Conexion miConexion = new Conexion();

            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();

                string query = @"
            SELECT 
                (p.nombre + ' ' + p.apellido) AS nombre_cliente,
                ISNULL(p.telefono, 'Sin teléfono') AS telefono,
                ISNULL(p.correo, 'Sin correo') AS correo,
                COUNT(v.id_venta) AS cantidad_ventas,
                ISNULL(SUM(v.monto_total), 0) AS monto_recaudado
            FROM dbo.clientes c
            INNER JOIN dbo.persona p 
                ON c.id_persona = p.id_persona
            LEFT JOIN dbo.ventas v 
                ON c.id_cliente = v.id_cliente
               AND v.creado_en >= @FechaDesde 
               AND v.creado_en <= @FechaHasta
            WHERE ISNULL(p.eliminado, 0) = 0
            GROUP BY 
                c.id_cliente,
                p.nombre,
                p.apellido,
                p.telefono,
                p.correo
            ORDER BY monto_recaudado DESC, nombre_cliente ASC;";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@FechaDesde", SqlDbType.DateTime).Value = fechaDesde;
                    comando.Parameters.Add("@FechaHasta", SqlDbType.DateTime).Value = fechaHasta;

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        tabla.Load(lector);
                    }
                }
            }

            return tabla;
        }

        // 7. Obtener clientes con su fecha de alta (c.creado_en) para las métricas y tablas del PDF
        public DataTable ObtenerClientesDetalladoPorRango(DateTime fechaDesde, DateTime fechaHasta)
        {
            DataTable tabla = new DataTable();
            Conexion miConexion = new Conexion();

            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();

                string query = @"
            SELECT 
                c.id_cliente AS IdCliente,
                c.creado_en AS FechaRegistroCliente,
                (p.nombre + ' ' + p.apellido) AS NombreCliente,
                ISNULL(p.telefono, 'Sin teléfono') AS Telefono,
                ISNULL(p.correo, 'Sin correo') AS Correo,
                COUNT(v.id_venta) AS CantidadVentas,
                ISNULL(SUM(v.monto_total), 0) AS MontoRecaudado
            FROM dbo.clientes c
            INNER JOIN dbo.persona p 
                ON c.id_persona = p.id_persona
            LEFT JOIN dbo.ventas v 
                ON c.id_cliente = v.id_cliente
               AND v.creado_en >= @FechaDesde 
               AND v.creado_en <= @FechaHasta
            WHERE ISNULL(p.eliminado, 0) = 0
            GROUP BY 
                c.id_cliente,
                c.creado_en,
                p.nombre,
                p.apellido,
                p.telefono,
                p.correo
            ORDER BY MontoRecaudado DESC, NombreCliente ASC;";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.Add("@FechaDesde", SqlDbType.DateTime).Value = fechaDesde;
                    comando.Parameters.Add("@FechaHasta", SqlDbType.DateTime).Value = fechaHasta;

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
