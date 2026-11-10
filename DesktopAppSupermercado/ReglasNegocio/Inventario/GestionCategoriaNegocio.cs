using DesktopAppSupermercado.Datos.Inventario;
using System;
using System.Data;

namespace DesktopAppSupermercado.ReglasNegocio.Inventario
{
    public class GestionCategoriaNegocio
    {
        private GestionCategoriaDatos datos = new GestionCategoriaDatos();

        public DataTable ListarCategorias()
        {
            return datos.ListarCategorias();
        }

        // Crea o modifica la categoría según el id; exige nombre y no deja renombrar una categoría con productos.
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

        // Da de baja lógica la categoría, pero solo si no tiene ningún producto activo usándola.
        public void EliminarCategoria(int idCategoria)
        {
            if (datos.TieneProductosActivos(idCategoria))
                throw new InvalidOperationException("No se puede eliminar: existen productos activos usando esta categoría.");

            datos.EliminarCategoriaLogico(idCategoria);
        }
    }
}