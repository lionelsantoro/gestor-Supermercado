using DesktopAppSupermercado.Datos;
using DesktopAppSupermercado.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

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
            string descripcionSeleccionada,
            int cantidadSolicitada)
        {
            if (cantidadSolicitada <= 0)
            {
                throw new Exception(
                    "La cantidad debe ser mayor a cero.");
            }

            Producto producto =
                datos.ObtenerProductoPorDescripcion(
                    descripcionSeleccionada);

            if (producto == null)
            {
                throw new Exception(
                    "El producto no existe o fue eliminado.");
            }

            bool esKg = string.Equals(
                producto.UnidadMedida?.Trim(),
                "Kg",
                StringComparison.OrdinalIgnoreCase);

            // Para Kg, la cantidad se ingresa en gramos.
            // Para Unidad, se ingresa la cantidad de unidades.
            decimal cantidadEnUnidadBase = esKg
                ? cantidadSolicitada / 1000m
                : cantidadSolicitada;

            if (cantidadEnUnidadBase > producto.Stock)
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

        public DataTable BuscarProductosParaSeleccion(
    string filtro,
    int? idCategoria = null)
        {
            return datos.BuscarProductosParaSeleccion(
                filtro?.Trim() ?? "",
                idCategoria);
        }
    }
}