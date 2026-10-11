using DesktopAppSupermercado.Datos;
using DesktopAppSupermercado.Entidades;
using System;
using System.Collections.Generic;
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
    }
}
