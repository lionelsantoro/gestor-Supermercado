using DesktopAppSupermercado.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopAppSupermercado.Datos
{
    public class ClienteDatos
    {
        public Cliente ObtenerPorCodigo(string codigoCliente)
        {
            Cliente cliente = null;
            Conexion miConexion = new Conexion();

            using (SqlConnection con = miConexion.ObtenerConexion())
            {
                con.Open();

                string query = @"
                    SELECT id_cliente, nombre, apellido, codigo_cliente
                    FROM dbo.clientes
                    WHERE codigo_cliente = @codigoCliente;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(
                        "@codigoCliente",
                        System.Data.SqlDbType.VarChar,
                        4).Value = codigoCliente;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = new Cliente
                            {
                                IdCliente = Convert.ToInt32(
                                    reader["id_cliente"]),

                                Nombre = reader["nombre"].ToString(),
                                Apellido = reader["apellido"].ToString(),

                                CodigoCliente =
                                    reader["codigo_cliente"].ToString()
                            };
                        }
                    }
                }
            }

            return cliente;
        }
    }
}
