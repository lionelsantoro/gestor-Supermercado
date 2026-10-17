using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace DesktopAppSupermercado.Datos
{
    public class GestionProductoDatos
    {
        private Conexion miConexion = new Conexion();

        // =============================================================
        // LISTAR
        // =============================================================
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