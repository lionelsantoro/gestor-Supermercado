using DesktopAppSupermercado.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

namespace DesktopAppSupermercado.Datos
{
    public class ClienteDatos
    {
        // 1. Obtener cliente por DNI exacto (solo si existe en dbo.clientes)
        public Cliente ObtenerPorDni(string dni)
        {
            Cliente cliente = null;
            Conexion miConexion = new Conexion();

            using (SqlConnection con = miConexion.ObtenerConexion())
            {
                con.Open();

                string query = @"
                    SELECT 
                        c.id_cliente,
                        p.id_persona,
                        p.nombre,
                        p.apellido,
                        p.dni
                    FROM dbo.clientes c
                    INNER JOIN dbo.persona p ON c.id_persona = p.id_persona
                    WHERE p.dni = @dni
                      AND ISNULL(p.eliminado, 0) = 0;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@dni", SqlDbType.VarChar, 20).Value = dni;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = MapearCliente(reader);
                        }
                    }
                }
            }

            return cliente;
        }

        // 2. Obtener cliente por Nombre y Apellido exacto (al seleccionarlo o escribirlo)
        public Cliente ObtenerPorNombreCompleto(string texto)
        {
            Cliente cliente = null;
            Conexion miConexion = new Conexion();

            using (SqlConnection con = miConexion.ObtenerConexion())
            {
                con.Open();

                string query = @"
                    SELECT TOP 1
                        c.id_cliente,
                        p.id_persona,
                        p.nombre,
                        p.apellido,
                        p.dni
                    FROM dbo.clientes c
                    INNER JOIN dbo.persona p ON c.id_persona = p.id_persona
                    WHERE (
                        (p.nombre + ' ' + p.apellido) = @texto
                        OR (p.apellido + ' ' + p.nombre) = @texto
                    )
                    AND ISNULL(p.eliminado, 0) = 0;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@texto", SqlDbType.VarChar, 210).Value = texto;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = MapearCliente(reader);
                        }
                    }
                }
            }

            return cliente;
        }

        // 3. Listar o filtrar clientes por letras para el ComboBox (ordenados alfabéticamente)
        public List<Cliente> ListarClientesPorTexto(string filtroTexto)
        {
            List<Cliente> lista = new List<Cliente>();
            Conexion miConexion = new Conexion();

            using (SqlConnection con = miConexion.ObtenerConexion())
            {
                con.Open();

                string query = @"
                    SELECT 
                        c.id_cliente,
                        p.id_persona,
                        p.nombre,
                        p.apellido,
                        p.dni
                    FROM dbo.clientes c
                    INNER JOIN dbo.persona p ON c.id_persona = p.id_persona
                    WHERE ISNULL(p.eliminado, 0) = 0
                      AND (
                          @filtro = ''
                          OR p.nombre LIKE '%' + @filtro + '%'
                          OR p.apellido LIKE '%' + @filtro + '%'
                          OR (p.nombre + ' ' + p.apellido) LIKE '%' + @filtro + '%'
                          OR (p.apellido + ' ' + p.nombre) LIKE '%' + @filtro + '%'
                      )
                    ORDER BY p.nombre ASC, p.apellido ASC;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@filtro", SqlDbType.VarChar, 160).Value = filtroTexto ?? "";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(MapearCliente(reader));
                        }
                    }
                }
            }

            return lista;
        }

        // 4. Búsqueda general en DataTable (por si la usas en otra grilla)
        public DataTable BuscarClientes(string filtro)
        {
            DataTable tabla = new DataTable();
            Conexion miConexion = new Conexion();

            using (SqlConnection con = miConexion.ObtenerConexion())
            {
                con.Open();

                string query = @"
                    SELECT
                        c.id_cliente,
                        p.nombre,
                        p.apellido,
                        p.dni
                    FROM dbo.clientes c
                    INNER JOIN dbo.persona p ON c.id_persona = p.id_persona
                    WHERE ISNULL(p.eliminado, 0) = 0
                      AND (
                          @filtro = N''
                          OR p.nombre LIKE N'%' + @filtro + N'%'
                          OR p.apellido LIKE N'%' + @filtro + N'%'
                          OR p.dni LIKE '%' + @filtro + '%'
                      )
                    ORDER BY p.nombre ASC, p.apellido ASC;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@filtro", SqlDbType.NVarChar, 160).Value = filtro ?? "";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(tabla);
                    }
                }
            }

            return tabla;
        }

        private Cliente MapearCliente(SqlDataReader reader)
        {
            return new Cliente
            {
                IdCliente = Convert.ToInt32(reader["id_cliente"]),
                IdPersona = Convert.ToInt32(reader["id_persona"]),
                Nombre = reader["nombre"].ToString(),
                Apellido = reader["apellido"].ToString(),
                Dni = reader["dni"] != DBNull.Value ? reader["dni"].ToString() : ""
            };
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

    }
}