using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopAppSupermercado.Entidades
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }

    public class DetalleVentaVista
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_Unitario { get; set; }
        public decimal Subtotal { get; set; }
        public int StockActual { get; set; }
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
}
