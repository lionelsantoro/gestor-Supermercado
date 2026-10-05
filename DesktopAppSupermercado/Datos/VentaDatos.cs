using DesktopAppSupermercado.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DesktopAppSupermercado.Datos
{
    internal class VentaDatos
    {
        public int ObtenerProximoIdVenta(int idCajero)
        {
            int proximoId = 1;
            Conexion miConexion = new Conexion();

            using (SqlConnection con = miConexion.ObtenerConexion())
            {
                con.Open();
                // Verificamos si este cajero ya tiene ventas
                string queryCheck = "SELECT COUNT(id_venta) FROM ventas WHERE id_usuario = @idCajero";
                using (SqlCommand cmdCheck = new SqlCommand(queryCheck, con))
                {
                    cmdCheck.Parameters.AddWithValue("@idCajero", idCajero);
                    int cantidadVentas = Convert.ToInt32(cmdCheck.ExecuteScalar());

                    if (cantidadVentas == 0)
                    {
                        proximoId = 1;
                    }
                    else
                    {
                        string queryNext = "SELECT ISNULL(IDENT_CURRENT('ventas'), 0) + 1";
                        using (SqlCommand cmdNext = new SqlCommand(queryNext, con))
                        {
                            object result = cmdNext.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                                proximoId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            return proximoId;
        }

        public void RegistrarVentaCompleta(int idUsuario, int idMedioPago, decimal montoTotal, BindingList<DetalleVentaVista> detalles)
        {
            Conexion miConexion = new Conexion();
            using (SqlConnection con = miConexion.ObtenerConexion())
            {
                con.Open();
                using (SqlTransaction transaccion = con.BeginTransaction())
                {
                    try
                    {
                        // 1. Insertar la Venta principal
                        string queryVenta = @"INSERT INTO ventas (id_usuario, id_medio_pago, monto_total) 
                                              OUTPUT INSERTED.id_venta 
                                              VALUES (@idUsuario, @idMedioPago, @montoTotal)";

                        SqlCommand cmdVenta = new SqlCommand(queryVenta, con, transaccion);
                        cmdVenta.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmdVenta.Parameters.AddWithValue("@idMedioPago", idMedioPago);
                        cmdVenta.Parameters.AddWithValue("@montoTotal", montoTotal);

                        int idVentaGenerada = Convert.ToInt32(cmdVenta.ExecuteScalar());

                        // Query para Detalle y Query para restar Stock
                        string queryDetalle = @"INSERT INTO detalle_venta (id_venta, id_producto, cantidad, precio_unitario, subtotal) 
                                                VALUES (@idVenta, @idProducto, @cantidad, @precioUnitario, @subtotal)";
                        string queryStock = @"UPDATE productos SET stock = stock - @cantidad WHERE id_producto = @idProducto";

                        foreach (var item in detalles)
                        {
                            SqlCommand cmdDetalle = new SqlCommand(queryDetalle, con, transaccion);
                            cmdDetalle.Parameters.AddWithValue("@idVenta", idVentaGenerada);
                            cmdDetalle.Parameters.AddWithValue("@idProducto", item.IdProducto);
                            cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                            cmdDetalle.Parameters.AddWithValue("@precioUnitario", item.Precio_Unitario);
                            cmdDetalle.Parameters.AddWithValue("@subtotal", item.Subtotal);
                            cmdDetalle.ExecuteNonQuery();

                            // Restar stock
                            SqlCommand cmdStock = new SqlCommand(queryStock, con, transaccion);
                            cmdStock.Parameters.AddWithValue("@cantidad", item.Cantidad);
                            cmdStock.Parameters.AddWithValue("@idProducto", item.IdProducto);
                            cmdStock.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        throw new Exception("Error al procesar la BD: " + ex.Message);
                    }
                }
            }
        }
    }
            
}
