using DesktopAppSupermercado.Datos;
using System;
using System.Data;

namespace DesktopAppSupermercado.ReglasNegocio
{
    public class GestionProductoNegocio
    {
        private GestionProductoDatos datos = new GestionProductoDatos();

        public DataTable ListarProductos()
        {
            return datos.ListarProductos();
        }

        public void GuardarProducto(int idProducto, int idCategoria, string descripcion, string precioTexto, string stockTexto, string unidadMedida, string codigoBarra)
        {
            // 1. Validaciones de campos obligatorios
            if (idCategoria <= 0)
                throw new ArgumentException("Seleccione una categoría válida.");
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción es obligatoria.");
            if (string.IsNullOrWhiteSpace(unidadMedida))
                throw new ArgumentException("Seleccione una unidad de medida.");

            // Validar que el código tenga exactamente 6 dígitos
            if (string.IsNullOrWhiteSpace(codigoBarra) || codigoBarra.Trim().Length != 6)
                throw new ArgumentException("El código de barras debe tener exactamente 6 dígitos.");

            // 2. Validaciones numéricas
            if (!decimal.TryParse(precioTexto, out decimal precio) || precio <= 0)
                throw new ArgumentException("Ingrese un precio numérico válido mayor a 0.");

            if (!decimal.TryParse(stockTexto, out decimal stock) || stock < 0)
                throw new ArgumentException("Ingrese un stock válido (puede ser 0 o un valor decimal).");

            // 3. Validación de duplicados en la base de datos
            if (datos.ExisteCodigoBarra(codigoBarra, idProducto))
                throw new InvalidOperationException("Este código de barras ya pertenece a otro producto activo.");

            // 4. Guardar o modificar según corresponda
            string? codigoLimpio = string.IsNullOrWhiteSpace(codigoBarra) ? null : codigoBarra.Trim();

            if (idProducto == 0)
                datos.InsertarProducto(idCategoria, descripcion.Trim(), precio, stock, unidadMedida, codigoLimpio!);
            else
                datos.ModificarProducto(idProducto, idCategoria, descripcion.Trim(), precio, stock, unidadMedida, codigoLimpio!);
        }

        public void EliminarProducto(int idProducto)
        {
            datos.EliminarProducto(idProducto);
        }

        public bool VerificarCodigoExistente(string codigoBarra, int idProductoActual)
        {
            return datos.ExisteCodigoBarra(codigoBarra, idProductoActual);
        }
    }
}