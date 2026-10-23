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
        // 1. Obtener cliente por DNI exacto
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

        // 3. Listar o filtrar clientes por letras para el ComboBox
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

        // 4. Búsqueda general en DataTable
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
                p.correo,
                p.dni,
                p.direccion,
                p.telefono,
                p.sexo
            FROM dbo.clientes c
            INNER JOIN dbo.persona p
                ON c.id_persona = p.id_persona
            WHERE ISNULL(p.eliminado, 0) = 0
              AND (
                    @filtro = N''
                    OR p.nombre LIKE N'%' + @filtro + N'%'
                    OR p.apellido LIKE N'%' + @filtro + N'%'
                    OR (p.nombre + N' ' + p.apellido)
                       LIKE N'%' + @filtro + N'%'
                    OR (p.apellido + N' ' + p.nombre)
                       LIKE N'%' + @filtro + N'%'
                    OR p.dni LIKE N'%' + @filtro + N'%'
                  )
            ORDER BY p.nombre ASC, p.apellido ASC;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@filtro", SqlDbType.NVarChar, 160)
                        .Value = filtro?.Trim() ?? "";

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

        public Cliente RegistrarCliente(
    string nombre,
    string apellido,
    string correo,
    string dni,
    string direccion,
    string telefono,
    string sexo,
    DateTime fechaNacimiento)
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
                        string queryExiste = @"
                    SELECT COUNT(1)
                    FROM dbo.persona WITH (UPDLOCK, HOLDLOCK)
                    WHERE dni = @dni;";

                        using (SqlCommand cmdExiste =
                            new SqlCommand(queryExiste, con, transaccion))
                        {
                            cmdExiste.Parameters.Add(
                                "@dni", SqlDbType.VarChar, 20).Value = dni;

                            int existe = Convert.ToInt32(
                                cmdExiste.ExecuteScalar());

                            if (existe > 0)
                            {
                                throw new Exception(
                                    "Ya existe una persona registrada con ese DNI.");
                            }
                        }

                        // Insertar persona y obtener el ID generado.
                        string queryPersona = @"
                    INSERT INTO dbo.persona
                    (
                        nombre,
                        apellido,
                        correo,
                        eliminado,
                        creado_en,
                        dni,
                        direccion,
                        telefono,
                        sexo,
                        fecha_nacimiento
                    )
                    OUTPUT INSERTED.id_persona
                    VALUES
                    (
                        @nombre,
                        @apellido,
                        @correo,
                        0,
                        GETDATE(),
                        @dni,
                        @direccion,
                        @telefono,
                        @sexo,
                        @fechaNacimiento
                    );";

                        int idPersona;

                        using (SqlCommand cmdPersona =
                            new SqlCommand(queryPersona, con, transaccion))
                        {
                            cmdPersona.Parameters.Add(
                                "@nombre", SqlDbType.NVarChar, 80).Value = nombre;

                            cmdPersona.Parameters.Add(
                                "@apellido", SqlDbType.NVarChar, 80).Value = apellido;

                            cmdPersona.Parameters.Add(
                                "@correo", SqlDbType.NVarChar, 150).Value =
                                (object)correo ?? DBNull.Value;

                            cmdPersona.Parameters.Add(
                                "@dni", SqlDbType.VarChar, 20).Value = dni;

                            cmdPersona.Parameters.Add(
                                "@direccion", SqlDbType.NVarChar, 250).Value =
                                (object)direccion ?? DBNull.Value;

                            cmdPersona.Parameters.Add(
                                "@telefono", SqlDbType.NVarChar, 20).Value =
                                (object)telefono ?? DBNull.Value;

                            cmdPersona.Parameters.Add(
                                "@sexo", SqlDbType.NVarChar, 10).Value = sexo;

                            cmdPersona.Parameters.Add(
                                "@fechaNacimiento", SqlDbType.Date).Value =
                                fechaNacimiento.Date;

                            idPersona = Convert.ToInt32(
                                cmdPersona.ExecuteScalar());
                        }

                        // Registrar cliente usando la persona recién creada.
                        string queryCliente = @"
                    INSERT INTO dbo.clientes (id_persona, creado_en)
                    OUTPUT INSERTED.id_cliente
                    VALUES (@idPersona, GETDATE());";

                        int idCliente;

                        using (SqlCommand cmdCliente =
                            new SqlCommand(queryCliente, con, transaccion))
                        {
                            cmdCliente.Parameters.Add(
                                "@idPersona", SqlDbType.Int).Value = idPersona;

                            idCliente = Convert.ToInt32(
                                cmdCliente.ExecuteScalar());
                        }

                        transaccion.Commit();

                        return new Cliente
                        {
                            IdCliente = idCliente,
                            IdPersona = idPersona,
                            Nombre = nombre,
                            Apellido = apellido,
                            Dni = dni
                        };
                    }
                    catch
                    {
                        try
                        {
                            transaccion.Rollback();
                        }
                        catch
                        {
                            // Se conserva la excepción original.
                        }

                        throw;
                    }
                }
            }
        }

    }
}