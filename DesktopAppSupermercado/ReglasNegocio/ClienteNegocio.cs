using DesktopAppSupermercado.Datos;
using DesktopAppSupermercado.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

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
            string apellido)
        {
            nombre = nombre?.Trim();
            apellido = apellido?.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception(
                    "El nombre del cliente es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(apellido))
            {
                throw new Exception(
                    "El apellido del cliente es obligatorio.");
            }

            if (nombre.Length > 80 || apellido.Length > 80)
            {
                throw new Exception(
                    "El nombre y el apellido no pueden superar los 80 caracteres.");
            }

            // Permite letras, tildes, espacios, apóstrofes y guiones.
            // No permite números ni cadenas formadas solo por espacios.
            string patronNombre =
                @"^[\p{L}\p{M}]+(?:[ '\-][\p{L}\p{M}]+)*$";

            if (!Regex.IsMatch(nombre, patronNombre))
            {
                throw new Exception(
                    "El nombre solo puede contener letras y separadores válidos.");
            }

            if (!Regex.IsMatch(apellido, patronNombre))
            {
                throw new Exception(
                    "El apellido solo puede contener letras y separadores válidos.");
            }

            return datos.RegistrarCliente(nombre, apellido);
        }

    }
}