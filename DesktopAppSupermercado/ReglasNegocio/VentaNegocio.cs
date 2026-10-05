using DesktopAppSupermercado.Datos;
using DesktopAppSupermercado.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DesktopAppSupermercado.ReglasNegocio
{
    internal class VentaNegocio
    {
        private VentaDatos datos = new VentaDatos();

        public int GenerarIdProvisional(int idCajero)
        {
            return datos.ObtenerProximoIdVenta(idCajero);
        }

        public void GuardarVentaConfirmada(int idUsuario, int idMedioPago, decimal montoTotal, BindingList<DetalleVentaVista> detalles)
        {
            if (detalles.Count == 0)
                throw new Exception("No se puede registrar una venta sin productos.");

            datos.RegistrarVentaCompleta(idUsuario, idMedioPago, montoTotal, detalles);
        }
    }
}
