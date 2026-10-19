using DesktopAppSupermercado.Datos;
using DesktopAppSupermercado.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace DesktopAppSupermercado.ReglasNegocio
{
    public class ClienteNegocio
    {
        private readonly ClienteDatos datos = new ClienteDatos();

        public Cliente ObtenerClienteValido(string codigo)
        {
            codigo = codigo?.Trim();

            if (string.IsNullOrWhiteSpace(codigo) ||
                !Regex.IsMatch(codigo, @"^[0-9]{4}$"))
            {
                throw new Exception(
                    "Ingrese un código de cliente de exactamente cuatro dígitos.");
            }

            Cliente cliente = datos.ObtenerPorCodigo(codigo);

            if (cliente == null)
            {
                throw new Exception(
                    "El código ingresado no corresponde a un cliente registrado.");
            }

            return cliente;
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

        public DataTable BuscarClientes(string filtro)
        {
            return datos.BuscarClientes(filtro?.Trim() ?? "");
        }
    }
}
