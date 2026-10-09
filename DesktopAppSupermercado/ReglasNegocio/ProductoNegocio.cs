using DesktopAppSupermercado.Datos;
using System;
using System.Collections.Generic;
using System.Text;
using DesktopAppSupermercado.Entidades;

namespace DesktopAppSupermercado.ReglasNegocio
{
    public class ProductoNegocio
    {
        private ProductoDatos datos = new ProductoDatos();

        public List<string> ObtenerListaParaBuscador()
        {
            return datos.ObtenerDescripcionesAutocomplete();
        }

        public Producto ValidarYObtenerProductoParaVenta(string nombreSeleccionado, int cantidadSolicitada)
        {
            // 1. Validar la cantidad ingresada
            if (cantidadSolicitada <= 0)
                throw new Exception("La cantidad debe ser mayor a cero.");

            // 2. Traer el producto de la BD a través de la capa de datos
            Producto producto = datos.ObtenerProductoPorNombre(nombreSeleccionado);

            // 3. Validar existencia
            if (producto == null)
                throw new Exception("El producto no existe o fue eliminado.");

            // 4. Validar Stock contra la cantidad solicitada
            if (producto.Stock < cantidadSolicitada)
                throw new Exception($"Stock insuficiente. Solo quedan {producto.Stock} unidades de este producto en el sistema.");

            // Si pasa todas las validaciones, devolvemos el producto entero a la vista
            return producto;
        }
    }
}
