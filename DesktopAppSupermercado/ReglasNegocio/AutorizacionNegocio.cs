using DesktopAppSupermercado.Datos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DesktopAppSupermercado.ReglasNegocio
{
    public class AutorizacionNegocio
    {
        private readonly AutorizacionDatos datos =
            new AutorizacionDatos();

        public bool ValidarCodigoSupervisor(string codigo)
        {
            codigo = codigo?.Trim();

            // El código es obligatorio.
            if (string.IsNullOrWhiteSpace(codigo))
            {
                throw new Exception(
                    "Ingrese el código de autorización del supervisor.");
            }

            // Debe contener exactamente cuatro números.
            if (!Regex.IsMatch(codigo, @"^[0-9]{4}$"))
            {
                throw new Exception(
                    "El código de autorización debe contener exactamente 4 dígitos numéricos.");
            }

            // Consultar si el código pertenece a un usuario autorizado.
            bool autorizado =
                datos.ExisteCodigoAutorizacionSupervisor(codigo);

            if (!autorizado)
            {
                throw new Exception(
                    "El código ingresado no es válido o no pertenece a un supervisor autorizado.");
            }

            return true;
        }
    }
}
