using DesktopAppSupermercado.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel;
using System.Data;

namespace DesktopAppSupermercado.Datos
{
    internal class VentaDatos
    {
        public int ObtenerNumeroTicketEstimado()
        {
            Conexion miConexion = new Conexion();

            using (SqlConnection con = miConexion.ObtenerConexion())
            {
                con.Open();

                string query = @"
            SELECT ultimo_numero + 1
            FROM dbo.ControlNumeracionTicket
            WHERE id = 1;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    object resultado = cmd.ExecuteScalar();

                    if (resultado == null || resultado == DBNull.Value)
                    {
                        throw new Exception(
                            "No se pudo consultar el próximo número de ticket.");
                    }

                    return Convert.ToInt32(resultado);
                }
            }
        }

        public int RegistrarVentaCompleta(
            int idUsuario,
            int idMedioPago,
            decimal montoTotal,
            BindingList<DetalleVentaVista> detalles)
        {
            if (detalles == null || detalles.Count == 0)
                throw new Exception("No hay productos para registrar.");

            Conexion miConexion = new Conexion();

            using (SqlConnection con = miConexion.ObtenerConexion())
            {
                con.Open();

                using (SqlTransaction transaccion = con.BeginTransaction())
                {
                    try
                    {
                        // 1. Generar el ticket dentro de la transacción.
                        string queryTicket = @"
                    UPDATE dbo.ControlNumeracionTicket
                    SET ultimo_numero = ultimo_numero + 1
                    OUTPUT INSERTED.ultimo_numero
                    WHERE id = 1;";

                        int numeroTicket;

                        using (SqlCommand cmdTicket =
                            new SqlCommand(queryTicket, con, transaccion))
                        {
                            object resultado = cmdTicket.ExecuteScalar();

                            if (resultado == null || resultado == DBNull.Value)
                                throw new Exception(
                                    "No se pudo generar el número de ticket.");

                            numeroTicket = Convert.ToInt32(resultado);
                        }

                        // 2. Insertar la venta.
                        string queryVenta = @"
                    INSERT INTO dbo.ventas
                        (numero_ticket, id_usuario,
                         id_medio_pago, monto_total)
                    OUTPUT INSERTED.id_venta
                    VALUES
                        (@numeroTicket, @idUsuario,
                         @idMedioPago, @montoTotal);";

                        int idVentaGenerada;

                        using (SqlCommand cmdVenta =
                            new SqlCommand(queryVenta, con, transaccion))
                        {
                            cmdVenta.Parameters.Add(
                                "@numeroTicket", SqlDbType.Int).Value = numeroTicket;

                            cmdVenta.Parameters.Add(
                                "@idUsuario", SqlDbType.Int).Value = idUsuario;

                            cmdVenta.Parameters.Add(
                                "@idMedioPago", SqlDbType.Int).Value = idMedioPago;

                            SqlParameter parametroMonto =
                                cmdVenta.Parameters.Add(
                                    "@montoTotal", SqlDbType.Decimal);

                            parametroMonto.Precision = 10;
                            parametroMonto.Scale = 2;
                            parametroMonto.Value = montoTotal;

                            idVentaGenerada =
                                Convert.ToInt32(cmdVenta.ExecuteScalar());
                        }

                        // 3. Preparar las consultas de detalles y stock.
                        string queryDetalle = @"
                    INSERT INTO dbo.detalle_venta
                        (id_venta, id_producto, cantidad,
                         precio_unitario, subtotal)
                    VALUES
                        (@idVenta, @idProducto, @cantidad,
                         @precioUnitario, @subtotal);";

                        string queryStock = @"
                    UPDATE dbo.productos
                    SET stock = stock - @cantidad
                    OUTPUT INSERTED.id_producto
                    WHERE id_producto = @idProducto
                      AND stock >= @cantidad;";
                                                
                        foreach (var item in detalles)
                        {
                            if (item.Cantidad <= 0)
                            {
                                throw new Exception(
                                    $"La cantidad del producto '{item.Nombre}' debe ser mayor que cero.");
                            }

                            // 4. Descontar el stock y comprobar que alcanzaba.
                            using (SqlCommand cmdStock =
                                new SqlCommand(queryStock, con, transaccion))
                            {
                                cmdStock.Parameters.Add(
                                    "@cantidad", SqlDbType.Int).Value = item.Cantidad;

                                cmdStock.Parameters.Add(
                                    "@idProducto", SqlDbType.Int).Value =
                                    item.IdProducto;

                                object resultadoStock = cmdStock.ExecuteScalar();

                                if (resultadoStock == null ||
                                    resultadoStock == DBNull.Value)
                                {
                                    throw new Exception(
                                        $"Stock insuficiente o producto inexistente: " +
                                        $"{item.Nombre}.");
                                }
                            }

                            // 5. Insertar el detalle de la venta.
                            using (SqlCommand cmdDetalle =
                                new SqlCommand(queryDetalle, con, transaccion))
                            {
                                cmdDetalle.Parameters.Add(
                                    "@idVenta", SqlDbType.Int).Value = idVentaGenerada;

                                cmdDetalle.Parameters.Add(
                                    "@idProducto", SqlDbType.Int).Value =
                                    item.IdProducto;

                                cmdDetalle.Parameters.Add(
                                    "@cantidad", SqlDbType.Int).Value = item.Cantidad;

                                SqlParameter precio =
                                    cmdDetalle.Parameters.Add(
                                        "@precioUnitario", SqlDbType.Decimal);

                                precio.Precision = 10;
                                precio.Scale = 2;
                                precio.Value = item.Precio_Unitario;

                                SqlParameter subtotal =
                                    cmdDetalle.Parameters.Add(
                                        "@subtotal", SqlDbType.Decimal);

                                subtotal.Precision = 10;
                                subtotal.Scale = 2;
                                subtotal.Value = item.Subtotal;

                                cmdDetalle.ExecuteNonQuery();
                            }
                        }

                        // 6. Confirmar la venta, los detalles,
                        // el stock y el contador juntos.
                        transaccion.Commit();

                        return numeroTicket;
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            transaccion.Rollback();
                        }
                        catch
                        {
                            // Evitar que un error de rollback oculte el original.
                        }

                        throw new Exception(
                            "Error al procesar la venta: " + ex.Message, ex);
                    }
                }
            }
        }

    }
}