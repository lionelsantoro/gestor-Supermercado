using DesktopAppSupermercado.Datos;
using DesktopAppSupermercado.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Globalization;

namespace DesktopAppSupermercado.ReglasNegocio
{
    public class ClienteNegocio
    {
        private readonly ClienteDatos datos = new ClienteDatos();

        public List<Cliente> ObtenerClientesPorFiltroTexto(string texto)
        {
            return datos.ListarClientesPorTexto(texto?.Trim() ?? "");
        }

        public Cliente ObtenerClienteValido(string entrada)
        {
            entrada = entrada?.Trim();

            if (string.IsNullOrWhiteSpace(entrada))
            {
                throw new Exception("Debe ingresar un DNI o seleccionar el nombre de un cliente válido para iniciar la venta.");
            }

            // CASO A: Se ingresaron números (o empezó con números intentando poner un DNI)
            if (entrada.All(char.IsDigit) || Regex.IsMatch(entrada, @"\d"))
            {
                // Validamos que TODOS los caracteres sean números
                if (!Regex.IsMatch(entrada, @"^[0-9]+$"))
                {
                    throw new Exception("El DNI ingresado no es válido. Debe contener únicamente números, o bien ingrese solo letras para buscar por nombre.");
                }

                // Validamos que tenga la longitud de un DNI (8 dígitos según tu tabla persona)
                if (entrada.Length != 8)
                {
                    throw new Exception("El DNI debe tener exactamente 8 dígitos numéricos.");
                }

                Cliente clientePorDni = datos.ObtenerPorDni(entrada);

                if (clientePorDni == null)
                {
                    throw new Exception($"No existe ningún cliente registrado con el DNI {entrada}.");
                }

                return clientePorDni;
            }

            // CASO B: Se ingresaron letras (Nombre y Apellido)
            Cliente clientePorNombre = datos.ObtenerPorNombreCompleto(entrada);

            if (clientePorNombre == null)
            {
                throw new Exception("El nombre ingresado no corresponde a un cliente registrado. Seleccione uno de la lista desplegable.");
            }

            return clientePorNombre;
        }

        public DataTable BuscarClientes(string filtro)
        {
            return datos.BuscarClientes(filtro?.Trim() ?? "");
        }

        public Cliente RegistrarCliente(
    string nombre,
    string apellido,
    string correo,
    string dni,
    string direccion,
    string telefono,
    string sexo,
    string fechaNacimientoTexto)
        {
            nombre = nombre?.Trim();
            apellido = apellido?.Trim();
            dni = dni?.Trim();
            sexo = sexo?.Trim();

            correo = string.IsNullOrWhiteSpace(correo)
                ? null : correo.Trim();

            direccion = string.IsNullOrWhiteSpace(direccion)
                ? null : direccion.Trim();

            telefono = string.IsNullOrWhiteSpace(telefono)
                ? null : telefono.Trim();

            // Nombre obligatorio.
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Ingrese el nombre del cliente.");

            if (nombre.Length > 80 ||
                !Regex.IsMatch(nombre, @"^[\p{L}\p{M}]+(?:[ '\-][\p{L}\p{M}]+)*$"))
            {
                throw new Exception(
                    "El nombre no puede superar los 80 caracteres y solo puede contener letras, espacios, apóstrofes y guiones.");
            }

            // Apellido obligatorio.
            if (string.IsNullOrWhiteSpace(apellido))
                throw new Exception("Ingrese el apellido del cliente.");

            if (apellido.Length > 80 ||
                !Regex.IsMatch(apellido, @"^[\p{L}\p{M}]+(?:[ '\-][\p{L}\p{M}]+)*$"))
            {
                throw new Exception(
                    "El apellido no puede superar los 80 caracteres y solo puede contener letras, espacios, apóstrofes y guiones.");
            }

            // DNI obligatorio: exactamente 8 dígitos.
            if (string.IsNullOrWhiteSpace(dni) ||
                !Regex.IsMatch(dni, @"^[0-9]{8}$"))
            {
                throw new Exception(
                    "El DNI es obligatorio y debe contener exactamente 8 dígitos numéricos.");
            }

            // Fecha de nacimiento obligatoria.
            if (string.IsNullOrWhiteSpace(fechaNacimientoTexto))
                throw new Exception("Ingrese la fecha de nacimiento.");

            string[] formatosFecha =
            {
        "dd/MM/yyyy",
        "d/M/yyyy",
        "dd-MM-yyyy",
        "d-M-yyyy",
        "yyyy-MM-dd"
    };

            if (!DateTime.TryParseExact(
                fechaNacimientoTexto.Trim(),
                formatosFecha,
                CultureInfo.GetCultureInfo("es-AR"),
                DateTimeStyles.None,
                out DateTime fechaNacimiento))
            {
                throw new Exception(
                    "La fecha de nacimiento no es válida. Use el formato dd/MM/aaaa.");
            }

            if (fechaNacimiento.Date > DateTime.Today)
                throw new Exception(
                    "La fecha de nacimiento no puede ser posterior al día de hoy.");

            // Sexo obligatorio.
            if (sexo != "Hombre" && sexo != "Mujer")
                throw new Exception("Seleccione Hombre o Mujer.");

            // Correo opcional, pero debe tener un formato válido si se completa.
            if (correo != null)
            {
                if (correo.Length > 150)
                    throw new Exception(
                        "El correo no puede superar los 150 caracteres.");

                if (!Regex.IsMatch(
                    correo,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    throw new Exception("El correo electrónico no tiene un formato válido.");
                }
            }

            // Dirección opcional.
            if (direccion != null && direccion.Length > 250)
                throw new Exception(
                    "La dirección no puede superar los 250 caracteres.");

            // Teléfono opcional, pero si se completa debe ser válido.
            if (telefono != null)
            {
                if (telefono.Length > 20 ||
                    !Regex.IsMatch(telefono, @"^[0-9+\-() ]+$") ||
                    Regex.Replace(telefono, @"\D", "").Length < 7)
                {
                    throw new Exception(
                        "El teléfono debe tener al menos 7 dígitos y puede incluir +, -, paréntesis y espacios.");
                }
            }

            // Debe existir al menos una forma de contacto.
            if (correo == null && telefono == null && direccion == null)
            {
                throw new Exception(
                    "Debe completar al menos uno de estos campos: correo, teléfono o dirección.");
            }

            return datos.RegistrarCliente(
                nombre,
                apellido,
                correo,
                dni,
                direccion,
                telefono,
                sexo,
                fechaNacimiento.Date);
        }
    }
}