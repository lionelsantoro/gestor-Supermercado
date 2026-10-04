using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopAppSupermercado.Entidades
{
    public class Entidadescs
    {
        // Entidad para mapear el producto consultado
        public class Producto
        {
            public int IdProducto { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public decimal Precio { get; set; }
            public int Stock { get; set; }
        }

        // Entidad específica para mostrar en el DataGridView de la Vista
        public class DetalleVentaVista
        {
            public int IdProducto { get; set; }
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
            public decimal Precio_Unitario { get; set; }
            public decimal Subtotal { get; set; }
        }
    }
}
