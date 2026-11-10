using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DesktopAppSupermercado.Datos.Inventario
{
    public class GestionProductoDatos
    {
        private Conexion miConexion = new Conexion();

        // =============================================================
        // LISTAR
        // =============================================================

        // Trae los productos activos unidos con su categoría, incluyendo el nombre que muestra la grilla y el id que usa el combo.
        public DataTable ListarProductos()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();
                string query = @"SELECT p.id_producto, p.codigo_barra, p.descripcion, p.precio, p.stock, p.unidad_medida, 
                                        c.nombre as categoria_nombre, p.id_categoria 
                                 FROM productos p INNER JOIN categorias c ON p.id_categoria = c.id_categoria 
                                 WHERE p.eliminado = 0";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd)) { adapter.Fill(tabla); }
            }
            return tabla;
        }

        // =============================================================
        // INSERTAR
        // =============================================================

        // Inserta un producto nuevo; el código de barras entra como NULL si viene vacío.
        public void InsertarProducto(int idCategoria, string descripcion, decimal precio, decimal stock, string unidadMedida, string codigoBarra)
        {
            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();
                // La columna 'nombre' ya no existe en la tabla.
                // 'kilogramo' es nullable, así que no hace falta nombrarla.
                string query = @"INSERT INTO productos (id_categoria, descripcion, precio, stock, unidad_medida, codigo_barra) 
                                 VALUES (@idCategoria, @descripcion, @precio, @stock, @unidadMedida, @codigoBarra)";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@unidadMedida", unidadMedida);
                    cmd.Parameters.AddWithValue("@codigoBarra", (object)codigoBarra ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // =============================================================
        // MODIFICAR
        // =============================================================

        // Actualiza todos los campos del producto y registra la fecha de actualización.
        public void ModificarProducto(int idProducto, int idCategoria, string descripcion, decimal precio, decimal stock, string unidadMedida, string codigoBarra)
        {
            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();
                string query = @"UPDATE productos 
                                 SET id_categoria = @idCategoria, descripcion = @descripcion, precio = @precio, stock = @stock, 
                                     unidad_medida = @unidadMedida, codigo_barra = @codigoBarra, actualizado_en = GETDATE() 
                                 WHERE id_producto = @idProducto";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@unidadMedida", unidadMedida);
                    cmd.Parameters.AddWithValue("@codigoBarra", (object)codigoBarra ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // =============================================================
        // ELIMINAR (baja lógica)
        // =============================================================

        // Baja lógica: marca eliminado = 1 con la fecha, no borra la fila.
        public void EliminarProducto(int idProducto)
        {
            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();
                string query = "UPDATE productos SET eliminado = 1, eliminado_en = GETDATE() WHERE id_producto = @idProducto";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // =============================================================
        // VALIDAR CÓDIGO DE BARRAS DUPLICADO
        // =============================================================

        // Indica si otro producto activo ya usa ese código, excluyendo el que se está editando.
        public bool ExisteCodigoBarra(string codigoBarra, int idProductoActual)
        {
            if (string.IsNullOrWhiteSpace(codigoBarra)) return false;
            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();
                string query = "SELECT COUNT(*) FROM productos WHERE codigo_barra = @codigoBarra AND id_producto != @idProductoActual AND eliminado = 0";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@codigoBarra", codigoBarra);
                    cmd.Parameters.AddWithValue("@idProductoActual", idProductoActual);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }
    }
}