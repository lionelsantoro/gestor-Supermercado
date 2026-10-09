using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DesktopAppSupermercado.Entidades
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
        public string UnidadMedida { get; set; }
    }

    public class DetalleVentaVista
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }

        // Para productos Kg: gramos ingresados por el cajero.
        // Para productos Unidad: cantidad de unidades.
        public int Cantidad { get; set; }

        // Para Kg: precio por kilogramo.
        // Para Unidad: precio por unidad.
        public decimal Precio_Unitario { get; set; }
        public decimal Subtotal { get; set; }

        // Stock expresado en la unidad base del producto:
        // Kg para pesables, unidades para los demás.
        public decimal StockActual { get; set; }
        public string UnidadMedida { get; set; }
    }

    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string NombreUsuario { get; set; }
    }

    public static class Sesion
    {
        public static Usuario UsuarioActual { get; set; }

        public static void CerrarSesion()
        {
            UsuarioActual = null;
        }
    }

    public class MedioPago
    {
        public int IdMedioPago { get; set; }
        public string Nombre { get; set; }
    }

    public class VentaEnMemoria
    {
        public int NumeroTicketEstimado { get; set; }
        public int IdUsuario { get; set; }
        public int IdMedioPago { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoTotal { get; set; }

        public BindingList<DetalleVentaVista> Detalles { get; set; }
            = new BindingList<DetalleVentaVista>();
    }
}
