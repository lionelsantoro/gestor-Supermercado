using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DesktopAppSupermercado.Datos.Inventario
{
    public class GestionCategoriaDatos
    {
        private Conexion miConexion = new Conexion();

        // Trae solo las categorías activas, para la grilla y para los dos combos.
        public DataTable ListarCategorias()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();
                string query = "SELECT id_categoria, nombre FROM categorias WHERE eliminado = 0";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd)) { adapter.Fill(tabla); }
            }
            return tabla;
        }

        // Inserta una categoría nueva; el id lo genera la base.
        public void InsertarCategoria(string nombre)
        {
            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();
                string query = "INSERT INTO categorias (nombre) VALUES (@nombre)";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        // Cambia el nombre de una categoría y registra la fecha de actualización.
        public void ModificarCategoria(int idCategoria, string nombre)
        {
            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();
                string query = "UPDATE categorias SET nombre = @nombre, actualizado_en = GETDATE() WHERE id_categoria = @idCategoria";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Indica si la categoría tiene productos activos; es lo que protege la integridad antes de modificar o eliminar.
        public bool TieneProductosActivos(int idCategoria)
        {
            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();
                string query = "SELECT COUNT(*) FROM productos WHERE id_categoria = @idCategoria AND eliminado = 0";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        // Baja lógica: marca eliminado = 1 con la fecha, no borra la fila.
        public void EliminarCategoriaLogico(int idCategoria)
        {
            using (SqlConnection conexion = miConexion.ObtenerConexion())
            {
                conexion.Open();
                string query = "UPDATE categorias SET eliminado = 1, eliminado_en = GETDATE() WHERE id_categoria = @idCategoria";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}