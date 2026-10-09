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

        public Producto ValidarYObtenerProductoParaVenta(
             string nombreSeleccionado,
             int cantidadSolicitada)
        {
            if (cantidadSolicitada <= 0)
                throw new Exception(
                    "La cantidad debe ser mayor a cero.");

            Producto producto =
                datos.ObtenerProductoPorNombre(nombreSeleccionado);

            if (producto == null)
                throw new Exception(
                    "El producto no existe o fue eliminado.");

            bool esKg = string.Equals(
                producto.UnidadMedida?.Trim(),
                "Kg",
                StringComparison.OrdinalIgnoreCase);

            // Si es Kg, la cantidad ingresada está en gramos.
            // El stock está expresado en kg.
            decimal cantidadEnStock = esKg
                ? cantidadSolicitada / 1000m
                : cantidadSolicitada;

            if (cantidadEnStock > producto.Stock)
            {
                string disponible = esKg
                    ? $"{producto.Stock * 1000m:0} gramos"
                    : $"{producto.Stock:0} unidades";

                throw new Exception(
                    $"Stock insuficiente para {producto.Nombre}. " +
                    $"Disponible: {disponible}.");
            }

            return producto;
        }
    }
}
