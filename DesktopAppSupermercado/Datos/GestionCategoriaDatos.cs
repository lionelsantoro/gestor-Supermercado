using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DesktopAppSupermercado.Datos
{
    public class GestionCategoriaDatos
    {
        private Conexion miConexion = new Conexion();

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