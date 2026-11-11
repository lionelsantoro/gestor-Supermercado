using DesktopAppSupermercado.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

namespace DesktopAppSupermercado.Datos.Supervisor_Cajero
{
    public class ClienteDatos
    {
        // Busca un cliente activo por su DNI exacto y devuelve sus datos como entidad Cliente.
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

        // Busca un cliente activo por nombre y apellido, admitiendo ambos órdenes de escritura.
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

        // Obtiene los clientes activos y los filtra por nombre o apellido para el buscador desplegable.
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

        // Consulta los datos de los clientes activos y devuelve una tabla para la grilla de registro.
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
        p.sexo,
        p.fecha_nacimiento
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

        // Convierte la fila actual del lector SQL en un objeto Cliente.
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

        // Registra los datos personales y crea su registro de cliente dentro de una transacción SQL.
        public Cliente RegistrarCliente(string nombre,string apellido,string correo,string dni,string direccion,string telefono,string sexo,DateTime fechaNacimiento)
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

        // Actualiza los datos personales del cliente y controla que el DNI no pertenezca a otra persona.
        public Cliente ActualizarCliente(int idCliente,string nombre,string apellido,string correo,string dni,string direccion,string telefono,string sexo,DateTime fechaNacimiento)
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
                        // Obtener el id_persona correspondiente al cliente.
                        string queryPersona = @"
                    SELECT p.id_persona
                    FROM dbo.clientes c
                    INNER JOIN dbo.persona p WITH (UPDLOCK, HOLDLOCK)
                        ON c.id_persona = p.id_persona
                    WHERE c.id_cliente = @idCliente
                      AND ISNULL(p.eliminado, 0) = 0;";

                        int idPersona;

                        using (SqlCommand cmdPersona =
                            new SqlCommand(queryPersona, con, transaccion))
                        {
                            cmdPersona.Parameters.Add(
                                "@idCliente", SqlDbType.Int).Value = idCliente;

                            object resultado = cmdPersona.ExecuteScalar();

                            if (resultado == null || resultado == DBNull.Value)
                            {
                                throw new Exception(
                                    "No se encontró el cliente que desea modificar.");
                            }

                            idPersona = Convert.ToInt32(resultado);
                        }

                        // Comprobar que el DNI no pertenezca a otra persona.
                        string queryDni = @"
                    SELECT COUNT(1)
                    FROM dbo.persona WITH (UPDLOCK, HOLDLOCK)
                    WHERE dni = @dni
                      AND id_persona <> @idPersona;";

                        using (SqlCommand cmdDni =
                            new SqlCommand(queryDni, con, transaccion))
                        {
                            cmdDni.Parameters.Add(
                                "@dni", SqlDbType.VarChar, 20).Value = dni;

                            cmdDni.Parameters.Add(
                                "@idPersona", SqlDbType.Int).Value = idPersona;

                            int existe = Convert.ToInt32(
                                cmdDni.ExecuteScalar());

                            if (existe > 0)
                            {
                                throw new Exception(
                                    "El DNI ingresado ya pertenece a otro cliente.");
                            }
                        }

                        // Actualizar los datos de la persona.
                        string queryActualizar = @"
                    UPDATE p
                    SET
                        nombre = @nombre,
                        apellido = @apellido,
                        correo = @correo,
                        dni = @dni,
                        direccion = @direccion,
                        telefono = @telefono,
                        sexo = @sexo,
                        fecha_nacimiento = @fechaNacimiento
                    FROM dbo.persona p
                    INNER JOIN dbo.clientes c
                        ON c.id_persona = p.id_persona
                    WHERE c.id_cliente = @idCliente
                      AND p.id_persona = @idPersona
                      AND ISNULL(p.eliminado, 0) = 0;";

                        using (SqlCommand cmdActualizar =
                            new SqlCommand(queryActualizar, con, transaccion))
                        {
                            cmdActualizar.Parameters.Add(
                                "@idCliente", SqlDbType.Int).Value = idCliente;

                            cmdActualizar.Parameters.Add(
                                "@idPersona", SqlDbType.Int).Value = idPersona;

                            cmdActualizar.Parameters.Add(
                                "@nombre", SqlDbType.NVarChar, 80).Value = nombre;

                            cmdActualizar.Parameters.Add(
                                "@apellido", SqlDbType.NVarChar, 80).Value = apellido;

                            cmdActualizar.Parameters.Add(
                                "@correo", SqlDbType.NVarChar, 150).Value =
                                (object)correo ?? DBNull.Value;

                            cmdActualizar.Parameters.Add(
                                "@dni", SqlDbType.VarChar, 20).Value = dni;

                            cmdActualizar.Parameters.Add(
                                "@direccion", SqlDbType.NVarChar, 250).Value =
                                (object)direccion ?? DBNull.Value;

                            cmdActualizar.Parameters.Add(
                                "@telefono", SqlDbType.NVarChar, 20).Value =
                                (object)telefono ?? DBNull.Value;

                            cmdActualizar.Parameters.Add(
                                "@sexo", SqlDbType.NVarChar, 10).Value = sexo;

                            cmdActualizar.Parameters.Add(
                                "@fechaNacimiento", SqlDbType.Date).Value =
                                fechaNacimiento.Date;

                            int filasAfectadas = cmdActualizar.ExecuteNonQuery();

                            if (filasAfectadas == 0)
                            {
                                throw new Exception(
                                    "No se pudieron actualizar los datos del cliente.");
                            }
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

        // Realiza la baja lógica del cliente marcando como eliminado a su persona asociada.
        public bool EliminarCliente(int idCliente)
        {
            Conexion miConexion = new Conexion();

            using (SqlConnection con = miConexion.ObtenerConexion())
            {
                con.Open();

                string query = @"
            UPDATE p
            SET p.eliminado = 1
            FROM dbo.persona p
            INNER JOIN dbo.clientes c
                ON c.id_persona = p.id_persona
            WHERE c.id_cliente = @idCliente
              AND ISNULL(p.eliminado, 0) = 0;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(
                        "@idCliente", SqlDbType.Int).Value = idCliente;

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    return filasAfectadas > 0;
                }
            }
        }

    }
}