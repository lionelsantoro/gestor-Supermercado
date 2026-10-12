using DesktopAppSupermercado.Datos;
using System;
using System.Data;

namespace DesktopAppSupermercado.ReglasNegocio
{
    public class GestionCategoriaNegocio
    {
        private GestionCategoriaDatos datos = new GestionCategoriaDatos();

        public DataTable ListarCategorias()
        {
            return datos.ListarCategorias();
        }

        public void GuardarCategoria(int idCategoria, string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de la categoría es obligatorio.");

            if (idCategoria == 0)
            {
                // Si el ID es 0, es una categoría NUEVA, la creamos normalmente.
                datos.InsertarCategoria(nombre.Trim());
            }
            else
            {
                // REGLA ESTRICTA: Si ya existe y se intenta modificar, verificamos si tiene productos.
                if (datos.TieneProductosActivos(idCategoria))
                {
                    throw new InvalidOperationException("No se puede modificar esta categoría porque tiene productos asociados.");
                }

                datos.ModificarCategoria(idCategoria, nombre.Trim());
            }
        }

        public void EliminarCategoria(int idCategoria)
        {
            if (datos.TieneProductosActivos(idCategoria))
                throw new InvalidOperationException("No se puede eliminar: existen productos activos usando esta categoría.");

            datos.EliminarCategoriaLogico(idCategoria);
        }
    }
}