using DesktopAppSupermercado.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

        public Cliente RegistrarCliente(string nombre, string apellido)
        {
            Conexion miConexion = new Conexion();

            using (SqlConnection con = miConexion.ObtenerConexion())
            {
                con.Open();

                using (SqlTransaction transaccion =
                    con.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        // Obtener el próximo código de cliente.
                        // Los bloqueos evitan que dos registros simultáneos
                        // calculen el mismo número.
                        string queryCodigo = @"
                            SELECT ISNULL(
                                MAX(TRY_CONVERT(INT, codigo_cliente)), 0
                            ) + 1
                            FROM dbo.clientes WITH (UPDLOCK, HOLDLOCK);";

                        int siguienteCodigo;

                        using (SqlCommand cmdCodigo =
                            new SqlCommand(queryCodigo, con, transaccion))
                        {
                            siguienteCodigo = Convert.ToInt32(
                                cmdCodigo.ExecuteScalar());
                        }

                        if (siguienteCodigo > 9999)
                        {
                            throw new Exception(
                                "Se alcanzó el límite de 9999 clientes codificados.");
                        }

                        string codigoCliente =
                            siguienteCodigo.ToString("D4");

                        // Insertar el cliente.
                        string queryInsertar = @"
                            INSERT INTO dbo.clientes
                                (nombre, apellido, codigo_cliente)
                            OUTPUT
                                INSERTED.id_cliente,
                                INSERTED.codigo_cliente
                            VALUES
                                (@nombre, @apellido, @codigoCliente);";

                        Cliente cliente;

                        using (SqlCommand cmdInsertar =
                            new SqlCommand(queryInsertar, con, transaccion))
                        {
                            cmdInsertar.Parameters.Add(
                                "@nombre", SqlDbType.NVarChar, 80).Value =
                                nombre;

                            cmdInsertar.Parameters.Add(
                                "@apellido", SqlDbType.NVarChar, 80).Value =
                                apellido;

                            cmdInsertar.Parameters.Add(
                                "@codigoCliente", SqlDbType.VarChar, 4).Value =
                                codigoCliente;

                            using (SqlDataReader reader =
                                cmdInsertar.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    throw new Exception(
                                        "No se pudo registrar el cliente.");
                                }

                                cliente = new Cliente
                                {
                                    IdCliente = Convert.ToInt32(
                                        reader["id_cliente"]),

                                    Nombre = nombre,
                                    Apellido = apellido,

                                    CodigoCliente =
                                        reader["codigo_cliente"].ToString()
                                };
                            }
                        }

                        transaccion.Commit();

                        return cliente;
                    }
                    catch
                    {
                        try
                        {
                            transaccion.Rollback();
                        }
                        catch
                        {
                            // Mantener el error original.
                        }

                        throw;
                    }
                }
            }
        }

        public DataTable BuscarClientes(string filtro)
        {
            DataTable tabla = new DataTable();
            Conexion miConexion = new Conexion();

            using (SqlConnection con = miConexion.ObtenerConexion())
            {
                con.Open();

                string query = @"
                    SELECT
                        id_cliente,
                        nombre,
                        apellido
                    FROM dbo.clientes
                    WHERE
                        @filtro = N''
                        OR nombre LIKE N'%' + @filtro + N'%'
                        OR apellido LIKE N'%' + @filtro + N'%'
                        OR codigo_cliente LIKE '%' + @filtro + '%'
                    ORDER BY apellido, nombre;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(
                        "@filtro", SqlDbType.NVarChar, 160).Value =
                        filtro ?? "";

                    using (SqlDataAdapter adapter =
                        new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(tabla);
                    }
                }
            }

            return tabla;
        }
    }
}
