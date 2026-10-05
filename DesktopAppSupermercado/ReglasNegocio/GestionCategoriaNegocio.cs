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
                datos.InsertarCategoria(nombre.Trim());
            else
                datos.ModificarCategoria(idCategoria, nombre.Trim());
        }

        public void EliminarCategoria(int idCategoria)
        {
            // Regla de negocio: No se puede borrar si hay productos usándola
            if (datos.TieneProductosActivos(idCategoria))
                throw new InvalidOperationException("No se puede eliminar: existen productos activos usando esta categoría.");

            datos.EliminarCategoriaLogico(idCategoria);
        }
    }
}